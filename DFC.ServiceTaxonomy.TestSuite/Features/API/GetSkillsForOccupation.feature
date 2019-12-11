Feature: GetSkillsForOccupation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@GetAllSkillsForOccupation
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Get skills for occupation	
	Given The Occupation ID i wish to look up is 114e1eff-215e-47df-8e10-45a5b72f8197
	When I make the request
	Then The number of skills returned is 35

