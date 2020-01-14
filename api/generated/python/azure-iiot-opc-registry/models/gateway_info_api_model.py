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


class GatewayInfoApiModel(Model):
    """Gateway info model.

    :param gateway:
    :type gateway: ~azure-iiot-opc-registry.models.GatewayApiModel
    :param supervisor:
    :type supervisor: ~azure-iiot-opc-registry.models.SupervisorApiModel
    :param publisher:
    :type publisher: ~azure-iiot-opc-registry.models.PublisherApiModel
    :param discoverer:
    :type discoverer: ~azure-iiot-opc-registry.models.DiscovererApiModel
    """

    _validation = {
        'gateway': {'required': True},
    }

    _attribute_map = {
        'gateway': {'key': 'gateway', 'type': 'GatewayApiModel'},
        'supervisor': {'key': 'supervisor', 'type': 'SupervisorApiModel'},
        'publisher': {'key': 'publisher', 'type': 'PublisherApiModel'},
        'discoverer': {'key': 'discoverer', 'type': 'DiscovererApiModel'},
    }

    def __init__(self, gateway, supervisor=None, publisher=None, discoverer=None):
        super(GatewayInfoApiModel, self).__init__()
        self.gateway = gateway
        self.supervisor = supervisor
        self.publisher = publisher
        self.discoverer = discoverer