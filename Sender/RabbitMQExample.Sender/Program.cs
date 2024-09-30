using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQExample.Sender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://ibfnxmgi:505o89xyJclBwAjh7--cEwAy17AU6OMk@shrimp.rmq.cloudamqp.com/ibfnxmgi");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("message-queue", true, false, false);

            var message = "Hello World";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, "message-queue", null, body);

            Console.WriteLine("Message sent!");
            Console.ReadLine();
        }
    }
}