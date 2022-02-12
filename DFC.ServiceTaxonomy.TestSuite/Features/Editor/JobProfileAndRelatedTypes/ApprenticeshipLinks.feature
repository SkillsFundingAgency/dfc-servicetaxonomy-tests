﻿@webtest
Feature: ApprenticeshipLinks

@DataSource:Data/03-ApprenticeshipLink.xlsx
Scenario: Verify ApprenticeshipLinks content items 
	Given I logon to the editor
	And I Navigate to "/Admin/Contents/ContentItems" 
	And I search under ApprenticeshipLink for the text <Title_en>
	When I click on the link with text <Title_en>
	Then I see <Title_en> as unique Title
	And I see <Id> in Uri field
	And I see <Url_en> in url field
	And I see <Text_en> in text field
