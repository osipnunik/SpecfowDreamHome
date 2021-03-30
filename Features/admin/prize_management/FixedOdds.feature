@admin
Feature: Fixed odds scenarios	

Scenario: Create fixed odds Prize
	Given admin logged in
    And click Fixed odds
	When click add new prize
    When input Life Style prize (car) title randomly generated
	When upload non house main picture
	When input in about "Mi Watch Lite is not just a smart watch, it has its own unique personality.There are three color options for the watch case, five color options for the strap,over 120 themed watch faces and watch face function customization* to satisfy your ever-changing style." text
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 10	
	When input Number of tickets value 15
	When click on status in Discount tab
    When click save button
	Then popup with message "Fixed Odds saved" appears
	And created title exist in list
	
Scenario: check arithmetically active, unactive and all Fixed Odds
	Given admin logged in
    And click Fixed odds
	When Change pagination to 100 with wait
	When notice all prizes titles quantity
	When click on Active prizes
	When notice active prizes titles quantity
	When click on Unactive prizes
	When notice unactive prizes titles quantity
	Then all prizes should be equal the sum of active and unactive

Scenario: check tickets creation of fixed odds prizes and quontity decreasing 
	Given admin logged in
    And click Fixed odds
	When click on Active prizes
	When notice titles, Number of tickets and Tickets left
	When admin go to UserManagement page
	When click edit last user
	When go to ticket tab
	When add first 10 fixed odds tickets 
	Given click Fixed odds
	When click on Active prizes
	Then tickets left should decrease on 2, Numbers of tickets should be the same as a Titles
	#When click Add ticket
	#Then form with title "Add tickets" should appeared
	#When choose Fixed Odds ticket
	#When notice Competition and Product and number
	#When click save
	#Then last ticket should be with product and competition type as expected