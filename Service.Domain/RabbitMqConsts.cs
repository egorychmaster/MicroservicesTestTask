namespace Service.Domain
{
    public record RabbitMqConsts
    {
        public const string RabbitMqRootUri = "rabbitmq://rabbitmq";
        //public const string RabbitMqRootUri = "rabbitmq://localhost:15672";
        //public const string RabbitMqRootUri = "rabbitmq://localhost";

        public const string RabbitMqUri = "rabbitmq://localhost/usersQueue";
        public const string UserName = "guest";
        public const string Password = "guest";
        //public const string NotificationServiceQueue = "notification.service";
    }
}