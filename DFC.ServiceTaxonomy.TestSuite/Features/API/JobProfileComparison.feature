Feature: JobProfileComparison
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Compare output from current and new job profile API
	Given I have got a list of all available job profile from the existing API
	Then The output for each API matches for all job profiles

@mytag
Scenario: Compare output from current and new job profile API new version
	Given I have got a list of all available job profile from the existing API
	Then The output for each API matches for all job profiles NEW VERSION

Scenario: Compare output from current and new job profile summary API
	Given I have got a list of all available job profile from the existing API
	And I have got a list of all available job profile from the new API
    Then The existing and new job profile summaries are comparable


Scenario: Job Profile ACTOR is compared in old and new API
    Given I compare actor

    Scenario: htmloutputtest
    Given htmloutputtest

Scenario:  Check mocked response against api

Given mock test step
"""
{
  "SalaryStarter": "13500",
  "SalaryExperienced": "24000",
  "LastUpdatedDate": "ToDo",
  "MinimumHours": 41.0,
  "RelatedCareers": [
    "ToDo"
  ],
  "Soc": "9134",
  "Title": "Bottler",
  "Overview": "<p>Bottlers fill, pack and operate bottling machinery in food, drink and bottling factories.</p>",
  "WorkingPattern": "evenings / weekends",
  "AlternativeTitle": "canning and bottling operative, canning operative, canning and bottling worker, canner",
  "WorkingHoursDetails": "a week",
  "Url": "https://pp.api.nationalcareers.service.gov.uk/job-profiles/bottler",
  "WhatYouWillDo": {
    "WYDDayToDayTasks": [
      "<p>keeping machinery clean and sterile, to meet high standards of food safety</p>",
      "<p>setting up machines and starting the bottling process</p>",
      "<p>making sure bottles or jars are correctly filled and labelled</p>",
      "<p>reporting more serious machinery problems to your line manager or a technician</p>",
      "<p>sorting out any problems with the production line so bottling is not held up</p>"
    ],
    "WorkingEnvironment": {
      "Environment": "<p>Your working environment may be noisy.</p>",
      "Uniform": "",
      "Location": "<p>You could work in a factory.</p>"
    }
  },
  "ONetOccupationalCode": "ToDo",
  "MaximumHours": 43.0,
  "WhatItTakes": {
    "Skills": [
      "ToDo"
    ],
    "DigitalSkillsLevel": "<p>to be able to carry out basic tasks on a computer or hand-held device</p>"
  },
  "CareerPathAndProgression": {
    "CareerPathAndProgression": [
      "<p>With experience, you could progress to team supervisor or manager.</p>"
    ]
  },
  "WorkingPatternDetails": "on shifts",
  "HowToBecome": {
    "EntryRoutes": {
      "University": {
        "AdditionalInformation": [
          "ToDo"
        ],
        "EntryRequirements": [
          "ToDo"
        ],
        "RelevantSubjects": [
          "ToDo"
        ],
        "FurtherInformation": [
          "ToDo"
        ],
        "EntryRequirementPreface": [
          "ToDo"
        ]
      }
    },
    "EntryRouteSummary": "ToDo",
    "MoreInformation": {
      "Registration": [
        "ToDo"
      ],
      "FurtherInformation": [
        ""
      ],
      "ProfessionalAndIndustryBodies": [
        ""
      ],
      "CareerTips": [
        ""
      ]
    }
  }
}
"""
