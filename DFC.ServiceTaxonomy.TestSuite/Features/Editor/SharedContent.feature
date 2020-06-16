@webtest
Feature: SharedContent

Background:
    Given I set the content type to be "SharedContent" 
	Given I logon to the editor

@Editor @Ignore 
# this should not be run in dev as dependant on imported data. consider running in sit / pp
Scenario: Content for "Get help using this service" is available

	Then I can navigate to the content item "Contact us" in Orchard Core core
    Given I capture the generated URI
	Then the values displayed in the editor match the following values and types
    | Name          | Type | Value      |
    | Title         | Base | Contact us |
    And the editor field "Content" matches
"""
<div class="sfContentBlock sf-Long-text">
  <h2 class="heading-medium">Get help using this service</h2>
  <p class="font-small" style="margin-bottom:0px;"><span class="bold-small">Call&nbsp;</span>0800 100 900 or <a style="white-space:nowrap;" href="/webchat/chat/" target="'_blank'">use webchat</a>
  </p>
  <p class="grey font-xsmall">8am to 10pm, 7 days a week<br></p>
  <p>More ways to <a href="/contact-us">contact us</a>
  </p>
</div>
"""
   And the data is present in the Graph databases


@Editor
Scenario: Add a new shared content item
	Given I set up a data prefix for "Title"
	And I Navigate to "/Admin/Contents/ContentTypes/SharedContent/Create" 
	#And I have ensured the activity I intend to add doesn't exist
	And I capture the generated URI
	And I Enter the following form data for "SharedContent"
	| Title              |  Content          |
	| New Shared Content |  <p>Here it is</p> |
	When I publish the item
	Then the add action completes succesfully
	And the data is present in the Graph databases
	#And an event has been published to notify consumers of the change

#Scenario: Edit the new activity
	Given I Navigate to "/Admin/Contents/ContentItems" 
	And I search for the "Title"
	And I select the first item that is found
	And I Enter the following form data for "SharedContent"
	| Title                  | Content              |
	| updated Shared Content | <p>Here it is now</p> |
	When I publish the item
	Then the edit action completes succesfully
	And the data is present in the Graph databases

#Scenario: Delete the new activity
	Given I search for the "Title"
	When I delete the item
#	And I confirm the delete action
	Then the delete action completes succesfully
	And the data is not present in the Graph databases