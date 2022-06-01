@webtest @logon
Feature: Republish

Scenario Outline: Update job profiles 
	Given I search under JobProfile for the text <Title>
	When I click on the link with text <Title>
	And I switch to the Content tab
	And I enter a comment "." and click the Publish and Exit button
	Then the item is published succesfully


Examples: 
| Title                                |
| 3D printing technician               |