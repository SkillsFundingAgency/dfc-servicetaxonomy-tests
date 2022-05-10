@webtest
Feature: UpdateRelatedSkillsOrder

@DataSource:Data/JobProfileSkills.xlsx 
Scenario: Update Contextualised Text content items 
	Given I logon to the editor
	And I search under JobProfile for the text <Title>
	When I click on the link with text <Title>
	And I switch to the What it takes tab
	#And I remove all the related skills
	And I check order or rearrange list items <Skill-01>|<Skill-02>|<Skill-03>|<Skill-04>|<Skill-05>|<Skill-06>|<Skill-07>|<Skill-08>|<Skill-09>|<Skill-10>|<Skill-11>|<Skill-12>|<Skill-33>|<Skill-14>|<Skill-15>|<Skill-16>|<Skill-17>|<Skill-18>|<Skill-19>|<Skill-20>
	And I switch to the Content tab
	And I click the Publish and Exit button after entering a comment
	Then the item is published succesfully