@longrunning @webtest
Feature: ImportRecipes


#Scenario: Load the files
#	Given I logon to the editor
#	Given I Navigate to "/Admin/DeploymentPlan/Import/Index"
#	And Load the file "F:\recipeFiles\20200330_18\14. QCFLevels0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\15. ApprenticeshipStandardRoutes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\16. ApprenticeshipStandards0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\17. RequirementsPrefixes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\18. ApprenticeshipLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\19. ApprenticeshipRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\20. CollegeLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\21. CollegeRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\22. UniversityLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\23. UniversityRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\24. DayToDayTasks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\25. DayToDayTasks1.zip"
#	And Load the file "F:\recipeFiles\20200330_18\26. DayToDayTasks2.zip"
#	And Load the file "F:\recipeFiles\20200330_18\27. DayToDayTasks3.zip"
#	And Load the file "F:\recipeFiles\20200330_18\28. DayToDayTasks4.zip"
#	And Load the file "F:\recipeFiles\20200330_18\29. DayToDayTasks5.zip"
#	And Load the file "F:\recipeFiles\20200330_18\30. DayToDayTasks6.zip"
#	And Load the file "F:\recipeFiles\20200330_18\31. OtherRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\32. Registrations0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\33. Restrictions0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\34. SocCodes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\35. WorkingEnvironments0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\36. WorkingLocations0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\37. WorkingUniforms0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\38. JobProfiles0.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\39. JobProfiles1.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\40. JobProfiles2.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\41. JobProfiles3.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\42. JobProfiles4.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\43. JobCategories0.zip"
#
#	
#
#Scenario: Load the 18 files
#	Given I logon to the editor
#	Given I Navigate to "/Admin/DeploymentPlan/Import/Index"
#	And Load the file "F:\recipeFiles\20200330_18\15. QCFLevels0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\16. ApprenticeshipStandardRoutes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\17. ApprenticeshipStandards0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\18. RequirementsPrefixes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\19. ApprenticeshipLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\20. ApprenticeshipRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\21. CollegeLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\22. CollegeRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\23. UniversityLinks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\24. UniversityRequirements0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\25. DayToDayTasks0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\26. SocCodes0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\27. WorkingEnvironments0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\28. WorkingLocations0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\29. WorkingUniforms0.zip"
#	And Load the file "F:\recipeFiles\20200330_18\30. JobProfiles0.zip" 
#	And Load the file "F:\recipeFiles\20200330_18\31. JobCategories0.zip"

@ignore
Scenario: Load from import file
	Given I logon to the editor
	And I import recipes from the file "content items count.txt"
