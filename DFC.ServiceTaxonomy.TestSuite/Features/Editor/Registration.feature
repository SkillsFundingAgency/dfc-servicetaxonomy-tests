@webtest
Feature: Registration
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add a new Registration
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Registration/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Registration"
	| Title                | Description         |
	| My Test Registration | My test description |
	When I publish the item
	Then the add action completes succesfully
	And the new data is present in the Graph databases