Feature: FixedOddsUser
	Simple calculator for adding two numbers

Scenario: as a user i want to buy random Fixed odds
	When user(client) login on web with login "proton001@lenta.ru" and pass "sobaka"
	Then on header should be displayed "test CmdKYgZIVO"
	When user go to Fexed Odds
	When notice all info about first product from fixedOddsList
	When click on first product

	Then product popup appeares
	When user choose number randomly
	Then he will see that number in TICKETS QUANITY
