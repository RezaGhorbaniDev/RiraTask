# Rira gRPC Api task

Thank you for the opportunity to present this project! This README outlines how to set up and test the gRPC API built
with ASP.NET Core.

---

## Overview

This project uses MongoDB for data persistence, AutoMapper for efficient object mapping, and includes custom middleware
to handle errors gracefully.

---

## Features

- **gRPC API**.
- **MongoDB Database**.
- **Custom Middleware** for centralized error handling.
- **AutoMapper** for seamless object mapping and data transformations.
- Built on **ASP.NET Core with .NET 8** for modern and robust development.

---

## Prerequisites

To run this project, ensure you have the following installed:

- **.NET 8 SDK**
- **MongoDB** (configured and running)
- **Postman** (for API testing)

---

## Running the Project

1. **Clone the Repository**
   ```bash
   git https://github.com/RezaGhorbaniDev/RiraTask.git
   cd <repository-folder>
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Update App Settings**
   Configure the MongoDB connection string in `appsettings.json`:
   ```json
   "MongoDbSettings": {
     "ConnectionString": "your-connection-string",
     "DatabaseName": "your-database-name"
   }
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```
   The gRPC server will start and listen for requests.

---

## Testing the API

### Using Postman

1. Download and install Postman from [here](https://www.postman.com/downloads/)
2. Open **Postman** and create a new gRPC request.
3. Enter the server address (e.g., `localhost:5001`).
4. Add the required method and message parameters in Postman’s gRPC interface.
5.Send the request and view the response.
