// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    /// <summary>
    /// The reserved eDTUs value range for a "Basic" edition of an Azure SQL Elastic Pool.
    /// </summary>
    public enum SqlElasticPoolBasicEDTUs : int
    {
        /** 50 eDTUs available to the pool. */
        eDTU_50 = 50,
        /** 100 eDTUs available to the pool. */
        eDTU_100 = 100,
        /** 200 eDTUs available to the pool. */
        eDTU_200 = 200,
        /** 400 eDTUs available to the pool. */
        eDTU_400 = 400,
        /** 800 eDTUs available to the pool. */
        eDTU_800 = 800,
        /** 1200 eDTUs available to the pool. */
        eDTU_1200 = 1200,
        /** 1600 eDTUs available to the pool. */
        eDTU_1600 = 1600
    }
}