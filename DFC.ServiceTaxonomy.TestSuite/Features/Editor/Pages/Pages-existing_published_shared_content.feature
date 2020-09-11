@webtest
Feature: Pages-existing_published_shared_content
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

@Editor @ignore
Scenario: Add an published shared item to a new page and publish it. Unpublish the shared content item then the page
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

#unpublish the shared content item
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query
	| skos__prefLabel | 
	| My Test Page    |
	And the "publish" graph matches the expect results using the "shared_content_by_uri" query
	| shared_content_found |
	| 0                    |

#unpublish the page
	Given I store the uri from the "preview" graph and tag it "WidgetUri" using the "get_sharedhtml_uri_for_page" query 
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_by_uri" query and the "PageUri" Uri
	| pages_found |
	| 0           |  
	And the "publish" graph matches the expect results using the "widget_by_uri" query 
	| widgets_found |
	| 0             |



@Editor @ignore
Scenario: Add an published shared item to a new page and publish it. Unpublish the page item then the shared content
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

#unpublish the page
	Given I store the uri from the "preview" graph and tag it "SharedHTMLUri" using the "get_sharedhtml_uri_for_page" query 
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_by_uri" query and the previous URI
	| pages_found |
	| 0           |  
	And the "publish" graph matches the expect results using the "widget_by_uri" query 
	| widgets_found |
	| 0             |
	And the "publish" graph matches the expect results using the "shared_content_by_uri" query and the "SharedContentUri" Uri
	| shared_content_found |
	| 1                    |

#unpublish the shared content item
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Unpublish" option for the first item that is found
	Then the unpublish action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "SharedHTMLUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query and the "SharedHTMLUri" Uri
	| skos__prefLabel | 
	| My Test Page    |
	And the "publish" graph matches the expect results using the "shared_content_by_uri" query and the "SharedHTMLUri" Uri
	| shared_content_found |
	| 0                    |

	@ignore
Scenario: Attempt to delete a shared content item which is in use on a page
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

#delete the shared content item
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Delete" option for the first item that is found
	Then the unpublish action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	And the "publish" graph matches the expect results using the "page_with_wiget_only" query
	| skos__prefLabel | 
	| My Test Page    |
	And the "publish" graph matches the expect results using the "shared_content_by_uri" query
	| shared_content_found |
	| 0                    |