// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Grpc.Net.Client;
using ConsoleGRPCClient;


Console.WriteLine("Hello, World!");


// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7199");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClientperro" });

var client2 = new Products.ProductsClient(channel);
var reply2 = await client2.GetProductsAsync(new ProductsRequest()
{
    Name = "test",
    Price = 200
});

var client3 = new Users.UsersClient(channel);
var reply3 =await client3.GetUsersAsync(new UsersRequest() { Id=1});

List<UsersDTO> response = new List<UsersDTO>();
response.AddRange(reply3.Data);

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Products: " + reply2.Productid);

if(response.Count>0)
{
    foreach(var data in response)
    {
        Console.WriteLine($"dato de base GRPC {data.Id} - {data.Name}");
    }
}
else
{
    Console.WriteLine("no hay datos con ese id");
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
