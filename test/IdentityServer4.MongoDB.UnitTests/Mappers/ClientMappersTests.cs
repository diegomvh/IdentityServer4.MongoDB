﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.MongoDB.Mappers;
using Xunit;
using Client = IdentityServer4.Models.Client;

namespace IdentityServer4.MongoDB.UnitTests.Mappers
{
    public class ClientMappersTests
    {
        [Fact]
        public void ClientAutomapperConfigurationIsValid()
        {
            var model = new Client();
            var mappedEntity = model.ToDocument();
            var mappedModel = mappedEntity.ToModel();
            
            Assert.NotNull(mappedModel);
            Assert.NotNull(mappedEntity);
            ClientMappers.Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}