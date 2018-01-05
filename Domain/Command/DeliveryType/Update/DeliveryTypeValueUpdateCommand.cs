using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class DeliveryTypeValueUpdateCommand
    {
        public string DeliveryTypeId { get; set; }
        public string Value { get; set; }
        public string UserId { get; set; }
    }
}
