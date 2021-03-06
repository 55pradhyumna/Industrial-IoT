/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package com.microsoft.azure.iiot.opc.publisher.models;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Publish request.
 */
public class PublishStartRequestApiModel {
    /**
     * The item property.
     */
    @JsonProperty(value = "item", required = true)
    private PublishedItemApiModel item;

    /**
     * The headerProperty property.
     */
    @JsonProperty(value = "header")
    private RequestHeaderApiModel headerProperty;

    /**
     * Get the item value.
     *
     * @return the item value
     */
    public PublishedItemApiModel item() {
        return this.item;
    }

    /**
     * Set the item value.
     *
     * @param item the item value to set
     * @return the PublishStartRequestApiModel object itself.
     */
    public PublishStartRequestApiModel withItem(PublishedItemApiModel item) {
        this.item = item;
        return this;
    }

    /**
     * Get the headerProperty value.
     *
     * @return the headerProperty value
     */
    public RequestHeaderApiModel headerProperty() {
        return this.headerProperty;
    }

    /**
     * Set the headerProperty value.
     *
     * @param headerProperty the headerProperty value to set
     * @return the PublishStartRequestApiModel object itself.
     */
    public PublishStartRequestApiModel withHeaderProperty(RequestHeaderApiModel headerProperty) {
        this.headerProperty = headerProperty;
        return this;
    }

}
