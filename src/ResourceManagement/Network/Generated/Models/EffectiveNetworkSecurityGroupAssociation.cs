// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The effective network security group association.
    /// </summary>
    public partial class EffectiveNetworkSecurityGroupAssociation
    {
        /// <summary>
        /// Initializes a new instance of the
        /// EffectiveNetworkSecurityGroupAssociation class.
        /// </summary>
        public EffectiveNetworkSecurityGroupAssociation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// EffectiveNetworkSecurityGroupAssociation class.
        /// </summary>
        /// <param name="subnet">The ID of the subnet if assigned.</param>
        /// <param name="networkInterface">The ID of the network interface if
        /// assigned.</param>
        public EffectiveNetworkSecurityGroupAssociation(Management.ResourceManager.Fluent.SubResource subnet = default(Management.ResourceManager.Fluent.SubResource), Management.ResourceManager.Fluent.SubResource networkInterface = default(Management.ResourceManager.Fluent.SubResource))
        {
            Subnet = subnet;
            NetworkInterface = networkInterface;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of the subnet if assigned.
        /// </summary>
        [JsonProperty(PropertyName = "subnet")]
        public Management.ResourceManager.Fluent.SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets the ID of the network interface if assigned.
        /// </summary>
        [JsonProperty(PropertyName = "networkInterface")]
        public Management.ResourceManager.Fluent.SubResource NetworkInterface { get; set; }

    }
}
