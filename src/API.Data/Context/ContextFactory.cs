using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public string _connectioString = "Data Source=[SEU_SERVIDOR];Initial Catalog=[SEU_DB];persist security info=True;User ID=[SEU_USUARIO];Password=[SUA_SENHA]";
       
        public MyContext CreateDbContext(string[] args)
        {
           
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseSqlServer(_connectioString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
