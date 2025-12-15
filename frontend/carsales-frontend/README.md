# Prueba Técnica – .NET 8 & Angular

Este repositorio contiene una prueba técnica que implementa una arquitectura Backend For Frontend (BFF) utilizando .NET 8 y una aplicación frontend en Angular.  
La solución consume la API pública de Rick and Morty y permite listar episodios, buscar por nombre y visualizar el detalle de cada episodio junto con sus personajes.

## Tecnologías utilizadas
- .NET 8 (API REST – BFF)
- Angular (Standalone components, Signals)
- API pública Rick and Morty
- HTML, CSS puro (sin frameworks)

## Arquitectura
La solución está separada en capas para el backend:
- **Controllers**: Exponen los endpoints al frontend
- **Application / Services**: Contiene la lógica de negocio
- **Infrastructure**: Clientes HTTP y acceso a servicios externos
- **Domain**: Modelos y DTOs

El frontend está organizado por:
- **Pages**: Componentes de página
- **Components**: Componentes reutilizables (cards, modales, grids)
- **Services**: Comunicación con la API
- **Models**: Tipos y contratos

## Ejecución del Backend
Desde la carpeta raíz del backend:

```bash
cd backend
dotnet restore
dotnet run
