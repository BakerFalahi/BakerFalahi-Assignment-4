# Academy Schedule Analyzer

A C# console application for managing and analyzing an academy training schedule. The project demonstrates arrays, reusable functions, parameter passing, date and time operations, exception handling, string construction, and performance benchmarking with BenchmarkDotNet.

## Student Information

- Student Name: Baker Al-Falahi
- Cohort: Add cohort
- Assignment: C# Intermediate - Module 2-1
- Current Progress: Parts 1-31 completed

## Project Status

This repository contains the completed implementation and supporting evidence for Parts 1-31 of the assignment.

- Parts 1-20: Academy Schedule Analyzer operations
- Parts 21-25: BenchmarkDotNet performance and memory analysis
- Parts 26-28: LeetCode tasks and submission evidence
- Parts 29-30: LinkedIn posts and submission file
- Part 31: Final console menu integration

## Implemented Features

### Schedule Data and Display

- Stores session names in a `string[]`
- Stores starting dates and times in a `DateTime[]`
- Stores durations in an `int[]`
- Uses matching array indexes to represent each session
- Displays session name, date, start time, and duration
- Displays detailed date information and calculates session end times

### Search and Array Operations

- Searches for a session by name
- Sorts a copy of the session names without modifying the original schedule
- Reverses a copied array
- Finds a session index
- Checks whether a session exists
- Finds a session and its index using conditions
- Demonstrates that `Array.Copy()` creates a separate array

The following required array methods are demonstrated:

- `Array.Copy()`
- `Array.Sort()`
- `Array.Reverse()`
- `Array.IndexOf()`
- `Array.Find()`
- `Array.FindIndex()`
- `Array.Exists()`

### Duration Analysis

The application calculates these values from the duration array without hard-coding the results:

- Total duration
- Average duration
- Shortest duration
- Longest duration
- Durations sorted from smallest to largest

### Functions and Parameter Passing

The application is divided into reusable functions that receive parameters, accept arrays, and return values such as `int`, `double`, `DateTime`, and `string`.

It also demonstrates:

- `ref` to modify an existing value-type variable
- `out` to return a session index and duration
- Modification of array elements without using `ref`
- `params int[]` to accept a variable number of duration arguments

### Date and Time Features

- Displays the full session date and day of the week
- Extracts year, month, and day values
- Calculates session end times with `DateTime.AddMinutes()`
- Calculates differences between session dates using `TimeSpan`
- Classifies sessions as past or upcoming using `DateTime.Now`
- Finds the nearest upcoming session dynamically
- Displays custom date and time formats
- Reads dates in exactly `yyyy-MM-dd HH:mm` format
- Validates dates with `DateTime.TryParseExact()`

### Exception Handling

The application demonstrates:

- `try`
- `catch`
- `finally`
- `throw`
- `FormatException`
- `OverflowException`
- `IndexOutOfRangeException`
- `ArgumentException`

Invalid menu input, invalid indexes, invalid numeric values, and non-positive session durations are handled with clear messages.

### Report Generation

The schedule report is generated in two equivalent ways:

1. Repeated `string` concatenation
2. `StringBuilder`

Both versions return the same report content. Their equality is verified before benchmarking.

## BenchmarkDotNet

The project uses BenchmarkDotNet to compare repeated string concatenation with `StringBuilder` at these loop sizes:

- 100 iterations
- 1,000 iterations
- 10,000 iterations
- 100,000 iterations

`MemoryDiagnoser` is enabled to measure managed-memory allocations. Both benchmark methods append the same text the same number of times and return equivalent results. No console output or `Stopwatch` is used inside the measured operations.

### Benchmark Environment

- BenchmarkDotNet: 0.15.8
- Operating System: Windows 11
- Processor: Intel Core i7-10700K
- .NET SDK: 10.0.400
- Runtime: .NET 10.0.11

### Benchmark Summary

| Method | Iterations | Mean | Allocated |
|---|---:|---:|---:|
| String concatenation | 100 | 4,326.7 ns | 71.45 KB |
| StringBuilder | 100 | 421.1 ns | 3.88 KB |
| String concatenation | 1,000 | 366,279.5 ns | 6,867.15 KB |
| StringBuilder | 1,000 | 3,221.8 ns | 30.4 KB |
| String concatenation | 10,000 | 57,441,091.3 ns | 683,951.53 KB |
| StringBuilder | 10,000 | 78,113.0 ns | 279.02 KB |
| String concatenation | 100,000 | 11,742,205,246.7 ns | 68,368,869.2 KB |
| StringBuilder | 100,000 | 832,100.0 ns | 2,749.52 KB |

At 100 iterations, `StringBuilder` was approximately 10.3 times faster. At 100,000 iterations, it was approximately 14,111 times faster. Repeated string concatenation also allocated considerably more memory because strings are immutable and each append creates a new accumulated string.

The detailed benchmark results and required written analysis belong in [`BENCHMARK.md`](BENCHMARK.md).

## Project Structure

```text
repository-root/
|-- AcademyScheduleAnalyzer/
|   |-- AcademyScheduleAnalyzer.csproj
|   |-- Program.cs
|   `-- Benchmarks/
|       `-- StringBenchmark.cs
|-- BENCHMARK.md
|-- README.md
|-- LeetCode/                 # Added during Parts 26-28
`-- LinkedIn/                 # Added during Parts 29-30
```

## Requirements

- .NET SDK compatible with the project target framework
- BenchmarkDotNet NuGet package
- Visual Studio, Visual Studio Code, or another C# development environment

Install or restore dependencies with:

```powershell
dotnet restore
```

## Run the Console Application

Open a terminal in the folder containing `AcademyScheduleAnalyzer.csproj`, then run:

```powershell
dotnet run
```

## Run the Benchmarks

Run benchmarks using the Release configuration:

```powershell
dotnet run -c Release -- --benchmark
```

Generated reports are stored in:

```text
BenchmarkDotNet.Artifacts/results/
```

## Assignment Restrictions Followed

- No LINQ is used
- No application classes such as `Session`, `Course`, `Student`, or `Schedule` are created
- The BenchmarkDotNet benchmark class is the only additional custom class
- Calculated values are not hard-coded
- Original parallel arrays are preserved when sorting or reversing data
- `DateTime.TryParseExact()` is used for expected invalid date input
- Specific exception types are handled
- Benchmark methods perform equivalent work
- No `Console.WriteLine()` appears inside benchmark loops
- No `Stopwatch` is used for performance measurement

## Completion Status

All assignment parts are complete:

- Academy Schedule Analyzer operations and reusable functions
- Final repeating console menu
- BenchmarkDotNet performance and memory comparison
- Benchmark analysis
- Valid Anagram and Greatest Common Divisor of Strings submissions
- LeetCode profile, problem links, and accepted-submission evidence
- Four published technical LinkedIn posts and submission links
- Required repository documentation and structure
