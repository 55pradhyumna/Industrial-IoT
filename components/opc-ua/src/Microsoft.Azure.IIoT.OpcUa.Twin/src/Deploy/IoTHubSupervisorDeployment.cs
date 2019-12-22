// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Twin.Deploy {
    using Microsoft.Azure.IIoT.Hub;
    using Microsoft.Azure.IIoT.Hub.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Deploys twin module
    /// </summary>
    public sealed class IoTHubSupervisorDeployment : IHost {

        /// <summary>
        /// Create edge base deployer
        /// </summary>
        /// <param name="service"></param>
        public IoTHubSupervisorDeployment(IIoTHubConfigurationServices service) {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <inheritdoc/>
        public async Task StartAsync() {

            await _service.CreateOrUpdateConfigurationAsync(new ConfigurationModel {
                Id = "__default-opctwin-linux",
                Content = new ConfigurationContentModel {
                    ModulesContent = GetLayeredDeployment(true)
                },
                SchemaVersion = kDefaultSchemaVersion,
                TargetCondition = "tags.__type__ = 'gateway' AND tags.os = 'Linux'",
                Priority = 1
            }, true);

            await _service.CreateOrUpdateConfigurationAsync(new ConfigurationModel {
                Id = "__default-opctwin-windows",
                Content = new ConfigurationContentModel {
                    ModulesContent = GetLayeredDeployment(false)
                },
                SchemaVersion = kDefaultSchemaVersion,
                TargetCondition = "tags.__type__ = 'gateway' AND tags.os = 'Windows'",
                Priority = 1
            }, true);
        }

        /// <inheritdoc/>
        public Task StopAsync() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Get base edge configuration
        /// </summary>
        /// <param name="version"></param>
        /// <param name="isLinux"></param>
        /// <returns></returns>
        private IDictionary<string, IDictionary<string, object>> GetLayeredDeployment(
            bool isLinux, string version = "latest") {

            var registryCredentials = @"
                ""properties.desired.runtime.settings.registryCredentials.test"": {
                    ""address"": ""test"",
                    ""password"": ""test"",
                    ""username"": ""test""
                },
            ";
            registryCredentials = ""; // TODO

            // Configure create options per os specified
            string createOptions;
            if (isLinux) {
                // Linux
                createOptions = @"
                {
                    ""Hostname"": ""opctwin"",
                    ""Cmd"": [
                        ""AutoAccept=true""
                    ],
                    ""NetworkingConfig"":{
                        ""EndpointsConfig"": {
                            ""host"": {
                            }
                        }
                    },
                    ""HostConfig"": {
                        ""NetworkMode"": ""host"",
                        ""CapAdd"": [ ""NET_ADMIN"" ]
                    }
                }";
            }
            else {
                // Windows
                createOptions = @"
                {
                    ""Hostname"":""opctwin"",
                    ""Cmd"": [
                        ""PkiRootPath=\\mount\\pki"",
                        ""AutoAccept=true""
                    ],
                    ""NetworkingConfig"":{
                        ""EndpointsConfig"":{
                            ""host"":{
                            }
                        }
                    },
                    ""HostConfig"": {
                        ""NetworkMode"": ""host"",
                        ""CapAdd"": [ ""NET_ADMIN"" ],
                        ""Mounts"": [
                            {
                                ""Type"": ""bind"",
                                ""Source"": ""C:\\IoTEdgeMapping"",
                                ""Target"": ""C:\\mount""
                            }
                        ]
                    }
                }";
            }
            createOptions = JObject.Parse(createOptions).ToString(Formatting.None).Replace("\"", "\\\"");

            // Return deployment modules object
            var content = @"
            {
                ""$edgeAgent"": {
                    " + registryCredentials + @"
                    ""properties.desired.modules.twin"": {
                        ""settings"": {
                            ""image"": ""mcr.microsoft.com/iotedge/opc-twin:" + version + @""",
                            ""createOptions"": """ + createOptions + @"""
                        },
                        ""type"": ""docker"",
                        ""status"": ""running"",
                        ""restartPolicy"": ""always"",
                        ""version"": """ + (version == "latest" ? "1.0" : version) + @"""
                    }
                },
                ""$edgeHub"": {
                    ""properties.desired.routes.upstream"": ""FROM /messages/* INTO $upstream""
                }
            }";
            return JsonConvertEx.DeserializeObject<IDictionary<string, IDictionary<string, object>>>(content);
        }

        private const string kDefaultSchemaVersion = "1.0";
        private readonly IIoTHubConfigurationServices _service;
    }
}
