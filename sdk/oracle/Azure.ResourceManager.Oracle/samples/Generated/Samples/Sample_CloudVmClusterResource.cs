// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Oracle;
using Azure.ResourceManager.Oracle.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Oracle.Samples
{
    public partial class Sample_CloudVmClusterResource
    {
        // List VM Clusters by subscription
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetCloudVmClusters_ListVMClustersBySubscription()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_listBySubscription.json
            // this example is just showing the usage of "CloudVmClusters_ListBySubscription" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this SubscriptionResource created on azure
            // for more information of creating SubscriptionResource, please refer to the document of SubscriptionResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource subscriptionResource = client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the operation and iterate over the result
            await foreach (CloudVmClusterResource item in subscriptionResource.GetCloudVmClustersAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                CloudVmClusterData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Get VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_GetVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_get.json
            // this example is just showing the usage of "CloudVmClusters_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            CloudVmClusterResource result = await cloudVmCluster.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CloudVmClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Patch VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_PatchVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_patch.json
            // this example is just showing the usage of "CloudVmClusters_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            CloudVmClusterPatch patch = new CloudVmClusterPatch();
            ArmOperation<CloudVmClusterResource> lro = await cloudVmCluster.UpdateAsync(WaitUntil.Completed, patch);
            CloudVmClusterResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CloudVmClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Delete VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_DeleteVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_delete.json
            // this example is just showing the usage of "CloudVmClusters_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            await cloudVmCluster.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Succeeded");
        }

        // Add VMs to VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task AddVms_AddVMsToVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_addVms.json
            // this example is just showing the usage of "CloudVmClusters_AddVms" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            AddRemoveDbNode body = new AddRemoveDbNode(new string[]
            {
"ocid1..aaaa","ocid1..aaaaaa"
            });
            ArmOperation<CloudVmClusterResource> lro = await cloudVmCluster.AddVmsAsync(WaitUntil.Completed, body);
            CloudVmClusterResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CloudVmClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // List Private IP Addresses for VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetPrivateIPAddresses_ListPrivateIPAddressesForVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_listPrivateIpAddresses.json
            // this example is just showing the usage of "CloudVmClusters_ListPrivateIpAddresses" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation and iterate over the result
            PrivateIPAddressesFilter body = new PrivateIPAddressesFilter("ocid1..aaaaaa", "ocid1..aaaaa");
            await foreach (PrivateIPAddressProperties item in cloudVmCluster.GetPrivateIPAddressesAsync(body))
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine($"Succeeded");
        }

        // Remove VMs from VM Cluster
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task RemoveVms_RemoveVMsFromVMCluster()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/vmClusters_removeVms.json
            // this example is just showing the usage of "CloudVmClusters_RemoveVms" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            AddRemoveDbNode body = new AddRemoveDbNode(new string[]
            {
"ocid1..aaaa"
            });
            ArmOperation<CloudVmClusterResource> lro = await cloudVmCluster.RemoveVmsAsync(WaitUntil.Completed, body);
            CloudVmClusterResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CloudVmClusterData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // Create Virtual Network Address
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdateVirtualNetworkAddress_CreateVirtualNetworkAddress()
        {
            // Generated from example definition: specification/oracle/resource-manager/Oracle.Database/preview/2023-09-01-preview/examples/virtualNetworkAddresses_create.json
            // this example is just showing the usage of "VirtualNetworkAddresses_CreateOrUpdate" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CloudVmClusterResource created on azure
            // for more information of creating CloudVmClusterResource, please refer to the document of CloudVmClusterResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "rg000";
            string cloudvmclustername = "cluster1";
            ResourceIdentifier cloudVmClusterResourceId = CloudVmClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, cloudvmclustername);
            CloudVmClusterResource cloudVmCluster = client.GetCloudVmClusterResource(cloudVmClusterResourceId);

            // invoke the operation
            string virtualnetworkaddressname = "hosname1";
            VirtualNetworkAddress resource = new VirtualNetworkAddress()
            {
                IPAddress = "192.168.0.1",
                VmOcid = "ocid1..aaaa",
            };
            ArmOperation<VirtualNetworkAddress> lro = await cloudVmCluster.CreateOrUpdateVirtualNetworkAddressAsync(WaitUntil.Completed, virtualnetworkaddressname, resource);
            VirtualNetworkAddress result = lro.Value;

            Console.WriteLine($"Succeeded: {result}");
        }
    }
}
