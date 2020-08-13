@webtest
Feature: Page

Background:
	Given I set up a data prefix for "skos__prefLabel"

@Editor
Scenario: Add a new page with an html item
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Page"
	| Title                    |  
	| My Test Page | 
	#And I run my testbed
	And I select the default page location
	And I add an html item to the page with content
	"""
	Test HTML
	"""
	When I publish the item
	Then the preview and publish graphs returns the expected results using the "page_with_html" query
	| skos__prefLabel | htmlbody_Html    |
	| My Test Page    | <p>Test HTML</p> |


Scenario: Add a new page with a shared content item
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Page"
	| Title                    |  
	| My Test Page | 
	#And I run my testbed
	And I select the default page location
	And I add the "Contact us" shared content item to the page
	When I publish the item
	Then the preview and publish graphs returns the expected results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent |
	| My Test Page    | Contact us    |


Scenario: Add a new page with a shared content item and save as draft
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Page"
	| Title                    |  
	| My Test Page | 
	#And I run my testbed
	And I select the default page location
	And I add the "Contact us" shared content item to the page
	When I save the draft item
	Then the "preview" graph matches the expect results using the "page_with_shared_content" query
	| skos__prefLabel | sharedContent |
	| My Test Page    | Contact us    |
	And the data is not present in the PUBLISH Graph database

Scenario: Add an unpublished shared item to a new page and attempt to publish
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	When I save the draft item
	Then the item is saved succesfully
	And the data is present in the DRAFT Graph database
	And the data is not present in the PUBLISH Graph database

	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "Page"
	| Title        |
	| My Test Page |
	#And I run my testbed
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
	| 0           |

#	Given I store the uri from the "preview" graph using the "get_sharedhtml_uri_for_page" query 


#	cycling through the state changes i guess and checking the graph is correct
#so combos of published/draft pages/content types
#e.g published page referencing pub + draft shared content
#publishing the shared content (edited) 
#unbpublishing the shared content
#new draft of the page with pub+draft shared items
#checking the widgets get deleted also when unpublishing/deleting a page
#making sure when publishing a referenced draft item that the icoming relationships from the htmlshared widget are recreated
#good to have other content items in the mix, even if they're not part of the core test
#that's why i suggested page -> pub & draft items
#even if the test is publishing a referenced draft shared content item
#it should check that the whole page/shared content/widgets graph stuff that you'd expect to be unchanged was actually unchanged
#also of course adding locations, deleting locations etc
#also checking that it doesn't allow you to delete items that are referenced
#e.g. you shouldn't be able to delete a location/shared content item if its in use by a page (only after deleting what references it can it be deleted)