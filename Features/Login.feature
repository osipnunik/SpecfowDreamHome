Feature: Authentification, Authorisation as user in web

  Scenario: as a user i want to be login with valid credentials
    When user go to login page
    And input in email value "proton001@lenta.ru"
    And input in password "sobaka"
    And click submit
    Then user redirected to dream house page

  

