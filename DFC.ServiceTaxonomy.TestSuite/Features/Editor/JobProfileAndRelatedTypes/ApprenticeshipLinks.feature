@webtest
Feature: ApprenticeshipLinks

@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
@Dataset:Uniform
Scenario: Verify ApprenticeshipLinks content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under ApprenticeshipLink for the text <Title_en>
	And I select the first item that is found
	Then I see <Title_en> as Title
	And I see <Id> in Uri field