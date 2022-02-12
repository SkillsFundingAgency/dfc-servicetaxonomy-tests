@webtest
Feature: HiddenAlternativeTitles

@DataSource:Data/14-HiddenAlternativeTitle-256.xlsx
Scenario: Verify HiddenAlternativeTitles content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under HiddenAlternativeTitle for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in HiddenAlternativeTitle description field