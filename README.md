# EmployeesAPI
This project is a web API built with ASP.NET Core and Angular that allows users to manage a list of employees. Users can view a list of employees, add new employees, edit existing employee information, and delete employees from the list - perform CRUD (Create, Read, Update, Delete) operations on employee data.

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

## Screenhots

### List of Employees
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/efc1fe55-8ea6-4925-8352-e658f40c3353)

### Add Employee
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/82f1e5db-517b-40c7-8f8e-9d37f962769d)

### Edit or Delete Employee
![image](https://github.com/venkataprabhav/EmployeesAPI/assets/123014399/3e144439-7601-422d-96c4-213e62a73aee)




