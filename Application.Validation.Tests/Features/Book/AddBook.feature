Feature: CreateBook

Create Book

Background: 
    Given available authors are:
        | firstName | lastName | birthDay   | id |
        | jean      | Ferra    | 1985-05-01 | 1  |
        | Joe       | Labat    | 1982-01-01 | 2  |

@OK
Scenario: I want to add a new Book
    Given I have a new book to add
    And I had alredy register the Author
    When I add the book
    Then The book is added

@KO
Scenario: I want to add a Book Alredy registred
    Given a list of book :
    | title | Autor |
    |   livre1    | Gide |
    |   livre2    | King |
    And I have a new book 'livre1' to add
    When I add the book to the validator
    Then An ValidationException is raised by the validator

@KO
Scenario: I want to add a new Book without Title
    Given I have a new book without title to add
    When I add the book to the validator
    Then An ValidationException is raised by the validator
