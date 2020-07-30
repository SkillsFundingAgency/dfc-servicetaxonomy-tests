@webtest
Feature: ContentChangeEvents_ExistingPublished

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
	| New Shared Content |  <p>Here it is</p> |
	When I publish the item
	#Then an event of type "draft" has been issued to notify consumers of the change
	#Given I check time of the latest event message
	Given I check the number of events sent for this contentItem

@Editor
Scenario: 18. A new draft version of an existing, published content item is created
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                  | Content              |
	| updated Shared Content | <p>Here it is now</p> |
	When I save the draft item
	Then the save action completes succesfully
	And an event of type "Draft" has been issued to notify consumers of the change
	And the data is present in the DRAFT Graph database
	And the intial data is present in the PUBLISH Graph database
	And the number of events sent for this content Item is 2

@Editor @NegativeTest
Scenario: 19. A new draft version of an existing, published content item has validation issues
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title | Content              |
	|       | <p>Here it is now</p> |
	When I save the draft item
	Then an "EmptyField" validation error is shown for "Title"
	And the intial data is present in the DRAFT Graph database
	And the intial data is present in the PUBLISH Graph database
	And the number of events sent for this content Item is 1

@Editor
Scenario: 20. Updates to an existing published content item are published succesfully
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                  | Content              |
	| updated Shared Content | <p>Here it is now</p> |
	When I publish the item
	Then the edit action completes succesfully
	And an event of type "Published" has been issued to notify consumers of the change
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database
	And the number of events sent for this content Item is 2

@Editor @NegativeTest
Scenario: 21. Updates to an existing published content item fails to publish with validation issues
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title | Content              |
	|       | <p>Here it is now</p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And the intial data is present in the DRAFT Graph database
	And the intial data is present in the PUBLISH Graph database
	And the number of events sent for this content Item is 1

@Editor
Scenario: 28. A published item is unpublished from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And an event of type "Unpublished" has been issued to notify consumers of the change
	And an event of type "Draft" has been issued to notify consumers of the change
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database
	And the number of events sent for this content Item is 3

@Editor
Scenario: 32. An existing published content item is deleted from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Delete" option for the first item that is found
	Then the delete action completes succesfully
	And an event of type "Deleted" has been issued to notify consumers of the change
	And the data is not present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database
	And the number of events sent for this content Item is 2

@Editor @ignore
Scenario: 35. An existing draft content item is cloned from the content item list view
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the "Clone" option for the first item that is found
	Then the clone action completes succesfully
	Given I select the first item that is found
	Then no event is issued
