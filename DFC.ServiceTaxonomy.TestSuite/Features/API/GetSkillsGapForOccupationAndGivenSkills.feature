Feature: GetSkillsGapForOccupationAndGivenSkills

	
@GetSkillsGapOforOccupationAndGivenSkills
@ignore
@todo
Scenario: Occupation is supplied with a skill list which has some commonality
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills" with request body
"""
{
  "label": "torch",
  "matchAltLabels": "true"
}

"""
	Then the response code is 200
	And the response json with elements "missingSkills" and "matchingSkills" removed matches:
    """
{
    "occupation": "microbiologist",
    "lastModified": "2017-01-17T14:18:17Z",
    "jobProfileTitle": "Microbiologist",
    "alternativeLabels": [
        "microbiology studies research scientist",
        "microbiology research analyst",
        "microbiology studies analyst",
        "virologist",
        "histologist",
        "microbiology scholar",
        "microbiology research scientist",
        "microbiology researcher",
        "bacteriologist",
        "microbiology studies scientist",
        "microbiology analyst",
        "helminthologist",
        "microbiology biotechnologist",
        "microbiology studies scholar",
        "microbiology scientist",
        "microbiology studies researcher",
        "parasitologist",
        "microbiology science researcher",
        "microbiology studies research analyst"
    ],
    "jobProfileUri": "http://nationalcareers.service.gov.uk/jobprofile/2abdd237-350f-433f-b96f-4f4e231e16f1",
    "uri": "http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c"
}
    """
    And the response json has collection "missingSkills" with an item matching
    """
{
            "relationshipType": "essential",
            "skill": "gather experimental data",
            "lastModified": "2016-12-20T20:24:44Z",
            "alternativeLabels": [
                "accumulate experimental data",
                "gathering of experimental data",
                "experimental data gathering",
                "collect experimental data",
                "compile experimental data"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/89db623e-e1fc-4ec2-9a0f-7b72b4c35303",
            "skillReusability": "cross-sectoral"
        }
    """
    And the response json has collection "missingSkills" with an item matching
    """
        {
            "relationshipType": "essential",
            "skill": "microbiology-bacteriology",
            "lastModified": "2016-12-20T19:31:41Z",
            "alternativeLabels": [
                "microbiology-bacteriologies",
                "science of bacteria",
                "bacteriology and microbiology",
                "micro-biology",
                "characteristics of micobioloy",
                "study of bacteria",
                "bacteriology",
                "microbiology",
                "specialties of bacteria",
                "principles of microbiology",
                "study of microbiology",
                "study of microscopic organisms",
                "classification and characteristics of bacteria"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4",
            "skillReusability": "sector-specific"
        }
   """
    And the response json has collection "missingSkills" with an item matching
   """
        {
            "relationshipType": "optional",
            "skill": "helminthology",
            "lastModified": "2016-12-20T20:22:40Z",
            "alternativeLabels": [
                "parasitic worms studies",
                "the study of parasitic worms"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/b3f74d7d-82d6-48e0-8460-219b4aa5dcaa",
            "skillReusability": "occupation-specific"
        }
   """
    And the response json has collection "missingSkills" with an item matching
   """
        {
            "relationshipType": "optional",
            "skill": "write research proposals",
            "lastModified": "2016-10-20T10:15:31Z",
            "alternativeLabels": [],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a",
            "skillReusability": "cross-sectoral"
        }
   """
   And the count of collection "missingSkills" is 45
   And the element "uri" in the collection "missingSkills" has distinct values
   And the response json has collection "matchingSkills" with an item matching
   """
{
            "relationshipType": "essential",
            "skill": "conduct research on flora",
            "lastModified": "2016-12-20T20:26:33Z",
            "alternativeLabels": [
                "carry out research on flora",
                "flora research",
                "perform research on flora",
                "run research on flora",
                "research on flora"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/0058526a-11e9-40a1-ab33-7c5ffdf5da05",
            "skillReusability": "sector-specific"
        }
   """
   And the response json has collection "matchingSkills" with an item matching
   """
{
            "relationshipType": "essential",
            "skill": "collect biological data",
            "lastModified": "2016-12-20T17:31:28Z",
            "alternativeLabels": [
                "biological data analysing",
                "analysing biological records",
                "collect biological records",
                "collecting biological records",
                "analyse biological records",
                "analysing biological data",
                "analyse biological data",
                "biological data collecting",
                "collecting biological data"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281",
            "skillReusability": "cross-sectoral"
        }
   """
   And the response json has collection "matchingSkills" with an item matching
   """
        {
            "relationshipType": "essential",
            "skill": "apply scientific methods",
            "lastModified": "2017-01-05T10:54:11Z",
            "alternativeLabels": [
                "employ scientific methods",
                "utilise scientific methods",
                "implement scientific methods",
                "apply a scientific method",
                "administer scientific methods",
                "apply scientific methodology"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/7a34b3d9-bd3b-4f4e-a0f6-f97439901cb7",
            "skillReusability": "cross-sectoral"
        }
   """
   And the response json has collection "matchingSkills" with an item matching
   """
       {
            "relationshipType": "optional",
            "skill": "develop bioremediation techniques",
            "lastModified": "2016-12-20T20:25:58Z",
            "alternativeLabels": [
                "prepare bioremediation techniques",
                "developing bioremediation techniques",
                "developing bioremediation technique",
                "compile bioremediation techniques define bioremediation techniques",
                "create bioremediation techniques"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/23cb29ec-5738-4966-8453-09952ed8c1fc",
            "skillReusability": "occupation-specific"
        }
    """
   And the count of collection "matchingSkills" is 4
   And the element "uri" in the collection "matchingSkills" has distinct values
	

@GetSkillsGapOforOccupationAndGivenSkills
@ignore
@todo
Scenario: Occupation is supplied with a skill list including a matching skill with no alternate labels
# also covers matching skill of type knowledge
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills" with request body
"""
{
  "occupation": "http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c",
  "skillList": [
    "http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a",
    "http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4"
  ]
}
"""
    Then the response code is 200
    And the response json has collection "matchingSkills" with an item matching
   """
        {
            "relationshipType": "optional",
            "skill": "write research proposals",
            "lastModified": "2016-10-20T10:15:31Z",
            "alternativeLabels": [],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/0ee7b0d6-db98-4785-9948-f2ef415d155a",
            "skillReusability": "cross-sectoral"
        }
   """
    And the response json has collection "matchingSkills" with an item matching
    """
        {
            "relationshipType": "essential",
            "skill": "microbiology-bacteriology",
            "lastModified": "2016-12-20T19:31:41Z",
            "alternativeLabels": [
                "microbiology-bacteriologies",
                "science of bacteria",
                "bacteriology and microbiology",
                "micro-biology",
                "characteristics of micobioloy",
                "study of bacteria",
                "bacteriology",
                "microbiology",
                "specialties of bacteria",
                "principles of microbiology",
                "study of microbiology",
                "study of microscopic organisms",
                "classification and characteristics of bacteria"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/0bc42cda-a6f0-4cac-9b34-7911faba0bd4",
            "skillReusability": "sector-specific"
        }
   """
   And the count of collection "matchingSkills" is 2
   And the count of collection "missingSkills" is 47


   

@GetSkillsGapOforOccupationAndGivenSkills
Scenario: Occupation is supplied with a skill list including no matching skills
# also covers matching skill of type knowledge
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills" with request body
"""
{
  "occupation": "http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c",
  "skillList": [
    "http://data.europa.eu/esco/nonmatchingskill/0ee7b0d6-db98-4785-9948-f2ef415d155a"
  ]
}
"""
    Then the response code is 200
    And the count of collection "matchingSkills" is 0
    And the count of collection "missingSkills" is 49


@GetSkillsGapOforOccupationAndGivenSkills
Scenario: Unknown occupation is supplied
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills" with request body
"""
{
  "occupation": "http://data.europa.eu/esco/Invalidoccupation/a7a74a05-3dd0-46c6-99af-92df8042520c",
  "skillList": [
    "http://data.europa.eu/esco/skill/0058526a-11e9-40a1-ab33-7c5ffdf5da05",
	"http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281",
	"http://data.europa.eu/esco/skill/7a34b3d9-bd3b-4f4e-a0f6-f97439901cb7",
	"http://data.europa.eu/esco/skill/23cb29ec-5738-4966-8453-09952ed8c1fc",
	"http://data.europa.eu/esco/skill/e3fcd642-5f9c-48ee-be58-258dd895d281"
  ]
}
"""
    Then the response code is 204



@GetSkillsGapOforOccupationAndGivenSkills
Scenario: No body is supplied
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills"
    	| dataItem | value  |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"


@GetSkillsGapOforOccupationAndGivenSkills
Scenario: Invalid body is supplied
	Given I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills"
    	| dataItem | value                                                                 |
    	| skill    | http://data.europa.eu/esco/skill/4d97e3c3-f335-47cc-a4ee-0d779fd42222 |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"



@GetSkillsGapOforOccupationAndGivenSkills
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills"
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


@GetSkillsGapOforOccupationAndGivenSkills
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getskillsgapforoccupationandgivenskills"
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
