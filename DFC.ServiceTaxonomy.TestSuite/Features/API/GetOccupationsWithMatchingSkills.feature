Feature: GetOccupationsWithMatchingSkills


Scenario: Search for matching occupations
	Given I supply the parameter "minumMatchingSkills" as a string with value "123"
	And I supply the parameter "skillList" as a collection with values
	 | Value  |
	 | 1232   |
	 | 234    |
	 | 234234 |
	When I request occupations with matching skills
	Then the response code is 201
	And the response matches the expected format
	And the results include
	| skill | uri | type | reuselevel |
	| 123   | 12  | 123  | 12312      |
	| 123   | 12  | 123  | 12312      |
	And the number of results is 43
