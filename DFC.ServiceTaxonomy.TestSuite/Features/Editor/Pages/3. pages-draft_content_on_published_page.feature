@webtest
Feature: 3. Pages-draft_content_on_published_page
Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "SharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	#And I add a comment before submitting for review "comment "
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
	When I publish the item
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query and the "PageUri" Uri
	| skos__prefLabel |
	| My Test Page    | 
	Given I store the uri from the "preview" graph and tag it "SharedHTMLUri" using the "get_sharedhtml_uri_for_page" query 


Scenario: Publish the shared content
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the first item that is found
	When I publish the item
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |


Scenario: Unpublish the page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I select the "Unpublish" option for the first item that is found
	Then the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |
	And the "publish" graph matches the expect results using the "widget_by_uri" query and the "PageUri" Uri
	| widgets_found |
	| 0             |


Scenario: Add new draft version of the page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I Enter the following form data for "Page"
	| Title                |
	| My Updated Test Page |
	And I add a comment before submitting for review "comment "
	When I save the draft item
	Then the item is saved succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel      | sharedContent           |
	| My Updated Test Page | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query and the "PageUri" Uri
	| skos__prefLabel | 
	| My Test Page    |


Scenario: Delete the page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I delete the item
	And I confirm I wish to proceed
	Then the delete action completes succesfully
	And the "preview" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |
	And the "preview" graph matches the expect results using the "widget_by_uri" query and the "PageUri" Uri
	| widgets_found |
	| 0             |
	And the "publish" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |
	And the "publish" graph matches the expect results using the "widget_by_uri" query and the "PageUri" Uri
	| widgets_found |
	| 0             |
	And the "preview" graph matches the expect results using the "shared_content_by_uri" query and the "SharedContentUri" Uri
	| shared_content_found |
	| 1                    |
	And the "preview" graph matches the expect results using the "shared_content_by_uri" query and the "SharedContentUri" Uri
	| shared_content_found |
	| 1                    |



Scenario: Delete the shared content
Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the first item that is found
	And I delete the item
	And I confirm I wish to proceed
	Then the delete action could not be completed
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |

