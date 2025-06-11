# Habit Logger

A simple and interactive command-line application for tracking your daily habits. Easily add, view, update, and delete habits, with all your data managed in a MySQL database.

## Features

- **Add Habits**: Log new habits with a start date and allocated time.
- **View All Habits**: See a list of all your tracked habits in a formatted table.
- **Update Habits**: Mark habits as ended and update their progress.
- **Delete Habits**: Remove habits from your tracking list.

## How It Works

1. **Start the Application**  
   Run the program and you'll be greeted with a menu:
   - Type `a` to add a new habit.
   - Type `v` to view all habits.
   - Type `u` to update a habit.
   - Type `d` to delete a habit.
   - Type `0` to exit.

2. **Habit Management**  
   The application guides you through entering habit details. All changes are saved in a MySQL database.

## Technologies Used

- **Language:** C#
- **Framework:** .NET 8.0
- **Database:** MySQL
- **Libraries:**  
  - [MySql.Data](https://www.nuget.org/packages/MySql.Data) (for database access)  
  - [ConsoleTableExt](https://github.com/minhhungit/ConsoleTableExt) (for displaying tables)

## Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Codersauruse/Habit-tracker.git
   ```

2. **Configure the Database**
   - Ensure you have a MySQL server running.
   - Create a database named `habits`.
   - Update the connection string in `DatabaseConnection.cs` if your MySQL credentials differ:
     ```
     _connectionString = "datasource=localhost;port=3306;database=habits;user=code;password=code123";
     ```
   - Create the required table:
     ```sql
     CREATE TABLE habits (
       habitName VARCHAR(255) PRIMARY KEY,
       startDate DATETIME,
       endDate DATETIME,
       hours INT,
       progress INT
     );
     ```

3. **Build and Run the Application**
   - Open the project in your preferred C# IDE (e.g., Visual Studio or VS Code with the C# extension).
   - Restore NuGet packages.
   - Build and run the project.

## Example Usage

```text
..........Hello Welcome To The Habbit Logger..........

MAIN MENU

What do you like to do :
--------------------------
Type "0" to exit :
Type "v" to View All Habits :
Type "a" to add a Habit :
Type "d" to delete a Habit :
Type "u" to update a Habit :

Enter your choice : a
enter the habit name : Reading
enter the current year : 2025
enter the current month : 6
enter the current day : 10
enter the Allocated time for the habit in minutes(ex:- 60) : 30
```

## License

This project is open-source and available under the [MIT License](LICENSE).

---

**Happy habit tracking!**
