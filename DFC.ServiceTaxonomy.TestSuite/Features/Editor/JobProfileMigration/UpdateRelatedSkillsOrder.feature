@webtest @logon
Feature: UpdateRelatedSkillsOrder

@DataSource:Data/JobProfileSkills.xlsx 
Scenario: Update related skills order in job profiles 
	Given I search under JobProfile for the text <Title>
	When I click on the link with text <Title>
	And I switch to the What it takes tab
	And I check order or rearrange list items <Skill-01>|<Skill-02>|<Skill-03>|<Skill-04>|<Skill-05>|<Skill-06>|<Skill-07>|<Skill-08>|<Skill-09>|<Skill-10>|<Skill-11>|<Skill-12>|<Skill-13>|<Skill-14>|<Skill-15>|<Skill-16>|<Skill-17>|<Skill-18>|<Skill-19>|<Skill-20>
	And I switch to the Content tab
	And I enter a comment "." and click the Publish and Exit button
	Then the item is published succesfully