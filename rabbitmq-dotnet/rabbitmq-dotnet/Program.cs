using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections;
using System.Text;

Customer customer = new Customer() { Name = "admin", SurName="Test"};
var factory = new ConnectionFactory() { HostName = "localhost" };
using(IConnection connection = factory.CreateConnection()) 
using(IModel channel = connection.CreateModel())
{
    channel.QueueDeclare(
                        queue: "FirstQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
        );
    string message = JsonConvert.SerializeObject(customer);
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "",
        routingKey: "FirstQueue",
        basicProperties: null,
        body:body);
}

public class Customer
{
    public string Name { get; set; }
    public string SurName { get; set; }
}