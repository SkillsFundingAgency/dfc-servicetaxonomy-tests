Feature: GetAllOccupations

@Ignore
@GetAllOccupations
Scenario: Retrieve a list of all occupations
	Given I get a list of occupations from esco
	And I request all occupations from the NCS API
	Then the occupations returned by each service match
	And the alternate labels listed for first Occupation returned matches esco data
	And the alternate labels listed for mid Occupation returned matches esco data
	And the alternate labels listed for last Occupation returned matches esco data
