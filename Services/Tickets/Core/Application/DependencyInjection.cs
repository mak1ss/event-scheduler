using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Promotions.gRPC.Protos;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string grpcUrl)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddGrpcClient<PromotionProtoService.PromotionProtoServiceClient>(opt =>
            {
                opt.Address = new Uri(grpcUrl);
            });

            return services;
        }
    }
}
