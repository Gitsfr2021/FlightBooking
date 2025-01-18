# Utravs Task

This project is a backend API for a travel booking system. It demonstrates the use of **Clean Architecture**, **CQRS**, and **MediatR** to manage flights, passengers, and bookings. The project follows industry best practices and is designed to be scalable, maintainable, and testable.

---

## **Features**
- Manage flights:
  - Create a new flight.
  - Retrieve flights with optional filters (e.g., origin, destination, date).
  - Update available seats for a flight.
- Manage passengers:
  - Create a new passenger with validation for duplicate email, phone, or passport number.
  - Retrieve passenger details.
- Booking management:
  - Book a flight for a passenger if seats are available.
  - Retrieve all bookings for a flight.

---

## **Technologies Used**
- **.NET 8**
- **Entity Framework Core** for database interactions.
- **MediatR** for implementing CQRS (Command and Query Responsibility Segregation).
- **FluentValidation** for input validation.
- **Swagger** for API documentation.

---

## **Setup Instructions**

### **Prerequisites**
1. Install [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Install a SQL Server instance or use Docker to run a SQL Server container.

---

### **Steps to Run the Project**

#### **Option 1: Run Locally**
1. Clone the repository:
   ```bash
   git clone https://github.com/Gitsfr2021/FlightBooking
   cd UtravsTask
