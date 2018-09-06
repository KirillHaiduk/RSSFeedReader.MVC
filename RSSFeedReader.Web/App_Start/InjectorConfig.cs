using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace RSSFeedReader.Web.App_Start
{
    public static class InjectorConfig
    {
        public static void Configure()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            var asm = GetAssemblies();

            container.RegisterPackages(asm);//etAssemblies());

            MapperSetup(container);
            
            container.Verify(VerificationOption.VerifyOnly);
        }

        private static Assembly[] GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(asm =>
                asm.FullName.StartsWith("RSSFeedReader", StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        private static void MapperSetup(Container container)
        {
            Mapper.Initialize(config => config.AddProfiles(GetAssemblies()));
            Mapper.AssertConfigurationIsValid();
            var mapper = Mapper.Configuration.CreateMapper(container.GetInstance);
            container.RegisterInstance(typeof(IMapper), mapper);
        }        
    }

    public class SimpleInjectorFactory : IValidatorFactory
    {
        private readonly Container _container;

        public SimpleInjectorFactory(Container container)
        {
            _container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            try
            {
                return (IValidator<T>)_container.GetInstance(typeof(T));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IValidator GetValidator(Type type)
        {
            try
            {
                return (IValidator)_container.GetInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}