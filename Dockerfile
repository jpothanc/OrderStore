# Use the official .NET 6.0 SDK image as the base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY . /app

WORKDIR /app

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnetcore:6.0

#COPY --from=0 /app/out .
# Copy the published application from the build container to the runtime container
COPY --from=build /app/OrderStore/out ./OrderStore  # Replace YourModule with the actual module name


ENTRYPOINT ["dotnet", "OrderStore.dll"]