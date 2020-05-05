@webtest
Feature: FurtherInfo

Background:
	Given I set up a data prefix for "Title"

@Editor
Scenario: Add a new FurtherInfo content item
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/FurtherInfo/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "FurtherInfo"
	| Title                    |  Url            | LinkText       |
	| My Test FurtherInfo item |  http://testcom | more info here |
	When I publish the item
	Then the add action completes succesfully
	And the new data is present in the Graph databases
