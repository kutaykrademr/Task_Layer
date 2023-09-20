namespace Task.API
{
    public class Settings
    {
        public string RabbitMQUrl { get; set; }
        public string RabbitMQUsername { get; set; }
        public string RabbitMQPassword { get; set; }

    } 
    public class Constants
    {
        public static Settings settings = new Settings();
        public static Logging.RabbitMq.RabbitMQ rabbitMq = new Logging.RabbitMq.RabbitMQ();
        public static Helpers.Monitizer monitizer;
        
    }
}
