@longrunning @webtest
Feature: ImportRecipes


#TODO_DRAFT update recipe import tests to include draft / publish checks
# restrict data set to 1+ job profile and dependants
# add in skill labels etc (explore  displayname prefix to keep seperate from any existing data)
#consider using single run background statement + feature level teardown to set up data 


#Background: 
#	Given I only want to run this once with this feature
#	#Given I import the test recipe files
#	Given I logon to the editor
#	Given I prepare the test recipes
#	And I load the test recipes
#	And I have completed the run once section


@Editor
Scenario: Import data from recipe file
	Given I logon to the editor
	Given I prepare the test recipes
	And I load the test recipes