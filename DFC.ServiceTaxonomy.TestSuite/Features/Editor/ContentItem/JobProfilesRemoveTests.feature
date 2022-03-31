@webtest
Feature: JobProfilesRemoveTests
	Remove Job Profile tests

Scenario: Remove tests
Given I logon to the editor
And I had created tests infix "_Auto_" in the Title
When I run this scenario
Then all tests with such infix are removed