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

Scenario: Missing Node

	Then the "preview" graph matches the expect results using the "remove_relationship_to_widget" query and the "PageUri" Uri
	| skos__prefLabel | 
	| My Test Page    | 
	Given I run the sync check
	And the sync completes succesfully
	And I get the results
	Then document 1 appears in the "Validated" section