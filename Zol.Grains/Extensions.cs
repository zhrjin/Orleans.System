﻿using Microsoft.Extensions.DependencyInjection;
using Ray.Core.Internal;
using Ray.Core.EventBus;
using Ray.MongoDB;
using Ray.RabbitMQ;

namespace Ray.Grain
{
    public static class Extensions
    {
       
        public static void AddMongoDbSiloGrain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMQService();
            serviceCollection.AddSingleton<IMongoStorage, MongoStorage>();
            serviceCollection.AddSingleton<IStorageContainer, MongoStorageContainer>();
        }

        private static void AddMQService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRabbitMQ();
            serviceCollection.AddSingleton<IProducerContainer, ProducerContainer>();
        }
    }
}
