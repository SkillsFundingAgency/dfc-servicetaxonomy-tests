﻿@webtest
Feature: RequirementsPrefix


Background:
	Given I set up a data prefix for "Title"

@Editor
Scenario: Add a new RequirementsPrefix
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/RequirementsPrefix/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "RequirementsPrefix"
	| Title                      | Text                |
	| My Test RequirementsPrefix | My test description |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the Graph databases