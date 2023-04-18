# Getting Started with eShopModular (API)

## Run the project

In the project directory `server/Api`, you can run:

### `dotnet run`

The app is listening to:\
`https://localhost:5011`
`http://localhost:5012`

#### Domains
There are two main domains in this project
- Order
- Product

Within the solution the code is organized based on the above domains.

#### Notes
`MediatR` is used to support loose coupling.

#### Docker Compose
 
First of all change the connection string. Use this `Data Source=eshop.db` for data source.

`cd docker`

`docker-compose up`

Docker compose will start the following containers:
- `eshop.api` http://localhost:5012
- `eshop.ui` http://localhost:3000
- `eshop.db`
- `eshop.seq` http://localhost:5342

