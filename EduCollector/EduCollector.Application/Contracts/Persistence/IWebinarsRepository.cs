﻿using EduCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public interface IWebinarsRepository : IAsyncRepository<Webinars>
    {
    }
}
