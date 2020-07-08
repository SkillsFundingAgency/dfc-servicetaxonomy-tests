@webtest
Feature: GraphDataIntegritity

#TODO_DRAFT 
#add checks for missing data in draft
#add check for missing draft data in published item
#review teardown
#review coverage


Background:
	Given I set up a data prefix for "skos__prefLabel"
	Given I logon to the editor
	And I try to delete content type "TestContentPicker1"
	And I try to delete content type "TestCollectionOfTypes"

# create content type for content picker
    
	Given I add a new graph contentType called "TestContentPicker1"
	And I add the following fields
	| Display Name | Type       | Editor         |
	| Description  | Html Field | Wysiwyg editor |
	And I save the contentItem

# create second type

	Given I add a new graph contentType called "TestCollectionOfTypes"
	#Given I add a new graph contentType with bag called "TestCollectionOfTypes"
	#| Content Type       |
	#| TestContentPicker1 |
	And I add the following fields
	| Display Name | Type                 | Editor         |
	| Description  | Html Field           | Wysiwyg editor |
	| PickContent  | Content Picker Field |                |
	And I edit the "PickContent" field
	And I allow multiple items to be selected
	And I select the following items from the displayed list
	| Content Type       |
	| TestContentPicker1 |
	And I save the contentItem

# Add content to first type @URi1@
	Given I Navigate to "/Admin/Contents/ContentTypes/TestContentPicker1/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "TestContentPicker1"
	| Title           | Description         |
	| My Test content | My test description |
	When I publish the item
	Given I record the new documentId
	Then the add action completes succesfully

# Add 2nd content item to first type @URi2@
	Given I Navigate to "/Admin/Contents/ContentTypes/TestContentPicker1/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "TestContentPicker1"
	| Title            | Description          |
	| My Test content2 | My test description2 |
	When I publish the item
	Given I record the new documentId
	Then the add action completes succesfully


@Editor @Ignore
Scenario: Extra relationship
		
	# Add content the collection type, only relating the first item @URi3#
	Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "TestCollectionOfTypes"
	| Title           | Description         |
	| My Test content | My test description |
	And I pick content
	| Content         |
	| My Test content |
	When I publish the item
	Given I record the new documentId
	Then the add action completes succesfully

	# Modify neo4J data directly to relate to the second item
	Given I replace tokens in and then run the following graph update statement
"""
MATCH (a:TestCollectionOfTypes),(b:TestContentPicker1)
WHERE a.uri = '@URI3@'
and b.uri = '@URI2@'
CREATE (a)-[r:hasTestContentPicker1]->(b)
RETURN type(r)
"""

		Given I run the sync check
		And the sync completes succesfully
		And I get the results
		Then document 1 appears in the "Validated" section
		Then document 2 appears in the "Validated" section
		And document 3 appears in the "Failed Validation" section with message "expecting 1 relationships of type hasTestContentPicker1 in graph, but found 2"
		And document 3 appears in the "Repaired" section
		And the following graph query returns 0 record
	"""
MATCH (a:TestCollectionOfTypes)-[r:hasTestContentPicker1]->(b:TestContentPicker1)
WHERE a.uri = '@URI3@'
and b.uri = '@URI2@'
RETURN count(a)
	"""

@Editor @Ignore
Scenario: Missing relationship
		
	# Add content the collection type, only relating the first item
	Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "TestCollectionOfTypes"
	| Title           | Description         |
	| My Test content | My test description |
	And I pick content
	| Content         |
	| My Test content |
	| My Test content2 |
	When I publish the item
	Given I record the new documentId
	Then the add action completes succesfully

	# Modify neo4J data directly to relate to the second item
	Given I replace tokens in and then run the following graph update statement
"""
MATCH (a:TestCollectionOfTypes)-[r]-(b:TestContentPicker1)
WHERE a.uri = '@URI3@'
and b.uri = '@URI2@'
DELETE r
"""

		Given I run the sync check
		And the sync completes succesfully
		And I get the results
		Then document 1 appears in the "Validated" section
		Then document 2 appears in the "Validated" section
		And document 3 appears in the "Failed Validation" section with message "PickContent ContentPickerField did not validate: expecting 2 relationships of type hasTestContentPicker1 in graph, but found 1"
		And document 3 appears in the "Repaired" section
		And the following graph query returns 1 record
	"""
MATCH (a:TestCollectionOfTypes)-[r:hasTestContentPicker1]->(b:TestContentPicker1)
WHERE a.uri = '@URI3@'
and b.uri = '@URI2@'
RETURN count(a)
	"""

@Editor @Ignore
Scenario: Mistmatched label
	# Add content the collection type, only relating the first item
		Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
		#And I have ensured the activity I intend to add doesn't exist
		And I capture the generated URI
		And I Enter the following form data for "TestCollectionOfTypes"
		| Title           | Description         |
		| My Test content | My test description |
		And I pick content
		| Content         |
		| My Test content |
		When I publish the item
		Given I record the new documentId
		Then the add action completes succesfully

		# Modify neo4J data directly to relate to the second item
		Given I replace tokens in and then run the following graph update statement
	"""
    MERGE (a:TestCollectionOfTypes {uri: '@URI3@'})
    SET a.Description = 'update value'
    RETURN a
	"""
		Given I run the sync check
		And the sync completes succesfully
		And I get the results
		Then document 1 appears in the "Validated" section
		Then document 2 appears in the "Validated" section
		And document 3 appears in the "Failed Validation" section 
		#with message "Description HtmlField did not validate"
		And document 3 appears in the "Repaired" section
		And the following graph query returns 1 record
	"""
	MATCH (a:TestCollectionOfTypes)
	WHERE a.uri = '@URI3@'
	And a.Description = '<p>My test description</p>'
	return count(a)
	"""

@Editor @Ignore
Scenario: Missing label
	# Add content the collection type, only relating the first item
		Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
		#And I have ensured the activity I intend to add doesn't exist
		And I capture the generated URI
		And I Enter the following form data for "TestCollectionOfTypes"
		| Title           | Description         |
		| My Test content | My test description |
		And I pick content
		| Content         |
		| My Test content |
		When I publish the item
		Given I record the new documentId
		Then the add action completes succesfully

		# Modify neo4J data directly to relate to the second item
		Given I replace tokens in and then run the following graph update statement
	"""
	MERGE (a:TestCollectionOfTypes {uri: '@URI3@'})
   SET a = { uri :'@URI3@', skos__prefLabel : 'My Test content' }
   RETURN a
	"""
		Given I run the sync check
		And the sync completes succesfully
		And I get the results
		Then document 1 appears in the "Validated" section
		Then document 2 appears in the "Validated" section
		And document 3 appears in the "Failed Validation" section with message "Description HtmlField did not validate: node property value was null, but content property value was not null"
		And document 3 appears in the "Repaired" section
		And the following graph query returns 0 record
	"""
	MATCH (a:TestContentPicker1)
	WHERE a.uri = '@URI2@'
	And a.Description2 = 'new value'
	return count(a)
	"""

@Editor @Ignore
Scenario: Missing Node
	# Add content the collection type, only relating the first item
		Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
		#And I have ensured the activity I intend to add doesn't exist
		And I capture the generated URI
		And I Enter the following form data for "TestCollectionOfTypes"
		| Title           | Description         |
		| My Test content | My test description |
		And I pick content
		| Content         |
		| My Test content |
		When I publish the item
		Given I record the new documentId
		Then the add action completes succesfully

		# Modify neo4J data directly to relate to the second item
		Given I replace tokens in and then run the following graph update statement
	"""
	MATCH (a:TestContentPicker1)
	WHERE a.uri = '@URI2@'
	DELETE a
	"""

			Given I run the sync check
			And the sync completes succesfully
			And I get the results
			Then document 1 appears in the "Validated" section
			Then document 3 appears in the "Validated" section
			And document 2 appears in the "Failed Validation" section with message "Node not found."
			And document 2 appears in the "Repaired" section
			And the following graph query returns 1 record
	"""
	MATCH (a:TestContentPicker1)
	WHERE a.uri = '@URI2@'
	return count(a)
	"""
@Editor @Ignore
Scenario: Missing Node and relationship
	# Add content the collection type, only relating the first item
		Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
		#And I have ensured the activity I intend to add doesn't exist
		And I capture the generated URI
		And I Enter the following form data for "TestCollectionOfTypes"
		| Title           | Description         |
		| My Test content | My test description |
		And I pick content
		| Content         |
		| My Test content |
		| My Test content2 |
		When I publish the item
		Given I record the new documentId
		Then the add action completes succesfully

		# Modify neo4J data directly to relate to the second item
		Given I replace tokens in and then run the following graph update statement
	"""
	MATCH (a:TestCollectionOfTypes)-[r]-(b:TestContentPicker1)
	WHERE a.uri = '@URI3@'
	and b.uri = '@URI2@'
	DELETE b,r
	"""

			Given I run the sync check
			And the sync completes succesfully
			And I get the results
			Then document 1 appears in the "Validated" section
			And document 2 appears in the "Failed Validation" section with message "Node not found."
			And document 3 appears in the "Failed Validation" section with message "expecting 2 relationships of type hasTestContentPicker1 in graph, but found 1"
			And document 3 appears in the "Repaired" section
			And document 3 appears in the "Repaired" section
			And the following graph query returns 1 record
	"""
	MATCH (a:TestCollectionOfTypes)-[r]-(b:TestContentPicker1)
	WHERE a.uri = '@URI3@'
	and b.uri = '@URI2@'
	RETURN count(b)
	"""

@Editor @Ignore
Scenario: Missing parent and child Nodes and relationship
	# Add content the collection type, only relating the first item
		Given I Navigate to "/Admin/Contents/ContentTypes/TestCollectionOfTypes/Create" 
		#And I have ensured the activity I intend to add doesn't exist
		And I capture the generated URI
		And I Enter the following form data for "TestCollectionOfTypes"
		| Title           | Description         |
		| My Test content | My test description |
		And I pick content
		| Content         |
		| My Test content |
		When I publish the item
		Given I record the new documentId
		Then the add action completes succesfully

		# Modify neo4J data directly to relate to the second item
		Given I replace tokens in and then run the following graph update statement
	"""
	MATCH (a:TestCollectionOfTypes)-[r]-(b:TestContentPicker1)
	WHERE a.uri = '@URI3@'
	and b.uri = '@URI1@'
	DETACH DELETE a,b
	"""

			Given I run the sync check
			And the sync completes succesfully
			And I get the results
			Then document 2 appears in the "Validated" section
			Then document 1 appears in the "Failed Validation" section with message "Node not found."
			And document 3 appears in the "Failed Validation" section with message "Node not found."
			And document 1 appears in the "Repaired" section
			And document 3 appears in the "Repaired" section
			And the following graph query returns 1 record
	"""
	MATCH (a:TestCollectionOfTypes)-[r]-(b:TestContentPicker1)
	WHERE a.uri = '@URI3@'
	and b.uri = '@URI1@'
	RETURN count (b)
	"""

@ignore
Scenario: Extra node

	Given I generate and store a new URI
	Given I replace tokens in and then run the following graph update statement
	"""
	CREATE (a:TestContentPicker1 { uri: '@URI3@' , skos__prefLabel : 'Extra item', Description : 'Test Description'})
	RETURN a.name
	"""
	Given I run the sync check
	And the sync completes succesfully
	And I get the results
	Then document 1 appears in the "Validated" section
	Then document 2 appears in the "Validated" section
	Then document 3 appears in the "Failed Validation" section
	#section with message "Node not found."
	And document 3 appears in the "Repaired" section
	And the following graph query returns 0 record
	"""
	MATCH (a:TestContentPicker1)
	WHERE a.uri = '@URI3@'
	RETURN count (b)
	"""

#Scenario: Mismatched URI
