using System.Linq;
using ControleOrcamento.Banco;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ControleOrcamento
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //comprimir zipando os arquivos json para a tela e o HTML consegue extrair e mostrar os dados
            services.AddResponseCompression(options => {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });

            });

            services.AddScoped<IRepositorioBase<Usuario, int>, UsuarioRepositorio>();
            services.AddScoped<IRepositorioBase<Ativo, int>, AtivoRepositorio>();
            services.AddScoped<IRepositorioBase<Passivo, int>, PassivoRepositorio>();
            services.AddScoped<IRepositorioBase<Investimento, int>, InvestimentoRepositorio>();

            services.AddCors();

            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContext>(
            opt => opt.UseSqlServer(
                Configuration.GetConnectionString("connectionString")
                ));

            services.AddScoped<DataContext, DataContext>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Controle de Orçamento - Programação Orientada a Objetos", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Orçamento"));
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
