using ApiAssignment.ServiceInterface;
using System.Collections.Generic;

namespace ApiAssignment.Entities
{
    [CollectionName("Cars")]
    public class Car : BaseEntity
    {
        public string CarName { get; set; }
        public string CarCode { get; set; }
        public bool IsActive { get; set; }
        public List<Variant> Variants { get; set; }
    }

    public class Variant
    {
        public string VariantCode { get; set; }
        public string VariantName { get; set; }
        public decimal Price { get; set; }
        public string FuelType { get; set; }
    }
}