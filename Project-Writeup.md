# Portfolio Writeup: Phumla Kamnandi Hotel Booking System

## Short Description

Phumla Kamnandi Hotel Booking System is a C# Windows Forms desktop application that supports hotel reception staff with the core booking workflow: making reservations, changing bookings, cancelling bookings, and viewing booking enquiries.

## Problem Context

The project is based on the Phumla Kamnandi Hotels case study, where hotel staff need an accurate single-user system for managing reservations and room occupancy. The key business risk is overbooking rooms or losing track of deposit and confirmation status.

## My Solution

I developed a layered desktop system with separate presentation, business, and data-access responsibilities. The application allows a receptionist to:

- Check room availability by date range.
- Create a booking for a new or existing guest.
- Calculate seasonal stay costs and a 10% deposit.
- Record payment details and mark bookings as confirmed.
- Search for a booking by reference number.
- Modify booking dates and guest counts.
- Cancel existing bookings.
- View all bookings in a list.

## Technical Implementation

- **Frontend:** C# Windows Forms
- **Backend logic:** Business controller classes for bookings, guests, accounts, rooms, and reports
- **Database:** SQL Server LocalDB
- **Data access:** Repository classes using SQL queries and parameterized commands
- **Architecture:** Presentation layer, business layer, and data layer

## Requirements Covered

The project covers the major use cases from the case study:

- Make a telephone booking
- Change a guest booking
- Cancel a guest booking
- Make a guest booking enquiry
- Maintain guest and booking records in a relational database
- Display outputs on screen
- Validate user input and protect booking integrity

## UI and UX Improvements

- Added return-to-home navigation on every workflow window.
- Standardized buttons, textboxes, and listboxes with readable white backgrounds and black text.
- Added an all-bookings list view for quick receptionist lookup.
- Improved confirmation screen layout so email and print actions are visible.
- Added a confirmation summary after payment.

## Validation and Business Rules

- Check-out date must be after check-in date.
- At least one adult is required.
- No more than four guests can be assigned to one room.
- Guest names, email addresses, dates of birth, and addresses are validated.
- Payment fields validate account holder, bank name, account number, CVV, and expiry date.
- Booking references are searched case-insensitively.

## What I Learned

This project strengthened my understanding of layered application design, database-backed desktop systems, and how business rules should be enforced close to the workflow. I also learned the importance of matching code to the real database schema and testing workflows end to end rather than only checking that the project compiles.

## Portfolio Summary

This project demonstrates practical C# development, SQL database integration, input validation, business-rule implementation, and user-centered workflow design for a real-world hotel booking scenario.
