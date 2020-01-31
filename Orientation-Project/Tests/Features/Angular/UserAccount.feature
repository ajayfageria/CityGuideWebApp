Feature: UserAccount

Scenario Outline: Register a new user
	Given user is on home page
	When user click on Register option
	Then user is redirected to Register page
	Then user register a new user with  '<Email>','<FullName>','<UserName>','<Password>' in the Registeration form
	Then user should be successfully registered from the page
Examples:
| Email           | FullName   | UserName  | Password | 
| test10@gmail.com | test10    | test10    | test@10  | 