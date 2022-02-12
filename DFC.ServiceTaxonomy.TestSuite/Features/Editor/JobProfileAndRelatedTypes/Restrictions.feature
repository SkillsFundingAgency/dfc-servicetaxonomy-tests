@webtest
Feature: Restrictions

@DataSource:Data/02-Restrictions.xlsx 
Scenario: Verify Restrictions content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under Restriction for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Info_en> in Restriction info field