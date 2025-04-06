# 🎟️ Event Scheduler – Microservices-Based Learning Project

**Event Scheduler** is a learning-oriented, microservices-based platform for managing events, tickets, feedback, and promo codes. The system simulates a real-world architecture using modern development practices like DDD, CQRS, gRPC, and service aggregation.

This project was built for educational purposes to explore distributed systems, service communication, and modular design with a focus on real business logic separation.

---

## 🧩 Architecture

The project consists of the following microservices:

### 🗂️ Events API
- Core service that manages event data
- Supports creation, editing, and deletion of events
- Events can have tags and categories
- Events have no physical location but can have multiple feedbacks
- Events can have one or multiple **promo codes** with limited usage and custom discount percentages
- Only the **event owner** can create promo codes
- Implements **DDD** (Domain-Driven Design), **CQRS**, and **MediatR**
- Uses **Redis** for caching event data
- Uses **MSSQL** as its database

### 🎫 Tickets API
- Handles ticket purchases
- Users can select multiple events and buy access to them in one purchase
- Applies promo code discounts through **gRPC call** to Promotions service
- Stores ticket and purchase data
- Uses **EF Core** and **MSSQL**

### 💬 Feedbacks API
- Lets users leave feedback on events
- Feedback entries can receive likes from other users
- Uses **ADO.NET** and **MSSQL**
- Lightweight and straightforward, focusing on raw SQL operations

### 🏷️ Promotions.gRPC
- Handles promo code creation and validation
- Each promo code has a usage limit and discount percentage
- Works only via gRPC
- Used during ticket purchase to calculate discount and track code usage
- Uses **EF Core** and **MSSQL**

---

## 🔄 Aggregators

These are separate services that combine data from multiple microservices to create a more complete response:

### 📦 PurchaseAggregator.gRPC
- Aggregates data from Ticket and Event services
- Allows creating a purchase that bundles several events
- Returns event details along with associated purchases

### 🧠 EventAggregator
- Combines event data with user feedbacks
- Makes it easy to fetch an event along with its feedback in one call

---

## 🌐 API Gateway

- Uses **Ocelot** for request routing
- Central point for accessing all microservices
- Swagger endpoints for each service are defined for easy testing

---

## 💾 Database

All microservices consistently use **Microsoft SQL Server (MSSQL)** as their relational database engine. Each service has its own isolated database to ensure data encapsulation and service independence.

---

## 🧪 Technologies & Tools

- **.NET 7**
- **Entity Framework Core**, **ADO.NET**
- **MediatR**, **CQRS**, **DDD**
- **gRPC**
- **Redis** (Events Service)
- **MSSQL**
- **AutoMapper**
- **Ocelot Gateway**
- **Docker & Docker Compose**

---

This project is an educational sandbox and not intended for production use, but it demonstrates modern architectural practices for microservice ecosystems.
