Feature: JobProfileComparison
  This was used to  compare the output of the current live JobProfile API against the new version


Scenario: Compare output from current and new job profile API new version
	Given I have got a list of all available job profile from the existing API
	Then The output for each API matches for all job profiles NEW VERSION

