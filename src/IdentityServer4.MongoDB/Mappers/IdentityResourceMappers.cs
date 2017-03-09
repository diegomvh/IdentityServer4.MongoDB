// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

namespace IdentityServer4.MongoDB.Mappers
{
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.IdentityResource ToModel(this Documents.IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<Models.IdentityResource>(resource);
        }

        public static Documents.IdentityResource ToDocument(this Models.IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<Documents.IdentityResource>(resource);
        }
    }
}