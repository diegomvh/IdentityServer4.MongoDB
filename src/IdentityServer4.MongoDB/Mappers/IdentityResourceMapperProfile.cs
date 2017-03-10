// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using AutoMapper;
using IdentityServer4.MongoDB.Documents;

namespace IdentityServer4.MongoDB.Mappers
{
    /// <summary>
    /// AutoMapper configuration for identity resource
    /// Between model and entity
    /// </summary>
    public class IdentityResourceMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="IdentityResourceMapperProfile"/>
        /// </summary>
        public IdentityResourceMapperProfile()
        {
            // entity to model
            CreateMap<Documents.IdentityResource, Models.IdentityResource>(MemberList.Destination);

            // model to entity
            CreateMap<Models.IdentityResource, Documents.IdentityResource>(MemberList.Source);
        }
    }
}
