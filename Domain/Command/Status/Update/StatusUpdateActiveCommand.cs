using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class StatusUpdateActiveCommand
    {
        public string StatusId { get; set; }
        public string UserId { get; set; }
    }
}
