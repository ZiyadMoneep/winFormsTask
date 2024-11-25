# User Authentication System

A simple **WinForms** app for managing user authentication. The app handles user registration, validation, and email updates using in-memory data storage.

## Features

- **User Registration**:
  - Validates email format.
  - Ensures strong passwords (length, cases, numbers, and special characters).
  - Checks for duplicate emails.
  - Verifies matching passwords.

- **User Authentication**:
  - Validates login credentials.
  - Supports in-memory user data storage.

- **Update Email**:
  - Allows updating user email while ensuring uniqueness.

- **Unit Testing**:
  - Tested with **xUnit** to verify registration, validation, and email updates.

## How to Use

1. Clone the repository and open the project in **Visual Studio**.
2. Build the project.
3. Run the app to test its functionality.

## Future Ideas

- Add a **database** for persistent storage.
- Improve the UI for better usability.
- Expand testing to include integration scenarios.

## Building an EXE

1. In Visual Studio, go to **Build** > **Publish**.
2. Choose a target folder or deployment method.
3. Configure and publish the executable.

---
