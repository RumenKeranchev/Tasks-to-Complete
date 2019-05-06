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

namespace WebTradingApp
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
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
				options.UseSqlServer(
					Configuration.GetConnectionString( "DefaultConnection" ) ) );

			services.AddDefaultIdentity< IdentityUser >()
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
			this.CreateUserRoles( serviceProvider ).Wait();

			app.UseMvc( routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}" );
			} );
		}

		private async Task CreateUserRoles( IServiceProvider serviceProvider )
		{
			var roleManager = serviceProvider.GetService< RoleManager< IdentityRole > >();
			var userManager = serviceProvider.GetService< UserManager< IdentityUser > >();

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

			var adminEmail = "admin@webtrading.com";
			var user = await userManager.FindByEmailAsync( adminEmail );

			if ( user == null )
			{
				await userManager.CreateAsync( new IdentityUser()
				{
					UserName = Roles.Admin,
					Email = adminEmail
				} );
			}

			await userManager.AddToRoleAsync( user, Roles.Admin );
		}
	}
}