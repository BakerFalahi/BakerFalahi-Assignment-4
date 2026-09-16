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

        RunMenu(
            sessionNames,
            sessionDates,
            sessionDurations);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("Academy Schedule Analyzer");
        Console.WriteLine("===================================");
        Console.WriteLine();
        Console.WriteLine("1. Display all sessions");
        Console.WriteLine("2. Search for a session");
        Console.WriteLine("3. Sort session names");
        Console.WriteLine("4. Reverse session names");
        Console.WriteLine("5. Find session index");
        Console.WriteLine("6. Check if session exists");
        Console.WriteLine("7. Show duration statistics");
        Console.WriteLine("8. Show session date details");
        Console.WriteLine("9. Show past and upcoming sessions");
        Console.WriteLine("10. Find next session");
        Console.WriteLine("11. Compare two session dates");
        Console.WriteLine("12. Read and validate a custom date");
        Console.WriteLine("13. Select session by index");
        Console.WriteLine("14. Validate session duration");
        Console.WriteLine("15. Generate report using string");
        Console.WriteLine("16. Generate report using StringBuilder");
        Console.WriteLine("17. Show date formats");
        Console.WriteLine("18. Show array method examples");
        Console.WriteLine("19. Show parameter passing examples");
        Console.WriteLine("0. Exit");
        Console.WriteLine();
    }

    static void ShowDurationStatistics(int[] durations)
    {
        Console.WriteLine(
            $"Total Duration: {GetTotalDuration(durations)} minutes");

        Console.WriteLine(
            $"Average Duration: {GetAverageDuration(durations):0.##} minutes");

        Console.WriteLine(
            $"Shortest Duration: {GetShortestDuration(durations)} minutes");

        Console.WriteLine(
            $"Longest Duration: {GetLongestDuration(durations)} minutes");

        Console.WriteLine();

        DisplaySortedDurations(durations);
    }

    static void RunMenu(
    string[] sessionNames,
    DateTime[] sessionDates,
    int[] sessionDurations)
    {
        int option;

        do
        {
            Console.Clear();

            DisplayMenu();

            option = ReadMenuOption();

            Console.WriteLine();

            switch (option)
            {
                case 1:
                    DisplaySessions(
                        sessionNames,
                        sessionDates,
                        sessionDurations);
                    break;

                case 2:
                    SearchSession(
                        sessionNames,
                        sessionDates,
                        sessionDurations);
                    break;

                case 3:
                    SortSessionNames(sessionNames);
                    break;

                case 4:
                    ReverseSessionNames(sessionNames);
                    break;

                case 5:
                    FindSessionIndex(sessionNames);
                    break;

                case 6:
                    CheckSessionExists(sessionNames);
                    break;

                case 7:
                    ShowDurationStatistics(sessionDurations);
                    break;

                case 8:
                    ShowSessionDateDetails(
                        sessionNames,
                        sessionDates,
                        sessionDurations);
                    break;

                case 9:
                    ShowPastAndUpcomingSessions(
                        sessionNames,
                        sessionDates);
                    break;

                case 10:
                    FindNextSession(
                        sessionNames,
                        sessionDates);
                    break;

                case 11:
                    CompareSessionDates(
                        sessionNames,
                        sessionDates);
                    break;

                case 12:
                    DateTime customDate = ReadSessionDate();

                    Console.WriteLine(
                        $"Valid date: {customDate:yyyy-MM-dd HH:mm}");
                    break;

                case 13:
                    SelectSessionByIndex(sessionNames);
                    break;

                case 14:
                    ReadAndValidateDuration();
                    break;

                case 15:
                    string stringReport =
                        BuildReportUsingString(
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                    Console.WriteLine(stringReport);
                    break;

                case 16:
                    string stringBuilderReport =
                        BuildReportUsingStringBuilder(
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                    Console.WriteLine(stringBuilderReport);
                    break;

                case 17:
                    ShowSessionDateFormats(sessionNames, sessionDates);
                    break;

                case 18:
                    ShowArrayMethodExamples(sessionNames);
                    break;

                case 19:
                    ShowParameterPassingExamples(
                        sessionNames,
                        sessionDurations);
                    break;

                case 0:
                    Console.WriteLine("Application closed.");
                    break;

                default:
                    Console.WriteLine(
                        "Unknown menu option. Choose a number from 0 to 19.");
                    break;
            }

            if (option != 0)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Press any key to return to the menu...");

                Console.ReadKey();
            }

        } while (option != 0);
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


    static void DisplaySessions(
        string[] names,
        DateTime[] dates,
        int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.Write($"{i + 1}. ");

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

    static void SearchSession(
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

        if (index >= 0)
        {
            DisplaySessionDetails(
                names[index],
                dates[index],
                durations[index]);
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

    static void ShowArrayMethodExamples(string[] names)
    {
        FindSessionByCondition(names);
        FindSessionIndexByCondition(names);
        DemonstrateArrayCopy(names);
    }

    static void ShowParameterPassingExamples(
        string[] names,
        int[] durations)
    {
        int duration = 180;

        Console.WriteLine($"Before ref: {duration}");
        IncreaseDuration(ref duration);
        Console.WriteLine($"After ref: {duration}");

        Console.WriteLine();
        Console.Write("Enter session name for out example: ");
        string input = Console.ReadLine() ?? "";

        bool found = TryGetSessionInfo(
            input,
            names,
            durations,
            out int index,
            out int sessionDuration);

        if (found)
        {
            Console.WriteLine($"Index: {index}");
            Console.WriteLine($"Duration: {sessionDuration} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }

        string[] copiedNames = new string[names.Length];
        Array.Copy(names, copiedNames, names.Length);

        Console.WriteLine();
        Console.WriteLine($"Before array change: {copiedNames[0]}");
        ChangeFirstSessionName(copiedNames);
        Console.WriteLine($"After array change: {copiedNames[0]}");

        Console.WriteLine();
        Console.WriteLine(
            $"params total (120, 180): {CalculateTotalDuration(120, 180)} minutes");
        Console.WriteLine(
            $"params total (120, 180, 240): {CalculateTotalDuration(120, 180, 240)} minutes");
    }

    static int GetTotalDuration(int[] durations)
    {
        int total = 0;

        foreach (int duration in durations)
        {
            total += duration;
        }

        return total;
    }

    static double GetAverageDuration(int[] durations)
    {
        if (durations.Length == 0)
        {
            throw new ArgumentException("The durations array must not be empty.");
        }

        return (double)GetTotalDuration(durations) / durations.Length;
    }

    static int GetShortestDuration(int[] durations)
    {
        if (durations.Length == 0)
        {
            throw new ArgumentException("The durations array must not be empty.");
        }

        int shortest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] < shortest)
            {
                shortest = durations[i];
            }
        }

        return shortest;
    }

    static int GetLongestDuration(int[] durations)
    {
        if (durations.Length == 0)
        {
            throw new ArgumentException("The durations array must not be empty.");
        }

        int longest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] > longest)
            {
                longest = durations[i];
            }
        }

        return longest;
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
