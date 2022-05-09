﻿@webtest
Feature: CollegeEntryRequirements

@DataSource:Data/19-CollegeEntryRequirements-7.xlsx 
Scenario: Verify CollegeEntryRequirements content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under CollegeEntryRequirements for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Description_en> in CollegeEntryRequirements description field