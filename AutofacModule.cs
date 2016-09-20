using Autofac;

using HandsOnApi.Repositories;

namespace HandsOnApi
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
        }
    }
}
