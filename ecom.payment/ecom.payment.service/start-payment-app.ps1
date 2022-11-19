dapr run `
    --app-id payment `
    --app-port 5293 `
    --dapr-http-port 3503 `
    --components-path ../dapr/components `
    dotnet run