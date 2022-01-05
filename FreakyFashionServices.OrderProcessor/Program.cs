using AutoMapper;
using FreakyFashionServices.OrderProcessor.Data;
using FreakyFashionServices.OrderProcessor.Models.DbModel;
using FreakyFashionServices.OrderProcessor.Models.Dtos;
using FreakyFashionServices.OrderProcessor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


var factory = new ConnectionFactory { Uri = new Uri("amqp://guest:guest@localhost:5672") };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(queue: "order", durable: false, exclusive: false, autoDelete: false, arguments: null);


string connectionString = "Server=.;Database= OrdersDataBase;Trusted_Connection=True;MultipleActiveResultSets=true";
var services = new ServiceCollection();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddDbContext<OrderDbContext>(
   options => options.UseSqlServer(connectionString));

var consumer = new EventingBasicConsumer(channel);
ServiceProvider serviceProvider = services.BuildServiceProvider();
var context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<OrderDbContext>();
var orderservice = new OrderService(context);
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
consumer.Received += (sender, e) => {

    Console.WriteLine("Processing order...");

    var body = e.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);
    var orderDto = JsonConvert.DeserializeObject<CreateOrderDto>(json); 
    orderservice.CreateOrder(orderDto);
};

channel.BasicConsume(
   queue: "order",
   autoAck: true,
   consumer: consumer);

Console.WriteLine(" Press [ENTER] to exit.");
Console.ReadLine();