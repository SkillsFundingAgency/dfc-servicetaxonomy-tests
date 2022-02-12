@webtest
Feature: WorkingHoursDetails

@DataSource:Data/22-WorkingHoursDetails-8.xlsx
Scenario: Verify WorkingHoursDetails content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under WorkingHoursDetail for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in WorkingHoursDetail description field