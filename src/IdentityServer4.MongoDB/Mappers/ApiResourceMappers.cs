// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;
using IdentityServer4.MongoDB.Documents;

namespace IdentityServer4.MongoDB.Mappers
{
    public static class ApiResourceMappers
    {
        static ApiResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.ApiResource ToModel(this Documents.ApiResource resource)
        {
            return resource == null ? null : Mapper.Map<Models.ApiResource>(resource);
        }

        public static Documents.ApiResource ToDocument(this Models.ApiResource resource)
        {
            return resource == null ? null : Mapper.Map<Documents.ApiResource>(resource);
        }
    }
}