# Heavy WIP 

#### A little playground/training with concepts such as:
* configurable database connection string source (Appsettings or Azure KeyVault) through abstractions and a provider which returns the connection string with the consumer not knowing (or needing to care) where it's coming from **-> ✅ DONE**
* RBS - ordinary and admin user (admins can see and manage all TODOs), implementing RBS from scratch using JWT on frontend and backend 
* Database migration and versioning scripts - because this is a database-first project and no EF Core native migration/upgrade functionality is available
* Playing with Zustand for global state management in React - https://github.com/pmndrs/zustand
* *Big maybe* - Application Insights logging using `ILogger<T>`
* build-time PS/Bash scripts to ensure frontend assets are copied to the main API project output folder

### Tech Stack:
* NextJS 
* .NET 9 
* SQL server 
* Azure

### Some challenges and a tech overview



#### Proxying requests to API (local development only)

NextJS natively supports redirects and proxying - https://nextjs.org/docs/app/api-reference/config/next-config-js/redirects

This ensures all API requests can use a relative URL, instead of specifying an absolute path.

#### Serving a NextJS app in production

A NextJS SPA cannot simply be served as a static .html file with accompanying assets like a vanilla react app. It has its own routing and naming convention of various assets. This makes is fundamentally incompatible with .NET. It's intended to be served from a Node.JS server.

This nuget package solves that issue: https://github.com/davidnx/NextjsStaticHosting-AspNetCore \
All statically built assets are served from `/wwwroot` in the .Main project.

The frontend and backend thus live on the same URL - no cross-origin issues when deployed, and ensures all API requests can use the a relative URL without any issues.