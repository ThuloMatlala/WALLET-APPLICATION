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
8. [Dockerization](#dockerization)
9. [Conclusion](#conclusion)

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

### Running with docker

1. Clone the repository:

   ```bash
   git clone https://github.com/yourcompany/wallet-app.git
   cd WALLET-APPLICATION
   ```
2. Start utility services:

   With a docker deamon (I used Docker Desktop running) please run these from the project root where the docker-compose.yml file is lcoated

   ```bash
   docker-compose -f docker-compose-utilities.yml up
   ```
3. Run create tables using SQL IDE and connection string

- ```
  "Server=azure-sql-edge,1433;Initial Catalog=account_db; User ID=sa;Password=Str#ng_Passw#rd;Persist Security Info=False;Encrypt=False"
  ```
- Go the the *Sql* folder and run the *createTables* script

  5. Start Wallet App services:

  With a docker deamon (I used Docker Desktop running) please run these from the project root where the docker-compose.yml file is lcoated
- ```
  docker-compose -f docker-compose-wallet-app.yml up
  ```

## API Endpoints

### User Registration

Endpoint: `POST /api/authorization/Register`

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
  "message": "User registered successfully."
}
```

### User Login

Endpoint: `POST /api/authorization/login`

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

Endpoint: `GET /api/Account/{id}/transactions`

**Requires Authorization - using bearer token from login**

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

Endpoint: `GET /api/account/{id}/balance`

Requires Authorization - using bearer token from login

Response:

```json
{
  "balance": 500
}
```

### Credit Account

Endpoint: `POST /api/account/{id}/credit`

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

Endpoint: `POST /api/account/{id}/debit`

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

1. Account Management Service
2. Gateway

## Messaging Queue

A messaging queue, such as RabbitMQ, is used for communication between microservices. This ensures loose coupling and asynchronous processing.

Endpoint: `POST /api/Event`

Request body :

```{
{
  "event": "account.credited",
  "message" : {
    "transactionType": "credit",
    "amount" : 10.00
  }
}
```

Response body :

```{
{  
"message" : "Message published"
}
```

###### Events

- account.credited
- account.debited

## Persistence

Azure-sql was leveraged for data storage with Entityramework as the object relational mapper.

## Dockerization

Docker containers are used to ensure consistent deployment across different environments.

Containers :

- azure sql edge
- Rabbitmq
- thulomaepaa/bas-identity-service
- thulomaepaa/bas-account-management-service
