# Basket - ASP Core + Vue.js + webpack4

## Prerequisites

- [.NET Core SDK 2.1](https://www.microsoft.com/net/download) <small>(or higher)</small>
- [Node.js 8.11.4](https://nodejs.org/) <small>(or higher)</small>

## Install

1. Restore node dependencies:
```console
npm install
```
2. Run web application:

```console
dotnet run
```

## Some considerations

- For brevity ```TechBasket.DomainService``` project exposes services as a DLL reference
- In a real-world scenario they would most likely be Web APIs exposing different bounded contexts to the frontend 
- MVC is only used to provide the initial page. The rest of the ASP Core application is effectively an API gateway between Vue.js frontend and the services 