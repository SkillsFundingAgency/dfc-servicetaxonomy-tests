@webtest
Feature: ContentChangeEvents_EdgeCases
	Scenarios that don't fit into another section

@Editor @NotDev
@ignore  
#todo
#Publish option not available for a published item in the list view
Scenario: 22. Publish draft is selected from the content item list view for an existing published item without changes 
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Publish" option for the first item that is found
	Then the edit action completes succesfully
	And no event is issued