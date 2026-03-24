
# InventoryAPI

A .NET 8 REST API for inventory management with PostgreSQL and Docker.

## Stack
- **C# / .NET 8** — Web API with Entity Framework Core
- **PostgreSQL** — Relational persistence with indexed lookups
- **Docker Compose** — Multi-container local environment
- **xUnit** — Unit tests with in-memory database

## Run
```bash
docker-compose up --build
```
API available at `http://localhost:8080/swagger`

## Endpoints
| Method | Route            | Description       |
|--------|------------------|-------------------|
| GET    | /api/items       | List all items    |
| GET    | /api/items/{id}  | Get item by ID    |
| POST   | /api/items       | Create item       |
| PUT    | /api/items/{id}  | Update item       |
| DELETE | /api/items/{id}  | Delete item       |

## Tests
```bash
dotnet test
```
