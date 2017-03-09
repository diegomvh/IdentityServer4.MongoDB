// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Threading.Tasks;
using IdentityServer4.MongoDB.Documents;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Options;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.DbContexts
{
    public class ConfigurationDbContext : IConfigurationDbContext
    {
        private readonly ConfigurationStoreOptions storeOptions;

        public ConfigurationDbContext(IMongoDatabase db, ConfigurationStoreOptions storeOptions)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;
            Clients = db.GetCollection<Documents.Client>(storeOptions.Clients);
            IdentityResources = db.GetCollection<Documents.IdentityResource>(storeOptions.IdentityResources);
            ApiResources = db.GetCollection<Documents.ApiResource>(storeOptions.ApiResources);
        }

        public IMongoCollection<Documents.Client> Clients { get; set; }
        public IMongoCollection<Documents.IdentityResource> IdentityResources { get; set; }
        public IMongoCollection<Documents.ApiResource> ApiResources { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}