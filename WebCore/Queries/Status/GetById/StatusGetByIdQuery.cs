﻿using Data;
using Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Queries
{
    public class StatusGetByIdQuery:IQuery<Status>
    {
        public string StatusId { get; set; }
    }
}
