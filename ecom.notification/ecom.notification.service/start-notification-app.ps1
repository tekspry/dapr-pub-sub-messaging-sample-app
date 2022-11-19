dapr run `
    --app-id payment `
    --app-port 5294 `
    --dapr-http-port 3504 `
    --components-path ../dapr/components `
    dotnet run