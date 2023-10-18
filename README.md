# Task

Upon launching the application, it should create a SQLite database (if it doesn't already exist) with two related tables: Modes and Steps. The Modes table should have the following columns: ID, Name, MaxBottleNumber, MaxUsedTips. The Steps table should have the following columns: ID, ModeId, Timer, Destination, Speed, Type, Volume. Additionally, a table for users and their roles has been added, and foreign key relationships need to be established.

The application should feature user registration and authentication capabilities. Users should be able to view, delete, and edit records in the tables. It should also allow users to add new records by importing data from an Excel document. The login names must be unique and not repeated, and passwords must meet the following criteria: a minimum of 6 characters, including at least one digit and one letter.

Key Requirements:
 - Database Creation: The application should create an SQLite database with two tables: Modes and Steps. Modes contain ID, Name, MaxBottleNumber, and MaxUsedTips, while Steps contain ID, ModeId, Timer, Destination, 
   Speed, Type, and Volume.

 - User Management: Implement user registration and authentication, ensuring unique login names and password requirements (at least 6 characters, including at least one digit and one letter).

 - CRUD Operations: Users should be able to perform Create, Read, Update, and Delete operations on the data in the tables.

 - Excel Data Import: Allow users to add records by importing data from an Excel document.

 - Foreign Keys: Establish relationships between the tables using foreign keys for data integrity.
