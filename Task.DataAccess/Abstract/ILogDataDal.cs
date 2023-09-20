using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DataAccess;
using Task.Entities.Concrete;

namespace Task.DataAccess.Abstract
{
    public interface ILogDataDal: IEntityRepository<LogData>
    {
    }
}
