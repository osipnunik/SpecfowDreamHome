@admin
Feature: Referrals
	All tests for referrals

Scenario: Saving default values for user
	Given admin logged in
	And go to referrals	
	When admin check first user
	And input in default amount random number from 0 to 250
	And click Save default values for users
	Then admin see referrals page
	Then the first user has default value as generated earlier
	Then text message "default value has been set" appeared
