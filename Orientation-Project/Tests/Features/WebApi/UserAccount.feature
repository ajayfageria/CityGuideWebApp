Feature: User Accounts

Scenario Outline: Register a new user
	When user register a new user with  '<Email>','<FullName>','<UserName>','<Password>'
	Then user should be successfully registered
Examples:
| Email           | FullName   | UserName  | Password | Code |
| test10@gmail.com | test10    | test10    | test@10  | 200  |



Scenario Outline: User login with valid credentials
	When user logs in with '<UserName>' and '<Password>'
	Then user should get a token with the Role '<Role>' with status code 200
Examples:
| UserName | Password  | Role      |
| test2    | test@12   | Traveller |
| Admin    | Admin@123 | Admin     |



Scenario Outline: User login with invalid credentials
	When user logs in with '<UserName>' and '<Password>'
	Then user should not get a token with a status code 400 with error message '<error>'
Examples:
| UserName | Password | error                             |
| test1    | test1    | Username or Password is incorrect |
| test1    |          | Username or Password is incorrect |
|          | test1    | Username or Password is incorrect |


Scenario Outline: Invalid Registration
	When user register a new user with  '<Email>','<FullName>','<UserName>','<Password>'
	Then user should not be able to register the user due to '<error>' and '<Code>'
Examples:
| Email           | FullName | UserName | Password | Code | error                       |
| test2@gmail.com | test2    | test2    | test@12  | 400  | DuplicateUserName           |
| test2@gmail.com | test2    | test2    |          | 400  | PasswordTooShort            |

