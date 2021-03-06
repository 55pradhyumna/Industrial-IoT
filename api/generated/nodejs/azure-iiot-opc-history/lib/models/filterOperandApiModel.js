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
 * Filter operand
 *
 */
class FilterOperandApiModel {
  /**
   * Create a FilterOperandApiModel.
   * @property {number} [index] Element reference in the outer list if
   * operand is an element operand
   * @property {object} [value] Variant value if operand is a literal
   * @property {string} [nodeId] Type definition node id if operand is
   * simple or full attribute operand.
   * @property {array} [browsePath] Browse path of attribute operand
   * @property {string} [attributeId] Possible values include: 'NodeClass',
   * 'BrowseName', 'DisplayName', 'Description', 'WriteMask', 'UserWriteMask',
   * 'IsAbstract', 'Symmetric', 'InverseName', 'ContainsNoLoops',
   * 'EventNotifier', 'Value', 'DataType', 'ValueRank', 'ArrayDimensions',
   * 'AccessLevel', 'UserAccessLevel', 'MinimumSamplingInterval',
   * 'Historizing', 'Executable', 'UserExecutable', 'DataTypeDefinition',
   * 'RolePermissions', 'UserRolePermissions', 'AccessRestrictions'
   * @property {string} [indexRange] Index range of attribute operand
   * @property {string} [alias] Optional alias to refer to it makeing it a
   * full blown attribute operand
   */
  constructor() {
  }

  /**
   * Defines the metadata of FilterOperandApiModel
   *
   * @returns {object} metadata of FilterOperandApiModel
   *
   */
  mapper() {
    return {
      required: false,
      serializedName: 'FilterOperandApiModel',
      type: {
        name: 'Composite',
        className: 'FilterOperandApiModel',
        modelProperties: {
          index: {
            required: false,
            serializedName: 'index',
            type: {
              name: 'Number'
            }
          },
          value: {
            required: false,
            serializedName: 'value',
            type: {
              name: 'Object'
            }
          },
          nodeId: {
            required: false,
            serializedName: 'nodeId',
            type: {
              name: 'String'
            }
          },
          browsePath: {
            required: false,
            serializedName: 'browsePath',
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
          attributeId: {
            required: false,
            serializedName: 'attributeId',
            type: {
              name: 'Enum',
              allowedValues: [ 'NodeClass', 'BrowseName', 'DisplayName', 'Description', 'WriteMask', 'UserWriteMask', 'IsAbstract', 'Symmetric', 'InverseName', 'ContainsNoLoops', 'EventNotifier', 'Value', 'DataType', 'ValueRank', 'ArrayDimensions', 'AccessLevel', 'UserAccessLevel', 'MinimumSamplingInterval', 'Historizing', 'Executable', 'UserExecutable', 'DataTypeDefinition', 'RolePermissions', 'UserRolePermissions', 'AccessRestrictions' ]
            }
          },
          indexRange: {
            required: false,
            serializedName: 'indexRange',
            type: {
              name: 'String'
            }
          },
          alias: {
            required: false,
            serializedName: 'alias',
            type: {
              name: 'String'
            }
          }
        }
      }
    };
  }
}

module.exports = FilterOperandApiModel;
