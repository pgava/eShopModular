﻿using Autofac;
using Quartz;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Quartz;

public class QuartzModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(x => typeof(IJob).IsAssignableFrom(x)).InstancePerDependency();
    }
}