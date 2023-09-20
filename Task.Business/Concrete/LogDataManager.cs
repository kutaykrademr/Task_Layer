using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Business.Abstract;
using Task.DataAccess.Abstract;
using Task.DataAccess.Concrete.EntityFramework;
using Task.Entities.Concrete;

namespace Task.Business.Concrete
{
    public class LogDataManager : ILogDataService
    {
        private readonly ILogDataDal _logDataDal;

        public LogDataManager(ILogDataDal logDataDal)
        {
            _logDataDal = logDataDal;
        }

        public void Add(LogData logData)
        {
            _logDataDal.Add(logData);
        }

        public List<LogData> GetAll()
        {
            return _logDataDal.GetAll();
        }
    }
}
