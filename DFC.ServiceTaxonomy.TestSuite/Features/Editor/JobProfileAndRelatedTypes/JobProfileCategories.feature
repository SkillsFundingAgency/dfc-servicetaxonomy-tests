@webtest
Feature: JobProfileCategories

@DataSource:Data/17-JobProfileCategories-25.xlsx
Scenario: Verify JobProfileCategories content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under JobProfileCategory for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in JobProfileCategory description field
	And I see <UrlName> as url name
	And I see <FullUrl> as full url