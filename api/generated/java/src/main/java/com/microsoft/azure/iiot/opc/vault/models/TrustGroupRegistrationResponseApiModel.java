/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package com.microsoft.azure.iiot.opc.vault.models;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Trust group registration response model.
 */
public class TrustGroupRegistrationResponseApiModel {
    /**
     * The id of the trust group.
     */
    @JsonProperty(value = "id")
    private String id;

    /**
     * Get the id of the trust group.
     *
     * @return the id value
     */
    public String id() {
        return this.id;
    }

    /**
     * Set the id of the trust group.
     *
     * @param id the id value to set
     * @return the TrustGroupRegistrationResponseApiModel object itself.
     */
    public TrustGroupRegistrationResponseApiModel withId(String id) {
        this.id = id;
        return this;
    }

}
