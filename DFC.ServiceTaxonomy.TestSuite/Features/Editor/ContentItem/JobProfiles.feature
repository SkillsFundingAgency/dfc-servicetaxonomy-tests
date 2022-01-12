@webtest
Feature: JobProfilesUserActions

Background:
	Given I logon to the editor
	And I create the following number of Content Types
	| Content Type                  | number |
	| Job profile specialism        | 1      |
	#| Job profile category          | 1      |
	#| SOC code                      | 2      |
	#| Working hours detail          | 1      |
	#| Working pattern detail        | 1      |
	#| Working patterns              | 1      |
	#| University entry requirements | 1      |
	#| University requirements | 1      |
	#| University link | 1      |
	#| College entry requirements | 1      |
	#| College requirements | 1      |
	#| College link | 1      |
	#| Apprenticeship entry requirements | 1      |
	#| Apprenticeship requirements | 1      |
	#| Apprenticeship link | 1      |
	#| Registration| 1      |
	| Restriction | 1      |
	#| Digital skills | 1      |

Scenario: Add Job Profile Content Item
