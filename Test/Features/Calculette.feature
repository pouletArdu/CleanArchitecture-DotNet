Feature: Calculette

A short summary of the feature

#@tag1
#Scenario: Additionner deux nombre
#	Given le premier est 1
#	And  le deuxième est 2
#	When on additionne 
#	Then on obtient 3


@tag1
Scenario Outline: Additionner deux nombre
	Given le premier est <a>
	And  le deuxième est <b>
	When on additionne 
	Then on obtient <result>

Examples: 
	| a | b   | result |
	| 1 | 2   | 3      |
	| 10 | -5 | 5      |
	| 10 | -5 | 58     |
