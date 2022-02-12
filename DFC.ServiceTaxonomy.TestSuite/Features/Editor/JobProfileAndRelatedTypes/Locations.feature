@webtest
Feature: Locations

@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
@Dataset:Location
Scenario: Verify Locations content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under Location for the text <Title_en>
	And I select the first item that is found
	Then I see <Title_en> as Title
	And I see <Id> in Uri field