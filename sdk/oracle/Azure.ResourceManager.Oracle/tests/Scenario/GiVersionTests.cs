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
            AsyncPageable<GiVersion> giVersionListResponse = OracleExtensions.GetGiVersionsByLocationAsync(DefaultSubscription, AzureLocation.EastUS);
            List<GiVersion> giVersions = await giVersionListResponse.ToEnumerableAsync();
            Assert.NotNull(giVersions);
            Assert.IsTrue(giVersions.Count >= 1);
            Assert.AreEqual("19.0.0.0", giVersions[0].Name);
        }
    }
}