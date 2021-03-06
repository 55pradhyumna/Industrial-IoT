// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Registry.Models {
    using Microsoft.Azure.IIoT.OpcUa.Core.Models;
    using Microsoft.Azure.IIoT.Hub;
    using Microsoft.Azure.IIoT.Hub.Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Discoverer registration extensions
    /// </summary>
    public static class DiscovererRegistrationEx {

        /// <summary>
        /// Create device twin
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static DeviceTwinModel ToDeviceTwin(this DiscovererRegistration registration) {
            return Patch(null, registration);
        }

        /// <summary>
        /// Create patch twin model to upload
        /// </summary>
        /// <param name="existing"></param>
        /// <param name="update"></param>
        public static DeviceTwinModel Patch(this DiscovererRegistration existing,
            DiscovererRegistration update) {

            var twin = new DeviceTwinModel {
                Etag = existing?.Etag,
                Tags = new Dictionary<string, JToken>(),
                Properties = new TwinPropertiesModel {
                    Desired = new Dictionary<string, JToken>()
                }
            };

            // Tags

            if (update?.IsDisabled != null && update.IsDisabled != existing?.IsDisabled) {
                twin.Tags.Add(nameof(DiscovererRegistration.IsDisabled), (update?.IsDisabled ?? false) ?
                    true : (bool?)null);
                twin.Tags.Add(nameof(DiscovererRegistration.NotSeenSince), (update?.IsDisabled ?? false) ?
                    DateTime.UtcNow : (DateTime?)null);
            }

            if (update?.SiteOrGatewayId != existing?.SiteOrGatewayId) {
                twin.Tags.Add(nameof(DiscovererRegistration.SiteOrGatewayId),
                    update?.SiteOrGatewayId);
            }

            var policiesUpdate = update?.SecurityPoliciesFilter.DecodeAsList().SequenceEqualsSafe(
                existing?.SecurityPoliciesFilter?.DecodeAsList());
            if (!(policiesUpdate ?? true)) {
                twin.Tags.Add(nameof(DiscovererRegistration.SecurityPoliciesFilter),
                    update?.SecurityPoliciesFilter == null ?
                    null : JToken.FromObject(update.SecurityPoliciesFilter));
            }

            var trustListUpdate = update?.TrustListsFilter.DecodeAsList().SequenceEqualsSafe(
                existing?.TrustListsFilter?.DecodeAsList());
            if (!(trustListUpdate ?? true)) {
                twin.Tags.Add(nameof(DiscovererRegistration.TrustListsFilter),
                    update?.TrustListsFilter == null ?
                    null : JToken.FromObject(update.TrustListsFilter));
            }

            if (update?.SecurityModeFilter != existing?.SecurityModeFilter) {
                twin.Tags.Add(nameof(DiscovererRegistration.SecurityModeFilter),
                    update?.SecurityModeFilter == null ?
                    null : JToken.FromObject(update?.SecurityModeFilter));
            }

            // Settings

            var urlUpdate = update?.DiscoveryUrls.DecodeAsList().SequenceEqualsSafe(
                existing?.DiscoveryUrls?.DecodeAsList());
            if (!(urlUpdate ?? true)) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.DiscoveryUrls),
                    update?.DiscoveryUrls == null ?
                    null : JToken.FromObject(update.DiscoveryUrls));
            }

            var localesUpdate = update?.Locales?.DecodeAsList()?.SequenceEqualsSafe(
                existing?.Locales?.DecodeAsList());
            if (!(localesUpdate ?? true)) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.Locales),
                    update?.Locales == null ?
                    null : JToken.FromObject(update.Locales));
            }

            if (update?.Discovery != existing?.Discovery) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.Discovery),
                    JToken.FromObject(update?.Discovery));
            }

            if (update?.AddressRangesToScan != existing?.AddressRangesToScan) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.AddressRangesToScan),
                    update?.AddressRangesToScan);
            }

            if (update?.NetworkProbeTimeout != existing?.NetworkProbeTimeout) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.NetworkProbeTimeout),
                    update?.NetworkProbeTimeout);
            }

            if (update?.LogLevel != existing?.LogLevel) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.LogLevel),
                    update?.LogLevel == null ?
                    null : JToken.FromObject(update.LogLevel));
            }

            if (update?.MaxNetworkProbes != existing?.MaxNetworkProbes) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.MaxNetworkProbes),
                    update?.MaxNetworkProbes);
            }

            if (update?.PortRangesToScan != existing?.PortRangesToScan) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.PortRangesToScan),
                    update?.PortRangesToScan);
            }

            if (update?.PortProbeTimeout != existing?.PortProbeTimeout) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.PortProbeTimeout),
                    update?.PortProbeTimeout);
            }

            if (update?.MaxPortProbes != existing?.MaxPortProbes) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.MaxPortProbes),
                    update?.MaxPortProbes);
            }

            if (update?.IdleTimeBetweenScans != existing?.IdleTimeBetweenScans) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.IdleTimeBetweenScans),
                    update?.IdleTimeBetweenScans);
            }

            if (update?.MinPortProbesPercent != existing?.MinPortProbesPercent) {
                twin.Properties.Desired.Add(nameof(DiscovererRegistration.MinPortProbesPercent),
                    update?.MinPortProbesPercent);
            }

            if (update?.SiteId != existing?.SiteId) {
                twin.Properties.Desired.Add(TwinProperty.SiteId, update?.SiteId);
            }

            twin.Tags.Add(nameof(DiscovererRegistration.DeviceType), update?.DeviceType);
            twin.Id = update?.DeviceId ?? existing?.DeviceId;
            twin.ModuleId = update?.ModuleId ?? existing?.ModuleId;
            return twin;
        }

        /// <summary>
        /// Decode tags and property into registration object
        /// </summary>
        /// <param name="twin"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static DiscovererRegistration ToDiscovererRegistration(this DeviceTwinModel twin,
            Dictionary<string, JToken> properties) {
            if (twin == null) {
                return null;
            }

            var tags = twin.Tags ?? new Dictionary<string, JToken>();
            var connected = twin.IsConnected();

            var registration = new DiscovererRegistration {
                // Device

                DeviceId = twin.Id,
                ModuleId = twin.ModuleId,
                Etag = twin.Etag,

                // Tags

                IsDisabled =
                    tags.GetValueOrDefault<bool>(nameof(DiscovererRegistration.IsDisabled), null),
                NotSeenSince =
                    tags.GetValueOrDefault<DateTime>(nameof(DiscovererRegistration.NotSeenSince), null),
                SecurityModeFilter =
                    tags.GetValueOrDefault<SecurityMode>(nameof(DiscovererRegistration.SecurityModeFilter), null),
                SecurityPoliciesFilter =
                    tags.GetValueOrDefault<Dictionary<string, string>>(nameof(DiscovererRegistration.SecurityPoliciesFilter), null),
                TrustListsFilter =
                    tags.GetValueOrDefault<Dictionary<string, string>>(nameof(DiscovererRegistration.TrustListsFilter), null),

                // Properties

                LogLevel =
                    properties.GetValueOrDefault<TraceLogLevel>(nameof(DiscovererRegistration.LogLevel), null),
                Discovery =
                    properties.GetValueOrDefault(nameof(DiscovererRegistration.Discovery), DiscoveryMode.Off),
                AddressRangesToScan =
                    properties.GetValueOrDefault<string>(nameof(DiscovererRegistration.AddressRangesToScan), null),
                NetworkProbeTimeout =
                    properties.GetValueOrDefault<TimeSpan>(nameof(DiscovererRegistration.NetworkProbeTimeout), null),
                MaxNetworkProbes =
                    properties.GetValueOrDefault<int>(nameof(DiscovererRegistration.MaxNetworkProbes), null),
                PortRangesToScan =
                    properties.GetValueOrDefault<string>(nameof(DiscovererRegistration.PortRangesToScan), null),
                PortProbeTimeout =
                    properties.GetValueOrDefault<TimeSpan>(nameof(DiscovererRegistration.PortProbeTimeout), null),
                MaxPortProbes =
                    properties.GetValueOrDefault<int>(nameof(DiscovererRegistration.MaxPortProbes), null),
                MinPortProbesPercent =
                    properties.GetValueOrDefault<int>(nameof(DiscovererRegistration.MinPortProbesPercent), null),
                IdleTimeBetweenScans =
                    properties.GetValueOrDefault<TimeSpan>(nameof(DiscovererRegistration.IdleTimeBetweenScans), null),
                DiscoveryUrls =
                    properties.GetValueOrDefault<Dictionary<string, string>>(nameof(DiscovererRegistration.DiscoveryUrls), null),
                Locales =
                    properties.GetValueOrDefault<Dictionary<string, string>>(nameof(DiscovererRegistration.Locales), null),

                SiteId =
                    properties.GetValueOrDefault<string>(TwinProperty.SiteId, null),
                Connected = connected ??
                    properties.GetValueOrDefault(TwinProperty.Connected, false),
                Type =
                    properties.GetValueOrDefault<string>(TwinProperty.Type, null)
            };
            return registration;
        }

        /// <summary>
        /// Get discoverer registration from twin
        /// </summary>
        /// <param name="twin"></param>
        /// <param name="onlyServerState"></param>
        /// <returns></returns>
        public static DiscovererRegistration ToDiscovererRegistration(this DeviceTwinModel twin,
            bool onlyServerState) {
            return ToDiscovererRegistration(twin, onlyServerState, out var tmp);
        }

        /// <summary>
        /// Make sure to get the registration information from the right place.
        /// Reported (truth) properties take precedence over desired. However,
        /// if there is nothing reported, it means the endpoint is not currently
        /// serviced, thus we use desired as if they are attributes of the
        /// endpoint.
        /// </summary>
        /// <param name="twin"></param>
        /// <param name="onlyServerState">Only desired endpoint should be returned
        /// this means that you will look at stale information.</param>
        /// <param name="connected"></param>
        /// <returns></returns>
        public static DiscovererRegistration ToDiscovererRegistration(this DeviceTwinModel twin,
            bool onlyServerState, out bool connected) {

            if (twin == null) {
                connected = false;
                return null;
            }
            if (twin.Tags == null) {
                twin.Tags = new Dictionary<string, JToken>();
            }

            var consolidated =
                ToDiscovererRegistration(twin, twin.GetConsolidatedProperties());
            var desired = (twin.Properties?.Desired == null) ? null :
                ToDiscovererRegistration(twin, twin.Properties.Desired);

            connected = consolidated.Connected;
            if (desired != null) {
                desired.Connected = connected;
                if (desired.SiteId == null && consolidated.SiteId != null) {
                    // Not set by user, but by config, so fake user desiring it.
                    desired.SiteId = consolidated.SiteId;
                }
                if (desired.LogLevel == null && consolidated.LogLevel != null) {
                    // Not set by user, but reported, so set as desired
                    desired.LogLevel = consolidated.LogLevel;
                }
            }

            if (!onlyServerState) {
                consolidated._isInSync = consolidated.IsInSyncWith(desired);
                return consolidated;
            }
            if (desired != null) {
                desired._isInSync = desired.IsInSyncWith(consolidated);
            }
            return desired;
        }

        /// <summary>
        /// Patch this registration and create patch twin model to upload
        /// </summary>
        /// <param name="model"></param>
        /// <param name="disabled"></param>
        public static DiscovererRegistration ToDiscovererRegistration(
            this DiscovererModel model, bool? disabled = null) {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }
            var deviceId = DiscovererModelEx.ParseDeviceId(model.Id,
                out var moduleId);
            return new DiscovererRegistration {
                IsDisabled = disabled,
                DeviceId = deviceId,
                ModuleId = moduleId,
                LogLevel = model.LogLevel,
                Discovery = model.Discovery ?? DiscoveryMode.Off,
                AddressRangesToScan = model.DiscoveryConfig?.AddressRangesToScan,
                NetworkProbeTimeout = model.DiscoveryConfig?.NetworkProbeTimeout,
                MaxNetworkProbes = model.DiscoveryConfig?.MaxNetworkProbes,
                PortRangesToScan = model.DiscoveryConfig?.PortRangesToScan,
                PortProbeTimeout = model.DiscoveryConfig?.PortProbeTimeout,
                MaxPortProbes = model.DiscoveryConfig?.MaxPortProbes,
                IdleTimeBetweenScans = model.DiscoveryConfig?.IdleTimeBetweenScans,
                MinPortProbesPercent = model.DiscoveryConfig?.MinPortProbesPercent,
                SecurityModeFilter = model.DiscoveryConfig?.ActivationFilter?.
                    SecurityMode,
                TrustListsFilter = model.DiscoveryConfig?.ActivationFilter?.
                    TrustLists.EncodeAsDictionary(),
                SecurityPoliciesFilter = model.DiscoveryConfig?.ActivationFilter?.
                    SecurityPolicies.EncodeAsDictionary(),
                DiscoveryUrls = model.DiscoveryConfig?.DiscoveryUrls?.
                    EncodeAsDictionary(),
                Locales = model.DiscoveryConfig?.Locales?.
                    EncodeAsDictionary(),
                Connected = model.Connected ?? false,
                SiteId = model.SiteId,
            };
        }

        /// <summary>
        /// Convert to service model
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static DiscovererModel ToServiceModel(this DiscovererRegistration registration) {
            return new DiscovererModel {
                Discovery = registration.Discovery != DiscoveryMode.Off ?
                    registration.Discovery : (DiscoveryMode?)null,
                Id = DiscovererModelEx.CreateDiscovererId(registration.DeviceId, registration.ModuleId),
                SiteId = registration.SiteId,
                LogLevel = registration.LogLevel,
                DiscoveryConfig = registration.ToConfigModel(),
                Connected = registration.IsConnected() ? true : (bool?)null,
                OutOfSync = registration.IsConnected() && !registration._isInSync ? true : (bool?)null
            };
        }


        /// <summary>
        /// Returns if no discovery config specified
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        private static bool IsNullConfig(this DiscovererRegistration registration) {
            if (string.IsNullOrEmpty(registration.AddressRangesToScan) &&
                string.IsNullOrEmpty(registration.PortRangesToScan) &&
                registration.MaxNetworkProbes == null &&
                registration.NetworkProbeTimeout == null &&
                registration.MaxPortProbes == null &&
                registration.MinPortProbesPercent == null &&
                registration.PortProbeTimeout == null &&
                (registration.DiscoveryUrls == null || registration.DiscoveryUrls.Count == 0) &&
                (registration.Locales == null || registration.Locales.Count == 0) &&
                registration.IdleTimeBetweenScans == null) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns config model
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        private static DiscoveryConfigModel ToConfigModel(this DiscovererRegistration registration) {
            return registration.IsNullConfig() ? null : new DiscoveryConfigModel {
                AddressRangesToScan = registration.AddressRangesToScan,
                PortRangesToScan = registration.PortRangesToScan,
                MaxNetworkProbes = registration.MaxNetworkProbes,
                NetworkProbeTimeout = registration.NetworkProbeTimeout,
                MaxPortProbes = registration.MaxPortProbes,
                MinPortProbesPercent = registration.MinPortProbesPercent,
                PortProbeTimeout = registration.PortProbeTimeout,
                IdleTimeBetweenScans = registration.IdleTimeBetweenScans,
                DiscoveryUrls = registration.DiscoveryUrls?.DecodeAsList(),
                Locales = registration.Locales?.DecodeAsList(),
                ActivationFilter = registration.ToFilterModel()
            };
        }

        /// <summary>
        /// Returns if no activation filter specified
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        private static bool IsNullFilter(this DiscovererRegistration registration) {
            if (registration.SecurityModeFilter == null &&
                (registration.TrustListsFilter == null || registration.TrustListsFilter.Count == 0) &&
                (registration.SecurityPoliciesFilter == null || registration.SecurityPoliciesFilter.Count == 0)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns activation filter model
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        private static EndpointActivationFilterModel ToFilterModel(this DiscovererRegistration registration) {
            return registration.IsNullFilter() ? null : new EndpointActivationFilterModel {
                SecurityMode = registration.SecurityModeFilter,
                SecurityPolicies = registration.SecurityPoliciesFilter.DecodeAsList(),
                TrustLists = registration.TrustListsFilter.DecodeAsList()
            };
        }


        /// <summary>
        /// Flag twin as synchronized - i.e. it matches the other.
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="other"></param>
        internal static bool IsInSyncWith(this DiscovererRegistration registration,
            DiscovererRegistration other) {
            return
                other != null &&
                registration.SiteId == other.SiteId &&
                registration.LogLevel == other.LogLevel &&
                registration.Discovery == other.Discovery &&
                registration.AddressRangesToScan == other.AddressRangesToScan &&
                registration.PortRangesToScan == other.PortRangesToScan &&
                registration.MaxNetworkProbes == other.MaxNetworkProbes &&
                registration.NetworkProbeTimeout == other.NetworkProbeTimeout &&
                registration.MaxPortProbes == other.MaxPortProbes &&
                registration.MinPortProbesPercent == other.MinPortProbesPercent &&
                registration.PortProbeTimeout == other.PortProbeTimeout &&
                registration.IdleTimeBetweenScans == other.IdleTimeBetweenScans &&
                registration.DiscoveryUrls.DecodeAsList().SequenceEqualsSafe(
                    other.DiscoveryUrls.DecodeAsList()) &&
                registration.Locales.DecodeAsList().SequenceEqualsSafe(
                    other.Locales.DecodeAsList());
        }
    }
}
