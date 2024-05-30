# EmployeesAPI
This project is a full-stack web application built with ASP.NET Core and Angular that allows users to manage a list of employees. Users can perform CRUD (Create, Read, Update, Delete) operations on employee data. The project follows the MVC (Model-View-Controller) architectural pattern and includes unit testing using xUnit to ensure the reliability of the application.

## Features

- View a list of employees with their information
- Add a new employee to the list
- Edit or Delete an existing employee's information


## Technologies Used

- ASP.NET Core (Web API)
- Angular 14 (Frontend)
- Entity Framework Core (ORM)
- SQL Server (Database)
- Bootstrap (CSS Framework)


## Usage
### View Employees

Navigate to http://localhost:4200/employees to view the list of employees.

### Add Employee

Navigate to http://localhost:4200/employees/add to add a new employee by providing the required information.

### Edit Employee

Navigate to http://localhost:4200/employees/:id/edit (replace :id with the employee's ID) to edit an employee's information.

### Delete Employee

Navigate to http://localhost:4200/employees/:id/edit (replace :id with the employee's ID) and click the "Delete" button to remove the employee from the list.

## API Endpoints

- GET /api/employees - Get all employees
- POST /api/employees/add - Add a new employee
- PUT /api/employees/{id} - Update an existing employee
- DELETE /api/employees/{id} - Delete an employee


## Unit Testing

The project includes comprehensive unit tests using xUnit to ensure the functionality of the API:

- Set up an in-memory database for the controller, ensuring each test runs in isolation.
- Tested the retrieval of all employees to ensure the API returns the correct list.
- Verified the addition of a new employee, checking that the API responds with the created employee data.
- Tested the retrieval of a non-existing employee to ensure the API correctly returns a not found status.
- Verified the retrieval of an existing employee to ensure the API returns the correct employee data.
- Tested updating a non-existing employee to ensure the API correctly returns a not found status.
- Verified updating an existing employee to ensure the API responds with the updated employee data.
- Tested deleting a non-existing employee to ensure the API correctly returns a not found status.
- Verified deleting an existing employee to ensure the API responds with the deleted employee data.


## Screenhots

### List of Employees
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/efc1fe55-8ea6-4925-8352-e658f40c3353)

### Add Employee
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/82f1e5db-517b-40c7-8f8e-9d37f962769d)

### Edit or Delete Employee
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/3e144439-7601-422d-96c4-213e62a73aee)

### Unit Tests
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/09112098-3087-45de-9c43-c4c5c2e860ff)

