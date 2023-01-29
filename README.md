How to use Expense Tracker steps:-
1. Copy the code -> open visual studio -> clone repository with copied code.
2. Go to appsettings.json -> DefaultConnection then change the server name with your own MSSQL name.
3. Go to Tools -> Nugate Package Manage -> Package Manger Console, then new CLI will open, write : upgrade-database.
4. Go to Debug -> click start with debuging, then application will be open.
5. There will be two module in the application, 1. Category, 2. Expenses
6. In category module: user create new category, update and delete category. User can not create duplicate category, it will be a validation error.
7. In expenses module: user can add new record by selecting category with the amount and date. User can filter category record between two dates.
