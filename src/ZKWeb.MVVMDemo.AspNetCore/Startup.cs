using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ZKWeb.MVVMDemo.AspNetCore {
	/// <summary>
	/// Asp.Net Core Startup Class
	/// </summary>
	public class Startup : ZKWeb.Hosting.AspNetCore.StartupBase {
		/// <summary>
		/// �����м��
		/// </summary>
		/// <param name="app"></param>
		protected override void ConfigureMiddlewares(IApplicationBuilder app) {
			// ʹ�ô�����ʾҳ��
			var env = (IHostingEnvironment)app.ApplicationServices.GetService(typeof(IHostingEnvironment));
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseStatusCodePages();
			}
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
