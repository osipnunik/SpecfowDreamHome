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

@admin
Scenario: checking prize discounts of fresh-created Fixed odds with fixed odds discounts
	Given admin logged in
	Given go to general	

	When notice discounts 
	Given admin logged in
	And click Fixed odds
	When click add new prize
    When input Life Style prize (car) title unique randomly generated
	When upload non house main picture
	When input in about "Car about text." text
	When click active checkbox
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 10	
	When input Number of tickets value 100
	When go to Discount & ticket tab at Life prize

	When make discount percents at Fixed Odds bigger on 1 than on general admin page
	#When click on status in credits tab	
	When click on status in discounts tab	
	#When set credits euroes and percents as defined earlier
	When set discounts amount and percents as defined earlier

	When click fixed odds save button	
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania"
	#Jast"
	When user go to Fexed Odds
	When user scroll untill additional prizes appeared
	When click on earlier random generated title
	
	Then product popup appeares
	Then check default number of tickets 11, total Number of tickets as 102 and ticket old price value as 7
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	Then user check total price, total saving, them currency %Off
	Then discount table are as noticed earlier
	When notice Credit earned if they exist
	#Then credit calculated as at Admin General expected
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	#When user click Pay
	#Then user redirected to cards payment page
	When user input card data
	And click pay button
	Then user see order completed header
	
@admin
Scenario: checking discounts of fresh-created Fixed odds without fixed odds discounts
	Given admin logged in
	And click Fixed odds
	When click add new prize
    When input Life Style prize (car) title unique randomly generated
	When upload non house main picture
	When input in about "Car about text." text
	When click active checkbox
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 10	
	When input Number of tickets value 100
	When go to Discount & ticket tab at Life prize
	When click on status in credits tab
	When click fixed odds save button
	Given go to general	
	When notice discounts
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania"
	#Jast"
	When user go to Fexed Odds
	When user scroll untill additional prizes appeared
	When click on earlier random generated title
	
	Then product popup appeares
	Then check default number of tickets 10, total Number of tickets as 100 and ticket old price value as 6
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	Then user check total price, total saving, them currency %Off
	Then discount table are as noticed earlier
	When notice Credit earned if they exist
	#Then credit calculated as at Admin General expected
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	#When user click Pay
	#Then user redirected to cards payment page
	When user input card data
	And click pay button
	Then user see order completed header

@admin
Scenario: checking credits of fresh-created Fixed odds without fixed odds credit
	Given admin logged in
	And click Fixed odds
	When click add new prize
    When input Life Style prize (car) title unique randomly generated
	When upload non house main picture
	When input in about "Car about text." text
	When click active checkbox
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 10	
	When input Number of tickets value 100
	When go to Discount & ticket tab at Life prize
	When click on status in Discount tab
	When click fixed odds save button

	Then admin redirected to foxed odds list
	Then popup with message "Fixed Odds saved" appears
	Given go to general	
	When click on credit
	Then notice credits and check it with credits per Funt
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania"
	#Jast"
	When user go to Fexed Odds
	When notice initial credit amount
	When user scroll untill additional prizes appeared
	When click on earlier random generated title
	
	Then product popup appeares
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	Then user check total price, total saving, them currency %Off
	When notice Credit earned if they exist
	Then credit calculated as at Admin General expected
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	#When user click Pay
	#Then user redirected to cards payment page
	When user input card data
	#Then credit amount should be the sum of initial credit amount and rememberd 
	When click pay button
	Then user see order completed header
	#Then credit on header should be zero

@admin
Scenario: checking credits of fresh-created Fixed odds with fixed odds credit(not on general)
	Given admin logged in
	Given go to general	
	When click on credit
	Then notice credits and check it with credits per Funt
	Given click Fixed odds
	When click add new prize
    When input Life Style prize (car) title unique randomly generated
	When upload non house main picture
	When input in about "Car about text." text
	When click active checkbox
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 10	
	When input Number of tickets value 100
	#When go to Discount & ticket tab at Life prize
	When make credit percents at Fixed Odds bigger on 1 than on general admin page
	When click on status in credits tab	
	When set credits euroes and percents as defined earlier
	When click fixed odds save button
	
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania"
	#  Jast"
	When user go to Fexed Odds
	When notice initial credit amount
	When user scroll untill additional prizes appeared
	When click on earlier random generated title
	
	Then product popup appeares
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	Then user check total price, total saving, them currency %Off
	When notice Credit earned if they exist
	Then credit calculated as at Admin General expected
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	#When user click Pay
	#Then user redirected to cards payment page
	When user input card data
	#Then credit amount should be the sum of initial credit amount and rememberd
	When click pay button
	Then user see order completed header
	#Then credit on header should be zero

	
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

Scenario: check tickets creation of fixed odds prizes and quantity  decreasing 
	Given admin logged in
    And click Fixed odds
	When click on Active prizes in cycle
	When click upsort IDes
	When click lastPage
	When notice titles, Number of tickets and Tickets left
	When admin go to UserManagement page

	When admin click on add new user
	And input autogenerated user
	And click save user button
	Then message with text "User saved" should appeared
	When admin go to UserManagement page
	Then last user should be as generated

	When click edit last user
	When go to ticket tab
	When add first 10 fixed odds tickets 
	Given click Fixed odds
	When click on Active prizes in cycle
	When click upsort IDes
	When click lastPage
	Then tickets left should decrease on 2, Numbers of tickets should be the same as a Titles
	#When click Add ticket
	#Then form with title "Add tickets" should appeared
	#When choose Fixed Odds ticket
	#When notice Competition and Product and number
	#When click save
	#Then last ticket should be with product and competition type as expected

