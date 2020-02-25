Feature: JobProfileComparison
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Compare output from current and new job profile API
	Given I have got a list of all available job profile from the existing API
	Then The output for each API matches for all job profiles
