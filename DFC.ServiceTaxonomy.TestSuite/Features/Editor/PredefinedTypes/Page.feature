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
	Then the "Preview" graph matches the expect results using the "page_with_html" query
	| Title         | Html   | 
	| My Test Page  | Test Thing 1 | 
	| uri::thing2 | Test Thing 2 | 