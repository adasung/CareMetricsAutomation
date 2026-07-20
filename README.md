# CareMetrics Automation Framework

This is a local integration testing framework built with C# and .NET 8 to test clinical telemetry data ingestion. It simulates real-time patient monitor devices by generating vital sign payloads (Heart Rate, SpO2) and validating that the microservice layer accepts and processes the data correctly.

## Project Structure & Architecture

The solution is divided into two separate projects to keep the core code independent of the test runner:
*   **FrameworkCore**: Contains the core data models and business logic. It relies purely on native .NET libraries. Keeping third-party dependencies to a minimum is a conscious choice to align with medical device compliance standards, which require strict auditing of external software.
*   **BDDTests**: The test automation layer. It uses Reqnroll and NUnit to implement Behavior-Driven Development (BDD), translating clinical rules and alert conditions into human-readable Gherkin syntax.

## Cross-Platform Setup

Because this framework was developed on macOS but needs to run seamlessly on Windows environment pipelines, a few specific Git rules are configured in the repository root to prevent environmental bugs:
*   `core.autocrlf` is set to ensure line endings are standardized to LF across different operating systems.
*   A `.gitattributes` file handles automatic text normalization.
*   A localized `.gitignore` blocks local machine build files (`bin/`, `obj/`) from cluttering the repository.

## How to Run the Tests

### Prerequisites
*   .NET 8 SDK installed

### CLI Execution
To clean the project, compile the binaries, and execute the test suites, run the following commands in your terminal:

```bash
dotnet clean
dotnet build
dotnet test