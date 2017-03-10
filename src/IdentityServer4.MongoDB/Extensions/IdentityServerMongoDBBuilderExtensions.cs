// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Services;
using IdentityServer4.Stores;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Stores;
using IdentityServer4.MongoDB.Services;
using IdentityServer4.MongoDB.Options;
using IdentityServer4.MongoDB.DbContexts;
using IdentityServer4.MongoDB;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerMongoDBBuilderExtensions
    {
        public static IIdentityServerBuilder AddConfigurationStore(
            this IIdentityServerBuilder builder, 
            IConfiguration mongoConfiguration,
            Action<ConfigurationStoreOptions> storeOptionsAction = null)
        {
            builder.Services.AddScoped<IConfigurationDbContext, ConfigurationDbContext>();

            builder.Services.AddTransient<IClientStore, ClientStore>();
            builder.Services.AddTransient<IResourceStore, ResourceStore>();
            builder.Services.AddTransient<ICorsPolicyService, CorsPolicyService>();
            builder.Services.Configure<MongoOptions>(mongoConfiguration);
            
            var options = new ConfigurationStoreOptions();
            storeOptionsAction?.Invoke(options);
            builder.Services.AddSingleton(options);
            
            return builder;
        }

        public static IIdentityServerBuilder AddConfigurationStoreCache(
            this IIdentityServerBuilder builder)
        {
            builder.AddInMemoryCaching();

            // these need to be registered as concrete classes in DI for
            // the caching decorators to work
            builder.Services.AddTransient<ClientStore>();
            builder.Services.AddTransient<ResourceStore>();

            // add the caching decorators
            builder.AddClientStoreCache<ClientStore>();
            builder.AddResourceStoreCache<ResourceStore>();

            return builder;
        }

        public static IIdentityServerBuilder AddOperationalStore(
            this IIdentityServerBuilder builder,
            IConfiguration mongoConfiguration,
            Action<OperationalStoreOptions> storeOptionsAction = null,
            Action<TokenCleanupOptions> tokenCleanUpOptions = null)
        {
            builder.Services.AddScoped<IPersistedGrantDbContext, PersistedGrantDbContext>();

            builder.Services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();
            builder.Services.Configure<MongoOptions>(mongoConfiguration);

            var storeOptions = new OperationalStoreOptions();
            storeOptionsAction?.Invoke(storeOptions);
            builder.Services.AddSingleton(storeOptions);

            var tokenCleanupOptions = new TokenCleanupOptions();
            tokenCleanUpOptions?.Invoke(tokenCleanupOptions);
            builder.Services.AddSingleton(tokenCleanupOptions);
            builder.Services.AddSingleton<TokenCleanup>();
            
            return builder;
        }

        public static IApplicationBuilder UseIdentityServerMongoTokenCleanup(this IApplicationBuilder app, IApplicationLifetime applicationLifetime)
        {
            var tokenCleanup = app.ApplicationServices.GetService<TokenCleanup>();
            if(tokenCleanup == null)
            {
                throw new InvalidOperationException("AddOperationalStore must be called on the service collection.");
            }
            applicationLifetime.ApplicationStarted.Register(tokenCleanup.Start);
            applicationLifetime.ApplicationStopping.Register(tokenCleanup.Stop);

            return app;
        }
    }
}