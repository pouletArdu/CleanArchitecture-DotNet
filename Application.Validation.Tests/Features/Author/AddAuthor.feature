Feature: AddAuthor

Adding an author

@OK
Scenario: I want to add a new Author
    Given I have a new author to add
    And his last name is "foo"
    And his first name is "bar"
    And his birthDay  is "1985/04/25"  
    When I add the author
    Then The author is added
