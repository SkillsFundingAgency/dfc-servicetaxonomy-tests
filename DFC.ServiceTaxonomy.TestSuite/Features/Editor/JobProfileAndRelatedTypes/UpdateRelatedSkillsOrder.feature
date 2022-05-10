@webtest
Feature: UpdateRelatedSkillsOrder

@DataSource:Data/JobProfileSkills.xlsx 
Scenario: Update Contextualised Text content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under JobProfile for the text <Title>
	When I click on the link with text <Title>
	And I switch to the What it takes tab
	And I remove all the related skills
	And I select option "<Skill-01>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-02>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-03>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-04>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-05>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-06>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-07>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-08>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-09>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-10>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-11>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-12>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-33>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-14>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-15>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-16>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-17>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-18>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-19>" from the "Related skills" dropdown field of the What it takes tab
	And I select option "<Skill-20>" from the "Related skills" dropdown field of the What it takes tab
	And I switch to the Content tab
	And I click the Publish and Exit button after entering a comment
	Then the item is published succesfully