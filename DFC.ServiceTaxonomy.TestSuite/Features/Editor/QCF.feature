@webtest
Feature: QCF


Background:
	Given I set up a data prefix for "Title"

@Editor
Scenario: Add a new QCF Level
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/QCFLevel/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "QCFLevel"
	| Title             | Description         |
	| My Test QCF Level | My test description |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the Graph databases