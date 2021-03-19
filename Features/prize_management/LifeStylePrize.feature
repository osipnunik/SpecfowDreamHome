Feature: LifeStylePrize
	
@mytag
Scenario: Create Life Style Prize
	Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click Life Style prize
	When click add new prize
    When input Life Style prize title as "Xiaomi watch"
	When upload non house main picture
	When input in about "Mi Watch Lite is not just a smart watch, it has its own unique personality.There are three color options for the watch case, five color options for the strap,over 120 themed watch faces and watch face function customization* to satisfy your ever-changing style." text
	When choose category "At Home"
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
    When click save button