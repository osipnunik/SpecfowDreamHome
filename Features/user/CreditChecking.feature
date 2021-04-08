Feature: CreditChecking
	Simple calculator for adding two numbers

@mytag
Scenario: check credit sum 
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka1"
	When get credits from general page using API
	Then on header should be displayed "Vania"
	When user go to lifestyleprizes
	When click on random category
	When user click and close every prize on page noticing resulting credits and adding them to basket
	When user go basket
	Then user see credit amount at basket and header as noticed earlier
	When close all items in basket