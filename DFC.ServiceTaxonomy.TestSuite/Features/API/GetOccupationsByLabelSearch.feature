﻿Feature: GetOccupationsByLabelSearch

@GetOccupationsByLabel   #@ignore @todo
Scenario: Search for a full word

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
"""
{
  "label": "dietitian",
  "matchAltLabels": "true"
}
"""
Then the response json matches:
    """
{
    "occupations": [
        {
            "occupation": "dietitian",
            "lastModified": "2016-09-22T13:31:57Z",
            "alternativeLabels": [
				"public health nutritionist",
				"specialist dietician",
				"dietician"
            ],
            "uri": "http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f",
            "matches": {
                "occupation": [
                    "dietitian"
                ],
                "alternativeLabels": []
            }
        }
    ]
}
   """

@GetOccupationsByLabel @todo
Scenario: Search for a partial word

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "eauti",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
    """
 {
    "occupations": [
        {
            "occupation": "aesthetician",
            "lastModified": "2016-07-05T16:54:48Z",
            "alternativeLabels": [
                "skin care technician",
                "beauty specialist",
                "cosmetician",
                "facial treatment operator",
                "esthetician",
                "facialist",
                "skin care specialist",
                "beautician"
            ],
            "uri": "http://data.europa.eu/esco/occupation/a1e1a788-2352-4172-8fcf-1f985a6968b0",
            "matches": {
                "occupation": [],
                "alternativeLabels": [
                    "beautician"
                ]
            }
        }
    ]
}
    """

@GetOccupationsByLabel   #@ignore @todo
Scenario: Search for a full word with alternate labels included

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "dietician",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
"""
{
    "occupations": [
        {
            "occupation": "dietitian",
            "lastModified": "2016-09-22T13:31:57Z",
            "alternativeLabels": [
                "dietician",
                "public health nutritionist",
                "specialist dietician"
            ],
            "uri": "http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f",
            "matches": {
                "occupation": [],
                "alternativeLabels": [
                    "dietician",
                    "specialist dietician"
                ]
            }
        }
    ]
}
"""

@GetOccupationsByLabel   #@ignore @todo
Scenario: Search where there are no matches

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "guardian of the galaxy",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
    """
    {
    "occupations": []
}
    """

@GetOccupationsByLabel   #@ignore @todo
Scenario: Alt label search defaults to false

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "dietician"
}
    """
	Then the response code is 200
    And the response json matches:
    """
{
    "occupations": []
}
    """

# skill type, reusablity, no alt labels
@GetOccupationsByLabel   #@ignore @todo
Scenario: Search for that is only in alt labels without allowing alt label search

Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "dietician",
  "matchAltLabels": "false"
}
    """
	Then the response code is 200
    And the response json matches:
    """
{
    "occupations": []
}
    """


    

@GetOccupationsByLabel   #@ignore @todo
Scenario: Alt label value is supplied as parameter

Given I want to supply "?matchAltLabels=true" as a parameter in the following request
Given I make a request to the service taxonomy API "getoccupationsbylabelsearch" with request body
    """
{
  "label": "dietician"
}
    """
	Then the response code is 200
    And the response json matches:
"""
{
	"occupations": [
		{
			"occupation": "dietitian",
			"lastModified": "2016-09-22T13:31:57Z",
			"alternativeLabels": [
				"public health nutritionist",
				"specialist dietician",
				"dietician"
			],
			"uri": "http://data.europa.eu/esco/occupation/8a53f8d3-d995-4c7b-a70d-d79f76bdcb3f",
			"matches": {
				"occupation": [],
				"alternativeLabels": [
					"specialist dietician",
					"dietician"
				]
			}
		}
	]
}
"""



@GetOccupationsByLabel   #@ignore @todo
Scenario: No body is supplied
	Given I make a request to the service taxonomy API "getoccupationsbylabelsearch"
    	| dataItem | value  |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"


@GetOccupationsByLabel   #@ignore @todo
Scenario: Invalid body is supplied
	Given I make a request to the service taxonomy API "getoccupationsbylabelsearch"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"



@GetOccupationsByLabel   #@ignore @todo
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getoccupationsbylabelsearch"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to invalid subscription key. Make sure to provide a valid key for an active subscription."
    }
    """


@GetOccupationsByLabel   #@ignore @todo
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getoccupationsbylabelsearch"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to missing subscription key. Make sure to include subscription key when making requests to an API."
    }
    """
