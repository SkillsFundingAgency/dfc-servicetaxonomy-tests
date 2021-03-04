@webtest
Feature: 1. pages-location

Background:
	Given I set up a data prefix for "skos__prefLabel"
	And I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "SharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	And I add a comment before submitting for review "To be reviewed"		
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
	And I add a comment before submitting for review "To be reviewed"	
	When I save the draft item
	Then the save action completes succesfully
	And the "preview" graph matches the expect results using the "page_with_shared_content" query and the "PageUri" Uri
	| skos__prefLabel | sharedContent           |
	| My Test Page    | __PREFIX__Draft Content |
	Given I store the uri from the "preview" graph and tag it "SharedHTMLUri" using the "get_sharedhtml_uri_for_page" query 

@Editor
Scenario:  Add a second content item to a new draft page

	Given  I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "2ndSharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title             | Content                         |
	| 2nd Draft Content | <p>Some other draft content</p> |
	When I save the draft item
	Then the item is saved succesfully

	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I Enter the following form data for "Page"
	| Title                |
	| My Test Page Updated |
	And I add the "__PREFIX__2nd Draft Content" shared content item to the existing widget
	When I publish the item
	Then the item is published succesfully
	And the "preview" graph matches the expect results using the "number_of_shared_content_on_widget_on_page" query and the "PageUri" Uri
	| count_of_sharedContent |
	| 2                      |
	And the "preview" graph matches the expect results using the "page_widget_with_two_shared_content" query and "SharedHTMLUri" and "SharedContentUri" and "2ndSharedContentUri" Uris
    | SharedContent1            | SharedContent2              |
    | __PREFIX__Draft Content | __PREFIX__2nd Draft Content |
	And the "preview" graph matches the expect results using the "number_of_shared_content_on_widget_on_page" query and the "PageUri" Uri
	| count_of_sharedContent |
	| 2                      |

#Scenario:  Publish the first shared content
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__Draft Content"
	And I select the "Publish" option for the first item that is found
	Then the item is published succesfully
	And the "publish" graph matches the expect results using the "number_of_shared_content_on_widget_on_page" query and the "PageUri" Uri
	| count_of_sharedContent |
	| 1                      |

#Scenario:  Publish the 2nd shared content
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__2nd Draft Content"
	And I select the "Publish" option for the first item that is found
	Then the item is published succesfully
	And the "publish" graph matches the expect results using the "number_of_shared_content_on_widget_on_page" query and the "PageUri" Uri
	| count_of_sharedContent |
	| 2                      |


@Editor
Scenario: Add an html item to a page
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I Enter the following form data for "Page"
	| Title               |
	| My Test Page Update |  
	And I add an html item to the page with content
	"""
	Test HTML
	"""
	When I publish the item
	Then the "preview" graph matches the expect results using the "page_with_html" query and the "PageUri" Uri
	| skos__prefLabel     | htmlbody_Html    |
	| My Test Page Update | <p>Test HTML</p> |
	Then the "publish" graph matches the expect results using the "page_with_html" query and the "PageUri" Uri
	| skos__prefLabel     | htmlbody_Html    |
	| My Test Page Update | <p>Test HTML</p> |
