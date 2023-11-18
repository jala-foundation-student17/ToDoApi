using DataAccess;
using InfrastructureContracts.DataAccess;
using InfrastructureContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RequisitionHandlers;
using RequisitionHandlers.Contracts;

namespace Api.Extensions
{
    public static class DependencyExtensions
    {

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAssignmentRepository, AssignmentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAssignmentRequisitionHandler, AssignmentRequisitionHandler>();
            services.AddTransient<ICategoryRequisitionHandler, CategoryRequisitionHandler>();

        }

        public static void DataAccess(this IServiceCollection services)
        {

            services.AddTransient<DbContextOptionsBuilder>();


            services.AddDbContext<IMySqlContext, MySqlContext>(opt => opt.UseInMemoryDatabase("database"));


        }

        public static void DataAccess(this IServiceCollection services, string connStr)
        {
            if (String.IsNullOrEmpty(connStr))
            {
                throw new Exception("Connection string can not be null");
            }

            services.AddTransient<DbContextOptionsBuilder>();

            services.AddDbContext<IMySqlContext, MySqlContext>(opt => opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

        }
    }
}
