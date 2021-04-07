Feature: LyfeStylePrizeAdmin-User
	Calendar part of credit should be tested. Lyfestyle prize is a fastest prize for navigation after dream home.
	So while creating we can switch credits/discount

@mytag
Scenario: LyfeStylePrizeAdmin creation and checking price, discount and all info
	Given admin logged in
    And click Life Style prize
	#creation	
	When click add new prize
    When input Life Style prize (car) title randomly generated
	When upload non house main picture
	When input in about "this car is very expansive and perfect" text
	When click active checkbox
	When choose category "Luxury"
	When choose subcategoty "Ferrary"
	When go to Discount & ticket tab at Life prize
    When input ticket price value 6
    When input default number of tickets 15
	When click on status in Discount tab
	When notice the product with non-discount price 6
	#set calendar discount

	#complete creation
	When go to Discount & ticket tab at Life prize
    When click save button
	Then popup with message "Prize saved" appears
	#notice general discounts
	Given go to general	
	When notice discounts
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania"
	When user go to lifestyleprizes
	When user click on category "Luxury"
	When user click on subCategory "Ferrary"
	When user click on autogenerateg earlier LifeStile Prize title

	When notice all info about product(title, nonDisc price or old price, new price, percent)
	Then product popup appeares
	#Then price should be as was on product 
	Then product name should be as noticed earlier
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	When check total price on product dialog popup and totalSaving
	When notice Credit earned if they exist
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	When user input card data
	And click pay button
	Then user see order completed header
