# FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build-env
# WORKDIR /app

# COPY *.csproj ./
# RUN dotnet restore

# COPY . ./
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# ENTRYPOINT [ "dotnet", "StudentManage.dll" ]

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StudentManage/StudentManage.csproj", "StudentManage/"]
RUN dotnet restore "StudentManage/StudentManage.csproj"
COPY . .
WORKDIR "/src/StudentManage"
RUN dotnet build "StudentManage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentManage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet StudentManage.dll