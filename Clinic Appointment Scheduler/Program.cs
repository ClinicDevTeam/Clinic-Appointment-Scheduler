using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // the appointments array will store the following details:
        // string patientName
        // string bookingID
        // string healthCard (optional)
        // string appointmentDate
        // string appointmentTime
        // string appointmentReason


        // variables that support data entry
        string? readResult;
        string menuSelection = "";
        int nextBookingId = 1001;

        // array used to store runtime data, there is no persisted data
        List<string[]> appointments = new List<string[]>();

        // Load appointments when program starts and get the next booking ID
        nextBookingId = LoadAppointments(appointments);

        // display the top-level menu options
        do
        {
            Console.Clear();

            Console.WriteLine("Welcome to the COAT Clinic Appointment Scheduler. Your main menu options are:");
            Console.WriteLine(" 1. Book a new appointment");
            Console.WriteLine(" 2. View all scheduled appointments");
            Console.WriteLine(" 3. View appointment by Booking ID");
            Console.WriteLine(" 4. Update an appointment");
            Console.WriteLine(" 5. Cancel an appointment");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            switch (menuSelection)
            {
                case "1":
                    // Book a new appointment
                    nextBookingId = BookNewAppointment(appointments, nextBookingId);
                    break;

                case "2":
                    // View all scheduled appointments
                    ViewAllAppointments(appointments);
                    break;

                case "3":
                    //View  appointment by Booking ID
                    ViewAppointmentById(appointments);
                    break;

                case "4":
                    // Update an appointment
                    UpdateAppointment(appointments);
                    break;

                case "5":
                    // Cancel an appointment
                    CancelAppointment(appointments);
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");

        Console.WriteLine("Thank you for using the COAT Clinic Appointment Scheduler!");
    }

    // Modified function to load appointments from a file and return the next available booking ID
    static int LoadAppointments(List<string[]> appointments)
    {
        int nextId = 1001; // Default starting ID

        try
        {
            if (File.Exists("appointments.txt"))
            {
                string[] lines = File.ReadAllLines("appointments.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    appointments.Add(parts);
                }

                // Find the highest booking ID and set next ID accordingly
                if (appointments.Count > 0)
                {
                    int maxId = 0;
                    foreach (string[] appointment in appointments)
                    {
                        if (int.TryParse(appointment[0], out int currentId))
                        {
                            if (currentId > maxId)
                                maxId = currentId;
                        }
                    }
                    nextId = maxId + 1;
                }
            }
        }
        catch
        {
            // If something goes wrong, just continue with default ID
        }

        return nextId;
    }

    // Simple function to save appointments to file
    static void SaveAppointments(List<string[]> appointments)
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (string[] appointment in appointments)
            {
                string line = string.Join("|", appointment);
                lines.Add(line);
            }
            File.WriteAllLines("appointments.txt", lines);
        }
        catch
        {
            // If something goes wrong, just continue
        }
    }

    static int BookNewAppointment(List<string[]> appointments, int nextBookingId)
    {
        Console.Clear();
        Console.WriteLine("=== Book a New Appointment ===");

        string patientName, appointmentDate, appointmentTime, reason;

        // Get Patient Name (required)
        do
        {
            Console.Write("Enter Patient Name (required): ");
            patientName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(patientName))
            {
                Console.WriteLine("Patient name is required. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(patientName));

        // Get Health Card Number (optional)
        Console.Write("Enter Health Card Number (optional): ");
        string healthCard = Console.ReadLine() ?? "";

        // Validate date format (YYYY-MM-DD) and ensure it's not in the past
        bool validDate;
        DateTime parsedDate;
        do
        {
            Console.Write("Enter Appointment Date (YYYY-MM-DD) (required): ");
            appointmentDate = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(appointmentDate))
            {
                Console.WriteLine("Appointment date is required. Please try again.");
                validDate = false;
            }
            else
            {
                validDate = DateTime.TryParseExact(appointmentDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

                if (!validDate)
                {
                    Console.WriteLine("Invalid date format. Please use YYYY-MM-DD format (e.g., 2023-12-31).");
                }
                else if (parsedDate.Date < DateTime.Today)
                {
                    Console.WriteLine("Appointment date cannot be in the past. Please enter a future date.");
                    validDate = false;
                }
            }
        } while (!validDate);

        // Validate time format (HH:mm) and ensure it's between 8:00 AM and 3:00 PM
        bool validTime;
        DateTime parsedTime;
        do
        {
            Console.Write("Enter Appointment Time (HH:mm) - Available hours: 08:00 to 15:00 (required): ");
            appointmentTime = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(appointmentTime))
            {
                Console.WriteLine("Appointment time is required. Please try again.");
                validTime = false;
            }
            else
            {
                validTime = DateTime.TryParseExact(appointmentTime, "HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime);

                if (!validTime)
                {
                    Console.WriteLine("Invalid time format. Please use HH:mm format (e.g., 09:30 or 14:15).");
                }
                else
                {
                    // Check if time is between 8:00 AM (08:00) and 3:00 PM (15:00)
                    TimeSpan appointmentTimeSpan = parsedTime.TimeOfDay;
                    TimeSpan startTime = new TimeSpan(8, 0, 0);  // 8:00 AM
                    TimeSpan endTime = new TimeSpan(15, 0, 0);   // 3:00 PM
                    
                    if (appointmentTimeSpan < startTime || appointmentTimeSpan > endTime)
                    {
                        Console.WriteLine("Appointment time must be between 08:00 and 15:00 (8:00 AM to 3:00 PM).");
                        validTime = false;
                    }
                }
            }
        } while (!validTime);

        // Get Reason for Visit (required)
        do
        {
            Console.Write("Enter Reason for Visit (required): ");
            reason = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(reason))
            {
                Console.WriteLine("Reason for visit is required. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(reason));

        // Create a new appointment
        string[] newAppointment = new string[6];
        newAppointment[0] = nextBookingId.ToString();
        newAppointment[1] = patientName;
        newAppointment[2] = healthCard;
        newAppointment[3] = appointmentDate;
        newAppointment[4] = appointmentTime;
        newAppointment[5] = reason;

        appointments.Add(newAppointment);

        // Save to file after adding
        SaveAppointments(appointments);

        Console.WriteLine("\n** Appointment booked successfully! **");
        Console.WriteLine($"* Your Booking ID is: {nextBookingId} *");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        return nextBookingId + 1;
    }

    static void ViewAllAppointments(List<string[]> appointments)
    {
        Console.Clear();
        Console.WriteLine("=== All Scheduled Appointments ===\n");

        bool hasAppointments = false;

        // Iterate through the List
        foreach (string[] appointment in appointments)
        {
            if (!string.IsNullOrEmpty(appointment[0])) // Check if the slot is "occupied"
            {
                hasAppointments = true;
                Console.WriteLine($"Booking ID: {appointment[0]}");
                Console.WriteLine($"Patient Name: {appointment[1]}");
                Console.WriteLine($"Health Card Number: {(string.IsNullOrEmpty(appointment[2]) ? "Not provided" : appointment[2])}");
                Console.WriteLine($"Date: {appointment[3]}");
                Console.WriteLine($"Time: {appointment[4]}");
                Console.WriteLine($"Reason: {appointment[5]}");
                Console.WriteLine();
            }
        }

        if (!hasAppointments)
            Console.WriteLine("No appointments scheduled.");

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    static void ViewAppointmentById(List<string[]> appointments) // Updated parameter
    {
        Console.Clear();
        Console.WriteLine("=== View Appointment by Booking ID ===");

        Console.Write("Enter Booking ID: ");
        string bookingId = Console.ReadLine() ?? "";

        string[] foundAppointment = null; // To store the found appointment
        foreach (string[] appointment in appointments)
        {
            if (appointment[0].Equals(bookingId, StringComparison.OrdinalIgnoreCase))
            {
                foundAppointment = appointment;
                break;
            }
        }

        if (foundAppointment == null)
        {
            Console.WriteLine("Appointment not found.");
        }
        else
        {
            Console.WriteLine($"\nBooking ID: {foundAppointment[0]}");
            Console.WriteLine($"Patient Name: {foundAppointment[1]}");
            Console.WriteLine($"Health Card Number: {(string.IsNullOrEmpty(foundAppointment[2]) ? "Not provided" : foundAppointment[2])}");
            Console.WriteLine($"Date: {foundAppointment[3]}");
            Console.WriteLine($"Time: {foundAppointment[4]}");
            Console.WriteLine($"Reason: {foundAppointment[5]}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    static void UpdateAppointment(List<string[]> appointments) // Updated parameter
    {
        Console.Clear();
        Console.WriteLine("=== Update an Appointment ===");

        Console.Write("Enter Booking ID to update: ");
        string bookingId = Console.ReadLine() ?? "";

        string[] appointmentToUpdate = null;
        int index = -1; // To keep track of the index if needed for direct access (less common with List)
        for (int i = 0; i < appointments.Count; i++) // Iterate using index for potential direct modification
        {
            if (appointments[i][0].Equals(bookingId, StringComparison.OrdinalIgnoreCase))
            {
                appointmentToUpdate = appointments[i];
                index = i;
                break;
            }
        }

        if (appointmentToUpdate == null)
        {
            Console.WriteLine("Appointment not found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nLeave blank to keep existing value.");

        Console.Write($"Patient Name [{appointmentToUpdate[1]}]: ");
        string input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) appointmentToUpdate[1] = input;

        Console.Write($"Health Card Number [{appointmentToUpdate[2]}]: ");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) appointmentToUpdate[2] = input;

        // Validate date input with past date check
        bool validDate;
        DateTime parsedDate;
        do
        {
            Console.Write($"Date [{appointmentToUpdate[3]}]: ");
            input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                validDate = true; // Keep existing value
            }
            else
            {
                validDate = DateTime.TryParseExact(input, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

                if (!validDate)
                {
                    Console.WriteLine("Invalid date format. Please use YYYY-MM-DD format (e.g., 2023-12-31).");
                }
                else if (parsedDate.Date < DateTime.Today)
                {
                    Console.WriteLine("Appointment date cannot be in the past. Please enter a future date.");
                    validDate = false;
                }
                else
                {
                    appointmentToUpdate[3] = input;
                }
            }
    } while (!validDate);

        // Validate time inputwith business hours check
        bool validTime;
        DateTime parsedTime;
        do
        {
            Console.Write($"Time [{appointmentToUpdate[4]}]: ");
            input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                validTime = true; // Keep existing value
            }
            else
            {
                validTime = DateTime.TryParseExact(input, "HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime);

                if (!validTime)
                {
                    Console.WriteLine("Invalid time format. Please use HH:mm format (e.g., 09:30 or 14:15).");
                }
                else
                {
                    // Check if time is between 8:00 AM (08:00) and 3:00 PM (15:00)
                    TimeSpan appointmentTimeSpan = parsedTime.TimeOfDay;
                    TimeSpan startTime = new TimeSpan(8, 0, 0);  // 8:00 AM
                    TimeSpan endTime = new TimeSpan(15, 0, 0);   // 3:00 PM

                    if (appointmentTimeSpan < startTime || appointmentTimeSpan > endTime)
                    {
                        Console.WriteLine("Appointment time must be between 08:00 and 15:00 (8:00 AM to 3:00 PM).");
                        validTime = false;
                    }
                    else
                    {
                        appointmentToUpdate[4] = input;
                    }
                }
            }
        } while (!validTime);

        Console.Write($"Reason [{appointmentToUpdate[5]}]: ");
        input = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(input)) appointmentToUpdate[5] = input;

        Console.WriteLine("\nAppointment updated successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    static void CancelAppointment(List<string[]> appointments) // Updated parameter
    {
        Console.Clear();
        Console.WriteLine("=== Cancel an Appointment ===");

        Console.Write("Enter Booking ID to cancel: ");
        string bookingId = Console.ReadLine() ?? "";

        string[] appointmentToCancel = null;
        int indexToRemove = -1; // Keep track of the index to remove
        for (int i = 0; i < appointments.Count; i++)
        {
            if (appointments[i][0].Equals(bookingId, StringComparison.OrdinalIgnoreCase))
            {
                appointmentToCancel = appointments[i];
                indexToRemove = i;
                break;
            }
        }

        if (appointmentToCancel == null)
        {
            Console.WriteLine("Appointment not found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            return;
        }

        Console.Write($"Are you sure you want to cancel Booking ID {appointmentToCancel[0]}? (y/n): ");
        string confirm = Console.ReadLine() ?? "";
        if (confirm.ToLower() == "y")
        {
            appointments.RemoveAt(indexToRemove); // Remove the appointment from the list
            SaveAppointments(appointments); // Save the updated list to file
            Console.WriteLine("Appointment canceled.");
        }
        else
        {
            Console.WriteLine("Cancellation aborted.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}

   
