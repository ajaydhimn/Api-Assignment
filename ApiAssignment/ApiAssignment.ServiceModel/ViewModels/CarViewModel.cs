using System.Collections.Generic;

namespace ApiAssignment.ServiceModel
{
    public class CarViewModel
    {
        public string CarName { get; set; }
        public string CarCode { get; set; }
        public bool IsActive { get; set; }
        public List<VariantViewModel> Variants { get; set; }
    }

    public class VariantViewModel
    {
        public string VariantCode { get; set; }
        public string VariantName { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
    }
}