using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class BranchActiveUpdateCommand
    {
        public string BranchId { get; set; }
        public string UserId { get; set; }
    }
}
