using System.Globalization;
using System.Text;
using AcademyScheduleAnalyzer.Benchmarks;
using BenchmarkDotNet.Running;

namespace AcademyScheduleAnalyzer;



internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "--benchmark")
        {
            BenchmarkRunner.Run<StringBenchmark>();
            return;
        }

        string[] sessionNames =
        {
        "C# Basics",
        "Arrays",
        "Functions",
        "Date and Time",
        "Exception Handling"
        };

        DateTime[] sessionDates =
        {
        new DateTime(2026, 9, 10, 18, 0, 0),
        new DateTime(2026, 9, 13, 18, 0, 0),
        new DateTime(2026, 9, 17, 18, 0, 0),
        new DateTime(2026, 9, 20, 18, 0, 0),
        new DateTime(2026, 9, 24, 18, 0, 0)
        };

        int[] sessionDurations =
        {
        180,
        240,
        180,
        240,
        180
        };

        //DisplaySessions(sessionNames, sessionDates, sessionDurations);
        //Console.WriteLine("Enter the name of the session you want to search for:");
        //var sessionName = Console.ReadLine();
        //getSessionByName(sessionNames, sessionDates, sessionDurations, sessionName);

        //SortSessionNames(sessionNames);
        //ReverseSessionNames(sessionNames);
        //FindSessionIndex(sessionNames);
        //CheckSessionExists(sessionNames);
        //FindSessionByCondition(sessionNames);
        //FindSessionIndexByCondition(sessionNames);
        //DemonstrateArrayCopy(sessionNames);

        //DurationAnalysis(sessionDurations);
        //DisplaySortedDurations(sessionDurations);

        //DateTime endTime = GetSessionEndTime(sessionDates[1],sessionDurations[1]);

        //Console.WriteLine(
        //    $"End Time: {endTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");

        //int duration = 180;

        //Console.WriteLine($"Before: {duration}");

        //IncreaseDuration(ref duration);

        //Console.WriteLine($"After: {duration}");

        //Console.Write("Enter session: ");
        //string input = Console.ReadLine() ?? "";

        //bool found = TryGetSessionInfo(
        //    input,
        //    sessionNames,
        //    sessionDurations,
        //out int sessionIndex,
        //out int sessionDuration);

        //if (found)
        //{
        //  Console.WriteLine($"Index: {sessionIndex}");
        //  Console.WriteLine($"Duration: {sessionDuration} minutes");
        //}
        //else
        //{
        //  Console.WriteLine("Session not found.");
        //}

        //string[] demoNames = new string[sessionNames.Length];

        //Array.Copy(sessionNames, demoNames, sessionNames.Length);

        //Console.WriteLine("Before:");

        //foreach (string name in demoNames)
        //{
        //    Console.WriteLine(name);
        //}

        //ChangeFirstSessionName(demoNames);

        //Console.WriteLine();
        //Console.WriteLine("After:");

        //foreach (string name in demoNames)
        //{
        //    Console.WriteLine(name);
        //}

        //Console.WriteLine(CalculateTotalDuration(120, 180));
        //Console.WriteLine(CalculateTotalDuration(120, 180, 240));
        //Console.WriteLine(CalculateTotalDuration(60, 90, 120, 180, 240));

        //ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);
        //CompareSessionDates(sessionNames, sessionDates);

        //ShowPastAndUpcomingSessions(sessionNames, sessionDates);

        //FindNextSession(sessionNames, sessionDates);

        //ShowSessionDateFormats(sessionNames, sessionDates);

        //DateTime customDate = ReadSessionDate();

        //Console.WriteLine(
        //    $"Accepted date: {customDate.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)}");

        //int option = ReadMenuOption();

        //Console.WriteLine($"Selected option: {option}");

        //SelectSessionByIndex(sessionNames);

        //ReadAndValidateDuration();

        //string stringReport = BuildReportUsingString(sessionNames, sessionDates, sessionDurations);
        //string builderReport = BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations);


        //Console.WriteLine($"Reports match: {stringReport == builderReport}");
    }

    static string BuildReportUsingStringBuilder(
    string[] names,
    DateTime[] dates,
    int[] durations)
    {
        StringBuilder report = new StringBuilder();

        for (int i = 0; i < names.Length; i++)
        {
            report.Append(names[i]);
            report.Append(" - ");

            report.Append(dates[i].ToString(
                "dd/MM/yyyy hh:mm tt",
                CultureInfo.InvariantCulture));

            report.Append(" - ");
            report.Append(durations[i]);
            report.AppendLine(" minutes");
        }

        return report.ToString();
    }


    static string BuildReportUsingString(
    string[] names,
    DateTime[] dates,
    int[] durations)
    {
        string report = "";

        for (int i = 0; i < names.Length; i++)
        {
            report += names[i]
                + " - "
                + dates[i].ToString(
                    "dd/MM/yyyy hh:mm tt",
                    CultureInfo.InvariantCulture)
                + " - "
                + durations[i]
                + " minutes"
                + Environment.NewLine;
        }

        return report;
    }

    static void ReadAndValidateDuration()
    {
        Console.Write("Enter duration: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            int duration = int.Parse(input);

            ValidateSessionDuration(duration);

            Console.WriteLine("Duration accepted.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid duration. Enter a whole number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too large or too small for an int.");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Console.WriteLine("Input operation finished.");
        }
    }

    static void ValidateSessionDuration(int duration)
    {
        if (duration <= 0)
        {
            throw new ArgumentException(
                "Duration must be greater than zero.");
        }
    }

    static void SelectSessionByIndex(string[] names)
    {
        Console.Write("Enter session index: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            int index = int.Parse(input);

            Console.WriteLine($"Session: {names[index]}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid index. Enter a whole number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too large or too small for an int.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The selected session index is out of range.");
        }
    }

    static int ReadMenuOption()
    {
        while (true)
        {
            Console.Write("Choose an option: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                int option = int.Parse(input);
                return option;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid menu option. Enter a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small for an int.");
            }
        }
    }
    static DateTime ReadSessionDate()
    {
        while (true)
        {
            Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
            string input = Console.ReadLine() ?? "";

            bool isValid = DateTime.TryParseExact(
                input,
                "yyyy-MM-dd HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date);

            if (isValid)
            {
                return date;
            }

            Console.WriteLine(
                "Invalid date. Use yyyy-MM-dd HH:mm with a valid date and time.");
        }
    }

    static void ShowSessionDateFormats(string[] names, DateTime[] dates)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine() ?? "";

        int index = Array.FindIndex(
            names,
            name => string.Equals(
                name,
                input,
                StringComparison.OrdinalIgnoreCase));

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        DateTime date = dates[index];
        CultureInfo culture = CultureInfo.InvariantCulture;

        Console.WriteLine();
        Console.WriteLine($"Session: {names[index]}");

        Console.WriteLine(date.ToString("yyyy-MM-dd", culture));
        Console.WriteLine(date.ToString("dd/MM/yyyy", culture));
        Console.WriteLine(date.ToString("dd MMMM yyyy", culture));
        Console.WriteLine(date.ToString("dddd, dd MMMM yyyy", culture));
        Console.WriteLine(date.ToString("hh:mm tt", culture));
    }

    static void FindNextSession(string[] names, DateTime[] dates)
    {
        DateTime now = DateTime.Now;
        int nextIndex = -1;

        for (int i = 0; i < dates.Length; i++)
        {
            if (dates[i] > now)
            {
                if (nextIndex == -1 || dates[i] < dates[nextIndex])
                {
                    nextIndex = i;
                }
            }
        }

        if (nextIndex == -1)
        {
            Console.WriteLine("No upcoming sessions.");
            return;
        }

        TimeSpan remaining = dates[nextIndex] - now;

        Console.WriteLine("Next Session:");
        Console.WriteLine();
        Console.WriteLine(names[nextIndex]);

        Console.WriteLine(
            dates[nextIndex].ToString(
                "dd MMMM yyyy",
                CultureInfo.InvariantCulture));

        Console.WriteLine(
            dates[nextIndex].ToString(
                "hh:mm tt",
                CultureInfo.InvariantCulture));

        Console.WriteLine();
        Console.WriteLine("Time Remaining:");
        Console.WriteLine($"{remaining.Days} days");
        Console.WriteLine($"{remaining.Hours} hours");
    }

    static void ShowPastAndUpcomingSessions(
    string[] names,
    DateTime[] dates)
    {
        DateTime now = DateTime.Now;

        for (int i = 0; i < names.Length; i++)
        {
            if (dates[i] <= now)
            {
                Console.WriteLine($"{names[i]}: Past");
            }
            else
            {
                Console.WriteLine($"{names[i]}: Upcoming");
            }
        }
    }

    static void CompareSessionDates(string[] names, DateTime[] dates)
    {
        Console.Write("First Session: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("Second Session: ");
        string secondName = Console.ReadLine() ?? "";

        int firstIndex = Array.FindIndex(
            names,
            name => string.Equals(
                name,
                firstName,
                StringComparison.OrdinalIgnoreCase));

        int secondIndex = Array.FindIndex(
            names,
            name => string.Equals(
                name,
                secondName,
                StringComparison.OrdinalIgnoreCase));

        if (firstIndex == -1 || secondIndex == -1)
        {
            Console.WriteLine("One or both sessions were not found.");
            return;
        }

        TimeSpan difference = dates[secondIndex] - dates[firstIndex];

        difference = difference.Duration();

        Console.WriteLine();
        Console.WriteLine("Difference:");
        Console.WriteLine($"{difference.TotalDays} days");
        Console.WriteLine($"{difference.TotalHours} hours");
    }

    static void ShowSessionDateDetails(
    string[] names,
    DateTime[] dates,
    int[] durations)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine() ?? "";

        int index = Array.FindIndex(
            names,
            name => string.Equals(
                name,
                input,
                StringComparison.OrdinalIgnoreCase));

        if (index == -1)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        DateTime startTime = dates[index];
        int duration = durations[index];

        DateTime endTime = GetSessionEndTime(startTime, duration);

        Console.WriteLine();
        Console.WriteLine($"Session: {names[index]}");

        Console.WriteLine(
            $"Date: {startTime.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");

        Console.WriteLine($"Day: {startTime.DayOfWeek}");
        Console.WriteLine($"Year: {startTime.Year}");
        Console.WriteLine($"Month: {startTime.Month}");
        Console.WriteLine($"Day Number: {startTime.Day}");

        Console.WriteLine(
            $"Start Time: {startTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");

        Console.WriteLine($"Duration: {duration} minutes");

        Console.WriteLine(
            $"End Time: {endTime.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
    }

    static int CalculateTotalDuration(params int[] durations)
    {
        int total = 0;

        foreach (int duration in durations)
        {
            total += duration;
        }

        return total;
    }

    static void ChangeFirstSessionName(string[] names)
    {
        if (names.Length > 0)
        {
            names[0] = "Updated C# Basics";
        }
    }

    static bool TryGetSessionInfo(
    string sessionName,
    string[] names,
    int[] durations,
    out int index,
    out int duration)
    {
        index = Array.FindIndex(
            names,
            name => string.Equals(
                name,
                sessionName,
                StringComparison.OrdinalIgnoreCase));

        duration = 0;

        if (index == -1)
        {
            return false;
        }

        duration = durations[index];

        return true;
    }


    static void DisplaySessions(string[] names,DateTime[] dates,int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}");

            DisplaySessionDetails(
            names[i],
            dates[i],
            durations[i]);
        }
    }

    static void IncreaseDuration(ref int duration)
    {
        duration += 30;
    }

    static void DisplaySessionDetails(
    string name,
    DateTime date,
    int duration)
    {
        Console.WriteLine($"Session: {name}");

        Console.WriteLine(
            $"Date: {date.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");

        Console.WriteLine(
            $"Start Time: {date.ToString("hh:mm tt", CultureInfo.InvariantCulture)}");

        Console.WriteLine($"Duration: {duration} minutes");
        Console.WriteLine();
    }

    static DateTime GetSessionEndTime(
    DateTime startTime,
    int duration)
    {
        return startTime.AddMinutes(duration);
    }

    static void getSessionByName(string[] names, DateTime[] dates, int[] durations, string sessionName)
    {
       int index = Array.IndexOf(names, sessionName);
        if (index >= 0)
        {
            Console.WriteLine($"Session found: {names[index]}");
            Console.WriteLine($"Date: {dates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Start Time: {dates[index].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }

    static void SortSessionNames(string[] names)
    {
        string[] copiedNames = new string[names.Length];

        Array.Copy(names, copiedNames, names.Length);
        Array.Sort(copiedNames);

        Console.WriteLine("Sorted session names:");

        foreach (string name in copiedNames)
        {
            Console.WriteLine(name);
        }
    }

    static void ReverseSessionNames(string[] names)
    {
        string[] copiedNames = new string[names.Length];

        Array.Copy(names, copiedNames, names.Length);
        Array.Reverse(copiedNames);

        Console.WriteLine("Reversed session names:");

        foreach (string name in copiedNames)
        {
            Console.WriteLine(name);
        }
    }

    static void FindSessionIndex(string[] names)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine() ?? "";

        int index = Array.IndexOf(names, input);

        Console.WriteLine($"Index: {index}");
    }

    static void CheckSessionExists(string[] names)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine() ?? "";

        bool exists = Array.Exists(
            names,
            name => string.Equals(
                name,
                input,
                StringComparison.OrdinalIgnoreCase));

        Console.WriteLine(
            exists ? "Session exists." : "Session does not exist.");
    }

    static void FindSessionByCondition(string[] names)
    {
        string? foundName = Array.Find(
            names,
            name => name.Contains("Time"));

        Console.WriteLine(foundName ?? "Session not found.");
    }

    static void FindSessionIndexByCondition(string[] names)
    {
        int index = Array.FindIndex(
            names,
            name => name.Contains("Time"));

        Console.WriteLine($"Index: {index}");
    }

    static void DemonstrateArrayCopy(string[] names)
    {
        string[] copiedNames = new string[names.Length];

        Array.Copy(names, copiedNames, names.Length);

        copiedNames[0] = "Updated Session";

        Console.WriteLine("Original array:");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();
        Console.WriteLine("Copied array:");

        foreach (string name in copiedNames)
        {
            Console.WriteLine(name);
        }
    }

    static void DurationAnalysis(int[] durations)
    {
        // Calculate total, average, Shortest, and longest durations
        int Total = 0;
        int Shortest = int.MaxValue;
        int Longest = int.MinValue;
        foreach (int duration in durations)
        {
            Total += duration;
            if (duration < Shortest) Shortest = duration;
            if (duration > Longest) Longest = duration;
        }
        double averageDuration = (double)Total / durations.Length;
        Console.WriteLine($"Total Duration: {Total} minutes");
        Console.WriteLine($"Average Duration: {averageDuration:F2} minutes");
        Console.WriteLine($"Longest Duration: {Longest} minutes");
        Console.WriteLine($"Shortest Duration: {Shortest} minutes");
    }

    static void DisplaySortedDurations(int[] durations)
    {
        int[] copiedDurations = new int[durations.Length];

        Array.Copy(durations, copiedDurations, durations.Length);
        Array.Sort(copiedDurations);

        Console.WriteLine("Sorted durations:");

        foreach (int duration in copiedDurations)
        {
            Console.WriteLine($"{duration} minutes");
        }
    }

}


