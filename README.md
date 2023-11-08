# Fullstack Project
This project involves creating a Fullstack project with React and Redux on the frontend and ASP.NET Core 7 on the backend. The goal is to provide a seamless experience for users, along with robust management system for administrators.

- Frontend: SASS, TypeScript, React, Redux Toolkit
- Backend: ASP .NET Core, Entity Framework Core, PostgreSQL

- TypeScript SASS React Redux toolkit .NET Core EF Core PostgreSQL

# Table of Contents
1. Features
    - Mandatory features
    - Extra features
2. Requirements
3. Getting Started
4. Testing


# Features
## Mandatory features
### User Functionalities

    1. User Management: Users should be able to register for an account and log in. Users cannot register themselves as admin.
    2. Browse Books: Users should be able to view all available books and single book, search and sort books.
    3. Borrow Books: User should be able to borrow books.
    4. Checkout: Users should be able to place the order.

### Admin Functionalities
    
    1. User Management: Admins should be able to view and delete users.
    2. Book Management: Admin should be able to view, edit, delete and add new books.
    3. Order Management: Admins should be able to view all orders.
# Requirements

1. Apply CLEAN Architecture in your backend. In README file, explain the architecture of your project as well.

2. Implement Error Handling Middleware: This will ensure any exceptions thrown in a your application are handled approximately and helpful error messages are returned. 

3. Document with Swagger: Make sure to annotate your endpoints and generate a Swagger UI for easier testing and documentation.

4. Project should have proper file structure, naming convention, and comply with Rest API.

5. README file should sufficiently describe the project, as well as the deployment.

# Getting Started

1. Your full stack project should have one git repo to manage both frontend and backend. The shared .git in the root directory is used to push commit to the remote repo. In case you need to deploy frontend and backend to different server, you can inittiate another .git folder in each repository. Syntax: cd frontend -> git init (similar to backend folder). Remember to add .gitignore for each folder when you intiate git repo.

2. frontend folder is for the react frontend. Start with backend first before moving to frontend.

3. In the backend, here is the recommended order:

    - Plan Your Database Schema before start coding

    - Set Up the Project Structure

    - Build the models

    - Create the Repositories

    - Build the Services

    - Set Up Authentication & Authorization

    - Build the Controllers

    - Implement Error Handling Middleware

# Testing
Unit testing, and optionally integration testing, must be included for both frontend and backend code. Aim for high test coverage and ensure all major functionalities are covered.