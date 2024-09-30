using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQExample.Receiver
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

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("message-queue", true, consumer);

            consumer.Received += Consumer_Received;

            Console.ReadLine();
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("The message is: " + Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}