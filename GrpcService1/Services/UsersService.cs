using Microsoft.EntityFrameworkCore;
using Grpc.Core;
using System.Linq;
namespace GrpcService1.Services
{
    public class UsersService:Users.UsersBase
    {
        IDbContextFactory<DemoContext> Factory;
        public UsersService(IDbContextFactory<DemoContext> factory)
        {
            Factory = factory;
        }
        public override async Task<ListUsers> GetUsers(UsersRequest request, ServerCallContext context)
        {
            ListUsers dataR = new ListUsers();

            using (var contextDb = Factory.CreateDbContext())
            {
                var data = await contextDb.Users.Where(o => o.Id == request.Id).ToListAsync();
                if (data.Any())
                {
                    foreach (var value in data)
                    {
                        dataR.Data.Add(new UsersDTO
                        {
                            Id = value.Id,
                            Name = value.Name,
                        });
                    }

                }
                //contextDb.Database.CloseConnection();
                //contextDb.Dispose();
            }
            return dataR;
        }
    }
}
