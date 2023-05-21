using AutoMapper;
using Store.Application.DTO.User;
using Store.Application.Helper;
using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;

namespace Store.Application.Service
{
    public interface IAuthService
    {
        Task<bool> SignupAsync(SignupRequestDTO request);
        Task<AuthenticatedUserDTO?> AuthenticateAsync(AuthenticateRequestDTO request);
    }

    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTManager _jWTManager;

        public AuthService(IMapper mapper, IUnitOfWork unitOfWork, IJWTManager jWTManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jWTManager = jWTManager;
        }

        public async Task<bool> SignupAsync(SignupRequestDTO request)
        {
            var existingUser = await _unitOfWork.UserRepository
                .GetSingleBy(a => !a.IsDeleted &&
                 (!string.IsNullOrEmpty(a.Email) && a.Email.ToLower() == request.Email.ToLower())
                 || (!string.IsNullOrEmpty(a.Phone) && a.Phone == request.Phone)
                );

            if (existingUser != null) return false;

            var regUser = _mapper.Map<User>(request);
            regUser.PasswordSalt = PasswordHelper.PasswordSalt(request.Email + "-" + request.Phone);
            regUser.PasswordHash = PasswordHelper.PasswordHash(request.Password, regUser.PasswordSalt);

            regUser.IsDeleted = false;
            regUser.CreatedDate = DateTime.UtcNow;
            regUser.CreatedBy = 1;

            await _unitOfWork.UserRepository.Add(regUser);
            await _unitOfWork.Save();

            return true;
        }
        
        public async Task<AuthenticatedUserDTO?> AuthenticateAsync(AuthenticateRequestDTO request)
        {
            // Validate the email and password against the stored user data
            var regUser = await _unitOfWork.UserRepository
                 .GetSingleBy(a => !a.IsDeleted &&
                  (!string.IsNullOrEmpty(a.Email) && a.Email.ToLower() == request.Email.ToLower())
                  || (!string.IsNullOrEmpty(a.Phone) && a.Phone == request.Phone)
                 );

            if (regUser == null ||
                !PasswordHelper.VerifyPasswordHash(request.Password, regUser.PasswordHash, regUser.PasswordSalt))
                return null; // Authentication failed

            var rsp = _mapper.Map<AuthenticatedUserDTO>(regUser);

            // Generate a JWT token
            rsp.Token = _jWTManager.GenerateJwtToken(rsp);
            rsp.Id = null;

            regUser.Token = rsp.Token;
            regUser.UpdatedDate = DateTime.UtcNow;

            _unitOfWork.UserRepository.Edit(regUser);
            await _unitOfWork.Save();

            return rsp;
        }

    }
}
