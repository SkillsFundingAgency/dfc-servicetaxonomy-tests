@longrunning @webtest
Feature: ImportJobProfiles

@Editor 
# @ignore
@DataSource:Data/01SOCRecipes.xlsx 
Scenario: 01 Import SOC Codes from recipe file
	Given I logon to the editor
	And I import <Path> into stax


@Editor 
# @ignore
@DataSource:Data/02MiscItemsRecipes.xlsx 
Scenario: 02 Import All other items from recipe file
	Given I logon to the editor
	And I import <Path> into stax

	
@Editor 
# @ignore
@DataSource:Data/03JPRecipesFirstRun.xlsx 
Scenario: 03 Import job profile first run from recipe file
	Given I logon to the editor
	And I import <Path> into stax

	
@Editor 
# @ignore
@DataSource:Data/03JPRecipesSecondRun.xlsx 
Scenario: 04 Import job profiles second run from recipe file
	Given I logon to the editor
	And I import <Path> into stax