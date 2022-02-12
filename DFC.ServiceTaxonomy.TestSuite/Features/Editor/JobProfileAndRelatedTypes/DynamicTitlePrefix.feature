@webtest
Feature: DynamicTitlePrefix

@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
@Dataset:Uniform
Scenario: Verify DynamicTitlePrefix content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as Title
	And I see <Id> in Uri field
