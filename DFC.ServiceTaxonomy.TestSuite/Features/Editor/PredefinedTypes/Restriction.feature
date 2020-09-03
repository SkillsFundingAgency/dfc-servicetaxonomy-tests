@webtest
Feature: Restriction

Background:
	Given I set up a data prefix for "Title"

@EditorR2
Scenario: Add a new Restriction
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Restriction/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Restriction"
	| Title               | Description         |
	| My Test Restriction | My test description |
	When I publish the item
	Then the item is published succesfully
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database

#TODO_DRAFT draft checks