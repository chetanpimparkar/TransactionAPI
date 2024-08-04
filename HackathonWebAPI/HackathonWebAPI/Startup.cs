using Amazon.DynamoDBv2;
using Amazon.Runtime;
using HackathonWebAPI.BusinessLogic;
using HackathonWebAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HackathonWebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Set environment variables programmatically
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
            Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);

            // Log the AWS keys and region to verify they are being read correctly
            Console.WriteLine($"AWS_ACCESS_KEY_ID: {Configuration["AWS:AccessKey"]}");
            Console.WriteLine($"AWS_SECRET_ACCESS_KEY: {Configuration["AWS:SecretKey"]}");
            Console.WriteLine($"AWS_REGION: {Configuration["AWS:Region"]}");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure AWS options
            var awsOptions = Configuration.GetAWSOptions();
            awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();

            // Register AWS services
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonDynamoDB>();

            // Register DynamoDbContext
            services.AddSingleton<DynamoDbContext>();
            services.AddSingleton<ITransactionService, TransactionService>();

            // Register other services
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI();
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
                endpoints.MapControllers();
            });
        }
    }
}
