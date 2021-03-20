Feature: LifeStylePrizeAdmin
	
@mytag
Scenario: Create Life Style Prize
	Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click Life Style prize
	When click add new prize
    When input Life Style prize (car) title randomly generated
	When upload non house main picture
	When input in about "this car is perfect" text
	When choose category "Motors"
	When choose subcategoty "Cars"
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button
	Then popup with message "Prize saved" appears
	And Life Style prize title generated earlier is present with category "Motors"