using Entities;
using Microsoft.EntityFrameworkCore;

namespace GatewayTest.Config
{
    public  class AppDbContextInMemory
    {
        public static RepositoryContext Get()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>().UseInMemoryDatabase(databaseName: $"Gat.Db").Options ;
            return new RepositoryContext(options);
        }
    }
}
