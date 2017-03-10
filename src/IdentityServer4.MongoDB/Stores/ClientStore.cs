// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.MongoDB.Mappers;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IConfigurationRepository _context;
        private readonly ILogger<ClientStore> _logger;

        public ClientStore(IConfigurationRepository context, ILogger<ClientStore> logger)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _logger = logger;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _context.Clients.AsQueryable()
                .FirstOrDefault(x => x.ClientId == clientId);
            var model = client?.ToModel();

            _logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

            return Task.FromResult(model);
        }
    }
}