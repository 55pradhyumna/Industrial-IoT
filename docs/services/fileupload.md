# File Upload event forwarder

[Home](readme.md)

## Overview

The file upload notification event forwarder listens for blob notification messages and demultiplexes them into individual blob processors.  It is a glue handler for IoT Hub notifications and Blob processors.

One of these blob processors is the [model processor](graph.md) service.
