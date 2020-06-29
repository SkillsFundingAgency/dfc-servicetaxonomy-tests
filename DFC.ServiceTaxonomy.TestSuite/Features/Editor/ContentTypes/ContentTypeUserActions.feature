@webtest
Feature: ContentTypeUserActions

Background:
	Given I logon to the editor
	And I try to delete content type "AutomatedTestItem"

@Editor
Scenario: Add a new content type with Title Part
	Given I add a new contentType called "AutomatedTestItem"
#	Enter Display Name and Technical Name, click create
#Add Parts page shown
#	And I add the "Title" part
#	And I add the "Graph Sync" part
#	And I save the new item
	And I edit the "Graph Sync" part
	And I set the following field values
	| Field                  | Value                                                                                  |
	| RelationshipType       |                                                                                        |
	| NodeNameTransform      | $"{Value}"                                                                        |
	| PropertyNameTransform  | $"{Value}"                                                                        |
	| CreateRelationshipType |                                                                                        |
	| IDPropertyName         | uri                                                                                    |
	| GenerateIDValue        | $"http://nationalcareers.service.gov.uk/{Value.ToLowerInvariant()}/{Guid.NewGuid():D}" |
	And I save the edited part
	And I add the following fields
	| Display Name | Type          |
	| TextField    | Text Field    |
	| ValueField   | Numeric Field |

	And I save the contentItem
#TODO check in sql datastore
#New Type is saved
	And I Navigate to "/Admin/Contents/ContentTypes/AutomatedTestItem/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data 
	| Field      | Value     | Type           |
	| Title      | TestItem  | Title          |
	| TextField  | Test text | Text Field     |
	| ValueField | 26        | Numeric Field  |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the Graph databases
	When I publish the item
#	Then the graph item matches the one in the editor
	Then the data is present in the Graph databases
#	And the graph item matches the one in the editorTODO
	