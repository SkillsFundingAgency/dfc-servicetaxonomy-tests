@webtest
Feature: DayToDayTasks

Background:
	Given I set up a data prefix for "skos__prefLabel"

@EditorR2
Scenario: Add a new DayToDayTask
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/DayToDayTask/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "DayToDayTask"
	| Title                   | Description         |
	| My Test Day to Day task | My test description |
	When I publish the item
	Then the item is published succesfully
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database

#TODO_DRAFT draft checks
@EditorR2
Scenario: Save new draft DayToDayTask
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/DayToDayTask/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "DayToDayTask"
	| Title                   | Description         |
	| My Test Day to Day task | My test description |
	When I save the draft item
	Then the item is saved succesfully
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database
