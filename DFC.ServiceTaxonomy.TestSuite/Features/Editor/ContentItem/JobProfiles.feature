@webtest
Feature: JobProfilesUserActions

Background:
	Given I logon to the editor
	And I create the following number of Content Types
	| Content Type                      | number |
	| Job profile specialism            | 1      |
	| Job profile category              | 1      |
	| SOC code                          | 1      |
	| Working hours detail              | 1      |
	| Working pattern detail            | 1      |
	| Working patterns                  | 1      |
	| University entry requirements     | 1      |
	| University requirements           | 1      |
	| University link                   | 1      |
	| College entry requirements        | 1      |
	| College requirements              | 1      |
	| College link                      | 1      |
	| Apprenticeship entry requirements | 1      |
	| Apprenticeship requirements       | 1      |
	| Apprenticeship link               | 1      |
	| Registration                      | 1      |
	| Restriction                       | 1      |
	| Digital skills                    | 1      |
	| Location                          | 1      |
	| Environment                       | 1      |
	| Uniform                           | 1      |

Scenario Outline: Add Job Profile Content Item
	And I start a new Job Profile type
	And I enter "Test_Auto_JP_" plus an eight digit random alphanumeric into the Title field
	And I select "As Defined" from the Dynamic Title Prefix dropdown field
	And I select option "2" from the "Job profile specialism" dropdown field
	And I select option "1" from the "Job profile category" dropdown field
	And I enter "Test data for field" into the "Course keywords" field
	And I select option "2" from the "SOC code" dropdown field
	And I select option "2" from the "Related careers profiles" dropdown field
	And I switch to the Header tab
	And I enter "Test data for field" into the "Alternative title" field of the Header tab
	And I select option "1" from the "Hidden alternative title" dropdown field of the Header tab
	And I enter "Test data for field" into the "Widget content title" field of the Header tab
	And I enter "Test data for field" into the "Overview" field of the Header tab
	And I enter "8000.00" into the "Salary starter per year" field of the Header tab
	And I enter "16000.00" into the "Salary experienced per year" field of the Header tab
	And I enter "4" into the "Minimum hours" field of the Header tab
	And I enter "8" into the "Maximum hours" field of the Header tab
	And I select option "2" from the "Working hours details" dropdown field of the Header tab
	And I select option "2" from the "Working pattern" dropdown field of the Header tab
	And I select option "2" from the "Working pattern details" dropdown field of the Header tab
	And I switch to the How to become tab
	And I enter "Test data for field" into the "Entry routes" field of the How to become tab
	And I enter "Test data for field" into the "University relevant subjects" field of the How to become tab
	And I enter "Test data for field" into the "University further route info" field of the How to become tab
	And I select option "2" from the "University entry requirements" dropdown field of the How to become tab
	And I select option "2" from the "Related university requirements" dropdown field of the How to become tab
	And I select option "2" from the "Related university links" dropdown field of the How to become tab
	And I enter "Test data for field" into the "College relevant subjects" field of the How to become tab
	And I enter "Test data for field" into the "College further route info" field of the How to become tab
	And I select option "1" from the "College entry requirements" dropdown field of the How to become tab
	And I select option "1" from the "Related college requirements" dropdown field of the How to become tab
	And I select option "1" from the "Related college links" dropdown field of the How to become tab
	And I enter "Test data for field" into the "Apprenticeship relevant subjects" field of the How to become tab
	And I enter "Test data for field" into the "Apprenticeship further route info" field of the How to become tab
	And I select option "1" from the "Apprenticeship entry requirements" dropdown field of the How to become tab
	And I select option "1" from the "Related apprenticeship requirements" dropdown field of the How to become tab
	And I select option "1" from the "Related apprenticeship links" dropdown field of the How to become tab
	And I enter "Test data for field" into the "Work" field of the How to become tab
	And I enter "Test data for field" into the "Volunteering" field of the How to become tab
	And I enter "Test data for field" into the "Direct application" field of the How to become tab
	And I enter "Test data for field" into the "Other routes" field of the How to become tab
	And I select option "1" from the "Related registrations" dropdown field of the How to become tab
	And I enter "Test data for field" into the "Career tips" field of the How to become tab
	And I enter "Test data for field" into the "Professional and industry bodies" field of the How to become tab
	And I enter "Test data for field" into the "Further information" field of the How to become tab
	And I switch to the What it takes tab
	And I select option "1" from the "Related restrictions" dropdown field of the What it takes tab
	And I enter "Test data for field" into the "Other requirements" field of the What it takes tab
	And I select option "1" from the "Digital skills" dropdown field of the What it takes tab
	And I switch to the What youll do tab
	And I enter "Test data for field" into the "Day-to-day tasks" field of the What youll do tab
	And I select option "1" from the "Related locations" dropdown field of the What youll do tab
	And I select option "1" from the "Related environments" dropdown field of the What youll do tab
	And I select option "1" from the "Related uniforms" dropdown field of the What youll do tab
	And I switch to the Career path and progression tab
	And I enter "Test data for field" into the "Career path & progression" field of the Career path and progression tab
	And I switch to the Content tab
	#And I tick the "Override sitemap configuration" tick box of the Content tab
	#And I select "Monthly" from the "Change Frequency" dropdown field of the Content tab
	#And I select "0.9" from the "Priority" dropdown field of the Content tab
	#And I select option "1" from the "Related skills" dropdown field of the Content tab
	#And I tick the "Exclude" tick box of the Content tab
	And I click the Save Draft and Continue button
	When I click the Publish and Exit button after entering a comment
	Then the Job profile is created
	And the job profile is in "Published" status

