Feature: CreateBook

Create Book

Background: 
    Given available authors are:
        | Id | First Name | Last Name | Birthday   | Gender |
        | 1  | jean      | Ferra    | 1985-05-01 | Male   |
        | 2  | Léa       | Labat    | 1982-01-01 | Female |
        | 3  | Nath       | Klein    | 1985-24-04 | Male |
    And available Books are :
        | Title                      | Description                            | Author Id |
        | Une archi presque parfaite | Comment faire de la clean Architecture | 1         |
        | la cuisine pour les nulles | Comment faire de la cuisine            | 2         |

@OK
Scenario: I want to add a new Book
    Given I have a new book to add :
        | Title                      | Description                            | Author Id |
        | Frite presque parfaite     | Comment faire des bonnes frites        | 3         |
    When I add the book
    Then The book is added

@KO
Scenario: I want to add a Book Alredy registred
    Given I have a new book to add :
        | Title                      | Description                            | Author Id |
        | Une archi presque parfaite | Comment faire des bonnes frites        | 3         |
    When I add the book to the validator
    Then An ValidationException is raised by the validator

@KO
Scenario: I want to add a new Book without Title
    Given I have a new book to add :
        | Title | Description                            | Author Id |
        |       | Comment faire des bonnes frites        | 3         |
    When I add the book to the validator
    Then An ValidationException is raised by the validator
