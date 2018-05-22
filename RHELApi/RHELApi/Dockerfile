FROM microsoft/aspnetcore:2.0 AS base
RUN useradd -u 1001 -r -g 100 -d /app -s /sbin/nologin \
    -c "Default Application User" default
WORKDIR /app
RUN chown -R 1001:100 /app
EXPOSE 8080

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY RHELApi.sln ./
COPY RHELApi/RHELApi.csproj RHELApi/
RUN dotnet restore -r linux-x64
COPY . .
WORKDIR /src/RHELApi
RUN dotnet build -c Release -o /app -r linux-x64

FROM build AS publish
RUN dotnet publish -c Release -o /app -r linux-x64

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RHELApi.dll"]
USER 1001
