using Atividade2.Models;
using Microsoft.EntityFrameworkCore;


namespace Atividade2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //configuração para acesso ao banco de dados
            services.AddDbContext<Contexto>(options => options.UseSqlServer(
               Configuration["Data:Atividade2:ConnectionString"]));
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Aluno}/{action=Index}/{id?}");
            });
            SeedData.popularBancoDeDados(app);
        }
    }
}

