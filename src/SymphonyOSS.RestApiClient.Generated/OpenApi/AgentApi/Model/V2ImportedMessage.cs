﻿// Licensed to the Symphony Software Foundation (SSF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The SSF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
/* 
 * Agent API
 *
 * This document refers to Symphony API calls to send and receive messages and content. They need the on-premise Agent installed to perform decryption/encryption of content.  - sessionToken and keyManagerToken can be obtained by calling the authenticationAPI on the symphony back end and the key manager respectively. Refer to the methods described in authenticatorAPI.yaml. - Actions are defined to be atomic, ie will succeed in their entirety or fail and have changed nothing. - If it returns a 40X status then it will have sent no message to any stream even if a request to aome subset of the requested streams would have succeeded. - If this contract cannot be met for any reason then this is an error and the response code will be 50X. - MessageML is a markup language for messages. See reference here: https://developers.symphony.com/documentation/message_format_reference 
 *
 * OpenAPI spec version: current
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SymphonyOSS.RestApiClient.Generated.OpenApi.AgentApi.Model
{
    /// <summary>
    /// A historic message to be imported into the system. The importing user must have the Content Management role. Also, the importing user must be a member of the conversation it is importing into. The user that the message is intended to have come from must also be present in the conversation. The intended message timestamp must be a valid time from the past. It cannot be a future timestamp. By design, imported messages do not stream to datafeed or firehose endpoints. 
    /// </summary>
    [DataContract]
    public partial class V2ImportedMessage :  IEquatable<V2ImportedMessage>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatEnum
        {
            
            /// <summary>
            /// Enum TEXT for "TEXT"
            /// </summary>
            [EnumMember(Value = "TEXT")]
            TEXT,
            
            /// <summary>
            /// Enum MESSAGEML for "MESSAGEML"
            /// </summary>
            [EnumMember(Value = "MESSAGEML")]
            MESSAGEML
        }

        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name="format", EmitDefaultValue=false)]
        public FormatEnum? Format { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="V2ImportedMessage" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected V2ImportedMessage() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="V2ImportedMessage" /> class.
        /// </summary>
        /// <param name="Message">Message text in MessageML (required).</param>
        /// <param name="Format">Format.</param>
        /// <param name="IntendedMessageTimestamp">The timestamp representing the time when the message was sent in the original system in milliseconds since Jan 1st 1970.  (required).</param>
        /// <param name="IntendedMessageFromUserId">The long integer userid of the Symphony user who you intend to show sent the message.  (required).</param>
        /// <param name="OriginatingSystemId">The ID of the system through which the message was originally sent.  (required).</param>
        /// <param name="OriginalMessageId">The ID of the message in the original system. .</param>
        /// <param name="StreamId">StreamId (required).</param>
        public V2ImportedMessage(string Message = default(string), FormatEnum? Format = default(FormatEnum?), long? IntendedMessageTimestamp = default(long?), long? IntendedMessageFromUserId = default(long?), string OriginatingSystemId = default(string), string OriginalMessageId = default(string), string StreamId = default(string))
        {
            // to ensure "Message" is required (not null)
            if (Message == null)
            {
                throw new InvalidDataException("Message is a required property for V2ImportedMessage and cannot be null");
            }
            else
            {
                this.Message = Message;
            }
            // to ensure "IntendedMessageTimestamp" is required (not null)
            if (IntendedMessageTimestamp == null)
            {
                throw new InvalidDataException("IntendedMessageTimestamp is a required property for V2ImportedMessage and cannot be null");
            }
            else
            {
                this.IntendedMessageTimestamp = IntendedMessageTimestamp;
            }
            // to ensure "IntendedMessageFromUserId" is required (not null)
            if (IntendedMessageFromUserId == null)
            {
                throw new InvalidDataException("IntendedMessageFromUserId is a required property for V2ImportedMessage and cannot be null");
            }
            else
            {
                this.IntendedMessageFromUserId = IntendedMessageFromUserId;
            }
            // to ensure "OriginatingSystemId" is required (not null)
            if (OriginatingSystemId == null)
            {
                throw new InvalidDataException("OriginatingSystemId is a required property for V2ImportedMessage and cannot be null");
            }
            else
            {
                this.OriginatingSystemId = OriginatingSystemId;
            }
            // to ensure "StreamId" is required (not null)
            if (StreamId == null)
            {
                throw new InvalidDataException("StreamId is a required property for V2ImportedMessage and cannot be null");
            }
            else
            {
                this.StreamId = StreamId;
            }
            this.Format = Format;
            this.OriginalMessageId = OriginalMessageId;
        }
        
        /// <summary>
        /// Message text in MessageML
        /// </summary>
        /// <value>Message text in MessageML</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }
        /// <summary>
        /// The timestamp representing the time when the message was sent in the original system in milliseconds since Jan 1st 1970. 
        /// </summary>
        /// <value>The timestamp representing the time when the message was sent in the original system in milliseconds since Jan 1st 1970. </value>
        [DataMember(Name="intendedMessageTimestamp", EmitDefaultValue=false)]
        public long? IntendedMessageTimestamp { get; set; }
        /// <summary>
        /// The long integer userid of the Symphony user who you intend to show sent the message. 
        /// </summary>
        /// <value>The long integer userid of the Symphony user who you intend to show sent the message. </value>
        [DataMember(Name="intendedMessageFromUserId", EmitDefaultValue=false)]
        public long? IntendedMessageFromUserId { get; set; }
        /// <summary>
        /// The ID of the system through which the message was originally sent. 
        /// </summary>
        /// <value>The ID of the system through which the message was originally sent. </value>
        [DataMember(Name="originatingSystemId", EmitDefaultValue=false)]
        public string OriginatingSystemId { get; set; }
        /// <summary>
        /// The ID of the message in the original system. 
        /// </summary>
        /// <value>The ID of the message in the original system. </value>
        [DataMember(Name="originalMessageId", EmitDefaultValue=false)]
        public string OriginalMessageId { get; set; }
        /// <summary>
        /// Gets or Sets StreamId
        /// </summary>
        [DataMember(Name="streamId", EmitDefaultValue=false)]
        public string StreamId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class V2ImportedMessage {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  IntendedMessageTimestamp: ").Append(IntendedMessageTimestamp).Append("\n");
            sb.Append("  IntendedMessageFromUserId: ").Append(IntendedMessageFromUserId).Append("\n");
            sb.Append("  OriginatingSystemId: ").Append(OriginatingSystemId).Append("\n");
            sb.Append("  OriginalMessageId: ").Append(OriginalMessageId).Append("\n");
            sb.Append("  StreamId: ").Append(StreamId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as V2ImportedMessage);
        }

        /// <summary>
        /// Returns true if V2ImportedMessage instances are equal
        /// </summary>
        /// <param name="other">Instance of V2ImportedMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(V2ImportedMessage other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Message == other.Message ||
                    this.Message != null &&
                    this.Message.Equals(other.Message)
                ) && 
                (
                    this.Format == other.Format ||
                    this.Format != null &&
                    this.Format.Equals(other.Format)
                ) && 
                (
                    this.IntendedMessageTimestamp == other.IntendedMessageTimestamp ||
                    this.IntendedMessageTimestamp != null &&
                    this.IntendedMessageTimestamp.Equals(other.IntendedMessageTimestamp)
                ) && 
                (
                    this.IntendedMessageFromUserId == other.IntendedMessageFromUserId ||
                    this.IntendedMessageFromUserId != null &&
                    this.IntendedMessageFromUserId.Equals(other.IntendedMessageFromUserId)
                ) && 
                (
                    this.OriginatingSystemId == other.OriginatingSystemId ||
                    this.OriginatingSystemId != null &&
                    this.OriginatingSystemId.Equals(other.OriginatingSystemId)
                ) && 
                (
                    this.OriginalMessageId == other.OriginalMessageId ||
                    this.OriginalMessageId != null &&
                    this.OriginalMessageId.Equals(other.OriginalMessageId)
                ) && 
                (
                    this.StreamId == other.StreamId ||
                    this.StreamId != null &&
                    this.StreamId.Equals(other.StreamId)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Message != null)
                    hash = hash * 59 + this.Message.GetHashCode();
                if (this.Format != null)
                    hash = hash * 59 + this.Format.GetHashCode();
                if (this.IntendedMessageTimestamp != null)
                    hash = hash * 59 + this.IntendedMessageTimestamp.GetHashCode();
                if (this.IntendedMessageFromUserId != null)
                    hash = hash * 59 + this.IntendedMessageFromUserId.GetHashCode();
                if (this.OriginatingSystemId != null)
                    hash = hash * 59 + this.OriginatingSystemId.GetHashCode();
                if (this.OriginalMessageId != null)
                    hash = hash * 59 + this.OriginalMessageId.GetHashCode();
                if (this.StreamId != null)
                    hash = hash * 59 + this.StreamId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
