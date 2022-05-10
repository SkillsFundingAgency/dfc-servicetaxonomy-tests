@webtest
Feature: UpdateContextualisedText

@DataSource:Data/SSMToUpdate.xlsx 
Scenario: Update Contextualised Text content items 
	Given I logon to the editor
	And I search under SOCSkillsMatrix for the text <Title_en>
	When I click on the link with text <Title_en>
	And I enter <Contextualised_en> in the the contextualised field
	And I publish the item
	Then the item is published succesfully