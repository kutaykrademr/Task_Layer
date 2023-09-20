using Helpers;
using Helpers.Constants;
using Helpers.HelperModels;
using Task.Business.Abstract;
using Task.Entities.Concrete;
using Task.Logging.RabbitMq;

namespace Task.API
{
    public class MainWorker
    {
        /// <summary>
        ///  Initializes application (RabbitMQ connection check)
        /// </summary>
        public static void InitializeService()
        {

            Constants.monitizer = new Monitizer(Constants.settings.RabbitMQUrl, Constants.settings.RabbitMQUsername, Constants.settings.RabbitMQPassword);

            ApplicationStartResult rabbitControl = Constants.rabbitMq.Initialize(Constants.settings.RabbitMQUrl, Constants.settings.RabbitMQUsername, Constants.settings.RabbitMQPassword);
            if (!rabbitControl.Success)
            {
                Constants.monitizer.startSuccesful = -1;
            }
            if (Constants.monitizer.startSuccesful != -1)
            {
                Constants.monitizer.startSuccesful = 1;
                Constants.rabbitMq.ExchangeDeclare(FeedNames.ApplicationLogs, "direct", false, false);
                Constants.rabbitMq.QueueBind(FeedNames.ApplicationLogs, "", OnApplicationLog);
            }
        }

        private static ILogDataService _logDataService;

        public MainWorker(ILogDataService logDataService)
        {
            _logDataService = logDataService;
        }

        public static void OnApplicationLog(string source, byte[] data)
        {
            LogData log = Serializers.Deserialize<LogData>(data);

           // _logDataService.Add(log);

        }
    }
}
