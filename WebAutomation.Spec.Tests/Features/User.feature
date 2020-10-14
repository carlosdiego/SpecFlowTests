Feature: User
	I want Create a User
    

Scenario: User registers
	Given a user opens the Users page
	And the user enters a new name "C Diego L" into the registration form
	And the user enters a valid email "diego@email.com" into the registration form
	When the user submits the registration form
	Then the registration should be successful
    And a new user must be listed

