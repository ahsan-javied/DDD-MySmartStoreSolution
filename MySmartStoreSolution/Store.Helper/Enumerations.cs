using System.ComponentModel.DataAnnotations;

namespace Store.Helper
{
    public static class Enumerations
    {
        public enum ProductStatus
        {
            Sold = 0,
            InStock,
            Damaged
        }

        public enum ProductWeightedOrNonWeighted
        {
            [Display(Name = "Weighted")]
            Weighted = 0,
            
            [Display(Name = "Non Weighted")]
            NonWeighted,
        }
        public enum OrderStatus
        {
            Placed = 0,
            Shipped,
            Delivered,
            Canceled
        }
    }
}
