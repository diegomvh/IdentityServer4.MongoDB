// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.DbContexts
{
    public class ConfigurationDbContext : IConfigurationDbContext
    {
        private readonly ConfigurationStoreOptions storeOptions;
        public readonly IMongoDatabase Database;

        public ConfigurationDbContext(IOptions<MongoOptions> mongoOptions, ConfigurationStoreOptions storeOptions)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;

            var client = new MongoClient(mongoOptions.Value.ConnectionString);
            Database = client.GetDatabase(mongoOptions.Value.DatabaseName);
            Clients = Database.GetCollection<Documents.Client>(storeOptions.Clients);
            IdentityResources = Database.GetCollection<Documents.IdentityResource>(storeOptions.IdentityResources);
            ApiResources = Database.GetCollection<Documents.ApiResource>(storeOptions.ApiResources);
        }

        public IMongoCollection<Documents.Client> Clients { get; set; }
        public IMongoCollection<Documents.IdentityResource> IdentityResources { get; set; }
        public IMongoCollection<Documents.ApiResource> ApiResources { get; set; }
    }
}