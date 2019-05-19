using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTradingApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTradingApp.Data.Models;

namespace WebTradingApp
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			services.Configure< CookiePolicyOptions >( options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			} );

			#region DBContext config

			services.AddDbContext< WebTradingDbContext >( options =>
				options.UseSqlServer( this.Configuration.GetConnectionString( "DefaultConnection" ) ) );

			services.AddIdentity< User, IdentityRole >()
				.AddDefaultUI( UIFramework.Bootstrap4 )
				.AddEntityFrameworkStores< WebTradingDbContext >();

			#endregion

			services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler( "/Home/Error" );
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc( routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}" );
			} );

			this.CreateUserRoles( serviceProvider ).Wait();
		}

		private async Task CreateUserRoles( IServiceProvider serviceProvider )
		{
			var roleManager = serviceProvider.GetRequiredService< RoleManager< IdentityRole > >();
//			var userManager = serviceProvider.GetService< UserManager< User > >();

			var roles = typeof( Roles )
				.GetFields()
				.Select( r => r.GetValue( r ).ToString() )
				.ToList();

			foreach ( var role in roles )
			{
				var roleExist = await roleManager.RoleExistsAsync( role );

				if ( !roleExist )
				{
					await roleManager.CreateAsync( new IdentityRole( role ) );
				}
			}

			#region CreateADefaultAdminUser --> Not Working    

			//			var adminEmail = "admin@webtrading.com";
			//			var adminPassword = "admin";
			//
			//			var adminUser = await userManager.FindByEmailAsync( adminEmail );
			//
			//			if ( adminUser == null )
			//			{
			//				adminUser = new User()
			//				{
			//					UserName = Roles.Admin,
			//					Email = adminEmail,
			//
			//				};
			//
			//				await userManager.CreateAsync( adminUser, adminPassword );
			//
			//				await userManager.AddToRoleAsync( adminUser, Roles.Admin );
			//			}

			#endregion
		}

		//TODO: Ban users -> https://stackoverflow.com/questions/22652118/disable-user-in-aspnet-identity-2-0
	}
}