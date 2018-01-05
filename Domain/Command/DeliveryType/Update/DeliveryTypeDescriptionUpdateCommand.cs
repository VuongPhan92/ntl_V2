using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class DeliveryTypeDescriptionUpdateCommand
    {
        public string DeliveryTypeId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
