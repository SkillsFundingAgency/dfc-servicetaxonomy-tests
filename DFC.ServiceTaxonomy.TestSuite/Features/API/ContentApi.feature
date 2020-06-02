Feature: ContentApi

Background: 

Given I create a shared content item with the following data
	| Title     | Content          |
	| First Item | <p>Something</p> |
Given I create a shared content item with the following data
	| Title     | Content          |
	| Second Item | <p>Something</p> |

@ContentApi
Scenario: Request an NCS item by id
	Given I make a request to the content API
	Then the response matches the created item

@ContentApi
Scenario: Request an NCS item by invalid id

@ContentApi
Scenario: Request all NCS items of a type
	Given I define a test type and call it "__TYPE__"
	And I create a "__TYPE__" item with the following data
	| Title      | Content          |
	| First Item | <p>Something</p> |
	And I create a "__TYPE__" item with the following data
	| Title    | Content               |
	| 2nd Item | <p>Something else</p> |
	And I create a "__TYPE__" item with the following data
	| Title    | Content               |
	| 3rd Item | <p>Something more</p> |
	#And I create a "Not__TYPE__" item with the following data
	#| Title      | Content                    |
	#| Other Item | <p>Something different</p> |
	Given I make a request to the content API to retrive all "__TYPE__" items
	Then the response includes all items of type "__TYPE__"