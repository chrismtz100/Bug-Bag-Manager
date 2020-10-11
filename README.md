# Bug Bag Manager: A Bug Tracking Manager

Bug Bag Manager is a tracking system that keeps track of bugs, errors, glitches, and work logs of a software development team. This project is meant for small teams who are working together and keeping track of things that need to be done.


# Before using BBM, update connectionString. 
If you're trying to clone or download BBM to your machine, you must change your connectionString to your localdb in-order to use the database that is integrated inside of BBM. You need to do the following in order to use in your localhost. 
 1. Open the project in Visual Studios by clicking **Bug Bag Manager.sln**
 2. Open up your **SQL Server Object Explorer** window. (Note: You can find this window by going to the top of window: View > SQL Server Object Explorer). 
 3. Double-click on where it says **SQL Server**
 4. Find where it says **localdb\MYSQLLocalDB** (Note: If you have your own Datebase using PosgreSQL, this might be different)
 5. Right-click localdb and go to **Properties**
 6. Under Properties, find the column item that says **Connection string**. 
 7. On the right side of the "Connection string" column, you should be able to view your connection string. The connectionString starting with the text "Data Source=(localdb)..." 
 8. Copy this text and keep it somewhere safe.
 9. Close the Properties window.
 10. Next, go to **Solution Explorer** where the project files are located (Note: You can find this window by going to the top of window: View > Solution Explorer).  
 11. Under **Bug Bag Manager**, open the file that says **Web.config**.
 12. On Line 12 is the HTML tag called **connectionString**. On Line 13, you should see where it says  `<add  name="BugBagDB"  connectionString="Data Source=..."`
 14. Copy the connectionString you saved from your LocalDB and replace the value inside of the connectionString you see inside of Web.config with your connectionString from your localDB. 
 15. Before building the solution, double check to see if the connectionString value is closed off by quotation marks.
 16. Build the project by pressing **CTRL-B**
 17. Now go to Debug and **Start without Debugging**
 18. Have fun! 
