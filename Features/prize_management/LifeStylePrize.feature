Feature: LifeStylePrize
	
@mytag
Scenario: Create Life Style Prize
	Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click Life Style prize
	When click add new prize
    When input Life Style prize title as "LP title"
	When upload non house main picture
	When input in about "about bla bla text" text
	When choose category "At Home"
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button