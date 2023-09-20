using Helpers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Task.Business.Abstract;
using Task.Entities.Concrete;
namespace Task.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : Controller
    {
        private ILogDataService _logDataService;

        public LogController(ILogDataService logDataService)
        {
            _logDataService = logDataService;
        }


        [HttpGet]
        public List<LogData> Get()
        {
            return _logDataService.GetAll();

        }

        [HttpPost]
        public IActionResult Post(LogData logData)
        {
            try
            {
                _logDataService.Add(logData);

                var addedLogs = logData;

                return Ok(addedLogs);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                return StatusCode(500, $"İç Sunucu Hatası: {ex.Message}");
            }
        }
    }
}
