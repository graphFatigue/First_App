FROM mcr.microsoft.com/dotnet/aspnet:6.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 7266

ENV ASPNETCORE_URLS=http://+:7266

FROM mcr.microsoft.com/dotnet/sdk:6.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TaskBoard.API/TaskBoard.API.csproj", "TaskBoard.API/"]
COPY ["TaskBoard.Application/TaskBoard.Application.csproj", "TaskBoard.Application/"]
COPY ["TaskBoard.Infrastructure/TaskBoard.Infrastructure.csproj", "TaskBoard.Infrastructure/"]
COPY ["TaskBoard.Abstractions/TaskBoard.Abstractions.csproj", "TaskBoard.Abstractions/"]
COPY ["TaskBoard.Domain/TaskBoard.Domain.csproj", "TaskBoard.Domain/"]
COPY ["TaskBoard.Common/TaskBoard.Common.csproj", "TaskBoard.Common/"]
RUN dotnet restore "TaskBoard.API\TaskBoard.API.csproj"
COPY . .
WORKDIR "/src/TaskBoard.API"
RUN dotnet build "TaskBoard.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TaskBoard.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskBoard.API.dll"]
