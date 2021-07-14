using System;
using System.Text;
using DevMeetings.Services.Meetings.Core.Repositories;
using DevMeetings.Services.Meetings.Infrastructure.MessageBus;
using DevMeetings.Services.Meetings.Infrastructure.Persistence;
using DevMeetings.Services.Meetings.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DevMeetings.Services.Meetings.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services) {
            services.AddSingleton(sp => {
                var configuration = sp.GetService<IConfiguration>();

                var options = new MongoDbOptions();
                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton(sp => {
                var options = sp.GetService<MongoDbOptions>();

                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(sp => {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<MongoClient>();
                
                return mongoClient.GetDatabase(options.Database);
            });
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            
            return services;
        }

        public static IServiceCollection AddRabbitMq(this IServiceCollection services) {
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }

        public static string ToDashCase(this string text)
        {
            if(text == null) {
                throw new ArgumentNullException(nameof(text));
            }
            if(text.Length < 2) {
                return text;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for(int i = 1; i < text.Length; ++i) {
                char c = text[i];
                if(char.IsUpper(c)) {
                    sb.Append('-');
                    sb.Append(char.ToLowerInvariant(c));
                } else {
                    sb.Append(c);
                }
            }

            Console.WriteLine($"ToDashCase: "+ sb.ToString());

            return sb.ToString();
        }
    }
}