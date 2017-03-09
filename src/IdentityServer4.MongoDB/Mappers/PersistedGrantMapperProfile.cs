// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

namespace IdentityServer4.MongoDB.Mappers
{
    public class PersistedGrantMapperProfile:Profile
    {
        public PersistedGrantMapperProfile()
        {
            // entity to model
            CreateMap<Documents.PersistedGrant, Models.PersistedGrant>(MemberList.Destination);

            // model to entity
            CreateMap<Models.PersistedGrant, Documents.PersistedGrant>(MemberList.Source);
        }
    }
}
