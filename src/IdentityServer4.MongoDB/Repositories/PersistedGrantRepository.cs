// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.Repositories
{
    public class PersistedGrantRepository : IPersistedGrantRepository
    {
        private readonly OperationalStoreOptions storeOptions;
        public readonly IMongoDatabase Database;

        public PersistedGrantRepository(IOptions<MongoOptions> mongoOptions, OperationalStoreOptions storeOptions)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;

            var client = new MongoClient(mongoOptions.Value.ConnectionString);
            Database = client.GetDatabase(mongoOptions.Value.DatabaseName);
            PersistedGrants = Database.GetCollection<Documents.PersistedGrant>(storeOptions.PersistedGrants);
        }

        public IMongoCollection<Documents.PersistedGrant> PersistedGrants { get; set; }
    }
}