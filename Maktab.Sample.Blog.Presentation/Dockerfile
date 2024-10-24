FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Maktab.Sample.Blog.Presentation/Maktab.Sample.Blog.Presentation.csproj", "Maktab.Sample.Blog.Presentation/"]
RUN dotnet restore "Maktab.Sample.Blog.Presentation/Maktab.Sample.Blog.Presentation.csproj"
COPY . .
WORKDIR "/src/Maktab.Sample.Blog.Presentation"
RUN dotnet build "Maktab.Sample.Blog.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Maktab.Sample.Blog.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maktab.Sample.Blog.Presentation.dll"]
