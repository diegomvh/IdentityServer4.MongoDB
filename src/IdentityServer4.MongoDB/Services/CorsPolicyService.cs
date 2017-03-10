// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Threading.Tasks;
using IdentityServer4.Services;
using System.Linq;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Logging;
using IdentityServer4.MongoDB.Interfaces;
using MongoDB.Driver;

namespace IdentityServer4.MongoDB.Services
{
    public class CorsPolicyService : ICorsPolicyService
    {
        private readonly IConfigurationRepository _context;
        private readonly ILogger<CorsPolicyService> _logger;

        public CorsPolicyService(IConfigurationRepository context, ILogger<CorsPolicyService> logger)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
            _logger = logger;
        }

        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            var origins = _context.Clients.AsQueryable().SelectMany(x => x.AllowedCorsOrigins.Select(y => y)).ToList();

            var distinctOrigins = origins.Where(x => x != null).Distinct();

            var isAllowed = distinctOrigins.Contains(origin, StringComparer.OrdinalIgnoreCase);

            _logger.LogDebug("Origin {origin} is allowed: {originAllowed}", origin, isAllowed);

            return Task.FromResult(isAllowed);
        }
    }
}