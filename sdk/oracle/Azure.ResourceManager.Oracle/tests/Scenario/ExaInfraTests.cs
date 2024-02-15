// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Oracle.Models;
using System;

namespace Azure.ResourceManager.Oracle.Tests.Scenario
{
    [TestFixture]
    public class ExaInfraTests : OracleManagementTestBase
    {
        public ExaInfraTests() : base(true)
        {
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback){
                await CreateCommonClient();
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }
        [TestCase]
        public async Task TestExaInfraOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            await TryRegisterResourceGroupAsync(ResourceGroupsOperations, "eastus", resourceGroupName);
            CloudExadataInfrastructureCollection cloudExadataInfrastructureCollection = await GetCloudExadataInfrastructureCollectionAsync(resourceGroupName);
            var cloudExadataInfrastructureName = Recording.GenerateAssetName("OFake_SdkExadata");
            CloudExadataInfrastructureData exadataInfrastructureData = GetDefaultCloudExadataInfrastructureData(cloudExadataInfrastructureName);

            // Create
            var createExadataOperation = await cloudExadataInfrastructureCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            cloudExadataInfrastructureName, exadataInfrastructureData);
            await createExadataOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExadataOperation.HasCompleted);
            Assert.IsTrue(createExadataOperation.HasValue);

            // Get
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            CloudExadataInfrastructureResource exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);

            // ListByResourceGroup
            AsyncPageable<CloudExadataInfrastructureResource> exaInfras = cloudExadataInfrastructureCollection.GetAllAsync();
            List<CloudExadataInfrastructureResource> exaInfraResult = await exaInfras.ToEnumerableAsync();
            Assert.NotNull(exaInfraResult);
            Assert.IsTrue(exaInfraResult.Count >= 1);

            // ListBySubscription
            exaInfras = OracleExtensions.GetCloudExadataInfrastructuresAsync(DefaultSubscription);
            exaInfraResult = await exaInfras.ToEnumerableAsync();
            Assert.NotNull(exaInfraResult);
            Assert.IsTrue(exaInfraResult.Count >= 1);

            // Update, not implemented
            var tagName = Recording.GenerateAssetName("TagName");
            var tagValue = Recording.GenerateAssetName("TagValue");
            ChangeTrackingDictionary<string, string> tags = new ChangeTrackingDictionary<string, string>
            {
                new KeyValuePair<string, string>(tagName, tagValue)
            };
            CloudExadataInfrastructurePatch exaInfraParameter = new() {
                Tags = tags
            };
            var updateExaInfraOpreration = await exaInfraResource.UpdateAsync(WaitUntil.Completed, exaInfraParameter);
            Assert.IsTrue(updateExaInfraOpreration.HasCompleted);
            Assert.IsTrue(updateExaInfraOpreration.HasValue);

            // Get
            getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);
            Assert.IsTrue(exaInfraResource.Data.Tags.ContainsKey(tagName));

            // Delete
            var deleteExaInfraOperation = await exaInfraResource.DeleteAsync(WaitUntil.Completed);
            await deleteExaInfraOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteExaInfraOperation.HasCompleted);
        }
    }
}