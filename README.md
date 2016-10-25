
Task 1: CRUD

•	Need to implement simple ASP.NET MVC CRUD application. The domain model which covers all requirements of this task displayed on the figure 3.0. Besides this application should meet the requirements below.

1.	The application should contain 2 pages. For more information see figures 1.0 and 2.0;

2.	“Manage user” page should contain following fields:

-	Email;
-	Name;
-	Surname;
-	Birth Date which should be displayed using custom editor template.

3.	“List of users” page should contain grid with following columns:

- Name which should be build using following template “{Name} {Surname}”;
- Birth Date which should be displayed using custom display template;
- Company;
- Actions.

4.	“List of users” should have appropriate functionality for deleting user. See figures for more information.

Task 2: Validation

•	Need to add fluent based validation:
- Email is correct;
- Email is required;
- Name and Surname is required;
- The maximum number of users for one company is N (Configured value).

Task 3: Advanced Parameters Binding
•	Need to add “titles” functionality to the application. For more details see figures 1.0, 2.0 and 4.0.

Task 4: Filters

•	Need to implement custom filters of all mentioned types. Custom filters should log all method executions for the filters (need to override all possible methods and log all calls). The logs should be displayed for all pages of the application. Concept of master page should be applied. Some details of panned view has displayed on the figure 1.0.

Task 5: Asynchronous Controllers

•	Add possibility to upload photo for each user. User list should display small version of uploaded photo (icon) for each user. 
Details:
- Photo resizing should be performed dynamical for each icon request. Asynchronous controllers should be applied in appropriate way.
- DB should contain relative links to the photos only. Blob files should be stored on file system.
