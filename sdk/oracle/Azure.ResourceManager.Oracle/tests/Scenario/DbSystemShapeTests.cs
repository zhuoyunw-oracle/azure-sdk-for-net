// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.Oracle.Models;

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
            AsyncPageable<DbSystemShape> dbSystemShapeListResponse = OracleExtensions.GetDbSystemShapesByLocationAsync(DefaultSubscription, AzureLocation.EastUS);
            // DbSystemShapeCollection dbSystemShapes = OracleExtensions.GetDbSystemShapes(DefaultSubscription, AzureLocation.EastUS);
            List<DbSystemShape> dbSystemShapes = await dbSystemShapeListResponse.ToEnumerableAsync();
            Assert.NotNull(dbSystemShapes);
            Assert.IsTrue(dbSystemShapes.Count >= 1);
            Assert.AreEqual("Exadata.X9M", dbSystemShapes[0].Name);

            // // Get
            // Response<DbSystemShapeResource> getDbSystemShapeResponse = await OracleExtensions.GetDbSystemShapeAsync(DefaultSubscription, AzureLocation.EastUS, "EXADATA.X9M");
            // DbSystemShapeResource dbSystemShapeResource = getDbSystemShapeResponse.Value;
            // Assert.IsNotNull(dbSystemShapeResource);
        }
    }
}