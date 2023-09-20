using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Entities.Concrete
{
    public class LogData : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }
}
