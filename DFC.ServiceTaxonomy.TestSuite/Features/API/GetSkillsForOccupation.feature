Feature: GetSkillsForOccupation


Scenario: Get skills for valid occupation occupation	
	Given The Occupation ID i wish to look up is 114e1eff-215e-47df-8e10-45a5b72f8197
	When I make the request
	Then The number of skills returned is 35


Scenario: Get skills for occupation with invalid request body
		Given I request all skills for occupation "uri" from the NCS API
		Then the response code is 204

Scenario: Get skills for occupation with unknown occupation
		Given I request all skills for occupation "uri" from the NCS API
		Then the response code is 404

Scenario: Get skills for occupation with missing security header
		Given I don't want to send a security header with the next request
	    Given I request all skills for occupation "uri" from the NCS API
		Then the response code is 404


Scenario: Get skills for occupation with invalid security header
		Given I don't want to send an invalid API key with the next request
	    Given I request all skills for occupation "uri" from the NCS API
		Then the response code is 404
