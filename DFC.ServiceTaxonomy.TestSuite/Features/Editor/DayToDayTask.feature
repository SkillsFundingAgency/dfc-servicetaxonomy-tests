@notwebtest
Feature: DayToDayTasks

Background:
	Given I set up a data prefix for "skos__prefLabel"

@NotEditor
Scenario: Add a new DayToDayTask
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/DayToDayTask/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "DayToDayTask"
	| Title                   | Description         |
	| My Test Day to Day task | My test description |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the Graph databases
