﻿@webtest
Feature: ContentChangeEvents_NewItems

Background:
	Given I logon to the editor
	Given I set the content type to be "SharedContent" 
	Given I set up a data prefix for "Title"

Scenario: 1. A new content item draft is created that passes server validation
	Given I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title              |  Content          |
	| New Shared Content |  <p>Here it is<p> |
	When I save the draft item
	Then the save action completes succesfully
	And an event of type "Draft" has been issued to notify consumers of the change

Scenario: 2. A new content item draft is created that fails server validation
	Given I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title | Content          |
	|       | <p>Here it is<p> |
	When I save the draft item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

Scenario: 7. A new content item is published succesfully
	Given I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title              |  Content          |
	| New Shared Content |  <p>Here it is<p> |
	When I publish the item
	Then the edit action completes succesfully
	And an event of type "Publish" has been issued to notify consumers of the change

Scenario: 8. A new content item is published with validation issues
	Given I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title | Content          |
	|       | <p>Here it is<p> |
	When I publish the item
	Then an "EmptyField" validation error is shown for "Title"
	And no event is issued

@ignore
#TODO
Scenario: 37. A recipe file is imported
