using Helpers.Constants;
using Helpers.HelperModels;
using System.Net;
using System.Reflection;

namespace Helpers
{
    public class Monitizer
    {
        /// <summary>
        ///  Service start status
        ///  <value>-1: Application error in startup</value>
        ///  <value>0: Application loading</value>
        ///  <value>1: Application started successfully</value>
        /// </summary>
        public int startSuccesful = 0;

        /// <summary>
        ///  Application name
        /// </summary>
        public string appName = "";

        /// <summary>
        ///  Application hosting ip
        /// </summary>
        public string ipAddress = "";


        public Task.Logging.RabbitMq.RabbitMQ rabbitMq = new Task.Logging.RabbitMq.RabbitMQ();
        public bool rabbitConnected = false;

        /// <summary>
        ///  Initializes application Monitizer
        /// </summary>
        /// <param name="RabbitMQUrl">RabbitMQ Server Url</param>
        /// <param name="RabbitMQUsername">RabbitMQ Server Username</param>
        /// <param name="RabbitMQPassword">RabbitMQ Server Password</param>
        public Monitizer(string RabbitMQUrl, string RabbitMQUsername, string RabbitMQPassword)
        {
            if (!string.IsNullOrEmpty(RabbitMQUrl))
            {
                ApplicationStartResult res = rabbitMq.Initialize(RabbitMQUrl, RabbitMQUsername, RabbitMQPassword);
                if (res.Success)
                {                    
                    rabbitConnected = true;
                }
            }

            appName = Assembly.GetEntryAssembly().GetName().Name;

            var dns = Dns.GetHostAddresses(Dns.GetHostName());
            if (dns.Length > 0)
            {
                ipAddress = dns[dns.Length - 1].ToString();
                if (dns.Length > 1 && ipAddress.Length > 20)
                {
                    ipAddress = dns[0].ToString();
                }
            }

        }

        /// <summary>
        ///  Get application startup page data (Exceptions, logs, console, healthcheck etc.)
        /// </summary>
        /// <returns>MonitizerResult</returns>
        public MonitizerResult GetMonitizerResult()
        {
            MonitizerResult res = new MonitizerResult();            
            res.StartSuccesful = startSuccesful;
            res.AppName = appName;
            res.IpAddress = ipAddress;
            return res;
        }

        public void PublishLog(Task.Entities.Concrete.LogData log)
        {
            if (rabbitConnected)
                rabbitMq.Publish(FeedNames.ApplicationLogs, "", log);
        }


    }
}
