// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using System.Security.Claims;
using AutoMapper;

namespace IdentityServer4.MongoDB.Mappers
{
    /// <summary>
    /// AutoMapper configuration for Client
    /// Between model and entity
    /// </summary>
    public class ClientMapperProfile : Profile
    {
        /// <summary>
        /// <see>
        ///     <cref>{ClientMapperProfile}</cref>
        /// </see>
        /// </summary>
        public ClientMapperProfile()
        {
            // entity to model
            CreateMap<Documents.Client, Models.Client>(MemberList.Destination)
                .ForMember(x => x.ClientSecrets, opt => 
                    opt.MapFrom(src => src.ClientSecrets.Select(x => new Models.Secret(x.Value, x.Description, x.Expiration) { Type = x.Type })));

            // model to entity
            CreateMap<Models.Client, Documents.Client>(MemberList.Source)
                .ForMember(x => x.ClientSecrets, opt => 
                    opt.MapFrom(src => src.ClientSecrets.Select(x => new Documents.Secret(x.Value, x.Description, x.Expiration) { Type = x.Type })))
                ;
        }
    }
}