// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.PolicyInsights.Models
{
    /// <summary> The result of a check policy restrictions evaluation on a resource. </summary>
    public partial class CheckPolicyRestrictionsResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CheckPolicyRestrictionsResult"/>. </summary>
        internal CheckPolicyRestrictionsResult()
        {
            FieldRestrictions = new ChangeTrackingList<FieldRestrictions>();
        }

        /// <summary> Initializes a new instance of <see cref="CheckPolicyRestrictionsResult"/>. </summary>
        /// <param name="fieldRestrictions"> The restrictions that will be placed on various fields in the resource by policy. </param>
        /// <param name="contentEvaluationResult"> Evaluation results for the provided partial resource content. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CheckPolicyRestrictionsResult(IReadOnlyList<FieldRestrictions> fieldRestrictions, CheckRestrictionsResultContentEvaluationResult contentEvaluationResult, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FieldRestrictions = fieldRestrictions;
            ContentEvaluationResult = contentEvaluationResult;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The restrictions that will be placed on various fields in the resource by policy. </summary>
        public IReadOnlyList<FieldRestrictions> FieldRestrictions { get; }
        /// <summary> Evaluation results for the provided partial resource content. </summary>
        internal CheckRestrictionsResultContentEvaluationResult ContentEvaluationResult { get; }
        /// <summary> Policy evaluation results against the given resource content. This will indicate if the partial content that was provided will be denied as-is. </summary>
        public IReadOnlyList<PolicyEvaluationResult> PolicyEvaluations
        {
            get => ContentEvaluationResult?.PolicyEvaluations;
        }
    }
}
