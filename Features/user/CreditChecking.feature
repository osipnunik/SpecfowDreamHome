Feature: CreditChecking
	Simple calculator for adding two numbers

@mytag
Scenario: check credit sum 
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	#When notice credits and discounts from general page using API
	Then on header should be displayed "Vania"
	When user go to lifestyleprizes
	When click on random category
	When user click and close every prize on page noticing resulting credits and adding them to basket
	When user go basket
	Then user see credit amount at basket and header as noticed earlier
	When close all items in basket

Scenario: check credit sum on different type of prize
	
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	#When notice credits and discounts from general page using API
	Then on header should be displayed "Vania"
	When user go to lifestyleprizes		
	When click on random category
	When user click and close every prize on page noticing resulting credits and adding them to basket
	When scroll up
	When user go to Dream Home page
	When user click on Enter now
	When user add prize dialog credit to noticed credit summ and notice it
	When user go to Fexed Odds
	When user choose randomly element
	When user click on this element
	When user add prize dialog credit to noticed credit summ and notice it
	When user choose randomly element
	When user click on this element
	When user add prize dialog credit to noticed credit summ and notice it
	When user go basket
	#When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	#When user go basket
	Then user see credit amount at basket and header as noticed earlier
	When close all items in basket

	