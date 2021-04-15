Feature: SortingTable
	comment

@mytag
Scenario: Sorting table on LifeStyle prizes
	Given admin logged in
    And click Life Style prize
	When click downsort IDes
	#When change pagination 100
	Then all IDes should be downsorted
	When click downsort Title
	Then all Titles should be downsorted
	When click downsort Category
	Then all Categories should be downsorted
	When click downsort Sub-Category
	Then all Sub-Categories should be downsorted
	When click lastPage

	Then all Sub-Categories should be downsorted
	When click upsort IDes
	Then all IDes should be upsorted
	When click upsort Title
	Then all Titles should be upsorted
	When click upsort Category
	Then all Categories should be upsorted
	When click upsort Sub-Category
	Then all Sub-Categories should be upsorted

@mytag
Scenario: Sorting table on Fixed Odds
	Given admin logged in
    And click Fixed odds
	When click downsorting Fixed odds idies
	Then all Fixed odds IDes should be downsorted
	 When click downsort Title
	Then all Titles should be downsorted
	When click upsort Title
	Then all Titles should be upsorted

Scenario: Sorting of user management
    Given admin logged in
    And go to user management
	When click downsort first name
	Then all first names should be downsorted
	When click downsort last name
	Then all last names should be downsorted
	When click downsort email address
	Then all email addresses should be downsorted
	When click downsort phone
	Then all phones should be downsorted

	When click upsort first name
	Then all first names should be upsorted
	When click upsort last name
	Then all last names should be upsorted
	When click upsort email address
	Then all email addresses should be upsorted
	When click upsort phone
	Then all phones should be upsorted

Scenario: Sorting on staff management
	Given admin logged in
    And go to staff management
	When click downsort first name
	Then all first names should be downsorted
	When click downsort last name
	Then all last names should be downsorted
	When click downsort email address
	Then all email addresses should be downsorted

	When click upsort first name
	Then all first names should be upsorted
	When click upsort last name
	Then all last names should be upsorted
	When click upsort email address
	Then all email addresses should be upsorted
