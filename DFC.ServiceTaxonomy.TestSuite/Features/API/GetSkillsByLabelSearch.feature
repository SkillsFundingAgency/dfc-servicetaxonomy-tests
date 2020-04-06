Feature: GetSkillsByLabelSearch

@GetSkillsByLabel @ignore @todo
Scenario: Search for a full word

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
"""
{
  "label": "torch",
  "matchAltLabels": "true"
}

"""
	Then the response code is 200
    And the response json matches:
         """
{
    "skills": [
        {
            "skillType": "competency",
            "skill": "operate brazing equipment",
            "lastModified": "2016-12-20T19:49:34Z",
            "alternativeLabels": [
                "utilise brazing equipment",
                "run brazing equipment",
                "utilise welding torches",
                "use welding torches",
                "run welding torches",
                "use brazing equipment",
                "handle brazing equipment",
                "handle welding torches"
            ],
            "uri": "http://data.europa.eu/esco/skill/10f24e0d-bd23-4432-b96b-e9f23136c503",
            "matches": {
                "hiddenLabels": [],
                "skill": [],
                "alternativeLabels": [
                    "utilise welding torches",
                    "use welding torches",
                    "run welding torches",
                    "handle welding torches"
                ]
            },
            "skillReusability": "cross-sectoral"
        },
        {
            "skillType": "knowledge",
            "skill": "torch temperature for metal processes",
            "lastModified": "2017-01-05T13:52:33Z",
            "alternativeLabels": [
                "torch temperature for metal procedures",
                "torch temperature for metal working",
                "correct heat for machine and tool procedures",
                "torch temperature for metal activities",
                "correct heat for machine and tool working",
                "torch temperature for metal operations",
                "correct heat for machine and tool operations",
                "correct heat for machine and tool activities"
            ],
            "uri": "http://data.europa.eu/esco/skill/46f2796e-e1b8-4210-95e2-d9a89af956e7",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "torch temperature for metal processes"
                ],
                "alternativeLabels": [
                    "torch temperature for metal procedures",
                    "torch temperature for metal working",
                    "torch temperature for metal activities",
                    "torch temperature for metal operations"
                ]
            },
            "skillReusability": "cross-sectoral"
        },
        {
            "skillType": "competency",
            "skill": "operate oxy-fuel cutting torch",
            "lastModified": "2016-12-20T19:48:21Z",
            "alternativeLabels": [
                "use oxy-fuel cutting torch",
                "utilise oxyacetylene cutter",
                "run oxyacetylene cutter",
                "handle oxy-fuel cutting torch",
                "use oxyacetylene cutter",
                "handle oxyacetylene cutter",
                "utilise oxy-fuel cutting torch",
                "run oxy-fuel cutting torch"
            ],
            "uri": "http://data.europa.eu/esco/skill/8b09c290-c941-4119-870f-bdafbd78c669",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "operate oxy-fuel cutting torch"
                ],
                "alternativeLabels": [
                    "use oxy-fuel cutting torch",
                    "handle oxy-fuel cutting torch",
                    "utilise oxy-fuel cutting torch",
                    "run oxy-fuel cutting torch"
                ]
            },
            "skillReusability": "cross-sectoral"
        },
        {
            "skillType": "competency",
            "skill": "operate oxy-fuel welding torch",
            "lastModified": "2016-12-20T19:50:07Z",
            "alternativeLabels": [
                "handle oxy-fuel welding torch equipment",
                "operate oxyacetylene gas equipment",
                "utilise oxy-fuel welding torch equipment",
                "handle oxyacetylene gas equipment",
                "run oxy-fuel welding torch equipment",
                "utilise oxyacetylene gas equipment",
                "use oxy-fuel welding torch equipment",
                "use oxyacetylene gas equipment"
            ],
            "uri": "http://data.europa.eu/esco/skill/14b4a40e-da80-452a-86d6-88a959052219",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "operate oxy-fuel welding torch"
                ],
                "alternativeLabels": [
                    "handle oxy-fuel welding torch equipment",
                    "utilise oxy-fuel welding torch equipment",
                    "run oxy-fuel welding torch equipment",
                    "use oxy-fuel welding torch equipment"
                ]
            },
            "skillReusability": "cross-sectoral"
        },
        {
            "skillType": "competency",
            "skill": "operate oxygen cutting torch",
            "lastModified": "2016-12-20T18:23:07Z",
            "alternativeLabels": [
                "oxygen cutting torch operation",
                "cutting metal with oxygen torch",
                "metal cutting with oxygen torch",
                "oxygen torch metal-cutting",
                "operation of oxygen cutting torch",
                "operating oxygen cutting torch",
                "cut metal with oxygen torch"
            ],
            "uri": "http://data.europa.eu/esco/skill/d7cab350-7eba-41cf-9c35-827b74541ce8",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "operate oxygen cutting torch"
                ],
                "alternativeLabels": [
                    "oxygen cutting torch operation",
                    "cutting metal with oxygen torch",
                    "metal cutting with oxygen torch",
                    "oxygen torch metal-cutting",
                    "operation of oxygen cutting torch",
                    "operating oxygen cutting torch",
                    "cut metal with oxygen torch"
                ]
            },
            "skillReusability": "sector-specific"
        },
        {
            "skillType": "competency",
            "skill": "operate plasma cutting torch",
            "lastModified": "2016-12-20T18:23:01Z",
            "alternativeLabels": [
                "use plasma cutter",
                "cut with plasma torch",
                "operating plasma cutting torch",
                "plasma torch cutting",
                "operation of plasma cutting torch",
                "plasma cutting torch operation",
                "using plasma cutter"
            ],
            "uri": "http://data.europa.eu/esco/skill/f1e122e5-24a8-44c0-bf3f-90044e72370c",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "operate plasma cutting torch"
                ],
                "alternativeLabels": [
                    "cut with plasma torch",
                    "operating plasma cutting torch",
                    "plasma torch cutting",
                    "operation of plasma cutting torch",
                    "plasma cutting torch operation"
                ]
            },
            "skillReusability": "sector-specific"
        },
        {
            "skillType": "knowledge",
            "skill": "plasma torches",
            "lastModified": "2017-01-05T17:04:51Z",
            "alternativeLabels": [
                "plasma arc lamps",
                "plasma beacons",
                "plasma arc beacons",
                "plasma arc incendiaries",
                "plasma lamps",
                "plasma incendiaries",
                "plasm lanterns"
            ],
            "uri": "http://data.europa.eu/esco/skill/3cb0d886-1b34-4941-a134-b84d8a17b8d5",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "plasma torches"
                ],
                "alternativeLabels": []
            },
            "skillReusability": "occupation-specific"
        }
    ]
}         
         """

@GetSkillsByLabel @ignore @todo
Scenario: Search for a partial word

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "ncendiari",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
    """
    {
    "skills": [
        {
            "skillType": "knowledge",
            "skill": "plasma torches",
            "lastModified": "2017-01-05T17:04:51Z",
            "alternativeLabels": [
                "plasma arc lamps",
                "plasma beacons",
                "plasma arc beacons",
                "plasma arc incendiaries",
                "plasma lamps",
                "plasma incendiaries",
                "plasm lanterns"
            ],
            "uri": "http://data.europa.eu/esco/skill/3cb0d886-1b34-4941-a134-b84d8a17b8d5",
            "matches": {
                "hiddenLabels": [],
                "skill": [],
                "alternativeLabels": [
                    "plasma arc incendiaries",
                    "plasma incendiaries"
                ]
            },
            "skillReusability": "occupation-specific"
        }
    ]
}
    """

@GetSkillsByLabel @ignore @todo
Scenario: Search for a full word with alternate labels included

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "cocktail",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
"""
{
    "skills": [
        {
            "skillType": "competency",
            "skill": "prepare mixed beverages",
            "lastModified": "2016-09-15T10:50:50Z",
            "alternativeLabels": [
                "serve cocktails",
                "mix and serve alcoholic and non-alcoholic beverages",
                "prepare a mix of beverages"
            ],
            "uri": "http://data.europa.eu/esco/skill/81d5b408-e805-4788-8dbd-42f22e8fd199",
            "matches": {
                "hiddenLabels": [],
                "skill": [],
                "alternativeLabels": [
                    "serve cocktails"
                ]
            },
            "skillReusability": "sector-specific"
        },
        {
            "skillType": "competency",
            "skill": "assemble cocktail garnishes",
            "lastModified": "2016-09-15T10:55:54Z",
            "alternativeLabels": [
                "choose various items to present cocktails",
                "use different items to decorate cocktails",
                "assemble garnish for cocktails",
                "assemble garnishing for cocktails"
            ],
            "uri": "http://data.europa.eu/esco/skill/f42df0af-c63b-41a7-815f-ab5eb85098e3",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "assemble cocktail garnishes"
                ],
                "alternativeLabels": [
                    "choose various items to present cocktails",
                    "use different items to decorate cocktails",
                    "assemble garnish for cocktails",
                    "assemble garnishing for cocktails"
                ]
            },
            "skillReusability": "sector-specific"
        }
    ]
}
"""

@GetSkillsByLabel @ignore @todo
Scenario: Search where there are no matches

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "bincendiari",
  "matchAltLabels": "true"
}
    """
	Then the response code is 200
    And the response json matches:
    """
    {
    "skills": []
}
    """

@GetSkillsByLabel @ignore @todo
Scenario: Alt label search defaults to false

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "ncendiari"
}
    """
	Then the response code is 200
    And the response json matches:
    """
    {
    "skills": []
}
    """

# skill type, reusablity, no alt labels

@GetSkillsByLabel @ignore @todo
Scenario: Search for that is only in alt labels without allowing alt label search

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "ncendiari",
  "matchAltLabels": "false"
}
    """
	Then the response code is 200
    And the response json matches:
    """
{
    "skills": []
}
    """


@GetSkillsByLabel @ignore @todo
Scenario: Search that returns skill with no alt labels

Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "manage budgets"
}
    """
	Then the response code is 200
    And the response json matches:
    """
{
    "skills": [
        {
            "skillType": "competency",
            "skill": "manage budgets",
            "lastModified": "2016-10-20T15:06:39Z",
            "alternativeLabels": [],
            "uri": "http://data.europa.eu/esco/skill/21c5790c-0930-4d74-b3b0-84caf5af12ea",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "manage budgets"
                ],
                "alternativeLabels": []
            },
            "skillReusability": "cross-sectoral"
        },
        {
            "skillType": "competency",
            "skill": "manage budgets for social services programs",
            "lastModified": "2016-12-20T19:29:40Z",
            "alternativeLabels": [
                "administer budgets in social services",
                "plan budgets for social services programmes",
                "manage budget for social services programs",
                "manage budgets for social services programmes",
                "manage budget for social services programme"
            ],
            "uri": "http://data.europa.eu/esco/skill/d4eaa90c-598f-4453-a0b8-28345ba63bf2",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "manage budgets for social services programs"
                ],
                "alternativeLabels": [
                    "manage budgets for social services programmes"
                ]
            },
            "skillReusability": "sector-specific"
        }
    ]
}
    """



@GetSkillsByLabel @ignore @todo    
Scenario: Alt label value is supplied as parameter

Given I want to supply "?matchAltLabels=true" as a parameter in the following request
Given I make a request to the service taxonomy API "getskillsbylabelsearch" with request body
# includes all skill resablity examples, competncy and knowledge, skill match, alt label match
    """
{
  "label": "cocktail"
}
    """
	Then the response code is 200
    And the response json matches:
"""
{
    "skills": [
        {
            "skillType": "competency",
            "skill": "prepare mixed beverages",
            "lastModified": "2016-09-15T10:50:50Z",
            "alternativeLabels": [
                "serve cocktails",
                "mix and serve alcoholic and non-alcoholic beverages",
                "prepare a mix of beverages"
            ],
            "uri": "http://data.europa.eu/esco/skill/81d5b408-e805-4788-8dbd-42f22e8fd199",
            "matches": {
                "hiddenLabels": [],
                "skill": [],
                "alternativeLabels": [
                    "serve cocktails"
                ]
            },
            "skillReusability": "sector-specific"
        },
        {
            "skillType": "competency",
            "skill": "assemble cocktail garnishes",
            "lastModified": "2016-09-15T10:55:54Z",
            "alternativeLabels": [
                "choose various items to present cocktails",
                "use different items to decorate cocktails",
                "assemble garnish for cocktails",
                "assemble garnishing for cocktails"
            ],
            "uri": "http://data.europa.eu/esco/skill/f42df0af-c63b-41a7-815f-ab5eb85098e3",
            "matches": {
                "hiddenLabels": [],
                "skill": [
                    "assemble cocktail garnishes"
                ],
                "alternativeLabels": [
                    "choose various items to present cocktails",
                    "use different items to decorate cocktails",
                    "assemble garnish for cocktails",
                    "assemble garnishing for cocktails"
                ]
            },
            "skillReusability": "sector-specific"
        }
    ]
}
"""




@GetSkillsByLabel @ignore @todo
Scenario: No body is supplied
	Given I make a request to the service taxonomy API "getskillsbylabelsearch"
    	| dataItem | value  |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"


@GetSkillsByLabel @ignore @todo
Scenario: Invalid body is supplied
	Given I make a request to the service taxonomy API "getskillsbylabelsearch"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"



@GetSkillsByLabel @ignore @todo
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getskillsbylabelsearch"
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


@GetSkillsByLabel @ignore @todo
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getskillsbylabelsearch"
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
