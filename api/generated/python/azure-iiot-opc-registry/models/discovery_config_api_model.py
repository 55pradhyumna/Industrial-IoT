# coding=utf-8
# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 2.3.33.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.
# --------------------------------------------------------------------------

from msrest.serialization import Model


class DiscoveryConfigApiModel(Model):
    """Discovery configuration api model.

    :param address_ranges_to_scan: Address ranges to scan (null == all wired
     nics)
    :type address_ranges_to_scan: str
    :param network_probe_timeout_ms: Network probe timeout
    :type network_probe_timeout_ms: int
    :param max_network_probes: Max network probes that should ever run.
    :type max_network_probes: int
    :param port_ranges_to_scan: Port ranges to scan (null == all unassigned)
    :type port_ranges_to_scan: str
    :param port_probe_timeout_ms: Port probe timeout
    :type port_probe_timeout_ms: int
    :param max_port_probes: Max port probes that should ever run.
    :type max_port_probes: int
    :param min_port_probes_percent: Probes that must always be there as
     percent of max.
    :type min_port_probes_percent: int
    :param idle_time_between_scans_sec: Delay time between discovery sweeps in
     seconds
    :type idle_time_between_scans_sec: int
    :param discovery_urls: List of preset discovery urls to use
    :type discovery_urls: list[str]
    :param locales: List of locales to filter with during discovery
    :type locales: list[str]
    :param activation_filter:
    :type activation_filter:
     ~azure-iiot-opc-registry.models.EndpointActivationFilterApiModel
    """

    _attribute_map = {
        'address_ranges_to_scan': {'key': 'addressRangesToScan', 'type': 'str'},
        'network_probe_timeout_ms': {'key': 'networkProbeTimeoutMs', 'type': 'int'},
        'max_network_probes': {'key': 'maxNetworkProbes', 'type': 'int'},
        'port_ranges_to_scan': {'key': 'portRangesToScan', 'type': 'str'},
        'port_probe_timeout_ms': {'key': 'portProbeTimeoutMs', 'type': 'int'},
        'max_port_probes': {'key': 'maxPortProbes', 'type': 'int'},
        'min_port_probes_percent': {'key': 'minPortProbesPercent', 'type': 'int'},
        'idle_time_between_scans_sec': {'key': 'idleTimeBetweenScansSec', 'type': 'int'},
        'discovery_urls': {'key': 'discoveryUrls', 'type': '[str]'},
        'locales': {'key': 'locales', 'type': '[str]'},
        'activation_filter': {'key': 'activationFilter', 'type': 'EndpointActivationFilterApiModel'},
    }

    def __init__(self, address_ranges_to_scan=None, network_probe_timeout_ms=None, max_network_probes=None, port_ranges_to_scan=None, port_probe_timeout_ms=None, max_port_probes=None, min_port_probes_percent=None, idle_time_between_scans_sec=None, discovery_urls=None, locales=None, activation_filter=None):
        super(DiscoveryConfigApiModel, self).__init__()
        self.address_ranges_to_scan = address_ranges_to_scan
        self.network_probe_timeout_ms = network_probe_timeout_ms
        self.max_network_probes = max_network_probes
        self.port_ranges_to_scan = port_ranges_to_scan
        self.port_probe_timeout_ms = port_probe_timeout_ms
        self.max_port_probes = max_port_probes
        self.min_port_probes_percent = min_port_probes_percent
        self.idle_time_between_scans_sec = idle_time_between_scans_sec
        self.discovery_urls = discovery_urls
        self.locales = locales
        self.activation_filter = activation_filter
