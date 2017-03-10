// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer4.MongoDB.Documents
{
    public class Secret
    {
        public Secret()
        {
            Type = SecretTypes.SharedSecret;
        }

        public Secret(string value, DateTime? expiration = null)
            : this()
        {
            Value = value;
            Expiration = expiration;
        }

        public Secret(string value, string description, DateTime? expiration = null)
            : this()
        {
            Description = description;
            Value = value;
            Expiration = expiration;
        }
        
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } = SecretTypes.SharedSecret;
    }
}