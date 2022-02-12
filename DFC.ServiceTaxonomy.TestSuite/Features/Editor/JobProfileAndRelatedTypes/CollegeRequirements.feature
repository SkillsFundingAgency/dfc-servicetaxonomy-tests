@webtest
Feature: CollegeRequirements

@DataSource:Data/07-CollegeRequirements.xlsx 
Scenario: Verify CollegeRequirements content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under CollegeRequirements for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Info_en> in CollegeRequirements info field