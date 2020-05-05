Feature: GetOccupationsWithMatchingSkills

	
@GetOccupationsWithMatchingSkills
#@ignore
@todo
Scenario: Skill list is supplied that matches one occupation
	Given I make a request to the service taxonomy API "GetOccupationsWithMatchingSkills" with request body
	"""
{
    "minimumMatchingSkills":1,
    "skillList":["http://data.europa.eu/esco/skill/74be20a7-fcfe-4715-bb62-8937a547a982"]
}
	"""
    And I look up the job profile Uri for "actor/actress" 
	Then the response code is 200
	And the response json matches:
    """
{
    "matchingOccupations": [
        {
            "matchingOptionalSkills": 1,
            "occupation": "actor/actress",
            "jobProfileDescription": "<p>Actors use speech, movement and expression to bring characters to life in theatre, film, television and radio.</p>",
            "totalOccupationOptionalSkills": 40,
            "jobProfileTitle": "Actor",
            "totalOccupationEssentialSkills": 23,
            "matchingEssentialSkills": 0,
            "lastModified": "2017-01-17T13:01:57Z",
            "jobProfileUri": "@JobProfileUri@",
            "uri": "http://data.europa.eu/esco/occupation/26171f39-e85a-448f-bd28-a73a5a99927f",
            "socCode": "3413"
        }
    ]
}
    """


@GetOccupationsWithMatchingSkills
#@ignore
@todo
Scenario: Skill list is supplied that does not match any occupations with the given number of matches
	Given I make a request to the service taxonomy API "GetOccupationsWithMatchingSkills" with request body
	"""
{
    "minimumMatchingSkills":2,
    "skillList":["http://data.europa.eu/esco/skill/b3f74d7d-82d6-48e0-8460-219b4aa5dcaa"]
}
	"""
	Then the response code is 200
	And the response json matches:
    """
{
    "matchingOccupations": []
}
    """