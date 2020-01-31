Feature: Admin
	
Scenario Outline: Register a new Admin
	When user logs in with '<AdminUsername>' and '<AdminPassword>'
	And user sends a request to register new admin with  '<Email>','<FullName>','<UserName>','<Password>'
	Then user should get response with code '<Code>'
	When user logs in with '<UserName>' and '<Password>'
	Then user should get a token with the Role '<Role>' with status code <Code1>
Examples:
| Email            | FullName | UserName | Password | Code | AdminUsername | AdminPassword | Code1 | Role     |
| test11@gmail.com | test11   | test11   | test@11  | 200  | Admin         | Admin@123     | 200  | Admin     |
| test13@gmail.com | test13   | test13   | test@13  | 403  | test10        | test@10       | 400  | Traveller |


#Scenario Outline: Add a new Entity
#	When user is logged in as Admin
#	And user sends a new request to add a Tourist Entity
#	Then user should get response with code '<Code>'