// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Oracle.Tests.Scenario
{
    [TestFixture]
    public class DbSystemShapeTests : OracleManagementTestBase
    {
        public DbSystemShapeTests() : base(true)
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
        public async Task TestDbSystemShapeOperations()
        {
            // List By Location
            DbSystemShapeCollection dbSystemShapes = OracleExtensions.GetDbSystemShapes(DefaultSubscription, AzureLocation.EastUS);
            List<DbSystemShapeResource> dbSystemShapeResources = await dbSystemShapes.ToEnumerableAsync();
            Assert.NotNull(dbSystemShapeResources);
            Assert.IsTrue(dbSystemShapeResources.Count >= 1);
            Assert.AreEqual("Exadata.X9M", dbSystemShapeResources[0].Data.Name);

            // // Get
            // Response<DbSystemShapeResource> getDbSystemShapeResponse = await OracleExtensions.GetDbSystemShapeAsync(DefaultSubscription, AzureLocation.EastUS, "EXADATA.X9M");
            // DbSystemShapeResource dbSystemShapeResource = getDbSystemShapeResponse.Value;
            // Assert.IsNotNull(dbSystemShapeResource);
        }
    }
}