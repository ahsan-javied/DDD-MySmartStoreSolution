
namespace Store.Domain.Entity
{
    public abstract class Base
    {
        public bool IsDeleted { get; set; } = false;
        public virtual int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
