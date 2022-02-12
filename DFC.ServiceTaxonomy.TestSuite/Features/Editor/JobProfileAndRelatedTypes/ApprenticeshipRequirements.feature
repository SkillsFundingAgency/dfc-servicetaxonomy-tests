@webtest
Feature: ApprenticeshipRequirements

@DataSource:Data/06-ApprenticeshipRequirements.xlsx 
Scenario: Verify ApprenticeshipRequirements content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under ApprenticeshipRequirements for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Info_en> in ApprenticeshipRequirements info field