﻿@webtest
Feature: UniversityLink

Background:
	Given I set up a data prefix for "Title"

@EditorR2
Scenario: Add a new UniversityLink
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/UniversityLink/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "UniversityLink"
	| Title                  | Url             | LinkText      |
	| My Test UniversityLink | http://test.com | more info ho! |
	When I publish the item
	Then the item is published succesfully
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database


#TODO_DRAFT draft checks