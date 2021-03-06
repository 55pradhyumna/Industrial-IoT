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
 * Application info model
 *
 */
class ApplicationInfoApiModel {
  /**
   * Create a ApplicationInfoApiModel.
   * @property {string} [applicationId] Unique application id
   * @property {string} [applicationType] Possible values include: 'Server',
   * 'Client', 'ClientAndServer', 'DiscoveryServer'
   * @property {string} [applicationUri] Unique application uri
   * @property {string} [productUri] Product uri
   * @property {string} [applicationName] Default name of application
   * @property {string} [locale] Locale of default name - defaults to "en"
   * @property {object} [localizedNames] Localized Names of application keyed
   * on locale
   * @property {buffer} [certificate] Application public cert
   * @property {array} [capabilities] The capabilities advertised by the
   * server.
   * @property {array} [discoveryUrls] Discovery urls of the server
   * @property {string} [discoveryProfileUri] Discovery profile uri
   * @property {string} [gatewayServerUri] Gateway server uri
   * @property {array} [hostAddresses] Host addresses of server application or
   * null
   * @property {string} [siteId] Site of the application
   * @property {string} [discovererId] Discoverer that registered the
   * application
   * @property {date} [notSeenSince] Last time application was seen
   * @property {object} [created]
   * @property {string} [created.authorityId] Operation User
   * @property {date} [created.time] Operation time
   * @property {object} [updated]
   * @property {string} [updated.authorityId] Operation User
   * @property {date} [updated.time] Operation time
   */
  constructor() {
  }

  /**
   * Defines the metadata of ApplicationInfoApiModel
   *
   * @returns {object} metadata of ApplicationInfoApiModel
   *
   */
  mapper() {
    return {
      required: false,
      serializedName: 'ApplicationInfoApiModel',
      type: {
        name: 'Composite',
        className: 'ApplicationInfoApiModel',
        modelProperties: {
          applicationId: {
            required: false,
            serializedName: 'applicationId',
            type: {
              name: 'String'
            }
          },
          applicationType: {
            required: false,
            serializedName: 'applicationType',
            type: {
              name: 'Enum',
              allowedValues: [ 'Server', 'Client', 'ClientAndServer', 'DiscoveryServer' ]
            }
          },
          applicationUri: {
            required: false,
            serializedName: 'applicationUri',
            type: {
              name: 'String'
            }
          },
          productUri: {
            required: false,
            serializedName: 'productUri',
            type: {
              name: 'String'
            }
          },
          applicationName: {
            required: false,
            serializedName: 'applicationName',
            type: {
              name: 'String'
            }
          },
          locale: {
            required: false,
            serializedName: 'locale',
            type: {
              name: 'String'
            }
          },
          localizedNames: {
            required: false,
            serializedName: 'localizedNames',
            type: {
              name: 'Dictionary',
              value: {
                  required: false,
                  serializedName: 'StringElementType',
                  type: {
                    name: 'String'
                  }
              }
            }
          },
          certificate: {
            required: false,
            serializedName: 'certificate',
            type: {
              name: 'ByteArray'
            }
          },
          capabilities: {
            required: false,
            serializedName: 'capabilities',
            constraints: {
              UniqueItems: true
            },
            type: {
              name: 'Sequence',
              element: {
                  required: false,
                  serializedName: 'StringElementType',
                  type: {
                    name: 'String'
                  }
              }
            }
          },
          discoveryUrls: {
            required: false,
            serializedName: 'discoveryUrls',
            constraints: {
              UniqueItems: true
            },
            type: {
              name: 'Sequence',
              element: {
                  required: false,
                  serializedName: 'StringElementType',
                  type: {
                    name: 'String'
                  }
              }
            }
          },
          discoveryProfileUri: {
            required: false,
            serializedName: 'discoveryProfileUri',
            type: {
              name: 'String'
            }
          },
          gatewayServerUri: {
            required: false,
            serializedName: 'gatewayServerUri',
            type: {
              name: 'String'
            }
          },
          hostAddresses: {
            required: false,
            serializedName: 'hostAddresses',
            constraints: {
              UniqueItems: true
            },
            type: {
              name: 'Sequence',
              element: {
                  required: false,
                  serializedName: 'StringElementType',
                  type: {
                    name: 'String'
                  }
              }
            }
          },
          siteId: {
            required: false,
            serializedName: 'siteId',
            type: {
              name: 'String'
            }
          },
          discovererId: {
            required: false,
            serializedName: 'discovererId',
            type: {
              name: 'String'
            }
          },
          notSeenSince: {
            required: false,
            serializedName: 'notSeenSince',
            type: {
              name: 'DateTime'
            }
          },
          created: {
            required: false,
            serializedName: 'created',
            type: {
              name: 'Composite',
              className: 'RegistryOperationApiModel'
            }
          },
          updated: {
            required: false,
            serializedName: 'updated',
            type: {
              name: 'Composite',
              className: 'RegistryOperationApiModel'
            }
          }
        }
      }
    };
  }
}

module.exports = ApplicationInfoApiModel;
