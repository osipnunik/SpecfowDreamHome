Feature: LifeStylePrizesUser

#@ignore
@user
Scenario: as user i want to see all info on LyfeSycle prize site as on admin LifeSycle prize page
	Given admin logged in
    And click Life Style prize
	When change paginarion prizes per page as 100   
	When go to active life style prizes          
	When logged admin get all lifeStylePrizes and notice them

	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	When user go to lifestyleprizes
	When notice list of categories
	Then admin category, subcategory, title should be same as on user site


Scenario: as a user i want to buy on basket from account
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	Then on header should be displayed "Vania Jast"
	When user go to lifestyleprizes	
	When click on first product
	When notice all info about product(title, nonDisc price or old price, new price, percent)
	Then product popup appeares
	Then price should be as was on product 
	Then product name should be as noticed earlier
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
	When check total price on product dialog popup and totalSaving
	When notice Credit earned if they exist
	When user click on buy now 
	Then user on basket page
	Then user see title, price per ticket, total amount of ticket and total price as expected
	Then user see Total Saving and Credit earned as expected if they exist
	When user click Pay
	Then user redirected to cards payment page
	When user input card data
	And click pay button
	Then user see order completed header

