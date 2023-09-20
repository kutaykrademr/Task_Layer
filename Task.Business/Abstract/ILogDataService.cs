using Task.Entities.Concrete;

namespace Task.Business.Abstract
{
    public interface ILogDataService
    {
        List<LogData> GetAll();
        void Add(LogData product);
    }
}