using System;

namespace Domain.ViewModels
{
    public class DeliveryTypeVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Value { get; set; }   
        public string UserId { get; set; }
    }
}
