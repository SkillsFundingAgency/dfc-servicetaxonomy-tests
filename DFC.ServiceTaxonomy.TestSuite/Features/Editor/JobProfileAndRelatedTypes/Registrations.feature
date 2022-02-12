@webtest
Feature: Registrations

@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
@Dataset:Registration
Scenario: Verify Registrations content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under Registration for the text <Title_en>
	And I select the first item that is found
	Then I see <Title_en> as Title
	And I see <Id> in Uri field