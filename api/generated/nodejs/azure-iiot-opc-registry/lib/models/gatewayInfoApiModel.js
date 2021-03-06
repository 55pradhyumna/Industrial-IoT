/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

'use strict';

/**
 * Gateway info model
 *
 */
class GatewayInfoApiModel {
  /**
   * Create a GatewayInfoApiModel.
   * @property {object} gateway
   * @property {string} [gateway.id] Gateway id
   * @property {string} [gateway.siteId] Site of the Gateway
   * @property {boolean} [gateway.connected] Whether Gateway is connected on
   * this registration
   * @property {object} [modules]
   * @property {object} [modules.supervisor]
   * @property {string} [modules.supervisor.id] Supervisor id
   * @property {string} [modules.supervisor.siteId] Site of the supervisor
   * @property {buffer} [modules.supervisor.certificate] Supervisor public
   * client cert
   * @property {string} [modules.supervisor.logLevel] Possible values include:
   * 'Error', 'Information', 'Debug', 'Verbose'
   * @property {boolean} [modules.supervisor.outOfSync] Whether the
   * registration is out of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [modules.supervisor.connected] Whether supervisor is
   * connected on this registration
   * @property {object} [modules.publisher]
   * @property {string} [modules.publisher.id] Publisher id
   * @property {string} [modules.publisher.siteId] Site of the publisher
   * @property {buffer} [modules.publisher.certificate] Publisher public client
   * cert
   * @property {string} [modules.publisher.logLevel] Possible values include:
   * 'Error', 'Information', 'Debug', 'Verbose'
   * @property {object} [modules.publisher.configuration]
   * @property {object} [modules.publisher.configuration.capabilities]
   * Capabilities
   * @property {string} [modules.publisher.configuration.jobCheckInterval]
   * Interval to check job
   * @property {string} [modules.publisher.configuration.heartbeatInterval]
   * Heartbeat interval
   * @property {number} [modules.publisher.configuration.maxWorkers] Parallel
   * jobs
   * @property {string} [modules.publisher.configuration.jobOrchestratorUrl]
   * Job orchestrator endpoint url
   * @property {boolean} [modules.publisher.outOfSync] Whether the registration
   * is out of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [modules.publisher.connected] Whether publisher is
   * connected on this registration
   * @property {object} [modules.discoverer]
   * @property {string} [modules.discoverer.id] Discoverer id
   * @property {string} [modules.discoverer.siteId] Site of the discoverer
   * @property {string} [modules.discoverer.discovery] Possible values include:
   * 'Off', 'Local', 'Network', 'Fast', 'Scan'
   * @property {object} [modules.discoverer.discoveryConfig]
   * @property {string}
   * [modules.discoverer.discoveryConfig.addressRangesToScan] Address ranges to
   * scan (null == all wired nics)
   * @property {number}
   * [modules.discoverer.discoveryConfig.networkProbeTimeoutMs] Network probe
   * timeout
   * @property {number} [modules.discoverer.discoveryConfig.maxNetworkProbes]
   * Max network probes that should ever run.
   * @property {string} [modules.discoverer.discoveryConfig.portRangesToScan]
   * Port ranges to scan (null == all unassigned)
   * @property {number} [modules.discoverer.discoveryConfig.portProbeTimeoutMs]
   * Port probe timeout
   * @property {number} [modules.discoverer.discoveryConfig.maxPortProbes] Max
   * port probes that should ever run.
   * @property {number}
   * [modules.discoverer.discoveryConfig.minPortProbesPercent] Probes that must
   * always be there as percent of max.
   * @property {number}
   * [modules.discoverer.discoveryConfig.idleTimeBetweenScansSec] Delay time
   * between discovery sweeps in seconds
   * @property {array} [modules.discoverer.discoveryConfig.discoveryUrls] List
   * of preset discovery urls to use
   * @property {array} [modules.discoverer.discoveryConfig.locales] List of
   * locales to filter with during discovery
   * @property {object} [modules.discoverer.discoveryConfig.activationFilter]
   * @property {array}
   * [modules.discoverer.discoveryConfig.activationFilter.trustLists]
   * Certificate trust list identifiers to use for
   * activation, if null, all certificates are
   * trusted.  If empty list, no certificates are
   * trusted which is equal to no filter.
   * @property {array}
   * [modules.discoverer.discoveryConfig.activationFilter.securityPolicies]
   * Endpoint security policies to filter against.
   * If set to null, all policies are in scope.
   * @property {string}
   * [modules.discoverer.discoveryConfig.activationFilter.securityMode]
   * Possible values include: 'Best', 'Sign', 'SignAndEncrypt', 'None'
   * @property {string} [modules.discoverer.logLevel] Possible values include:
   * 'Error', 'Information', 'Debug', 'Verbose'
   * @property {boolean} [modules.discoverer.outOfSync] Whether the
   * registration is out of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [modules.discoverer.connected] Whether discoverer is
   * connected on this registration
   */
  constructor() {
  }

  /**
   * Defines the metadata of GatewayInfoApiModel
   *
   * @returns {object} metadata of GatewayInfoApiModel
   *
   */
  mapper() {
    return {
      required: false,
      serializedName: 'GatewayInfoApiModel',
      type: {
        name: 'Composite',
        className: 'GatewayInfoApiModel',
        modelProperties: {
          gateway: {
            required: true,
            serializedName: 'gateway',
            type: {
              name: 'Composite',
              className: 'GatewayApiModel'
            }
          },
          modules: {
            required: false,
            serializedName: 'modules',
            type: {
              name: 'Composite',
              className: 'GatewayModulesApiModel'
            }
          }
        }
      }
    };
  }
}

module.exports = GatewayInfoApiModel;
