﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public class MerchandiseTypeTypeUpdateCommand
    {
        public string MerchandiseTypeId { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
    }
}