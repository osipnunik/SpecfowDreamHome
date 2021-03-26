Feature: LifeStylePrizeAdmin
	
@mytag
Scenario: Create Life Style Prize
	Given admin logged in
    And click Life Style prize
	When click add new prize
    When input Life Style prize (car) title randomly generated
	When upload non house main picture
	When input in about "this car is very expansive and perfect" text
	When choose category "Luxury"
	#When choose subcategoty "Cars"
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button
	Then popup with message "Prize saved" appears
	And Life Style prize title generated earlier is present with category "Luxury"

Scenario: check arithmetically active, unactive and all LifeStilePrizes
	Given admin logged in
    And click Life Style prize
	When Change pagination to 100 with wait
	When notice all prizes titles quantity
	When click on Active prizes
	When notice active prizes titles quantity
	When click on Unactive prizes
	When notice unactive prizes titles quantity
	Then all prizes should be equal the sum of active and unactive
	
