@webtest
Feature: ApprenticeshipStandards

@DataSource:Data/01-ApprenticeshipStandards-642.xlsx
Scenario: Verify ApprenticeshipStandards content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under ApprenticeshipStandard for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in ApprenticeshipStandard description field
	And I see <LARScode> in LARS code field