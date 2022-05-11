Feature: AddAuthor

Adding an author

@OK
Scenario: I want to add a new Author
    Given I have a new author to add
    And his last name is "John"
    And his first name is "Doe"
    And his Geder is "Male"
    And his birthDay  is "1985/04/25"  
    When I add the author
    Then The author is added
