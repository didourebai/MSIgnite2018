using TravelGuideTunisia.Infrastructure.BaseContext;
using TravelGuideTunisia.Infrastructure.BaseContext.Enumerations;
using TravelGuideTunisia.Infrastructure.SessionFactories;
using TravelGuideTunisia.Persistence.Base.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RH.CrossCutting.Logging;
using Swashbuckle.AspNetCore.Swagger;
using TravelGuideTunisia.Business.DomainServices.Event;
using TravelGuideTunisia.Business.DomainServices.Hotel;
using TravelGuideTunisia.Business.DomainServices.Place;
using TravelGuideTunisia.Business.DomainServices.User;
using TravelGuideTunisia.Persistence.Entities.TravelGuide;
using TravelGuideTunisia.Persistence.Mapping.TravelGuide.NhMapping;


namespace TravelGuideTunisia.Services
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connectionString = Configuration["Logging:DbContextSettings:ConnectionString"];

            ISessionFactoriesManager sessionFactoriesManager = new SessionFactoriesManager();

            sessionFactoriesManager.AddSessionFactoryForNamespaceOf<ITravelGuide, ITravelGuideMap>(EAvailableDBMS.PostgreSQL.ToString(), connectionString, false, false, true);
            services.AddSingleton(sessionFactoriesManager);



            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Place>, Repository<Place>>();
            services.AddTransient<IRepository<Event>, Repository<Event>>();
            services.AddTransient<IRepository<EventRegistration>, Repository<EventRegistration>>();
            

            // Domain API Services
            services.AddTransient<IPlaceDomainServices, PlaceDomainServices>();
            services.AddTransient<IUserDomainServices, UserDomainServices>();
            services.AddTransient<IEventDomainServices, EventDomainServices>();
            services.AddTransient<IHotelDomainServices, HotelDomainServices>();
            services.AddTransient<ILogger, Logger>();

            //SMSShortCode Controller
            //services.AddTransient<IDBCurrentSessionContext, CurrentNhSessionContext>();


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Hamida REBAI", Email = "didourebai@gmail.com", Url = "www.http://rebai-hamida.azurewebsites.net/.com" },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

                //    services.AddSwaggerGen(c =>
                //{
                //    c.SwaggerDoc("v1", new Info
                //    {
                //        Version = "v1",
                //        Title = "My API",
                //        Description = "My template",
                //        TermsOfService = "None",
                //        Contact = new Contact() { Name = "Hamida REBAI", Email = "didourebai@gmail.com", Url = "www.http://rebai-hamida.azurewebsites.net/.com" }
                //    });
            });

        }

    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
