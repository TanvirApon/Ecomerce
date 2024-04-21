# Ecommerce Practice Project

This repository contains a simple ecommerce web application project built using ASP.NET MVC with the DB first approach. It utilizes Microsoft SQL Server Management Studio for database management. The project is primarily created for practice purposes to understand various concepts of web development using the ASP.NET MVC framework.

## Project Structure

The project structure is organized as follows:

- **Controllers:** Contains MVC controller classes responsible for handling user requests and returning appropriate responses.

- **Models:** Includes the model classes representing the entities in the application, such as users, categories, products, and administrators. The models are generated using the DB first approach, which means they are automatically generated based on the database schema.

- **Views:** Contains the HTML templates responsible for rendering the user interface. Each controller has its corresponding folder containing related views.

- **Scripts:** Contains client-side JavaScript files if any.

- **Content:** Holds CSS stylesheets and uploaded files like images.

## Frontend Technologies

The frontend of this application is built using Bootstrap, a popular CSS framework for developing responsive and mobile-first websites. The Bootstrap components and styles used in this project are adapted from online resources.

## Functionality

The application provides the following functionality:

- **User Module:** Allows users to sign up, log in, view products, create advertisements, view advertisements, and log out.

- **Admin Module:** Allows administrators to log in, create categories, and view categories.

## Database

The database for this project consists of the following tables:

- **Admin:** Contains information about administrators.
- **Category:** Stores categories for products.
- **Product:** Holds details of products available in the ecommerce platform.
- **User:** Contains user information for registration and login purposes.

## Database Management

Microsoft SQL Server Management Studio (SSMS) is used for managing the database associated with this project. You can use SSMS to perform tasks such as creating, modifying, and querying the database.

## Getting Started

To run the application locally, follow these steps:

1. Ensure you have Visual Studio installed on your machine.
2. Clone this repository to your local machine.
3. Open the solution file (.sln) in Visual Studio.
4. Build the solution to restore NuGet packages and compile the project.
5. Set the appropriate startup project in Visual Studio.
6. Run the application using IIS Express or your preferred web server.

## Contributing

This project is intended for practice purposes, and contributions are not expected. However, if you have any suggestions or improvements, feel free to fork the repository and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
