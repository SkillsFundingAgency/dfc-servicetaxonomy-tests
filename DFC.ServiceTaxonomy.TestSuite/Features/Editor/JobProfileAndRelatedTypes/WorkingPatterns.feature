@webtest
Feature: WorkingPatterns

@DataSource:Data/16-WorkingPattern-16.xlsx
Scenario: Verify WorkingPatterns content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under WorkingPatterns for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in WorkingPatterns description field