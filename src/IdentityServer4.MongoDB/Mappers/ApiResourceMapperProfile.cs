// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using AutoMapper;
using IdentityServer4.Models;

namespace IdentityServer4.MongoDB.Mappers
{
    /// <summary>
    /// AutoMapper configuration for API resource
    /// Between model and entity
    /// </summary>
    public class ApiResourceMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="ApiResourceMapperProfile"/>
        /// </summary>
        public ApiResourceMapperProfile()
        {
            // entity to model
            CreateMap<ApiResource, Models.ApiResource>(MemberList.Destination)
                .ForMember(x => x.ApiSecrets, opt => opt.MapFrom(src => src.ApiSecrets.Select(x => x)))
                .ForMember(x => x.Scopes, opt => opt.MapFrom(src => src.Scopes.Select(x => x)))
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => x)));
            CreateMap<Secret, Models.Secret>(MemberList.Destination);
            CreateMap<Scope, Models.Scope>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x)));

            // model to entity
            CreateMap<Models.ApiResource, ApiResource>(MemberList.Source)
                .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(src => src.ApiSecrets.Select(x => x)))
                .ForMember(x => x.Scopes, opts => opts.MapFrom(src => src.Scopes.Select(x => x)))
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => x)));
            CreateMap<Models.Secret, Secret>(MemberList.Source);
            CreateMap<Models.Scope, Scope>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => x )));
        }
    }
}
