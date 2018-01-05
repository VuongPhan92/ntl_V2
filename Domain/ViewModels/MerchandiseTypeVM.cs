using System;

namespace Domain.ViewModels
{
    public class MerchandiseTypeVM
    {
        public string MerchandiseId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Value { get; set; }
        public string CalculationUnit { get; set; }
        public string Description { get; set; }
      
    }
}
