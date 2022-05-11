Feature: GetAuthorInPaginatedList

A short summary of the feature

@tag1
Scenario: Getting author in paginated list
	Given there is 100 authors
	When i want to get the page 2 with 10 items
	Then I got the expected page
