Feature: Authentification, Authorisation as user in web

  Scenario: as a user i want to be login with valid credentials
    When user go to login page
    And input in email value "proton001@lenta.ru"
    And input in password "sobaka1"
    And click submit
    Then user redirected to user-info page   

  Scenario: checking link sign up here and sign up in upper footer
    When user go to login page
    When user click on Sign up link at top of the page
    Then user see Sign up page
    When user go to login page
    When user click on Sign up here link lower of the page
    Then user see Sign up page

Scenario: as a user i want register the user
    When user go to login page
    When user click on Sign up link at top of the page
    When user autogenerate account and input all
    When user press sign up button
    #When user check i'm 18 checkbox and scroll down
   # And click i agree
    Then user redirected to user-info page
    Then name displayed at right upper footer
    Then user on user-info page should be as expected



