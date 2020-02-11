using FullStackDays.Models;
using FullStackDays.Schema;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FullStackDays
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQL(sp =>
                {
                    return SchemaBuilder.New()
                        .AddQueryType<Query>()
                        .AddMutationType<Mutation>()
                        .AddType<InstantType>()
                        .AddType<OrderResultType>()
                        .AddServices(sp)
                        .Create();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseGraphQLHttpPost(new HttpPostMiddlewareOptions { Path = "/graphql" })
                .UseGraphQLHttpGetSchema(new HttpGetSchemaMiddlewareOptions { Path = "/graphql/schema" });
        }
    }
}
