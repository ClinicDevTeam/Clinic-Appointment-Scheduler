using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        //Removed maxAppointmentss as List handles dynamic sizing
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
                    Console.WriteLine("UNDER CONSTRUCTION - working on it.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "2":
                    // View all scheduled appointments
                    Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "3":
                    // View appointment by Booking ID
                    Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "4":
                    // Update an appointment
                    Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                case "5":
                    // Cancel an appointment
                    Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }

        } while (menuSelection != "exit");
    }
}