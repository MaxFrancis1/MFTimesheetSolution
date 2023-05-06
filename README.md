# MFTimesheetSolution

This is a basic timesheet solution based.

Introduction of how to use.
Run program.
Enter a job eg 1stJob into the job field and enter a value for job hours then click button 'Create Job'.
Select 1stJob in job drop down and enter an employee eg John into the employee field and click button 'Create Employee'.
Re-select the 1stJob in the Job dropdown and select the John in the employee drop down. Now input a week ending date eg 20230505 using the date field and click the 'Create Timesheet' button.
Click 'Refresh' button.
To edit the timesheet you can enter how many hours John has spent on 1stJob for each day of the week and click the 'Save' button.

This is generally how to use the timesheet solution, more features follow below.

You can delete a timesheet for a specific job/employee by using the delete button.
You can view all timesheets on a specifc job by selecting that with no employee selected
When a employee goes over 10 hours in one day an email will be sent (due to no SMTP I have commented out this code and replaced it with a alert, if you wanted to add this everything is in the TimesheetService file ready to go)
By using the Print Report button you are able to print the currently displayed timesheet.
By using the calculate remaining hours button the timesheet will let you know the remaining hours on the job or let you know if it is over the predicted hours.

Thanks :)
