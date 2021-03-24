Feature: ShowResponseRedirectCheck
	Simple calculator for adding two numbers

@mytag
Scenario: Redirect check
	When user go to main page
	When user click on Enter now
	Then user redirected to page "lifestyleprizes"
	#Then product popup appeares
	When display time from last clicking
	When user go to main page
	#When user click on second Enter now
	#Then product popup appeares
	#When display time from last clicking
	When user click on Find out more 
	#Then product popup appeares
	#Then user redirected to page "about us"
	
	When user go to main page
	When user click on Find out more at "Dream Home"
	Then user redirected to page "dreamhome"
	When display time from last clicking

	When user go to main page
	When user click on Find out more at "Lifestyle Prizes"
	Then user redirected to page "lifestyleprizes" 
	When display time from last clicking

	When user go to main page
	When user click on Find out more at "Fixed Odds"
	Then user redirected to page "fixedodds"
	When display time from last clicking
