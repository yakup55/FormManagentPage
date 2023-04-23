using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CoreLayer.Repository;
using CoreLayer.Service;
using CoreLayer.UnitOfWork;
using RepositoryLayer.Context;
using RepositoryLayer.Repository;
using RepositoryLayer;
using ServiceLayer.Service;
using System.Reflection;
using Module = Autofac.Module;

namespace FormManagentProject.Models
{
    public class RepoServiceModel:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<,>)).As(typeof(IGenericService<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(Mapper));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
               .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
             .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();




            base.Load(builder);
        }
    }
}
