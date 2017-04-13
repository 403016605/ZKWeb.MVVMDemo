using Microsoft.AspNetCore.Builder;
using ZKWeb.Hosting.AspNetCore;

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
			// ʹ��Swagger�м��
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZKWeb MVVM Demo V1");
			});
			// ʹ��Mvc�м��
			app.UseMvc(routes => {
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
			// ע��IServiceProvider
			Application.Ioc.RegisterInstance(app.ApplicationServices);
		}
	}
}
