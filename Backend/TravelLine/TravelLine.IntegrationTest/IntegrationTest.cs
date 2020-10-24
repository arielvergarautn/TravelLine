using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TravelLine.IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient _TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                                .WithWebHostBuilder(builder => builder.ConfigureServices(services => {
                                    services.RemoveAll(typeof(TravelLine.DAOs.TravelLineContext));
                                    services.AddDbContext<TravelLine.DAOs.TravelLineContext>(options => {
                                        options.UseInMemoryDatabase("TestDb");
                                    });
                                })
                            );

            _TestClient = appFactory.CreateClient();
        }


        //protected async Task AuthenticateAsync()
        //{

        //}


    }
}
