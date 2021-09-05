# setup MSSql server
docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=kloia12345!@#$%' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU10-ubuntu-20.04

# connect to MSSql CLI
docker exec -it mssql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P kloia12345!@#$%

# create db for each microservices
create database Articles
go
create database Reviews
go

exit

# install EntityFramework globally
dotnet tool install --global dotnet-ef


# create migrations and update database
cd Services/Article/Src/ArticleService.Infrastructure/

dotnet ef migrations add initial

dotnet ef database update -c ArticleService.Infrastructure.Context.ArticleDbContext

cd ../../../../

cd Services/Review/Src/ReviewService.Infrastructure/

dotnet ef migrations add initial

dotnet ef database update -c ReviewService.Infrastructure.Context.ReviewDbContext

cd ../../../../

# build and run docker containers
cd Services/Article/Src/ArticleService.Api
docker build -t articlesImage .
docker run --name articleMicroservice -d -p 5001:80 articlesImage

cd ../../../../

cd Services/Review/Src/ReviewService.Api
docker build -t reviewsImage .
docker run --name reviewMicroservice -d -p 5011:80 reviewsImage