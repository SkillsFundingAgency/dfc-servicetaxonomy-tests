@webtest
Feature: JobProfilesUserActions

Background:
	Given I logon to the editor
	And I create the following number of Content Types
	| Content Type           | number |
	| Job profile specialism | 2      |
	| Job profile category   | 2      |
	| SOC code               | 2      |

Scenario: Add Job Profile Specialism Content Type
