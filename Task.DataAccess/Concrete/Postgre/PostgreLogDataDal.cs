using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DataAccess.EntityFramework;
using Task.DataAccess.Abstract;
using Task.Entities.Concrete;

namespace Task.DataAccess.Concrete.Postgre
{
    public class PostgreLogDataDal : EfEntityRepositoryBase<LogData, PostgreContext>, ILogDataDal
    {
    }
}
