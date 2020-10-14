Feature: CreateUser
	I want Create a User
    

Scenario: Add a User
	Given I input name "Carlos"
	And I input email "carlos@email.com"
	When I send create user request
	Then validate response is ok
