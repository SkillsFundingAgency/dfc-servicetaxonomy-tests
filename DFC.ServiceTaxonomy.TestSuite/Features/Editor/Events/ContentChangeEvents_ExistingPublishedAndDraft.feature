@webtest
Feature: ContentChangeEvents_ExistingPublishedAndDraft

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
	When I publish the item
	Then the edit action completes succesfully
	#Then an event of type "draft" has been issued to notify consumers of the change
	#Given I check time of the latest event message
	Given I check the number of events sent for this contentItem

	Given I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                 | Content                |
	| Update Shared Content | <p>Here it is again<p> |
	When I save the draft item
	Then the save action completes succesfully
	Given I check the number of events sent for this contentItem

Scenario: 23. Updates are made to an existing draft version of a published content item 
	Given I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                        | Content                |
	| Newly updated Shared Content | <p>Here it is again<p> |
	When I save the draft item
	Then the edit action completes succesfully
	And an event of type "Draft" has been issued to notify consumers of the change

Scenario: 24. Updates with validation issues  are made to an existing draft version of a published content item
	Given I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                        | Content                |
	| Newly updated Shared Content | <p>Here it is again<p> |
	When I save the draft item
	Then the edit action completes succesfully
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

Scenario: 25. An existing draft version of a published content item is published succesfully
	Given I search for the "Title"
	And I select the first item that is found
	When I publish the item
	Then the save action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change
	And an event of type "Draft-discarded" has been issued to notify consumers of the change

Scenario: 26. An existing draft version of a published content item is edited so validation errors exists and publishing fails
	Given I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title | Content                |
	|       | <p>Here it is again<p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

Scenario: 27. An existing draft version of a published content item is published succesfully from the content item list view
	Given I search for the "Title"
	And I select the "Publish" option for the first item that is found
	Then the edit action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change
	And an event of type "Draft-discarded" has been issued to notify consumers of the change


Scenario: 29. A published item with a draft version is unpublished from the content item list view
	Given I search for the "Title"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change

Scenario: 30. An existing draft version of a published content item is discarded from the content item list view
	Given I search for the "Title"
	And I select the "Discard Draft" option for the first item that is found
	Then the discard action completes succesfully
	And an event of type "Draft-Discarded" has been issued to notify consumers of the change

Scenario: 33. An existing published item with a draft version is deleted from the content item list view
	Given I search for the "Title"
	And I select the "Delete" option for the first item that is found
	Then the delete action completes succesfully
	And an event of type "Deleted" has been issued to notify consumers of the change

Scenario: 36. An existing published content item with a draft version  is cloned from the content item list view

	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Clone" option for the first item that is found
	Then the clone action completes succesfully
	Given I select the first item that is found
	Then no event is issued