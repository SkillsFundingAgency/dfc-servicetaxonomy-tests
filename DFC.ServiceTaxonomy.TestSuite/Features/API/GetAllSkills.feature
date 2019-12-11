Feature: GetAllSkills


@GetAllSkills
Scenario: Retrieve a list of all skills
	Given I get a list of skills from esco
	And I request all skills from the NCS API
	Then the skills returned by each service match
	And the alternate labels listed for first Skill returned matches esco data
	And the alternate labels listed for mid Skill returned matches esco data
	And the alternate labels listed for last Skill returned matches esco data

