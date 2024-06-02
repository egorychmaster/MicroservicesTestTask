namespace Service2.Api
{
    public static class AppOptions
    {
        public static string DefaultConnection { get; private set; }

        public static string RabbitMqRootUri { get; private set; } = string.Empty;// "rabbitmq://rabbitmq";
        public static string RabbitMqQueueUri { get; private set; } = string.Empty;// "rabbitmq://localhost/usersQueue";
        public static string RabbitMqUser { get; private set; } = string.Empty;// "guest";
        public static string RabbitMqPassword { get; private set; } = string.Empty;// "guest";

        public static void Configure(ConfigurationManager configuration)
        {
            DefaultConnection = configuration.GetConnectionString("DefaultConnection");

            string rabbitMQConnection = configuration.GetValue<string>("RabbitMQ_Connection");
            var items = ParseConnectionString(rabbitMQConnection);
            RabbitMqRootUri = items["host"];
            RabbitMqQueueUri = items["queue"];
            RabbitMqUser = items["user"];
            RabbitMqPassword = items["password"];
        }

        private static Dictionary<string, string> ParseConnectionString(string str)
        {
            var dic = new Dictionary<string, string>();
            var els = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var el in els)
            {
                var par = el.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var key = par[0].ToLower();
                var val = par.Length > 1 ? par[1] : string.Empty;
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, val);
                }
            }

            return dic;
        }
    }
}
