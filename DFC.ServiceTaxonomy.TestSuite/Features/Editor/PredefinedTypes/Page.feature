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


Scenario: Attempt to delete a shared content item that is in use
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
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