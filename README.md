# Dapr Service Invocation Sample Application

This application is intended to demonstrate the basics of using Dapr service invocation block for distributed application. It is a demo project for my blog series Demystifying Dapr, by Gagan Bajaj.

This version of the code is using Dapr 1.7

## Running the app development environment

**Prerequisites:** We need to have the [Dapr CLI installed](https://docs.dapr.io/getting-started/install-dapr-cli/), as well as Docker installed (e.g. Docker Desktop for Windows), and to have set up dapr in self-hosted mode with `dapr init`

Open two terminal windows. In the `ecom.product.service` folder run `start-product-app.ps1`, inside `ecom.order.service` folder run `start-order-app.ps1` and also run `npm start` in ecom.spa react app. The ports used are specified in the PowerShell start up scripts. The product service app will be available at `http://localhost:5016/` and order service app will be available at `http://localhost:5206/`. Their swagger links will be at `http://localhost:5016/swagger/index.html` and `http://localhost:5206/swagger/index.html`, and the frontend app is available at `http://localhost:3000`
