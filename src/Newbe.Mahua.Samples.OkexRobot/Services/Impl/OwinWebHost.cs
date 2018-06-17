﻿using System;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin.Hosting;

namespace Newbe.Mahua.Samples.OkexRobot.Services.Impl
{
    public class OwinWebHost : IWebHost
    {
        // 保存Web服务的实例
        private IDisposable _webhost;

        public Task StartAsync(string baseUrl, ILifetimeScope lifetimeScope)
        {
            _webhost = WebApp.Start(baseUrl, app => new Startup().Configuration(app, lifetimeScope));
            return Task.FromResult(0);
        }

        public Task StopAsync()
        {
            _webhost.Dispose();
            return Task.FromResult(0);
        }
    }
}
