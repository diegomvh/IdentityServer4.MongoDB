// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;

namespace IdentityServer4.MongoDB.Documents
{
    public class Scope
    {
        public Scope()
        {
        }

        public Scope(string name)
            : this(name, name, null)
        {
        }

        public Scope(string name, string displayName)
            : this(name, displayName, null)
        {
        }

        public Scope(string name, IEnumerable<string> claimTypes)
            : this(name, name, claimTypes)
        {
        }

        public Scope(string name, string displayName, IEnumerable<string> claimTypes)
        {
            Name = name;
            DisplayName = displayName;

            if (claimTypes != null && claimTypes.Count() != 0)
            {
                foreach (var type in claimTypes)
                {
                    UserClaims.Add(type);
                }
            }
        }
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Description { get; set; }

        public bool Required { get; set; } = false;

        public bool Emphasize { get; set; } = false;

        public bool ShowInDiscoveryDocument { get; set; } = true;

        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
    }
}