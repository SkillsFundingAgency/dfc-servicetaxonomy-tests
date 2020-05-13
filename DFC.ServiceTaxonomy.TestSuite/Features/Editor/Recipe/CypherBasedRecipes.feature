@notwebtest
Feature: CypherBasedRecipes
	This feature covers Content from cypher recipe and  Update neo4j recipe

	Background: 
	Given I set up a data prefix for "test__Name"
	And I get the recipe files ready
	Given I logon to the editor
#	And I delete any items of type "CypherItem"
	And I try to delete content type "CypherItem"
	And I delete Graph data for content type "test__CypherItem"
	And I delete SQL Server data for content type "CypherItem"
#create a new content type
	And I add a new contentType called "CypherItem"
	And I edit the "Graph Sync" part
	And I set the following field values
	| Field                  | Value                                                                             |
	| RelationshipType       |                                                                                   |
	| NodeNameTransform      | $"test__{ContentType}"                                                            |
	| PropertyNameTransform  |                                                                                   |
	| CreateRelationshipType |                                                                                   |
	| IDPropertyName         | uri                                                                               |
	| GenerateIDValue        | $"http://data.europa.eu/esco/occupation/{ContentType.ToLowerInvariant()}/{Value}" |
	And I save the edited part
	And I add the following fields
	| Display Name | Type          |
	| TextField    | Text Field    |
	| ValueField   | Numeric Field |

@NotEditor
Scenario: I use recipes to create neo4j content and import it into orchard core
#CypherCommand
	Given I load recipe file "create_neo4j_content.json"
	And I confirm the following "test__CypherItem" data is preset in the Graph Database
	| uri         | test__Name   | test__Description |
	| uri::thing1 | Test Thing 1 | test description |
	| uri::thing2 | Test Thing 2 | test description |


#CypherToContent
	And I load recipe file "import_neo4j_data.json"
	Then I can navigate to the content item "Test Thing 1" in Orchard Core core
	And the values displayed in the editor match
	| Uri         | Title        | 
	| uri::thing1 | Test Thing 1 | 
	

