@webtest
Feature: Get Job Profile by Title API
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Background: 
	Given I only want to run the background section once
	Given I set up a data prefix for "test__Name"
	And I logon to the editor
	And I load recipe file "test_data.json"
	And I have completed the background section

@GetJobProfileByTitle
Scenario: Get valid Job profile
	Given I make a request to the service taxonomy API "getjobprofilebytitle"
    	| dataItem  | value           |
    	| [path]    | Admin assistant |
  	Then the response json matches:
	"""
{
    "SalaryStarter": "14000",
    "SalaryExperienced": "30000",
    "LastUpdatedDate": "2020-05-04T10:08:03",
    "MinimumHours": 38.0,
    "RelatedCareers": [
        "ToDo"
    ],
    "Soc": "4159",
    "Title": "Admin assistant",
    "Overview": "<p>Admin assistants give support to offices by organising meetings, typing documents and updating computer records.</p>",
    "WorkingPattern": "between 8am and 6pm",
    "AlternativeTitle": "general office clerk, clerical assistant, administrative office assistant, office clerk, office administrator, executive administrative assistant, administrative office worker, communications assistant",
    "WorkingHoursDetails": "a week",
    "Url": "https://dev.api.nationalcareersservice.org.uk/servicetaxonomygetjobprofilebytitle/execute/admin-assistant",
    "WhatYouWillDo": {
        "WYDDayToDayTasks": [
            "dealing with queries on the phone, by email and social media; typing letters and reports; printing and photocopying; making travel arrangements for staff; greeting visitors at reception; updating computer records; setting up meetings and taking notes during them; ordering supplies"
        ],
        "WorkingEnvironment": {
            "Environment": "",
            "Uniform": "",
            "Location": ""
        }
    },
    "ONetOccupationalCode": "ToDo",
    "MaximumHours": 40.0,
    "WhatItTakes": {
        "Skills": [
            "ToDo"
        ],
        "DigitalSkillsLevel": "<p>to be able to use a computer and the main software packages competently</p>",
        "RestrictionsAndRequirements": {
            "RelatedRestrictions": [],
            "OtherRequirements": []
        }
    },
    "CareerPathAndProgression": {
        "CareerPathAndProgression": [
            "<p>With experience, you could progress from admin assistant to supervisor or office manager. You could also move into other departments such as IT or accounting.</p><p>With further training, you could specialise in an area like legal, financial or medical administration.</p>"
        ]
    },
    "WorkingPatternDetails": null,
    "HowToBecome": {
        "EntryRoutes": {
            "Apprenticeship": {
                "AdditionalInformation": [
                    "[equivalent entry requirements | https://www.gov.uk/what-different-qualification-levels-mean/list-of-qualification-levels]",
                    "[guide to apprenticeships | https://www.gov.uk/apprenticeships-guide]"
                ],
                "EntryRequirements": [
                    "5 GCSEs at grades 9 to 4 (A* to C) or equivalent, including English and maths, for an advanced apprenticeship",
                    "Intermediate apprenticeship entry reqs"
                ],
                "RelevantSubjects": [
                    "<p>You could get into this job through an intermediate apprenticeship in business administration or a business administrator advanced apprenticeship.</p>"
                ],
                "FurtherInformation": [],
                "EntryRequirementPreface": "You'll usually need:"
            },
            "Volunteering": [],
            "University": {
                "AdditionalInformation": [],
                "EntryRequirements": [],
                "RelevantSubjects": [],
                "FurtherInformation": [],
                "EntryRequirementPreface": null
            },
            "DirectApplication": [
                "<p>You could apply directly to become an admin assistant.</p><p>Some employers may expect you to have:<ul><li>GCSEs at grades 9 to 4 (A* to C) or equivalent qualifications, including English and maths</li><li>telephone, typing or IT skills</li></ul></p>"
            ],
            "College": {
                "AdditionalInformation": [
                    "[search for courses | /find-a-course]",
                    "[funding advice | https://www.gov.uk/further-education-courses/financial-help]",
                    "[equivalent entry requirements | https://www.gov.uk/what-different-qualification-levels-mean/list-of-qualification-levels]"
                ],
                "EntryRequirements": [
                    "Level 2 course entry reqs",
                    "Level 3 course entry reqs"
                ],
                "RelevantSubjects": [
                    "<p>You could do a college course, which would teach you some of the skills and knowledge you need in this job. Relevant subjects include a Level 2 or 3 Diploma in Business and Administration.</p>"
                ],
                "FurtherInformation": [],
                "EntryRequirementPreface": "You'll usually need:"
            },
            "Work": [
                "<p>Experience of temping could lead to a permanent job. Qualifications in business administration may also help.</p>"
            ],
            "OtherRoutes": []
        },
        "EntryRouteSummary": "ToDo",
        "MoreInformation": {
            "Registrations": [],
            "FurtherInformation": [],
            "ProfessionalAndIndustryBodies": [],
            "CareerTips": []
        }
    }
}
	"""


@GetJobProfileByTitle
Scenario: A body is supplied
	Given I make a request to the service taxonomy API "getjobprofilebytitle"
    	| dataItem  | value           |
    	| [path]    | Admin assistant |
    	| bodyField | Some text       |
    Then the response code is 200


@GetJobProfileByTitle
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getjobprofilebytitle"
    	| dataItem | value           |
    	| [path]   | Admin assistant |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to invalid subscription key. Make sure to provide a valid key for an active subscription."
    }
    """


@GetJobProfileByTitle
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getjobprofilebytitle"
    	| dataItem | value           |
    	| [path]   | Admin assistant |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to missing subscription key. Make sure to include subscription key when making requests to an API."
    }
    """