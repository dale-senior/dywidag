<h1> Leap Year Calculator (dywidag Tech Test)</h1>
<h2>Overview</h2>
This console application calculates the number of leap years since year 1 and outputs the results to both a CSV and JSON file formats.

<h2>Usage</h2>
Input: The application takes no input parameters. Simply execute the application.
Output: After execution, the application generates two files:
<ul>
  <li>output/LeapYears.csv: A CSV file containing the list of leap years.</li>
  <li>output/LeapYears.json: A JSON file containing the list of leap years.</li>
</ul>
Along with a console output of the total number of leap years 
<h2>Installation</h2>
Clone this repository to your local machine. Ensure you have .net 8 installed. Run "dotnet restore" then "dotnet build" then "dotnet run" to run the application from a terminal.

<h2>Tests</h2>
navigate to the tests solution from the terminal and run "dotnet test" to run the unit tests for the application

<h2>Improvements</h2>
Configuration file
  <ul>
    <li>output path/file name</li>
    <li>logging config</li>
    <li>end date</li>
  </ul>
Docker File
