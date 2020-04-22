Feature: GraphDataIntegritity
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I set up a data prefix for "skos__prefLabel"
	Given I logon to the editor

# create content type for content picker
Given I add a new graph contentType called "AutomatedTestItem"
#	Enter Display Name and Technical Name, click create
#Add Parts page shown
#	And I add the "Title" part
#	And I add the "Graph Sync" part
#	And I save the new item
	And I edit the "Graph Sync" part
	And I set the following field values
	| Field                  | Value                                                                                  |
	| RelationshipType       |                                                                                        |
	| NodeNameTransform      | $"ncs__{Value}"                                                                        |
	| PropertyNameTransform  | $"ncs__{Value}"                                                                        |
	| CreateRelationshipType |                                                                                        |
	| IDPropertyName         | uri                                                                                    |
	| GenerateIDValue        | $"http://nationalcareers.service.gov.uk/{Value.ToLowerInvariant()}/{Guid.NewGuid():D}" |
	And I save the edited part
	And I add the following fields
	| Display Name | Type          |
	| TextField    | Text Field    |
	| ValueField   | Numeric Field |

#contentType data
# Name
# Fie

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
