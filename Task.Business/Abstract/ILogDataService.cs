﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities.Concrete;

namespace Task.Business.Abstract
{
    public interface ILogDataService
    {
        List<LogData> GetAll();
        void Add(LogData product);
    }
}
