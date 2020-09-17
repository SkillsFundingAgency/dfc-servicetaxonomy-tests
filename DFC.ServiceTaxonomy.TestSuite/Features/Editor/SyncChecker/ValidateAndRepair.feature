@webtest
Feature: ValidateAndRepair


Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "SharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	When I publish the item
	Then the item is published succesfully
	And the data is present in the DRAFT Graph database
	And the data is present in the PUBLISH Graph database

	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        |
	| My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	When I publish the item
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |

@Editor
Scenario: Identify and repair a Missing Node

	Then the "preview" graph matches the expect results using the "remove_widget" query and the "PageUri" Uri
	| skos__prefLabel |
	| My Test Page    |
	Given I run the sync check
	And the sync completes succesfully
	Then the document "__PREFIX__My Test Page" appears in the "publish" and "Validated" section
	Then the document "__PREFIX__My Test Page" appears in the "preview" and "Failed Validation" section
	And the document "__PREFIX__My Test Page" appears in the "preview" and "Repaired" section
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |

@Editor
Scenario: Identify and repair a Missing Relationship

	Then the "preview" graph matches the expect results using the "remove_relationship_to_widget" query and the "PageUri" Uri
	| skos__prefLabel |
	| My Test Page    |
	Given I run the sync check
	And the sync completes succesfully
	Then the document "__PREFIX__My Test Page" appears in the "publish" and "Validated" section
	Then the document "__PREFIX__My Test Page" appears in the "preview" and "Failed Validation" section
	And the document "__PREFIX__My Test Page" appears in the "preview" and "Repaired" section
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |

@Editor
Scenario: Identify and repair a Missing Relationship Property

	Then the "preview" graph matches the expect results using the "remove_properties_from_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size |
	|           |         |      |
	Given I run the sync check
	And the sync completes succesfully
	Then the document "__PREFIX__My Test Page" appears in the "publish" and "Validated" section
	Then the document "__PREFIX__My Test Page" appears in the "preview" and "Failed Validation" section
	And the document "__PREFIX__My Test Page" appears in the "preview" and "Repaired" section
	And the "preview" graph matches the expect results using the "check_properties_for_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size |
	| Justify   | 0       | 100  |

@Editor
Scenario: Identify and repair a mismatching Relationship Property

	Then the "preview" graph matches the expect results using the "update_properties_for_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size |
	| xxx       | yyy     | zzz  |
	Given I run the sync check
	And the sync completes succesfully
	Then the document "__PREFIX__My Test Page" appears in the "publish" and "Validated" section
	Then the document "__PREFIX__My Test Page" appears in the "preview" and "Failed Validation" section
	And the document "__PREFIX__My Test Page" appears in the "preview" and "Repaired" section
	And the "preview" graph matches the expect results using the "check_properties_for_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size |
	| Justify   | 0       | 100  |

@Editor
Scenario: Identify and repair an unexpected Relationship Property

	Then the "preview" graph matches the expect results using the "add_property_to_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size | additional |
	| Justify   | 0       | 100  | xxx        |
	Given I run the sync check
	And the sync completes succesfully
	Then the document "__PREFIX__My Test Page" appears in the "publish" and "Validated" section
	Then the document "__PREFIX__My Test Page" appears in the "preview" and "Failed Validation" section
	And the document "__PREFIX__My Test Page" appears in the "preview" and "Repaired" section
	And the "preview" graph matches the expect results using the "check_for_additional_properties_on_page_to_widget_relationship" query and the "PageUri" Uri
	| alignment | ordinal | size | additional |
	| Justify   | 0       | 100  |            |