#Prueba Técnica – .NET 8 y Angular 17

Este repositorio contiene una prueba técnica que consiste en desarrollar un Backend For Frontend (BFF) en .NET 8 y una aplicación frontend en Angular 17.
La solución consume la API pública de Rick and Morty, aplicando paginación, filtrado y una interfaz inspirada en plataformas de streaming.
Se utilizaron buenas prácticas, arquitectura en capas y funcionalidades modernas de Angular según lo solicitado en la pauta de la prueba.


Ejecución del proyecto
Backend (.NET 8)

Abrir una terminal en:

PruebaTecnicaCarsales/backend/


Ejecutar:

`dotnet restore`
 
`cd .\src\PruebaTecnicaCarsales.Api\`

`dotnet run`


Frontend (Angular 17)

Abrir una terminal en:

PruebaTecnicaCarsales/frontend/carsales-frontend/


Instalar dependencias:

`npm install`

Configurar puerto de ejecución en el archivo enviroment.ts
Ruta: src/enviroments/enviroment.ts

Cambiar port por el puerto de ejecución donde se estará ejecutando el backend.

Ejecutar la aplicación:

`ng serve`