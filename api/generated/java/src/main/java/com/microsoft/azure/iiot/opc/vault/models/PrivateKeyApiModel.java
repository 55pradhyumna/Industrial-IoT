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
 * Private key.
 */
public class PrivateKeyApiModel {
    /**
     * Possible values include: 'RSA', 'ECC', 'AES'.
     */
    @JsonProperty(value = "kty")
    private PrivateKeyType kty;

    /**
     * RSA modulus.
     */
    @JsonProperty(value = "n")
    private byte[] n;

    /**
     * RSA public exponent, in Base64.
     */
    @JsonProperty(value = "e")
    private byte[] e;

    /**
     * RSA Private Key Parameter.
     */
    @JsonProperty(value = "dp")
    private byte[] dp;

    /**
     * RSA Private Key Parameter.
     */
    @JsonProperty(value = "dq")
    private byte[] dq;

    /**
     * RSA Private Key Parameter.
     */
    @JsonProperty(value = "qi")
    private byte[] qi;

    /**
     * RSA secret prime.
     */
    @JsonProperty(value = "p")
    private byte[] p;

    /**
     * RSA secret prime, with p &lt; q.
     */
    @JsonProperty(value = "q")
    private byte[] q;

    /**
     * The crv property.
     */
    @JsonProperty(value = "crv")
    private String crv;

    /**
     * X coordinate for the Elliptic Curve point.
     */
    @JsonProperty(value = "x")
    private byte[] x;

    /**
     * Y coordinate for the Elliptic Curve point.
     */
    @JsonProperty(value = "y")
    private byte[] y;

    /**
     * RSA private exponent or ECC private key.
     */
    @JsonProperty(value = "d")
    private byte[] d;

    /**
     * Symmetric key.
     */
    @JsonProperty(value = "k")
    private byte[] k;

    /**
     * The keyHsm property.
     */
    @JsonProperty(value = "key_hsm")
    private byte[] keyHsm;

    /**
     * Get possible values include: 'RSA', 'ECC', 'AES'.
     *
     * @return the kty value
     */
    public PrivateKeyType kty() {
        return this.kty;
    }

    /**
     * Set possible values include: 'RSA', 'ECC', 'AES'.
     *
     * @param kty the kty value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withKty(PrivateKeyType kty) {
        this.kty = kty;
        return this;
    }

    /**
     * Get rSA modulus.
     *
     * @return the n value
     */
    public byte[] n() {
        return this.n;
    }

    /**
     * Set rSA modulus.
     *
     * @param n the n value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withN(byte[] n) {
        this.n = n;
        return this;
    }

    /**
     * Get rSA public exponent, in Base64.
     *
     * @return the e value
     */
    public byte[] e() {
        return this.e;
    }

    /**
     * Set rSA public exponent, in Base64.
     *
     * @param e the e value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withE(byte[] e) {
        this.e = e;
        return this;
    }

    /**
     * Get rSA Private Key Parameter.
     *
     * @return the dp value
     */
    public byte[] dp() {
        return this.dp;
    }

    /**
     * Set rSA Private Key Parameter.
     *
     * @param dp the dp value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withDp(byte[] dp) {
        this.dp = dp;
        return this;
    }

    /**
     * Get rSA Private Key Parameter.
     *
     * @return the dq value
     */
    public byte[] dq() {
        return this.dq;
    }

    /**
     * Set rSA Private Key Parameter.
     *
     * @param dq the dq value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withDq(byte[] dq) {
        this.dq = dq;
        return this;
    }

    /**
     * Get rSA Private Key Parameter.
     *
     * @return the qi value
     */
    public byte[] qi() {
        return this.qi;
    }

    /**
     * Set rSA Private Key Parameter.
     *
     * @param qi the qi value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withQi(byte[] qi) {
        this.qi = qi;
        return this;
    }

    /**
     * Get rSA secret prime.
     *
     * @return the p value
     */
    public byte[] p() {
        return this.p;
    }

    /**
     * Set rSA secret prime.
     *
     * @param p the p value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withP(byte[] p) {
        this.p = p;
        return this;
    }

    /**
     * Get rSA secret prime, with p &lt; q.
     *
     * @return the q value
     */
    public byte[] q() {
        return this.q;
    }

    /**
     * Set rSA secret prime, with p &lt; q.
     *
     * @param q the q value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withQ(byte[] q) {
        this.q = q;
        return this;
    }

    /**
     * Get the crv value.
     *
     * @return the crv value
     */
    public String crv() {
        return this.crv;
    }

    /**
     * Set the crv value.
     *
     * @param crv the crv value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withCrv(String crv) {
        this.crv = crv;
        return this;
    }

    /**
     * Get x coordinate for the Elliptic Curve point.
     *
     * @return the x value
     */
    public byte[] x() {
        return this.x;
    }

    /**
     * Set x coordinate for the Elliptic Curve point.
     *
     * @param x the x value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withX(byte[] x) {
        this.x = x;
        return this;
    }

    /**
     * Get y coordinate for the Elliptic Curve point.
     *
     * @return the y value
     */
    public byte[] y() {
        return this.y;
    }

    /**
     * Set y coordinate for the Elliptic Curve point.
     *
     * @param y the y value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withY(byte[] y) {
        this.y = y;
        return this;
    }

    /**
     * Get rSA private exponent or ECC private key.
     *
     * @return the d value
     */
    public byte[] d() {
        return this.d;
    }

    /**
     * Set rSA private exponent or ECC private key.
     *
     * @param d the d value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withD(byte[] d) {
        this.d = d;
        return this;
    }

    /**
     * Get symmetric key.
     *
     * @return the k value
     */
    public byte[] k() {
        return this.k;
    }

    /**
     * Set symmetric key.
     *
     * @param k the k value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withK(byte[] k) {
        this.k = k;
        return this;
    }

    /**
     * Get the keyHsm value.
     *
     * @return the keyHsm value
     */
    public byte[] keyHsm() {
        return this.keyHsm;
    }

    /**
     * Set the keyHsm value.
     *
     * @param keyHsm the keyHsm value to set
     * @return the PrivateKeyApiModel object itself.
     */
    public PrivateKeyApiModel withKeyHsm(byte[] keyHsm) {
        this.keyHsm = keyHsm;
        return this;
    }

}
