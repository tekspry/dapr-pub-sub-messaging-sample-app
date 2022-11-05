dapr run `
    --app-id order `
    --app-port 5206 `
    --dapr-http-port 3502 `
    --components-path ../dapr/components `
    dotnet run