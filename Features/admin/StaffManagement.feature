Feature: StaffManagement
	Simple calculator for adding two numbers

@mytag
Scenario: Create Stuff 
	Given admin logged in
	When admin go to staff Management page
	When admin click on add new user
	When autogenerate and notice user
	When input first name, last name, address	
	And input skype
	When click save staff 
	Then message with text "User saved" should appeared
	When scroll to staff Management href
	When admin go to staff Management page
	Then staff user should be created
	


