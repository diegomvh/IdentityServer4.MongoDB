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
        public ApiResourceMapperProfile()
        {
            // document to model
            CreateMap<Documents.ApiResource, Models.ApiResource>(MemberList.Destination)
                .ForMember(x => x.ApiSecrets, opt => 
                    opt.MapFrom(src => src.ApiSecrets.Select(x => new Models.Secret(x.Value, x.Description, x.Expiration) { Type = x.Type })))
                .ForMember(x => x.Scopes, opt => 
                    opt.MapFrom(src => src.Scopes.Select(x => new Models.Scope(x.Name, x.DisplayName, x.UserClaims) { 
                        Required = x.Required, 
                        Emphasize = x.Emphasize, 
                        ShowInDiscoveryDocument = x.ShowInDiscoveryDocument })));
                
            // model to document
            CreateMap<Models.ApiResource, Documents.ApiResource>(MemberList.Source)
                .ForMember(x => x.ApiSecrets, opt => 
                    opt.MapFrom(src => src.ApiSecrets.Select(x => new Documents.Secret(x.Value, x.Description, x.Expiration) { Type = x.Type })))
                .ForMember(x => x.Scopes, opt => 
                    opt.MapFrom(src => src.Scopes.Select(x => new Documents.Scope(x.Name, x.DisplayName, x.UserClaims) { 
                        Required = x.Required, 
                        Emphasize = x.Emphasize, 
                        ShowInDiscoveryDocument = x.ShowInDiscoveryDocument })));

        }
    }
}
