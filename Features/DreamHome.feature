Feature: DreamHome
	Simple 

Scenario: As an administrator, I want to add new prizes for other users to view.
    Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    #When admin go to dream home page
    And click add new dream home
    When admin input title as "testHome11"
    When admin input address as "citing lang 2"
    When choose start and finish date
    #When swith in trending toggle
    When go to Description tab
    When input badroom desctiption as "My test badroom description."
    When download badroom picture
    #When input bathroom desctiption as "My test bathroom description."
    #When download bathroom picture
    #When input Outspace  desctiption as "My test Outspace  description."
    #When download Outspace picture
    #When add about descrition as "about my flat"
    #When go to discount & ticket tab
    #And input price as 35
    #And Click Save
    #Then user login as user on web