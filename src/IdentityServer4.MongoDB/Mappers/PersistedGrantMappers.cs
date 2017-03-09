// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

namespace IdentityServer4.MongoDB.Mappers
{
    public static class PersistedGrantMappers
    {
        static PersistedGrantMappers()
        {
            Mapper = new MapperConfiguration(cfg =>cfg.AddProfile<PersistedGrantMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static Models.PersistedGrant ToModel(this Documents.PersistedGrant token)
        {
            return token == null ? null : Mapper.Map<Models.PersistedGrant>(token);
        }

        public static Documents.PersistedGrant ToDocument(this Models.PersistedGrant token)
        {
            return token == null ? null : Mapper.Map<Documents.PersistedGrant>(token);
        }

        public static void UpdateEntity(this Models.PersistedGrant token, Documents.PersistedGrant target)
        {
            Mapper.Map(token, target);
        }
    }
}