Feature: FixedOddsUser
	Simple calculator for adding two numbers

Scenario: as a user i want to buy random Fixed odds
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania Jast"
	When user go to Fexed Odds
	When notice all info about first product from fixedOddsList
	When click on first Fixed Odds prize

	Then product popup appeares
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	Then user check total price, total saving, them currency %Off
	When notice Credit earned if they exist
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user calculate data from multiple products
	#Then user see Total Saving and Credit earned as expected if they exist
	When user click Pay
	Then user redirected to cards payment page
	When user input card data
	And click pay button
	Then user see order completed header
