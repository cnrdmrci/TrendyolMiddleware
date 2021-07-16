#!/bin/bash

while getopts ":a:v:h" flag;
do
  case "${flag}" in
    a) apikey=${OPTARG};;
    v) version=${OPTARG};;
    h) echo "[-a apikey] | [-v version]";;
    \?) echo "Invalid option: -$OPTARG" 1>&2;;
    : ) echo "Invalid option: -$OPTARG requires an argument" 1>&2;;
  esac
done

echo "ApiKey: $apikey";
echo "Version: $version";
echo "Nuget package: Trendyol.Middleware.${version}.nupkg"

echo "Creating dotnet package"

dotnet publish -c release -f net5.0
dotnet publish -c release -f netcoreapp3.1
dotnet publish -c release -f netcoreapp2.2
dotnet publish -c release -f netcoreapp2.0

echo "Creating nuget package"

dotnet pack --configuration Release

echo "Push nuget"

dotnet nuget push ./src/bin/Release/Trendyol.TyMiddleware.${version}.nupkg --api-key ${apikey} --source https://api.nuget.org/v3/index.json
