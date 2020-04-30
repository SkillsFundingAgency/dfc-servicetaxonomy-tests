@webtest
Feature: GraphEditor
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@ignore
Scenario: Add, edit and remove an activity in the editor
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Activity/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Activity"
	| Title           |
	| My new activity |
	When I publish the item
	Then the add action completes succesfully
	And the new data is present in the Graph databases

#Scenario: Edit the new activity
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data
         | Title              |
         | New activity title |
	When I publish the item
	Then the edit action completes succesfully
	And the new data is present in the Graph databases

#Scenario: Edit the new activity
	Given I search for the "Title"
	When I delete the item
	And I confirm the delete action
	Then the delete action completes succesfully
	And the data is not present in the Graph databases