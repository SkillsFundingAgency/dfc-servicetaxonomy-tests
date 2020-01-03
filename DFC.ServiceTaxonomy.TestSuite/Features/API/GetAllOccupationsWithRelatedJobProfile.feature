Feature: GetAllOccupationsWithRelatedJobProfile

Background: 
	Given I have made sure that "occupations" with related job profiles are present in the graph datastore

@GetAllOccupationsWithRelatedJobProfile
Scenario: Retrieve a list of occupations with related job profile
	Given I request all occupations with related job profile from the NCS API
	Then the alternate labels listed for first Occupation returned matches esco data
	And the alternate labels listed for mid Occupation returned matches esco data
	And the alternate labels listed for last Occupation returned matches esco data
	And the number of results returned matches the expected value
	# confirm all data items as expected