
cd Services\Consent\Consent.Actors
dapr run --dapr-http-port 3500 --app-id actors_instance --app-port 5010 dotnet run

cd Services\Consent\Consent.Api
dapr run --app-id blast_api --app-port 7276 --app-ssl dotnet run
