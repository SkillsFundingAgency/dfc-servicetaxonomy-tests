@webtest
Feature: 1. pages-draft_content

Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	And I add a comment before submitting for review "comment "
	When I save the draft item
	Then the item is saved succesfully
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database



@Editor
Scenario: Add Shared Content item to a new page and save as draft
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        |
	| My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I save the draft item
	Then the save action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "preview" graph matches the expect results using the "page_location" query and the "PageUri" Uri
	| location |
	| /        |
	Given I store the uri from the "preview" graph and tag it "SharedHTMLUri" using the "get_sharedhtml_uri_for_page" query 
	Then the "publish" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |  
	And the "publish" graph matches the expect results using the "widget_by_uri" query and the "SharedHTMLUri" Uri
	| widgets_found |
	| 0             |


@Editor
Scenario: Add Shared Content item to a new page and publish
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        |
	| My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query and the "PageUri" Uri
	| skos__prefLabel | 
	| My Test Page    | 
