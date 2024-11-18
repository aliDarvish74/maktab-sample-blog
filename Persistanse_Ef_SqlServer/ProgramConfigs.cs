using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistanse_Ef_SqlServer
{
    public static class ProgramConfigs
    {
        public static void AddSQLServerPersistance(this IServiceCollection services,string connectionString)
        {

            services.AddDbContext<SqlServerDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseSqlServer(connectionString);
    });


            services.AddScoped<IPostRepository, PostRepository>();


        }
    }
}
