# Phumla Kamnandi Hotel Booking System

Desktop booking system built in C# Windows Forms for the Phumla Kamnandi Hotels case study.

## Project Overview

The system supports reception staff with the core guest booking workflow:

- Make a booking
- Modify an existing booking
- Cancel a booking
- Make a booking enquiry
- View all bookings
- Record guest details, deposit status, room occupancy, and booking references

## Technologies

- C# Windows Forms
- .NET Framework 4.7.2
- SQL Server LocalDB
- Layered architecture:
  - Presentation forms
  - Business controllers and entity classes
  - Data repositories

## Key Features

- Room availability checks by date range
- Seasonal rate calculation
- 10% deposit calculation
- Guest validation
- Payment detail validation
- Booking reference search
- Confirmed, pending, and cancelled booking statuses
- All-bookings list view for receptionist lookup
- Return-to-home navigation across the application

## Requirements Covered

The implementation follows the project scope from the Phumla Kamnandi Hotels case study:

- Make a telephone booking
- Change a guest booking
- Cancel a guest booking
- Make a guest booking enquiry
- Maintain booking and guest data in a relational database
- Display outputs on screen
- Apply validation and controls to protect booking integrity

## Portfolio Notes

This is a desktop application, so the Netlify deployment is a static portfolio showcase rather than the executable app itself. The source project demonstrates object-oriented design, layered architecture, SQL data access, validation, and business-rule implementation.

## How to Run

1. Open `booking/booking.sln` in Visual Studio.
2. Restore packages if prompted.
3. Build the solution.
4. Run the project.
5. Use a sample booking reference such as `BKG1001` to test enquiry, modify, and cancel workflows.
