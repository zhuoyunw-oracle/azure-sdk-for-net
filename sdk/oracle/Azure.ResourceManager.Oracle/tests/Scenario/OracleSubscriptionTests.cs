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
    public class OracleSubscriptionTests : OracleManagementTestBase
    {
        public OracleSubscriptionTests() : base(true)
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
        public async Task TestOracleSubscriptionOperations()
        {
            // Get
            OracleSubscriptionResource oracleSubscriptionResource = OracleExtensions.GetOracleSubscription(DefaultSubscription);
            Response<OracleSubscriptionResource> getResponse = await oracleSubscriptionResource.GetAsync();
            OracleSubscriptionResource oracleSubscriptionResourceFromGet = getResponse.Value;
            Assert.IsNotNull(oracleSubscriptionResourceFromGet);
        }
    }
}