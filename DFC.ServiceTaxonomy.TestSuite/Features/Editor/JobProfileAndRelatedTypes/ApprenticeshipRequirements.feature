@webtest
Feature: ApprenticeshipRequirements

@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
@Dataset:Uniform
Scenario: Verify ApprenticeshipRequirements content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under ApprenticeshipRequirements for the text <Title_en>
	And I select the first item that is found
	Then I see <Title_en> as Title
	And I see <Id> in Uri field