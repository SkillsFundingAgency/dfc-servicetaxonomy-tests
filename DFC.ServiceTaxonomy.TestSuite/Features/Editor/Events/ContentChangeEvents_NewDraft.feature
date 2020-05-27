﻿@webtest
Feature: ContentChangeEvent for new draft

Background: 
	Given I logon to the editor
	Given I set the content type to be "SharedContent" 
	Given I set up a data prefix for "Title"

	#Given the test is tagged with ""
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title              |  Content          |
	| New Shared Content |  <p>Here it is<p> |
	And I save the draft item
	#Then an event of type "draft" has been issued to notify consumers of the change
	#Given I check time of the latest event message
	Given I check the number of events sent for this contentItem

Scenario: 13. An update to an existing draft document is succesful
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                  | Content              |
	| updated Shared Content | <p>Here it is now<p> |
	When I save the draft item
	Then the save action completes succesfully
	#And the data is present in the draft graph databases
	And an event of type "Draft" has been issued to notify consumers of the change


Scenario: 14. An update to an existing draft document fails with validation issues
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title | Content              |
	|       | <p>Here it is now<p> |
	When I save the draft item
	Then a validation error is shown
	And no event is issued

Scenario: 15. An existing draft content item is succesfully published
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	When I publish the item
	Then the edit action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change

Scenario: 16. An existing draft content item is updated and fails validation when published
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title | Content              |
	|       | <p>Here it is now<p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

Scenario: 17. An existing draft content item is published from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Publish" option first item that is found
	Then the edit action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change

Scenario: 31. An existing draft content item is deleted from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Delete" option first item that is found
	Then the delete action completes succesfully
	And an event of type "Delete" has been issued to notify consumers of the change


Scenario: 34. An existing published content item is cloned from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Clone" option first item that is found
	Then the clone action completes succesfully
	Given I select the first item that is found
#	And I capture the URI of the cloned item
#	Then the action completes succesfully
	Then an event of type "Clone" has been issued to notify consumers of the change

