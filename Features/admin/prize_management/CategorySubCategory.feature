Feature: CategorySubCategory
	Simple calculator for adding two numbers

@admin
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
	Then popup with text "Category created" appears
	Then category with title "Animal" exist
	When click on subcategories
	When click Add Sub-category
	Then Title Add Sub-category is displayed
	When input animal sub-category picture 
	When choose category in subcategory "Animal"
	When admin input title "Dog"
	When click save category
	When click on subcategories
	Then Sub-category with title "Dog" exist
