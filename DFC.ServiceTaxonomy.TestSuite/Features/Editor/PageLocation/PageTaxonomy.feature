@webtest
Feature: PageTaxonomy

Background:

	Given I set up a data prefix for "skos__prefLabel"
	Given I logon to the editor
	Given I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	And I capture the generated URI and tag it "SharedContentUri"
	And I Enter the following form data for "SharedContent"
	| Title         | Content                   |
	| Draft Content | <p>Some draft content</p> |
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully

@Editor
Scenario: Add a page with a full url that conflicts with an existing page location
	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to add an new PageLocation under the first item
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
	| Breadcrumb     | 
	| The Breadcrumb | 
	And I add a comment before submitting for review "comment "
	And I publish the item

	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        | URL Name                 |
	| My Test Page | __PREFIX__the breadcrumb |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I save the draft item
	Then the error "This URL has already been used as a Page Location" is displayed

@Editor
Scenario: Attempt to save edit to a page with a full url that conflicts with an existing page location
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        | URL Name               |
	| My Test Page | __PREFIX__My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully

	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to add an new PageLocation under the first item
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
		| Breadcrumb     | 
		| The Breadcrumb | 
	And I add a comment before submitting for review "comment "
	And I publish the item

	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I Enter the following form data for "Page"
	| URL Name                 |
	| __PREFIX__the breadcrumb |
	When I save the draft item
	Then the error "This URL has already been used as a Page Location" is displayed

@Editor
Scenario: Attempt to publish edits to a page with a full url that conflicts with an existing page location
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        | URL Name               |
	| My Test Page | __PREFIX__My Test Page |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully

	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to add an new PageLocation under the first item
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
		| Breadcrumb     | 
		| The Breadcrumb | 
	And I add a comment before submitting for review "comment "
	And I publish the item

	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text "__PREFIX__My Test Page"
	And I select the first item that is found
	And I Enter the following form data for "Page"
	| URL Name                 |
	| __PREFIX__the breadcrumb |
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the error "This URL has already been used as a Page Location" is displayed


@Editor
Scenario: Attempt to add a page location with a path that conflicts with an existing page full url
	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        | URL Name               |
	| My Test Page | __PREFIX__the breadcrumb |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully

	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to add an new PageLocation under the first item
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
		| Breadcrumb     | 
		| The Breadcrumb | 
	And I add a comment before submitting for review "comment "
	And I publish the item
	Then the error "The generated URL for '__PATH__' has already been used as a Page URL." is displayed

@Editor @Ignore
Scenario: Attempt to publish edits to a page location with a full url that conflicts with an existing page full url

	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to add an new PageLocation under the first item
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
		| Breadcrumb            |
		| The intial breadcrumb |
	And I add a comment before submitting for review "comment "
	And I publish the item

	Given I Navigate to "/Admin/Contents/ContentTypes/Page/Create" 
	And I capture the generated URI and tag it "PageUri"
	And I Enter the following form data for "Page"
	| Title        | URL Name               |
	| My Test Page | __PREFIX__the breadcrumb |
	And I select the default page location
	And I add the "__PREFIX__Draft Content" shared content item to the page
	And I add a comment before submitting for review "comment "
	When I publish the item
	Then the item is published succesfully

	Given I Navigate to "/Admin/Contents/ContentItems/4eembshqzx66drajtdten34tc8/Edit"
	Given I click to edit the PageLocation '__PATH__'
	And I capture the generated URI and tag it "PageLocationUri"
	And I Enter the following form data for "PageLocation"
		| Breadcrumb     | Path |
		| The Breadcrumb |      |
	And I add a comment before submitting for review "comment "
	And I publish the item
	And I confirm I wish to proceed
	Then the error "The generated URL for '__PATH__' has already been used as a Page URL." is displayed
