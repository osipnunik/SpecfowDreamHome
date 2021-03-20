﻿Feature: UserManagement
	all scenarion from UserManagement

Scenario: creation of user and remooving him
	Given admin logged in
	When admin go to UserManagement page
	When admin click on add new user
	And input autogenerated user
	And click save user button
	Then message with text "User saved" should appeared
	When admin go to UserManagement page
	Then last user should be as generated
	When delete last user
	Then last user should not be as generated

Scenario: while edditing and remooving user add 1 ticket
	Given admin logged in
	When admin go to UserManagement page
	When admin click on add new user
	And input autogenerated user
	And click save user button
	Then message with text "User saved" should appeared
	When admin go to UserManagement page
	Then last user should be as generated
	When click edit last user
	When go to ticket tab
	When click Add ticket
	Then form with title "Add tickets" should appeared
	When notice Competition and Product and number
	When click save
	Then last ticket should be with product and competition type as expected
	When click edit on last ticket order
	And click remove icon in new form
	Then last ticket should not be with product and competition type as expected