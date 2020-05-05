Feature: GetSkillById



Background: 
	Given I have made sure that "occupations" with related job profiles are present in the graph datastore

@GetSkillById 
Scenario: Get skill classified as Knowledge and cross-sectoral
	Given I make a request to the service taxonomy API "getskillbyid"
	| dataItem | value                                                                 |
	| uri      | http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7 |
	Then the response json matches:
	"""
	{
    "skillType": "competency",
    "skill": "types of wood materials",
    "lastModified": "2017-02-15T12:22:24Z",
    "alternativeLabels": [
        "type of wood material",
		"varieties of wood materials",
		"kinds of wood materials",
		"sorts of wood materials",
		"categories of wood materials"
    ],
    "uri": "http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7",
    "skillReusability": "cross-sectoral"
	}
	"""

@GetSkillById 
Scenario: Get skill classified as Competency and Sector Specific
	Given I make a request to the service taxonomy API "getskillbyid"
	| dataItem | value                                                                 |
	| uri      | http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d |
	Then the response json matches:
	"""
{
    "skillType": "competency",
    "skill": "operate forestry equipment",
    "lastModified": "2016-12-20T17:26:38Z",
    "alternativeLabels": [
        "forestry equipment operating",
        "use forestry equipment",
        "using forestry equipment",
        "forestry equipment using",
        "operating forestry equipment"
    ],
    "uri": "http://data.europa.eu/esco/skill/ffe198e3-3f51-40c1-8d43-6e559bb98c8d",
    "skillReusability": "sector-specific"
}
	"""

@GetSkillById
Scenario: Get skill classified as occupation-specific
	Given I make a request to the service taxonomy API "getskillbyid"
	| dataItem | value                                                                 |
	| uri      | http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512 |
	Then the response json matches:
	"""
{
    "skillType": "competency",
    "skill": "manage office appliance requirements",
    "lastModified": "2016-12-20T18:06:31Z",
    "alternativeLabels": [
        "monitor office appliance requirements",
        "managing office appliance requirements",
        "oversee office appliance requirements",
        "manage office appliance's requirements",
        "check needs for office stationary items",
        "manage requirements of office appliance"
    ],
    "uri": "http://data.europa.eu/esco/skill/cb108a0a-88e6-4579-885d-b1e794ada512",
    "skillReusability": "occupation-specific"
}
	"""

@GetSkillById
Scenario: Get skill classified as Transveral with no alternate labels
	Given I make a request to the service taxonomy API "getskillbyid"
	| dataItem | value                                                                 |
	| uri      | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
	Then the response json matches:
	"""
{
    "skillType": "competency",
    "skill": "manage data, information and digital content",
    "lastModified": "2017-02-10T16:32:20Z",
    "alternativeLabels": [],
    "uri": "http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222",
    "skillReusability": "transversal"
}
	"""

@GetSkillById
Scenario: Unknown skill is supplied
	Given I make a request to the service taxonomy API "getskillbyid"
	| dataItem | value                                                                 |
	| uri      | http://data.europa.eu/esco/InvalidSkill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7 |
    Then the response code is 204



@GetSkillById
Scenario: No body is supplied
	Given I make a request to the service taxonomy API "getskillbyid"
    	| dataItem | value  |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"


@GetSkillById
Scenario: Invalid body is supplied
	Given I make a request to the service taxonomy API "getskillbyid"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"



@GetSkillById
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getskillbyid"
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


@GetSkillById
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getskillbyid"
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