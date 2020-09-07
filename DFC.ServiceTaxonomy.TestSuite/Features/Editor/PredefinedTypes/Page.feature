@webtest
Feature: Page

Background:
	Given I set up a data prefix for "skos__prefLabel"

@Editor @ignore
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