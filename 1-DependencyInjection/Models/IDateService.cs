﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_DependencyInjection.Models
{
    public interface IDateService
    {
        DateTime GetDateTime { get; }
    }

}
