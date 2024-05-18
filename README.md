# ShoppingCart

## Description
This project is an eCommerce website developed using Web API (C#) for the backend and Angular for the frontend. It provides a platform for users to browse and purchase products online.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features
- User authentication and authorization
- Product browsing and search functionality
- Shopping cart management
- Checkout process
- Order history and tracking

## Technologies Used
- **Backend (Web API - C#)**
  - ASP.NET Web API
  - Entity Framework Core (for data access)
  - Authentication (JWT, OAuth, etc.)
  - Database (SQL Server, MySQL, etc.)
  
- **Frontend (Angular)**
  - Angular CLI
  - Angular Material (for UI components)
  - TypeScript
  
## Installation
1. Clone this repository:
   ```
   git clone https://github.com/your-username/ecommerce-website.git
   ```

2. Navigate to the backend folder:
   ```
   cd ecommerce-website/backend
   ```

3. Install backend dependencies:
   ```
   dotnet restore
   ```

4. Set up your database:
   - Create a database using your preferred database management system.
   - Update the connection string in `appsettings.json`.

5. Run the backend server:
   ```
   dotnet run
   ```

6. Navigate to the frontend folder:
   ```
   cd ../frontend
   ```

7. Install frontend dependencies:
   ```
   npm install
   ```

8. Run the frontend server:
   ```
   ng serve
   ```

9. Open your browser and navigate to `http://localhost:4200` to view the website.

## Usage
- **User Authentication:**
  - Register as a new user or login with existing credentials.
- **Browsing Products:**
  - Browse through the list of available products.
  - Use search and filtering options to find specific products.
- **Shopping Cart:**
  - Add products to the shopping cart.
  - Update quantities or remove items from the cart.
- **Checkout:**
  - Proceed to checkout and enter shipping/payment details.
  - Confirm the order.
- **Order History:**
  - View past orders and their statuses.

## Contributing
Contributions are welcome! Here's how you can contribute:
- Fork the repository.
- Create a new branch (`git checkout -b feature-branch`).
- Make your changes and commit them (`git commit -am 'Add new feature'`).
- Push your changes to the branch (`git push origin feature-branch`).
- Create a pull request.

