to run with docker use command: docker-compose up --build

to run without docker: 
1. change the connection string in appsettings.json to: User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=cards_db; (use your own data)
2. then in NuGet cli run command 'Update-Database' to apply migrations
3. run backend and client

![изображение](https://github.com/graphFatigue/First_App/assets/94828251/142233f4-8da3-4a47-bc86-2325260f2aa5)

