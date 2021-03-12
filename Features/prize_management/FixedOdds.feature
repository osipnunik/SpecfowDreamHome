Feature: Fixed odds scenarios
	
@mytag
Scenario: Create fixed odds Prize
	Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click Fixed odds
	When click add new prize
    When input Life Style prize title as "fixed odds testTitle"
	When upload non house main picture
	When input in about "Mi Watch Lite is not just a smart watch, it has its own unique personality.There are three color options for the watch case, five color options for the strap,over 120 themed watch faces and watch face function customization* to satisfy your ever-changing style." text
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button
	
	