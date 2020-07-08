@webtest
Feature: OtherRequirement

Background:
	Given I set up a data prefix for "Title"

@Editor
Scenario: Add a new FurtherInfo content item
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/OtherRequirement/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "OtherRequirement"
	| Title                     | Description         |
	| My Test Other Requirement | My test description |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the PUBLISH Graph databases

#TODO_DRAFT draft checks