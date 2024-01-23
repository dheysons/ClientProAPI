using ClienteAPI.Repositories;
using ClienteAPI.Services;
using Microsoft.OpenApi.Models;

namespace ClienteAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é chamado durante o tempo de execução. Usado para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração da injeção de dependência para os serviços e repositórios
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddControllers();
            services.Configure<BancoDadosConfig>(Configuration.GetSection("BancoDados"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClienteAPI", Version = "1.0" });
            });

        }

        // Este método é chamado durante o tempo de execução. Usado para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClienteAPI v1");
            }); 
        }
    }
}
