Feature: NavBar

@navbarregister
Scenario: check working of nav bar Register Option
	Given user is on home page
	When user click on Register option
	Then user is redirected to Register page

Scenario: check working of nav bar Login Option
	Given user is on home page
	When user click on Login option
	Then user is redirected to Login page