Feature: CategorySubCategory
	Simple calculator for adding two numbers

@mytag
Scenario: Category and Sub-category creation
	Given admin logged in
    And click Life Style prize
	When click on LyfeStyle Management
	When click add category
	Then Title Add category is displayed
	When input animal category picture 
	When make status active
	When admin input title "Animal"
	When click save category
	Then category with title "Animal" exist
	When click on subcategories
	When click Add Sub-category
	When input animal sub-category picture 
	When choose category "Animal"
	When admin input title "Dog"
	When click save category
	Then Sub-category with title "Dog" exist