﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GuestRegistrationDataManager.Startup))]

namespace GuestRegistrationDataManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
