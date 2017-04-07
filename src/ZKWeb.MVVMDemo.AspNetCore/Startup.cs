using Hangfire;
using Microsoft.AspNetCore.Builder;
using ZKWeb.Hosting.AspNetCore;
using ZKWeb.Server;

namespace ZKWeb.MVVMDemo.AspNetCore {
	/// <summary>
	/// Asp.Net Core Startup Class
	/// </summary>
	public class Startup : StartupBase {
		/// <summary>
		/// �����м��
		/// </summary>
		/// <param name="app"></param>
		protected override void ConfigureMiddlewares(IApplicationBuilder app) {
			// ʹ��Hangfire�м��
			var configManager = Application.Ioc.Resolve<WebsiteConfigManager>();
			var config = configManager.WebsiteConfig.ConnectionString;
			GlobalConfiguration.Configuration.UseSqlServerStorage(config);
			app.UseHangfireDashboard();
			app.UseHangfireServer();
			// ʹ��Swagger�м��
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZKWeb MVVM Demo V1");
			});
			// ʹ��Mvc�м��
			app.UseMvc();
			// ע��IServiceProvider
			Application.Ioc.RegisterInstance(app.ApplicationServices);
		}
	}
}
