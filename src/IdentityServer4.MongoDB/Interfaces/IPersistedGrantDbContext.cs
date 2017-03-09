// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.Interfaces
{
    public interface IPersistedGrantDbContext : IDisposable
    {
        IMongoCollection<Documents.PersistedGrant> PersistedGrants { get; set; }
    }
}