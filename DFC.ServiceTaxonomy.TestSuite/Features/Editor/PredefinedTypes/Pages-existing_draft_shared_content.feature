@webtest
Feature: Pages-existing_draft_shared_content
Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	When I save the draft item
	Then the item is saved succesfully
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database

@Editor
Scenario: Add an draft shared item to a new page and attempt to publish
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI
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
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query
	| skos__prefLabel | 
	| My Test Page    | 

#Scenario: Delete an published item with a draft shared content item
	Given I store the uri from the "preview" graph using the "get_sharedhtml_uri_for_page" query 
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	When I delete the item
	Then the delete action completes succesfully
	And the "preview" graph matches the expect results using the "page_by_uri" query and the previous URI
	| pages_found |
	| 0           |
	And the "publish" graph matches the expect results using the "widget_by_uri" query and the previous URI
	| widgets_found |
	| 0             |


@Editor
Scenario: Publish a draft shared content in use on a published page
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI
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
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query
	| skos__prefLabel | 
	| My Test Page    |
	Given  I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Publish" option for the first item that is found
	Then the edit action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |


@Editor
Scenario: Add an draft shared item to a new page and and save the page as draft, then publish the shared item, then publish the page
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI
	And I Enter the following form data for "Page"
	| Title        |
	| My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	When I save the draft item
	Then the item is saved succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_by_uri" query
	| pages_found |
	| 0           |  

# publish the shared item
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Publish" option for the first item that is found
	Then the edit action completes succesfully
	And the "publish" graph matches the expect results using the "shared_content_with_no_related_items" query
	| sharedContent           |
	| __PREFIX__Draft Content |

# publish the page
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the "Publish" option for the first item that is found
	Then the edit action completes succesfully
	And the "publish" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |