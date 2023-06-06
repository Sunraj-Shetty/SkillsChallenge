## The purpose of this app is to test your skills in .net and angular.  Below you will find a set of tasks to be performed.  You may complete as many or as few as you woudl like.

### Before you begin please fork this repository and work in your own instance. (https://docs.github.com/en/search?query=forking)

## Tasks
1. Bug Fix:  We have a memory leak somewhere in our application.  The description from the user is as follows:
	> For my job I have to navigate between people and places.  As the day gets later my browser seems to slow down a lot.
	
	The performance team ran some tests and found that memory is going up from 5 MB on load to 2 GB after only a couple of hours.
2. Bug Fix:  Navigation issue.  The description from the user is as follows:
	> When I click on the Things nav item nothing happens

3. Enhancement:  The users would like to see the search results cached for at least 2 minutes.  Introduce code that could accomplish this.

4. Refactor:  Remove the X-Powered-By response header

5. Refactor:  The quality of this application can be improved.  In your role as a great developer, please refactor/improve this application as you seem fit.  I know we can create a product that is easier to read by other developers, improve the quality and provide more functionality for our clients.

### For the following you may write code to demonstrate or just describe how it could be done

1. Is DbContext used in a thread safe manner?
	As per my understanding DbContext is used in entity framework is not thread safe, as each instance of DbContext is used in a single threaded manner within a specific unit of work. When multiple thread try to access the same DbContext it may lead to data inconsistency or concurrency issue may arise.
	Better to use seprate instance of DbContext for each thread  or by using lock/synchronization mechanisms to interact with the database.

2. What would be the server side steps to add an ability to input a new Person record?
	* first need to define the Person entity class to represent the data.
	* Next need to create a API endpoint to handle the request for adding a new person's record.
	* Need to validate the input data from the request.
	* Using entity framework or any other data access techniques to insert the person's data into the database.
	* Additional logic or validations if required, needs to be implemented.
	* Return the respective response to the request method to ensure the success or the failure of the operation.
	
3. What are the security concerns with data UPSERT?  How would you resolve those concerns?
	The security concerns with data UPSERT are:
		* Ensure the user have the authorized permission to perform the UPSERT operation.
		* Validation of the input data is required to prevent unexpected input.
		* Proper constraints, data validations and the referal integrity needs to be implemented.
		* Maintain the timestamps of the user information to trail the UPSERT operation.
	The resolution for the above security cocerns are:
		* Implement proper authentication and authorization.
		* Use certain quries or statements to prevent undefined inputs.
		* Apply proper data validation and utilize the use of database constarints like UNIQUE or the FORIEGN key constarints to enforce data integrity.
		* Maintain logs of the operations.