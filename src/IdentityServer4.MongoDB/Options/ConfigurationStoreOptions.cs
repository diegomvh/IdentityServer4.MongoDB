// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServer4.MongoDB.Options
{
    public class ConfigurationStoreOptions
    {
        public string IdentityResources { get; set; } = "IdentityResources";
        public string ApiResources { get; set; } = "ApiResources";
        public string Clients { get; set; } = "Clients";
    }
}