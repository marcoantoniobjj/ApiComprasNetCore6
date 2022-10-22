using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.ApiDotNet6.Application.Mappings;
using MP.ApiDotNet6.Application.Services;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Authentication;
using MP.ApiDotNet6.Infra.Data.Context;
using MP.ApiDotNet6.Infra.Data.Repositories;


namespace MP.ApiDotNet6.Infra.IoC
{
    public static class DependencyInjection
    {
        //Classe para InfraEstrutura (AddInfrastructure)
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //Injetar o Banco de Dados (ApplicationDbContext) e o PersonRepository na nossa
            //injecao de dependencia
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))); //DefaultConnectio a string de conexao com BD

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
            //________________________________________________________

        }


        //instalar pacotes NuGet - AutoMapper e AutoMapper.Extension.Microsoft.DependencyInjection

        //Classe para Servicos (AddServices)
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Injetar servicos IPersonservice e PersonService
            services.AddAutoMapper(typeof(DomainToDTOMap));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IUserService, UserService>();
            return services;
            //________________________________________________


        }

    }
}



