@webtest
Feature: 2. pages-draft_content_on_draft_page
Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "SharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	And I add a comment before submitting for review "comment "
	When I save the draft item
	Then the item is saved succesfully
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database

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
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	Given I store the uri from the "preview" graph and tag it "SharedHTMLUri" using the "get_sharedhtml_uri_for_page" query 


@Editor
Scenario: Publish the page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the "Publish" option for the first item that is found
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query and the "PageUri" Uri
	| skos__prefLabel | 
	| My Test Page    |

@Editor
Scenario: Delete the page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the "Delete" option for the first item that is found
	Then the delete action completes succesfully
	And the "preview" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |
	And the "preview" graph matches the expect results using the "widget_by_uri" query and the "PageUri" Uri
	| widgets_found |
	| 0             |
	And the "preview" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |
	And the "preview" graph matches the expect results using the "widget_by_uri" query and the "PageUri" Uri
	| widgets_found |
	| 0             |

@Editor
Scenario: Delete the shared content
Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Delete" option for the first item that is found
	Then the delete action could not be completed
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |

