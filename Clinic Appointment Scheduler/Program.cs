// the appointments array will store the following details:
// string patientName = "";
// string patientID = "";
// string appointmentDate = "";
// string appointmentTime = "";
// string doctorName = "";
// string appointmentReason = "";

// variables that support data entry
int maxAppointments = 10;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] appointments = new string[maxAppointments, 6];

// create some initial appointment entries (optional demo data)
for (int i = 0; i < maxAppointments; i++)
{
    appointments[i, 0] = "Patient ID: ";
    appointments[i, 1] = "Patient Name: ";
    appointments[i, 2] = "Appointment Date: ";
    appointments[i, 3] = "Appointment Time: ";
    appointments[i, 4] = "Doctor: ";
    appointments[i, 5] = "Reason: ";
}

// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso Clinic Appointment Scheduler. Your main menu options are:");
    Console.WriteLine(" 1. Book a new appointment");
    Console.WriteLine(" 2. View all scheduled appointments");
    Console.WriteLine(" 3. Update an appointment");
    Console.WriteLine(" 4. Cancel an appointment");
    Console.WriteLine(" 5. Search appointments by doctor");
    Console.WriteLine(" 6. Search appointments by date");
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
            Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
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
            // Update an appointment
            Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Cancel an appointment
            Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Search appointments by doctor
            Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Search appointments by date
            Console.WriteLine("UNDER CONSTRUCTION - please check back soon to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");