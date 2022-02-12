@webtest
Feature: CollegeLinks

@DataSource:Data/04-CollegeLinks.xlsx
Scenario: Verify CollegeLinks content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under CollegeLink for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Url_en> in CollegeLink url field
	And I see <Text_en> in CollegeLink text field