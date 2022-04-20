Feature: CreateBook

Create Book

@tag1
Scenario: I want to add a new Book
    Given I have a new book to add
    When I add the book
    Then The book is added

Scenario: I want to add a new Book without Title
    Given I have a new book without title to add
    When I add the book
    Then An Error 'Book Title is required' is raised

Scenario: I want to add a Book Alredy registred
    Given a list of book :
    | title | Autor |
    |   livre1    | Gide |
    |   livre2    | King |
    And I have a new book 'livre1' to add
    When I add the book
    Then An Error 'The specified title alredy exist' is raised
