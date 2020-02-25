Feature: GetSkillsGapForOccupationAndGivenSkills


Scenario:  Skills gap analysis where common skills exists
	Given I supply the parameter "occupation" as a string with value "123"
	And I supply the parameter "skilllist" as a collection with values
	 | Value  |
	 | 1232   |
	 | 234    |
	 | 234234 |
	When I request skill gap for an occupation and a list of skills
	Then the response code is 201
	And the response matches the expected format
	And the missing skills include
	| skill | uri | type | reuselevel |
	| 123   | 12  | 123  | 12312      |
	| 123   | 12  | 123  | 12312      |
	And the number of missings skills is 27
	And the match skills include
	| skill | uri | type | reuselevel |
	| 123   | 12  | 123  | 12312      |
	| 123   | 12  | 123  | 12312      |
	And the number of matching skills is 3
