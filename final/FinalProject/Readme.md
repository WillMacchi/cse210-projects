## Description
This program is a personal finance tracker created in C# as an open-ended final project. The purpose of the program is to help users keep track of their money by recording income and expense transactions, organizing them, and displaying a summary of their financial activity.

The program allows users to enter transactions, sort them, review spending habits, and monitor simple budget categories. It was designed to be a practical example of object-oriented programming while also creating something that could realistically be useful.

---

## What the Program Does
This program allows the user to:

- Add income transactions
- Add expense transactions
- View all saved transactions
- View a financial summary
- Sort transactions by date
- Sort transactions by amount
- Create budget categories with spending limits
- Check whether spending in a category is over budget
- Save data to files
- Load saved data when the program starts

---

## How to Use the Program
When the program starts, a menu will appear in the console. The user can type the number for the option they want to use.

### Main Menu Options
1. **Add Income**  
   Adds a new income transaction.

2. **Add Expense**  
   Adds a new expense transaction.

3. **View All Transactions**  
   Displays all transactions currently saved in the program.

4. **View Financial Summary**  
   Shows:
   - Total income
   - Total expenses
   - Current balance

5. **Sort Transactions by Date**  
   Sorts all transactions by date.

6. **Sort Transactions by Amount**  
   Sorts all transactions by amount.

7. **Add Budget**  
   Lets the user create a spending limit for a category.

8. **Check Budgets**  
   Displays how much has been spent in each budget category and whether the user is over budget.

9. **Save Data**  
   Saves transactions and budgets to files.

10. **Exit**  
   Saves the data and closes the program.

---

## Transaction Information
Each transaction includes:

- ID number
- Date
- Amount
- Category
- Description

### Income Transactions
Income transactions also include:
- **Source**

Examples:
- Paycheck
- Gift
- Refund
- Side job

### Expense Transactions
Expense transactions also include:
- **Payment method**

Examples:
- Debit Card
- Credit Card
- Cash

---

## Budget Feature
The program includes a simple budget system. Users can create budget categories such as:

- Food
- Gas
- Entertainment
- Shopping
- School

Each budget category has a spending limit. The program can compare the user’s expense transactions to the budget amount and let them know if they are over budget in that category.

---

### Classes Used
- `Transaction`  
  Base class for all transactions

- `IncomeTransaction`  
  Inherits from `Transaction` and stores income-specific information

- `ExpenseTransaction`  
  Inherits from `Transaction` and stores expense-specific information

- `BudgetCategory`  
  Stores budget category names and spending limits

- `FinanceTracker`  
  Handles the main financial logic, including storing transactions, calculating totals, sorting, and checking budgets

- `FileManager`  
  Handles saving and loading transaction and budget data from files

- `Program`  
  Runs the menu system and user interaction in the console

---

## Important Notes
- This is a **console application**, so all interaction happens in the terminal/console window.
- The program saves transaction and budget data to text files.
- If the program is closed normally using the menu, it should save data automatically.
- If invalid input is entered (such as letters instead of numbers for amounts), the program may need to be run again depending on the current version.
- Transactions are separated into income and expense types using inheritance.

---

## Files Used
The program saves data using text files:

- `transactions.txt`
- `budgets.txt`

These files are created automatically when the user saves data or exits the program.

---

## How to Run the Program
1. Open the project in **Visual Studio**
2. Build and run the program
3. Follow the menu prompts shown in the console
4. Enter transaction or budget information when prompted

---
