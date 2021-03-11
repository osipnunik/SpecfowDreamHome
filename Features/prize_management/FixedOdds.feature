Feature: Fixed odds scenarios
	
@mytag
Scenario: Create fixed odds Prize
	Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click Fixed odds
	When click add new prize
    When input Life Style prize title as "fixed odds testTitle"
	When upload non house main picture
	When input in about "about test fixed odds" text
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button