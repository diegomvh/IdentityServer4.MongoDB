// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.DbContexts
{
    public class PersistedGrantDbContext : IPersistedGrantDbContext
    {
        private readonly OperationalStoreOptions storeOptions;
        private readonly IMongoDatabase db;

        public PersistedGrantDbContext(IOptions<MongoOptions> mongoOptions, OperationalStoreOptions storeOptions)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;

            var client = new MongoClient(mongoOptions.Value.ConnectionString);
            db = client.GetDatabase(mongoOptions.Value.DatabaseName);
            PersistedGrants = db.GetCollection<Documents.PersistedGrant>(storeOptions.PersistedGrants);
        }

        public IMongoCollection<Documents.PersistedGrant> PersistedGrants { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}