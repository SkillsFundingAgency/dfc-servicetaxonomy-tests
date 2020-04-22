@webtest
Feature: GraphDataIntegritity
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I set up a data prefix for "skos__prefLabel"
	Given I logon to the editor
	And I try to delete content type "TestContentPicker1"

# create content type for content picker
    Given I add a new graph contentType called "TestContentPicker1"
	And I add the following fields
	| Display Name | Type       | Editor         |
	| Description  | Html Field | Wysiwyg editor |
	
#contentType data
# Name
# Fie

@mytag
Scenario: Initial Sync Test
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
