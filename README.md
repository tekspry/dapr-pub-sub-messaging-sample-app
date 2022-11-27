# Dapr Service Invocation Sample Application

This application is intended to demonstrate the basics of using Dapr Pub/ Sub building block for distributed application. It is a demo project for blog series Demystifying Dapr, by Gagan Bajaj.

This version of the code is using Dapr 1.9

## Running the app development environment

**Prerequisites:** We need to have the [Dapr CLI installed](https://docs.dapr.io/getting-started/install-dapr-cli/), as well as Docker installed (e.g. Docker Desktop for Windows), and to have set up dapr in self-hosted mode with `dapr init`

Open five terminal windows. In the `ecom.product.service` folder run `start-product-app.ps1`, inside `ecom.order.service` folder run `start-order-app.ps1`, inside `ecom.payment.service` folder run `start-payment-app.ps1`, inside `ecom.notification.service` folder run `start-notification-app.ps1` and also run `npm start` in ecom.spa react app. The ports used are specified in the PowerShell start up scripts. The product service app will be available at `http://localhost:5016/`, order service app will be available at `http://localhost:5206/`, payment service app will be available at `http://localhost:5293/` and notification service app will be available at `http://localhost:5294/` . Their swagger links will be at `http://localhost:5016/swagger/index.html`, `http://localhost:5206/swagger/index.html`, `http://localhost:5293/swagger/index.html`and `http://localhost:5294/swagger/index.html`, and the frontend app is available at `http://localhost:3000`
