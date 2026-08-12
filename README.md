# Community Web API – Assignment 1

## Overview

This project is an **ASP.NET Core Web API** that serves as the backend for a community
where users can register, log in, and create blog posts that other users
can read and comment on.

The application is built according to object-oriented principles and follows the guidelines
and architectural patterns covered in the course *Programming with C# and .NET – Advanced*.

All data is stored in a relational database and accessed through a REST-based API.

---

## Purpose of the Assignment

The purpose of the assignment is to demonstrate that I can:

- Create a functional **ASP.NET Core Web API**
- Communicate with a database using **Entity Framework Core**
- Work with object-oriented principles and a layered architecture
- Implement authentication and authorization
- Document and test an API using **Swagger** and **Postman**

---

## Technologies Used and How They Are Applied

### ASP.NET Core Web API
Used to create REST endpoints for:
- Users
- Login
- Blog posts
- Categories
- Comments

Controllers only handle HTTP logic and call services for business logic.

---

### Entity Framework Core
Used as an ORM to:
- Map entities to database tables
- Create the database through migrations
- Perform CRUD operations

Each entity corresponds to a table in the database.

---

### SQL Server
Used as the relational database for storing:
- Users
- Blog posts
- Comments
- Categories

---

### Repository Pattern
Repositories are responsible for database operations and isolate
database logic from the rest of the application.

Examples:
- UserRepository
- BlogPostRepository
- CommentRepository

---

### Service Layer
The service layer contains business logic such as:
- Authorization checks
- Rules (for example, users cannot comment on their own posts)
- Logic for creating, updating, and deleting data

Controllers always call services – never repositories directly.

---

### Authentication
When logging in, either the following is returned:
- a **JWT token**
  or
- a **UserId** that is used in subsequent requests

This is used to identify the logged-in user
and ensure the correct authorization.

---

### Swagger
Swagger is used to:
- Document all API endpoints
- Test the API directly in the browser
- Display request and response models

---

### Postman
All API requests can be tested using Postman, including:
- Registration
- Login
- Creating blog posts
- Comments
- Search
- Updating and deleting

---

## Functionality

### Users
- Create a user account (username, password, email)
- Log in
- Update a user account
- Delete a user account

---

### Blog Posts
- Create blog posts (requires authentication)
- Read all blog posts (public)
- Update blog posts (creator only)
- Delete blog posts (creator only)

Each blog post contains:
- Title
- Content
- Category
- Associated user

---

### Categories
- Categories are stored in a separate table
- Each blog post belongs to a category
- Searches can be performed based on category

---

### Comments
- Authenticated users can comment on other users' posts
- Users cannot comment on their own posts

---

### Search
- Search by title (partial match)
- Search by category

---

## Architecture

The project is structured into the following layers:

- Controllers – HTTP and API logic
- Services – business logic
- Repositories – database access
- Entities – database tables
- DTOs – input and output data

This provides a clear separation of responsibilities and maintainable code.

---

## Running the Project

1. Open the solution in Visual Studio
2. Check the connection string in `appsettings.json`
3. Run the Entity Framework migrations
4. Start the application
5. Test the API using Swagger or Postman

---

## Assessment

The assignment is graded as **Fail (IG)** or **Pass (G)** and is mandatory
to pass the course.

To achieve **Pass with Distinction (VG) in the course**, a passing grade on this assignment
as well as Assignment 2 is required.
