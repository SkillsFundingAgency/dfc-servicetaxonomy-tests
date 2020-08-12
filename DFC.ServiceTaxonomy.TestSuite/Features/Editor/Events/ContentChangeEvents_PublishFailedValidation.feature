@webtest
Feature: ContentChangeEvents_PublishFailedValidation

Background: 
	Given I logon to the editor
	Given I set the content type to be "SharedContent" 
	Given I set up a data prefix for "Title"

	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title | Content          |
	|       | <p>Here it is</p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"

@Editor
Scenario: 5. A succesful save to draft is made to a new content item which had validation issues on publish
	Given I Enter the following form data for "SharedContent"
	| Title       | Content          |
	| Title Added | <p>Here it is</p> |
	And I save the draft item
	Then the save action completes succesfully
	And an event of type "Draft" has been issued to notify consumers of the change
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database
	And the number of events sent for this content Item is 1

@Editor
Scenario: 6. An unsuccesful save to draft is made to a new content item which had validation issues on publish
	Given I Enter the following form data for "SharedContent"
	| Title | Content                   |
	|       | <p>Change this to this</p> |
	And I save the draft item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued
	And the data is not present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database

@Editor
Scenario: 11. A succesful Publishing of  new content item which had validation issues on publish
	Given I Enter the following form data for "SharedContent"
	| Title       | Content          |
	| Title Added | <p>Here it is</p> |
	When I publish the item
	Then the edit action completes succesfully
	And an event of type "Published" has been issued to notify consumers of the change
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database
	And the number of events sent for this content Item is 1

@Editor
Scenario: 12. An unsuccesful Publishing of  new content item which had validation issues on publish
	Given I Enter the following form data for "SharedContent"
	| Title | Content                   |
	|       | <p>Change this to this</p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued
	And the data is not present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database
