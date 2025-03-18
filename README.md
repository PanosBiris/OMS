# OMS
Order Management System Example

This is a sample application of the ordering system.
The application consists of 3 services (Ordering Service, Customer and Menu) each one created as a separate Rest Api using .NET Core 9 and a Single Page Application created using Angular 16.
*Customer and Menu are not completed.

The Ordering Service (PB.OMS.OrderingService sln) is created using the Clean Architecture Template and CQRS. Repository pattern and Dependency injection have been also used.
It contains endpoints:
- to create an order by selecing items from a menu
- to retrieve a list of orders of a customer
- to get the details of an order
- In a separate controller there is an endpoint that can be used from restaurant staff to update the status of an order.

Prerequisites to run the web api locally: VS 2022 + .NET 9.0, SQL Express or SQL Developer (connection string contains windows auth / server name: localhost)
For the database / data layer it uses EF Core code first approach. Database and migrations should be created on startup.

The UI / SPA is located in frontend folder in the repo.
Prerequisites: node.js.

To run the angular app locally navigate to the root folder and run the following commands:
- npm install
- npm -i -g @angular/cli
- ng serve
The last one should make the SPA available in: http://localhost:4200/
