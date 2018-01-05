using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class DeliveryTypeAddCommand
    {
        public DeliveryTypeVM  DeliveryType { get; set; }
        public string UserId { get; set; }
    }
}
