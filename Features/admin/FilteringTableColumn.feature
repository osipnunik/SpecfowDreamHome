Feature: FilteringTableColumn
	all tests concerning filtering

@mytag
Scenario: Filtering table column on LyfeStyle by title
	Given admin logged in
    And click Life Style prize	
	#When check pagination to 100
	When notice last title and category and subcategory
	When click on title dropdown
	When input noticed title in filter input
	When choose noticed earlier title
	When click filter button
	When close second filter popup
	When check pagination to 100
	Then all titles in table should be as noticed earlier
	And categories should be the same
	And subcategories should be the same

Scenario: Filtering of categories should contain all existing categories
	Given admin logged in
    And click Life Style prize	
	When click on LyfeStyle Management
	When check pagination to 100
	When notice all categories
	When click on subcategories
	When notice all subCategories
	When click opened Life Style prize
	When click on Category dropdown
	Then in list should be all categories
	When close third filter popup
	When click on Sub-Category dropdown
	Then in list should be all sub categories

Scenario: Filtering table column on Fixed Odds by title
	Given admin logged in
    And click Fixed odds
	When notice first title
	When click on title dropdown
	When input noticed title in filter input
	When choose first appeared
	When click filter button
	When close second filter popup
	Then all titles in table should be as noticed earlier
	



