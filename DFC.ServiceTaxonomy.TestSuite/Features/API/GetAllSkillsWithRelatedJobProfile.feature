Feature: GetAllSkillsWithRelatedJobProfile


Background: 
	Given I have made sure that "skills" with related job profiles are present in the graph datastore

@Ignore
Scenario:  Retreive a list of all skill relating to occupation with job profile
	Given I request all skills with related job profile from the NCS API
	Then the alternate labels listed for first Skill returned matches esco data
	And the alternate labels listed for mid Skill returned matches esco data
	And the alternate labels listed for last Skill returned matches esco data
	And the number of results returned matches the expected value
