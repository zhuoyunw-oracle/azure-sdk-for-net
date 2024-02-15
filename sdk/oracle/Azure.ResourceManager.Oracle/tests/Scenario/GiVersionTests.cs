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
    public class GiVersionTests : OracleManagementTestBase
    {
        public GiVersionTests() : base(true)
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
        public async Task TestGiVersionOperations()
        {
            // List By Location
            GiVersionCollection giVersions = OracleExtensions.GetGiVersions(DefaultSubscription, AzureLocation.EastUS);
            List<GiVersionResource> giVersionResources = await giVersions.ToEnumerableAsync();
            Assert.NotNull(giVersionResources);
            Assert.IsTrue(giVersionResources.Count >= 1);
            Assert.AreEqual("19.0.0.0", giVersionResources[0].Data.Name);
        }
    }
}