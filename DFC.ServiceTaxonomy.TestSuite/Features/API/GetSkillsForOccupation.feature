Feature: GetSkillsForOccupation


Scenario: Get skills for occupation	
	Given The Occupation ID i wish to look up is 114e1eff-215e-47df-8e10-45a5b72f8197
	When I make the request
	Then The number of skills returned is 35

