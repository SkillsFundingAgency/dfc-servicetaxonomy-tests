@webtest
Feature: ContentChangeEvents_DraftFailedValidation

Background: 
	Given I logon to the editor
	Given I set the content type to be "SharedContent" 
	Given I set up a data prefix for "Title"

	#Given the test is tagged with ""
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title | Content          |
	|       | <p>Here it is<p> |
	And I save the draft item
	Then an "EmptyField" validation error is shown for "Title"

@Editor
Scenario: 3. A succesful correction is made to a new draft with validation issues
	Given I Enter the following form data for "SharedContent"
	| Title       | Content          |
	| Title Added | <p>Here it is<p> |
	And I save the draft item
	Then the save action completes succesfully
	And an event of type "Draft" has been issued to notify consumers of the change

@Editor
Scenario: 4. An unsuccesful  correction is made to a new draft with validation issues
	Given I Enter the following form data for "SharedContent"
	| Title | Content                   |
	|       | <p>Change this to this<p> |
	And I save the draft item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

@Editor
Scenario: 9. A succesful Publishing of new content item which had validation issues on save to draft
	Given I Enter the following form data for "SharedContent"
	| Title       | Content          |
	| Title Added | <p>Here it is<p> |
	When I publish the item
	Then the edit action completes succesfully
	And an event of type "Published" has been issued to notify consumers of the change

@Editor
Scenario: 10. An unsuccesful Publishing of new content item which had validation issues on save to draft
	Given I Enter the following form data for "SharedContent"
	| Title | Content                   |
	|       | <p>Change this to this<p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued
