@webtest
Feature: JobProfilesUserActions

Background:
	Given I logon to the editor
	And I create the following number of Content Types
	| Content Type                      | number |
	| Job profile specialism            | 2      |
	| Job profile category              | 2      |
	| SOC code                          | 2      |
	| Working hours detail              | 2      |
	| Working pattern detail            | 2      |
	| Working patterns                  | 2      |
	| University entry requirements     | 2      |
	| University requirements           | 2      |
	| University link                   | 2      |
	| College entry requirements        | 2      |
	| College requirements              | 2      |
	| College link                      | 2      |
	| Apprenticeship entry requirements | 2      |
	| Apprenticeship requirements       | 2      |
	| Apprenticeship link               | 2      |
	| Registration                      | 2      |
	| Restriction                       | 2      |
	| Digital skills                    | 2      |
	| Location                          | 2      |
	| Environment                       | 2      |
	| Uniform                           | 2      |

Scenario: Add Job Profile Content Item
	#And I start a new Job Profile type
