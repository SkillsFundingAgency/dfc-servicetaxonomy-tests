@webtest
Feature: AdhocOperations
	
Background:
	Given I logon to the editor

Scenario Outline: Order related skills 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under JobProfile using Title text <Job profile>
	And I click on the link with text <Job profile>
	And I switch to the What it takes tab
	And I obtain the expected Related skills order from file "JobProfileSkills"
	When I compare that with the Related skills ordering in the UI
	Then the order is the same
	But if it is not then I rearrange them to be the same
	And I Save and Publish after entering a comment for this <Job profile> Related skills order task

Examples:
	| no. | SOC Code | Job profile            |
	| 1   | 3122D    | 3D printing technician |
	| 2   | 6144A    | Accommodation warden   |
	| 3   | 3537A    | Accounting technician  |
	| 4   | 2129A    | Acoustics consultant   |
	| 5   | 3413B    | Actor                  |