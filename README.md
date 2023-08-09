Wallet Application Developer Documentation

## Table of Contents

1. [Introduction](#introduction)
2. [Architecture Overview](#architecture-overview)
3. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Setting Up the Environment](#setting-up-the-environment)
4. [API Endpoints](#api-endpoints)
   - [User Registration](#user-registration)
   - [User Login](#user-login)
   - [Transaction History](#transaction-history)
   - [Account Balance](#account-balance)
   - [Credit Account](#credit-account)
   - [Debit Account](#debit-account)
5. [Authentication](#authentication)
6. [Microservices Architecture](#microservices-architecture)
7. [Messaging Queue](#messaging-queue)
8. [Redis Integration](#redis-integration)
9. [Angular Frontend](#angular-frontend)
10. [Dockerization](#dockerization)
11. [Third-Party API Integration](#third-party-api-integration)
12. [Conclusion](#conclusion)

## Introduction

This document serves as a guide for developers working on the implementation of the wallet application. The application aims to provide users with the ability to manage their accounts and perform transactions.

## Architecture Overview

The wallet application follows a microservices architecture to enhance scalability and maintainability. It consists of the following components:

- **C# API Endpoint**: Responsible for handling user interactions and account management.
- **Authentication**: Ensures secure access to user accounts.
- **Messaging Queue**: Facilitates communication between microservices.
- **Redis**: Acts as an in-memory caching solution for improved performance.
- **Angular Frontend**: Provides a visual interface for users to interact with their wallet accounts.
- **Dockerization**: Ensures consistent deployment across different environments.
- **Third-Party API Integration**: Allows account credit via third-party APIs.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org/)
- [Docker](https://www.docker.com/)

### Setting Up the Environment

1. Clone the repository:

   ```bash
   git clone https://github.com/yourcompany/wallet-app.git
   cd WALLET-APPLICATION
   ```
2. Build and run the C# API Endpoint:

   ```bash
   cd api
   dotnet restore
   dotnet run
   ```
3. Build and run the Angular Frontend:

   ```bash
   cd frontend
   npm install
   ng serve
   ```
4. Start containers/services:

   Please run these from the project root where the docker-compose.yml file is lcoated

   ```bash
   docker-compose up
   ```

## API Endpoints

### User Registration

Endpoint: `POST /api/users/register`

Request Body:

```json
{
  "username": "john_doe",
  "password": "P@ssw0rd",
}
```

Response:

```json
{
  "message": "User registered successfully."
}
```

### User Login

Endpoint: `POST /api/users/login`

Request Body:

```json
{
  "username": "john_doe",
  "password": "P@ssw0rd"
}
```

Response:

```json
{
  "token": "your_access_token"
}
```

### Transaction History

Endpoint: `GET /api/transactions`

Response:

```json
[
  {
    "id": 1,
    "type": "Credit",
    "amount": 100,
    "timestamp": "2023-08-15T12:00:00Z"
  },
  // ...
]
```

### Account Balance

Endpoint: `GET /api/account/balance`

Response:

```json
{
  "balance": 500
}
```

### Credit Account

Endpoint: `POST /api/account/credit`

Request Body:

```json
{
  "amount": 50
}
```

Response:

```json
{
  "message": "Account credited successfully."
}
```

### Debit Account

Endpoint: `POST /api/account/debit`

Request Body:

```json
{
  "amount": 30
}
```

Response:

```json
{
  "message": "Account debited successfully."
}
```

## Authentication

User authentication is implemented using JSON Web Tokens (JWT). The obtained token should be included in the `Authorization` header for protected API endpoints.

## Microservices Architecture

The application follows a microservices architecture to achieve modularity and scalability. Each microservice handles a specific set of functionalities.

## Messaging Queue

A messaging queue, such as RabbitMQ, is used for communication between microservices. This ensures loose coupling and asynchronous processing.

## Redis Integration

Redis is integrated as an in-memory caching solution to enhance performance and reduce database load.

## Angular Frontend

The Angular frontend provides users with a visual interface to interact with their wallet accounts, view transaction history, and perform account actions.

I've opted to use [Tailwind CCS](https://tailwindcss.com/docs/guides/angular) - it being a short-hand styling framework will help get styling done without thinking about it too much

## Dockerization

Docker containers are used to ensure consistent deployment across different environments. Containers include the C# API, Angular frontend,
