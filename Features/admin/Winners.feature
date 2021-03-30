Feature: Winners
	Simple Winners scenarios

@mytag
Scenario: Sorting and displaying should work properly
	Given admin logged in
	When admin go to Winners page
	Then  admin see following colume:
	|   columns   |
	#| Competition# |
	#| Competition  |
	| Finish date  |
	|     Title    |
	|    Actions   |
	#When admin click downsorting on column CompetitionSharp
	#Then All competitionSharp sorted downward
	#When admin click downsorting on column Competition
	#Then All competition sorted downward
	When admin click downsorting on column FinishDate
	Then All FinishDate sorted downward
	When admin click downsorting on column Title
	Then All Titles sorted downward
	#When admin click upsorting on column CompetitionSharp
	#Then All competitionSharp sorted upward
	#When admin click upsorting on column Competition
	#Then All competition sorted upward
	When admin click upsorting on column FinishDate
	Then All FinishDate sorted upward
	When admin click upsorting on column Title
	Then All Titles sorted upward

Scenario: Create Winner and delete him
	Given admin logged in
	When admin go to Winners page
	When admin click on add new winner
	#When admin choose product "609 Keith Cape"
	#And go to description 
	When input random title
	When input picture
	And click Save
	When click Winners
	Then message with text "Winner saved" should appeared
	When Change pagination to 25
	When click Last page
	Then winner with generated title should present in winner list
	When delete winner with title
	Then winner with title should not present in winner list
	Then message with text "Winner has been deleted." should appeared

	