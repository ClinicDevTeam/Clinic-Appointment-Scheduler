# Clinic Appointment Scheduler
## Team Members
Omoniyi Okewale - A00304464  
Chibuzor Ubah - A00287148  
Olatunji Olopade - A00331233  
Anthony Mbanu - A00322175  

## Introduction
The **Clinic Appointment Scheduler** is a web application designed to simplify the process of booking, managing, and canceling medical appointments at walk-in clinics. Built using C# and .NET in Visual Studio 2022, the app aims to reduce wait times and eliminate the inefficiencies of manual booking systems for both patients and clinic staff.

## Problem
Visiting walk-in clinics and booking medical appointments in Canada can often be time-consuming, inefficient, and frustrating for both patients and healthcare providers. Many clinics still rely on manual and in-person systems which lead to long wait times and poor coordination. Patients often spend hours waiting for medical services that only take minutes to deliver, creating unnecessary strain on both sides.

## Project Idea/ Solution
The Clinical Appointment Scheduler is a user-friendly web application to reduce clinic congestion and improve patient access.  Patients can easily:  
•	Book Appointment  
 - Primary: Anthony  
 - Secondary: Olatunji  
  
•	View all Appointments  
 - Primary: Olatunji   
 - Secondary: Chibuzor 

•	View Appointments by booking ID
 - Primary: Olatunji   
 - Secondary: Chibuzor  
   
•	Update Appointment
 - Primary: Chibuzor   
 - Secondary: Omoniyi  
    
•	Cancel Appointment  
 - Primary: Omoniyi  
 - Secondary: Anthony  
    
Clinics can manage daily schedules and improve staff planning with real-time updates.

Excluded in this version are:  
•	User accounts/logins  
•	Notifications (email/SMS)  
•	Patient registration  
•	Mobile responsiveness  

---

## Project Plan
Using Visual Studio 2022, the project is feasible within the 2-week timeline (June 13), typical for a sprint.
 
## Week 1:  
•	Project Setup  
•	Appointment booking logic  
•	View appointment functionality  
•	Cancel/ Update appointments  
•	Integration testing  

## Week 2:  
•	Input Validation & error handling  
•	Final testing  
•	Documentation & presentation preparations  

---

## Application Flow

1. *Step 1*: The user opens the application and is presented with a main menu to choose an action (Book, View All, View by ID, Update, Cancel).
2. *Step 2*: The user performs actions based on menu options (e.g., booking a new appointment or updating existing appointment details).
3. *Step 3*: The application validates all inputs including date formats, time slots, and business hours.
4. *Step 4*: All appointment data is automatically saved to appointments.txt file after each operation.

---

## Business Rules

- *Operating Hours*: 8:00 AM to 3:00 PM (08:00 to 15:00)
- *Time Slots*: 30-minute intervals only (e.g., 08:00, 08:30, 09:00, etc.)
- *Booking IDs*: Auto-generated starting from 1001
- *Required Fields*: Patient Name, Appointment Date, Appointment Time, Reason for Visit
- *Optional Fields*: Health Card Number
- *Date Validation*: No appointments can be scheduled in the past

---

## Agile Task Board (Progress Tracker)

### Backlog (Not Started)
- None - All planned features have been implemented.

### In Progress (Currently Being Worked On)
- None - All development work has been completed.

### In Review
- None - All features have been reviewed and approved.

### Completed
- Basic Application Structure - Core console application with main menu system. (Olatunji)
- Book New Appointment - Complete functionality to schedule new appointments. (Anthony)
  - Input validation for all required fields. (Anthony)
  - Date and time format validation. (Anthony)
  - Business hours enforcement. (Anthony)
  - Auto-generation of booking IDs. (Anthony)
- View All Appointments - Display complete list of scheduled appointments. (Olatunji)
  - Formatted output showing all appointment details. (Olatunji)
  - Handle empty appointment list gracefully. (Olatunji)
- View Appointment by ID - Search and display specific appointment by booking ID. (Olatunji)
  - Case-insensitive booking ID search. (Olatunji)
  - Clear error message for non-existent bookings. (Olatunji)
- Update Appointment - Modify existing appointment details. (Chibuzor)
  - Preserve existing values when user leaves fields blank. (Chibuzor)
  - Validate all updated information. (Chibuzor)
  - Prevent conflicts when changing date/time. (Chibuzor)
- Cancel Appointment - Remove appointments from the system. (Omoniyi)
  - Confirmation prompt before deletion. (Omoniyi)
  - Safe removal from appointments list. (Omoniyi)
- Data Persistence - Save and load appointments from text file. (Olatunji)
  - Automatic loading on application startup. (Olatunji)
  - Automatic saving after each modification. (Olatunji)
  - Proper handling of missing data file. (Olatunji)
- Time Slot Validation - Enforce 30-minute intervals and business hours. (Anthony)
  - Validate time format and intervals. (Anthony)
  - Check for appointment conflicts. (Anthony)
  - Display available time slots to users. (Anthony)
- Enhanced Error Handling - Comprehensive error handling for file operations and user input. (Olatunji)
  - Handle file read/write permissions errors. (Olatunji)
  - Graceful degradation when file is corrupted. (Olatunji)
  - Robust input validation for all user entries. (Olatunji)
- Search Functionality Enhancement - Advanced search options beyond booking ID. (Omoniyi)
  - Search functionality integrated into view by ID feature. (Omoniyi)
  - Comprehensive appointment lookup capabilities. (Omoniyi)
- User Interface Improvements - Enhanced console interface for optimal user experience. (Chibuzor)
  - Clear section headers and formatting. (Chibuzor)
  - Consistent spacing and layout throughout application. (Chibuzor)
  - Confirmation messages for all operations. (Chibuzor)
- Data Validation Refinement - Robust input validation across all functions. (Chibuzor)
  - Comprehensive date parsing and validation. (Chibuzor)
  - Strong time format validation with business rules. (Chibuzor)
  - Complete validation for all edge cases. (Chibuzor)
- Appointment Conflict Prevention - Complete prevention of double-booking. (Anthony)
  - Comprehensive time slot checking implemented. (Anthony)
  - Conflict detection tested with all scenarios. (Anthony)
  - Exclusion logic working perfectly during updates. (Anthony)
- File Data Integrity - Data consistency maintained in appointments.txt file. (Olatunji)
  - File format validation on load implemented. (Olatunji)
  - Data corruption detection and handling complete. (Olatunji)
  - Automatic data repair for recoverable issues. (Olatunji)
- Available Time Slots Display - Real-time display of available appointment times. (Omoniyi)
  - Available slots displayed when booking new appointments. (Omoniyi)
  - Available slots shown when updating appointments. (Omoniyi)
  - Dynamic display tested with all booking scenarios. (Omoniyi)
- Data Backup - Robust data persistence and backup functionality. (Olatunji)
  - Automatic saving after each operation ensures data backup. (Olatunji)
  - File-based storage provides persistent data retention. (Olatunji)
- Appointment Statistics - Basic statistics available through view functions. (Olatunji)
  - All appointments viewable with complete details. (Olatuji)
  - Appointment patterns visible through list view. (Olatunji)
- User Manual - Complete documentation provided in README.md. (All)
  - Setup and usage instructions documented. (All)
  - All menu functionalities explained. (All)
  - Console interface examples provided. (All)

---

## Console User Interfaces

### Main Menu

```text
+-------------------------------------------------------------------------------------+
| Welcome to the COAT Clinic Appointment Scheduler. Your main menu options are:       |
| 1. Book a new appointment                                                           |
| 2. View all scheduled appointments                                                  |
| 3. View appointment by Booking ID                                                   |
| 4. Update an appointment                                                            |
| 5. Cancel an appointment                                                            |
|                                                                                     |
| Enter your selection number (or type Exit to exit the program)                      |
+-------------------------------------------------------------------------------------+
```
### Book New Appointment Screen

```text
+----------------------------------------------------------------------------------------------------------------------+
| === Book a New Appointment ===                                                                                       |
| Enter Patient Name (required):                                                                                       |
| Enter Health Card Number (optional):                                                                                 |
| Enter Appointment Date (YYYY-MM-DD) (required):                                                                      |
| Available time slots for [DATE]:                                                                                     |
| Available: 08:00, 08:30, 09:00, 09:30, 10:00, 10:30, 11:00, 11:30, 12:00, 12:30, 13:00, 13:30, 14:00, 14:30, 15:00   |
| Enter Appointment Time (HH:mm) - Available hours: 08:00 to 15:00 (required):                                         |
| Enter Reason for Visit (required):                                                                                   |
|                                                                                                                      |
| ** Appointment booked successfully! **                                                                               |
| * Your Booking ID is: [ID] *                                                                                         |
+----------------------------------------------------------------------------------------------------------------------+
```
### View Appointment Details

```text
+------------------------------------------------+
| Booking ID: [ID]                               |
| Patient Name: [Name]                           |
| Health Card Number: [Number or "Not provided"] |
| Date: [YYYY-MM-DD]                             |
| Time: [HH:mm]                                  |
| Reason: [Reason]                               |
+------------------------------------------------+
```
---

## Data Storage Format

Appointments are stored in appointments.txt using a pipe-delimited format:

BookingID|PatientName|HealthCard|Date|Time|Reason


Example:

1001|John Doe|1234567890|2024-01-15|09:30|Annual checkup
1002|Jane Smith||2024-01-15|10:00|Flu symptoms
