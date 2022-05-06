@webtest
Feature: SocCode

#@DataSource:dfc-beta_Job_Profile_Job_Profiles_items.xlsx 
Scenario: Verify SocCode content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under SOCCode for the text 3537A
	And I select the first item that is found
	Then I see 3537A as unique Title
	And I see Accounting technician in SOCCode description field
	And I see 1daede8a-733e-46af-9fc0-05d8eebc8580 in Uri field
	And I see 43-3031.00 in onet occupation code field
	And I see Assistant Accountant (Level 3),Professional Accounting Taxation Technician (Level 4) items in the list