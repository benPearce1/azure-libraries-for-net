// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersion.Update;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for GalleryImageVersion and its create and update interfaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uR2FsbGVyeUltYWdlVmVyc2lvbkltcGw=
    internal partial class GalleryImageVersionImpl  :
        CreatableUpdatable<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion,
            Models.GalleryImageVersionInner,
            Microsoft.Azure.Management.Compute.Fluent.GalleryImageVersionImpl,
            IHasId,
            IUpdate>,
        IGalleryImageVersion,
        IDefinition,
        IUpdate
    {
        private string galleryImageName;
        private string galleryImageVersionName;
        private string galleryName;
        private IComputeManager computeManager;
        private string resourceGroupName;

        ///GENMHASH:C5378B9EF2CBEA67609922A619C2EE9C:D736A936D9D3AF7AC6642FBDEA5B2EE8
        internal  GalleryImageVersionImpl(string name, IComputeManager manager) : base(name, new GalleryImageVersionInner())
        {
            this.computeManager = manager;
            // Set resource name
            this.galleryImageVersionName = name;
        }

        ///GENMHASH:142BF410A4E871AE35AD3B4F42DEEEED:297C906CC91021F0511221843025550B
        internal  GalleryImageVersionImpl(GalleryImageVersionInner inner, IComputeManager manager) : base(inner.Name, inner)
        {
            this.computeManager = manager;
            // Set resource name
            this.galleryImageVersionName = inner.Name;
            // resource ancestor names
            this.resourceGroupName = GetValueFromIdByName(inner.Id, "resourceGroups");
            this.galleryName = GetValueFromIdByName(inner.Id, "galleries");
            this.galleryImageName = GetValueFromIdByName(inner.Id, "images");
            this.galleryImageVersionName = GetValueFromIdByName(inner.Id, "versions");
        }


        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:0E64D352F7F18B753618D9C7E943FF2F
        protected override async Task<Models.GalleryImageVersionInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.computeManager.Inner.GalleryImageVersions;
            return await client.GetAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, this.galleryImageVersionName, null, cancellationToken);
        }


        ///GENMHASH:7224D46AA307534DE0BFEED82F17A1C0:B050247F6761F446EEF781F3F6E12C58
        public IReadOnlyList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> AvailableRegions()
        {
            List<Region> regions = new List<Region>();
            if (this.Inner.PublishingProfile != null && this.Inner.PublishingProfile.Regions != null)
            {
                foreach(var regionStr in this.Inner.PublishingProfile.Regions)
                {
                    regions.Add(Region.Create(regionStr));
                }
            }
            return regions;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:1441758C6DA19434093428FE9E67FD01
        public override async Task<Microsoft.Azure.Management.Compute.Fluent.IGalleryImageVersion> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.computeManager.Inner.GalleryImageVersions.CreateOrUpdateAsync(this.resourceGroupName, this.galleryName, this.galleryImageName, this.galleryImageVersionName, this.Inner, cancellationToken);
            this.SetInner(inner);
            return this;
        }
        string IHasId.Id => this.Id();

        ///GENMHASH:E6D1DF89668E0AD4124D23BB98631AC0:11071DC7E9F68A11693C2CE5E4B0817D
        public DateTime? EndOfLifeDate()
        {
            if (this.Inner.PublishingProfile != null)
            {
                return this.Inner.PublishingProfile.EndOfLifeDate;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:8A213FD8405F2C845603E47927811561:73FA06F95F38023C7F0F52EBCA2CE6A8
        public bool IsExcludedFromLatest()
        {
            if (this.Inner.PublishingProfile != null)
            {
                return this.Inner.PublishingProfile.ExcludeFromLatest.HasValue ? this.Inner.PublishingProfile.ExcludeFromLatest.Value : false;
            }
            else
            {
                return false;
            }
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return this.Inner.Id == null;
        }

        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:3054A3D10ED7865B89395E7C007419C9
        public string Location()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IComputeManager Manager()
        {
            return this.computeManager;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public ProvisioningState ProvisioningState()
        {
            return this.Inner.ProvisioningState;
        }

        ///GENMHASH:94605B6F0BD0CA263FCBB508411FFFF0:9C7D53C899E49C633159535D1CE81AFA
        public GalleryImageVersionPublishingProfile PublishingProfile()
        {
            return this.Inner.PublishingProfile;
        }

        ///GENMHASH:3B3B7C094794D032CE158EBC4B2D9E26:B578795A48F3DB8254E4AA001394F983
        public ReplicationStatus ReplicationStatus()
        {
            return this.Inner.ReplicationStatus;
        }

        ///GENMHASH:113FEBA4AFA08F6AEFAB8F0B2A7A5058:3A95C6D93DAFB975B40ACDDF0DEC7D1A
        public ScaleTier ScaleTier()
        {
            if (this.Inner.PublishingProfile != null)
            {
                return this.Inner.PublishingProfile.ScaleTier;
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:BBFAD2E04A2C1C43EB33356B7F7A2AD6
        public GalleryImageVersionStorageProfile StorageProfile()
        {
            return this.Inner.StorageProfile;
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:3E9F81F446FDF2A19095DC13C7608416
        public IReadOnlyDictionary<string,string> Tags()
        {
            if (this.Inner.Tags == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return this.Inner.Tags.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:A8C57DD59CCFD6D7F740DC7D7758EDC1:E38D778F0AAB48C77F9650E19784F982
        public GalleryImageVersionImpl WithRegionAvailability(Region region)
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            if (this.Inner.PublishingProfile.Regions == null)
            {
                this.Inner.PublishingProfile.Regions = new List<string>();
            }
            bool found = false;
            string newRegionName = region.ToString();
            string newRegionNameTrimmed = newRegionName.Replace(" ", "");
            foreach(var regionStr in this.Inner.PublishingProfile.Regions)
            {
                string regionStrTrimmed = regionStr.Replace(" ", "");
                if (regionStrTrimmed.Equals(newRegionNameTrimmed, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found) {
                this.Inner.PublishingProfile.Regions.Add(newRegionName);
            }
            //
            // Gallery image version publishing profile regions list must contain the location of image version.
            //
            found = false;
            string locationTrimmed = this.Location().Replace(" ", "");
            foreach(var regionStr in this.Inner.PublishingProfile.Regions)
            {
                string regionStrTrimmed = regionStr.Replace(" ", "");
                if (regionStrTrimmed.Equals(locationTrimmed, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.Inner.PublishingProfile.Regions.Add(this.Location());
            }
            return this;
        }

        ///GENMHASH:004D55E89630E9E1C10773DB1F52DE2A:3D6CB07F9B48FC2F0B29107958928ACA
        public GalleryImageVersionImpl WithRegionAvailability(IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region> regions)
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            this.Inner.PublishingProfile.Regions = new List<string>();
            foreach(var region in regions)
            {
                this.Inner.PublishingProfile.Regions.Add(region.ToString());
            }
            //
            // Gallery image version publishing profile regions list must contain the location of image version.
            //
            bool found = false;
            string locationTrimmed = this.Location().Replace(" ", "");
            foreach(var regionStr in this.Inner.PublishingProfile.Regions)
            {
                string regionStrTrimmed = regionStr.Replace(" ", "");
                if (regionStrTrimmed.Equals(locationTrimmed, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.Inner.PublishingProfile.Regions.Add(this.Location());
            }
            return this;
        }

        ///GENMHASH:6E6C9FDCE928A4707B0B6A71AD136F25:84E126212433336C4E79C8A357C377D0
        public GalleryImageVersionImpl WithEndOfLifeDate(DateTime endOfLifeDate)
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            this.Inner.PublishingProfile.EndOfLifeDate = endOfLifeDate;
            return this;
        }

        ///GENMHASH:BF488E3276CB8B89B14E096DD1E0A03D:A1C20098EC06F8A48E1A122A8A57D1C2
        public GalleryImageVersionImpl WithExcludedFromLatest()
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            this.Inner.PublishingProfile.ExcludeFromLatest = true;
            return this;
        }

        ///GENMHASH:E44BAAD9FCF6E90BDB254FB2BF0F955B:4DAE24848544A97BAD55DBF0D905537D
        public GalleryImageVersionImpl WithExistingImage(string resourceGroupName, string galleryName, string galleryImageName)
        {
            this.resourceGroupName = resourceGroupName;
            this.galleryName = galleryName;
            this.galleryImageName = galleryImageName;
            return this;
        }

        ///GENMHASH:C8421133DBC453BD76FCC9BC29C80FA1:E4BC2D6403FDE9DB36572C1A7DC24543
        public GalleryImageVersionImpl WithLocation(string location)
        {
            this.Inner.Location = location;
            return this;
        }

        ///GENMHASH:3E6A2E1842CF7045A3B0CF12AF9A85DA:8631322721E2C0858A3ABA04A72303A3
        public IWithSource WithLocation(Region location)
        {
            this.Inner.Location = location.ToString();
            return null;
        }

        ///GENMHASH:03B1F797E02E1089DCD5EB13134EB163:0206C7B1F86570DBFF6507721145FD4A
        public IUpdate WithoutRegionAvailability(Region region)
        {
            if (this.Inner.PublishingProfile != null && this.Inner.PublishingProfile.Regions != null)
            {
                int foundIndex = -1;
                int i = 0;
                string regionNameToRemove = region.ToString();
                string regionNameToRemoveTrimmed = regionNameToRemove.Replace(" ", "");
                //
                foreach(var regionStr in this.Inner.PublishingProfile.Regions)
                {
                    string regionStrTrimmed = regionStr.Replace(" ", "");
                    if (regionStrTrimmed.Equals(regionNameToRemoveTrimmed, StringComparison.OrdinalIgnoreCase))
                    {
                        foundIndex = i;
                        break;
                    }
                    i++;
                }
                if (foundIndex != -1)
                {
                    this.Inner.PublishingProfile.Regions.RemoveAt(foundIndex);
                }
            }
            return this;
        }

        ///GENMHASH:2CC9A7DBF22BF553CC24950FE9142D95:A2295791B01645BAE72C0F5E5698B4AB
        public GalleryImageVersionImpl WithoutExcludedFromLatest()
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            this.Inner.PublishingProfile.ExcludeFromLatest = false;
            return this;
        }

        ///GENMHASH:304AD2D7A1FC4F36A157B7EA318613BC:19B02B933C00208C5868287AA1C2AFFE
        public GalleryImageVersionImpl WithScaleTier(ScaleTier scaleTier)
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            this.Inner.PublishingProfile.ScaleTier = scaleTier;
            return this;
        }

        ///GENMHASH:CA5E9729D8A52829B6C1B261BAF80C9D:3DBA090410887CA497FAFE10B7C1E724
        public GalleryImageVersionImpl WithSourceCustomImage(string customImageId)
        {
            if (this.Inner.PublishingProfile == null)
            {
                this.Inner.PublishingProfile = new GalleryImageVersionPublishingProfile();
            }
            if (this.Inner.PublishingProfile.Source == null)
            {
                this.Inner.PublishingProfile.Source = new GalleryArtifactSource();
            }
            this.Inner.PublishingProfile.Source.ManagedImage = new ManagedArtifact()
            {
                Id = customImageId
            };
            return this;
        }

        ///GENMHASH:241ACB6281D149D09A2157D0A5B10B64:D8ACFED2D38DB0F51BD0ED4DB649ED5E
        public GalleryImageVersionImpl WithSourceCustomImage(IVirtualMachineCustomImage customImage)
        {
            return this.WithSourceCustomImage(customImage.Id);
        }

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:0A35F4FBFC584D98FAACCA25325781E8
        public GalleryImageVersionImpl WithTags(IDictionary<string,string> tags)
        {
            this.Inner.Tags = tags;
            return this;
        }

        ///GENMHASH:040C20433B133A485717B23B1FE2B123:C873BEE2B01DFD8C21B2393F5FD68243
        private static string GetValueFromIdByName(string id, string name)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                IEnumerable<string> enumerable = id.Split(new char[] { '/' });
                var itr = enumerable.GetEnumerator();
                while (itr.MoveNext())
                {
                    string part = itr.Current;
                    if (!string.IsNullOrEmpty(part))
                    {
                        if (part.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            if (itr.MoveNext())
                            {
                                return itr.Current;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                return null;
            }
        }
    }
}