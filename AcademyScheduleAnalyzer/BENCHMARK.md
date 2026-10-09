# Benchmark Analysis: string vs StringBuilder

## Benchmark Environment

- BenchmarkDotNet: 0.15.8
- Operating System: Windows 11
- Processor: Intel Core i7-10700K
- .NET SDK: 10.0.400
- Runtime: .NET 10.0.11

## 1. Which approach was faster with 100 iterations?

StringBuilder was faster with 100 iterations.

String concatenation had a mean execution time of 4,326.7 ns,
while StringBuilder had a mean execution time of 421.1 ns.

Based on these results, StringBuilder was approximately 10.3 times
faster. It also allocated less memory: 3.88 KB compared with
71.45 KB for string concatenation.


## 2. Which approach was faster with 100,000 iterations?

StringBuilder was significantly faster with 100,000 iterations.

String concatenation had a mean execution time of
11,742,205,246.7 ns, which is approximately 11.74 seconds.

StringBuilder had a mean execution time of 832,100 ns,
which is approximately 0.832 milliseconds.

Based on these results, StringBuilder was approximately
14,111 times faster than repeated string concatenation.
The performance difference became much larger as the
number of iterations increased.

## 3. Which approach allocated more memory?

Repeated string concatenation allocated more memory at every
tested loop size.

At 100 iterations, string concatenation allocated 71.45 KB,
while StringBuilder allocated 3.88 KB.

At 100,000 iterations, string concatenation allocated
68,368,869.2 KB, while StringBuilder allocated 2,749.52 KB.
String concatenation therefore allocated approximately 24,865
times more memory in this test.

The Allocated column shows cumulative managed-memory allocations
during one benchmark operation. It does not mean that all this
memory was used simultaneously.

## 4. What happened to string concatenation performance
as the loop size increased?

String concatenation became disproportionately slower as the
number of iterations increased.

The mean execution time increased from 4,326.7 ns at 100
iterations to 11,742,205,246.7 ns at 100,000 iterations.

Although the iteration count increased by ten times at each
step, the execution time increased by much more than ten times.
This shows that repeated string concatenation does not scale
linearly in this benchmark.

The reason is that the accumulated string becomes longer after
every iteration. Each new concatenation must create another
string and copy the existing characters into it. Therefore,
later iterations require more work than earlier iterations.

## 5. Why does repeated string concatenation create
additional allocations?

Strings in C# are immutable. Their contents cannot be changed
after they have been created.

When the application executes `result += "Session"`, it cannot
append the new text directly to the existing string. It creates
a new string, copies the existing content, adds the new text,
and assigns the new string reference to `result`.

The previous intermediate string is no longer needed and
eventually becomes eligible for garbage collection.

This process occurs during every loop iteration. As the
accumulated string becomes longer, each new concatenation must
copy more existing characters. This causes increasing execution
time and a large number of temporary memory allocations.

## 6. Why does StringBuilder usually perform better
when text is repeatedly appended?

StringBuilder stores its content in a mutable internal buffer.
The Append method adds text to this buffer without creating a
complete new string after every operation.

When the internal buffer becomes full, StringBuilder increases
its capacity. This can cause occasional allocations, but it
avoids the repeated creation and copying of the complete
accumulated result.

The final string is created when ToString() is called after the
loop.

This behavior explains why StringBuilder scaled much better in
the benchmark. At 100,000 iterations, it completed the work in
approximately 0.832 milliseconds and allocated approximately
2.68 MB, while string concatenation took approximately 11.74
seconds and produced far more cumulative allocations.

## 7. Is StringBuilder always better than normal
string operations?

No. StringBuilder is not always the better choice.

Normal string concatenation and string interpolation are
appropriate when combining a small, fixed number of values.
They are concise, readable, and may perform efficiently because
the compiler and runtime can optimize simple string operations.

StringBuilder has its own setup and management overhead. It must
create an internal buffer and eventually convert its content
into a string using ToString(). For a small operation, this
overhead may provide no meaningful benefit.

StringBuilder becomes useful when text is repeatedly appended,
particularly inside large loops or when the final text size is
not known in advance.

In this benchmark, StringBuilder was already faster at 100
iterations, and its advantage increased substantially at larger
loop sizes. These results apply to this repeated-appending
scenario and do not prove that StringBuilder is faster for every
string operation.