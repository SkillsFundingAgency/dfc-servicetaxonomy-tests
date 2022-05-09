@webtest
Feature: UpdateRelatedSkillsOrder

@DataSource:Data/JobProfileSkills.xlsx 
Scenario: Update Contextualised Text content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under JobProfile for the text <Title>
	When I click on the link with text <Title>
	And I switch to the What it takes tab
	And I order <Skill-01> at 1
	And I order <Skill-02> at 2
	And I order <Skill-03> at 3
	And I order <Skill-04> at 4
	And I order <Skill-05> at 5
	And I order <Skill-06> at 6
	And I order <Skill-07> at 7
	And I order <Skill-08> at 8
	And I order <Skill-09> at 9
	And I order <Skill-10> at 10
	And I order <Skill-11> at 11
	And I order <Skill-12> at 12
	And I order <Skill-13> at 13
	And I order <Skill-14> at 14
	And I order <Skill-15> at 15
	And I order <Skill-16> at 16
	And I order <Skill-17> at 17
	And I order <Skill-18> at 18
	And I order <Skill-19> at 19
	And I order <Skill-20> at 20
	#And I enter <Contextualised_en> in the the contextualised field
	#And I publish the item
	#Then the item is published succesfully