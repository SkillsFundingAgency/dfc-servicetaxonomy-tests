Feature: GetAllOccupations



@GetAllOccupations
Scenario: Retreive full list of occupations
	Given I make a call to the api
	And I get the same information from esco
	When I check the results
	Then the number of items return matches
	And the results match


Scenario: Get occupations from esco
	Given I get a list of occupations from esco
