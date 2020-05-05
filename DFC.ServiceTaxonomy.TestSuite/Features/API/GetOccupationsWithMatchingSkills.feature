Feature: GetOccupationsWithMatchingSkills

	
@GetOccupationsWithMatchingSkills
#@ignore
@todo
Scenario: Skill list is supplied that matches one occupation
	Given I make a request to the service taxonomy API "GetOccupationsWithMatchingSkills" with request body
	"""
{
    "minimumMatchingSkills":1,
    "skillList":["http://data.europa.eu/esco/skill/b3f74d7d-82d6-48e0-8460-219b4aa5dcaa"]
}
	"""
	Then the response code is 200
	And the response json matches:
    """
{
    "matchingOccupations": [
        {
            "matchingOptionalSkills": 1,
            "occupation": "microbiologist",
            "jobProfileDescription": "<p>Microbiologists study micro-organisms like bacteria, viruses, fungi and algae.</p>",
            "totalOccupationOptionalSkills": 30,
            "jobProfileTitle": "Microbiologist",
            "totalOccupationEssentialSkills": 19,
            "matchingEssentialSkills": 0,
            "lastModified": "2017-01-17T14:18:17Z",
            "jobProfileUri": "http://nationalcareers.service.gov.uk/jobprofile/a9d9a3fd-cb00-4f94-966d-d9e71ca4131a",
            "uri": "http://data.europa.eu/esco/occupation/a7a74a05-3dd0-46c6-99af-92df8042520c",
            "socCode": "2112"
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