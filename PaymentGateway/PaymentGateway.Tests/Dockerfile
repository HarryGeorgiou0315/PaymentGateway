FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./PaymentGateway.sln ./
COPY ./PaymentGateway/PaymentGateway.csproj ./PaymentGateway/
COPY ./PaymentGateway.Tests/PaymentGateway.Tests.csproj ./PaymentGateway.Tests/

RUN dotnet restore ./PaymentGateway/PaymentGateway.csproj
RUN dotnet restore ./PaymentGateway.Tests/PaymentGateway.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out PaymentGateway.Tests/PaymentGateway.Tests.csproj

CMD dotnet test

