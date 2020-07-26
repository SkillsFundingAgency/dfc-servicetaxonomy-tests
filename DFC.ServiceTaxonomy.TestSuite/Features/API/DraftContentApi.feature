Feature: DraftContentApi


@ContentApi 
Scenario: Request an NCS item by invalid Type
	Given I define a test type and call it "__TYPE__"
	Given I make a request to the "Preview" content API to retrive all "__TYPE__" items
	Then the response code is 404

@ContentApi 
Scenario: Request an NCS item by invalid Id
	Given I define a test type and call it "__TYPE__"
	And I create a " __TYPE__" item in the "Preview" graph with the following data
	| Title      | Content          |
	| First Item | <p>Something</p> |
	And I delete "Preview" Graph data for content type "__TYPE__"
	Given I make a request to the "Preview" content API to retrive item 1
	Then the response code is 404

@ContentApi
Scenario: Request all NCS items of a type
	Given I define a test type and call it "__TYPE__"
	And I create a "__TYPE__" item in the "Preview" graph with the following data
	| Title      | Content          |
	| First Item | <p>Something</p> |
	And I create a "__TYPE__" item in the "Preview" graph with the following data
	| Title    | Content               |
	| 2nd Item | <p>Something else</p> |
	And I create a "__TYPE__" item in the "Preview" graph with the following data
	| Title    | Content               |
	| 3rd Item | <p>Something more</p> |
	#And I create a "Not__TYPE__" item with the following data
	#| Title      | Content                    |
	#| Other Item | <p>Something different</p> |
	Given I make a request to the "Preview" content API to retrive all "__TYPE__" items
	When I build the expected response for item 1
	Then the response matches the expectation
	#Then the response includes all items of type "__TYPE__"



@ContentApi
Scenario: Request an item with a related item
	Given I define a test type and call it "__TYPE__"
	And I create a "__TYPE__" item in the "Preview" graph with the following data
	| Title      | Content          | CreatedDate             | ModifiedDate            |
	| First Item | <p>Something</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPE__" in the "Preview" graph related by "hasRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 2nd Item | <p>Something else</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	Given I make a request to the "Preview" content API to retrive item 1
	When I build the expected response for item 1
	Then the response code is 200
	Then the response matches the expectation


@ContentApi
Scenario: Request an item with a number of related items
	Given I define a test type and call it "typea"
	And I create a "__TYPEA__" item in the "Preview" graph with the following data
	| Title      | Content          | CreatedDate             | ModifiedDate            |
	| First Item | <p>Something</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPEA__" in the "Preview" graph related by "hasRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 2nd Item | <p>Something else</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPEA__" in the "Preview" graph related by "hasOtherRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 3rd Item | <p>Something more</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	Given I make a request to the "Preview" content API to retrive item 1
	When I build the expected response for item 1
	Then the response code is 200
	Then the response matches the expectation


@ContentApi
Scenario: Request an item with a number of related items of different types
	Given I define a test type and call it "__TYPEA__"
	And I define a test type and call it "__TYPEB__"
	And I create a "__TYPEA__" item in the "Preview" graph with the following data
	| Title      | Content          | CreatedDate             | ModifiedDate            |
	| First Item | <p>Something</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPEA__" in the "Preview" graph related by "hasRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 2nd Item | <p>Something else</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPEA__" in the "Preview" graph related by "hasRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 3rd Item | <p>Something more</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPEB__" in the "Preview" graph related by "hasOtherRelationship" to item 1 with the following data
	| Title    | Content                    | CreatedDate             | ModifiedDate            |
	| 4th Item | <p>Something different</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	Given I make a request to the "Preview" content API to retrive item 1
	When I build the expected response for item 1
	Then the response code is 200
	Then the response matches the expectation


@ContentApi
Scenario: Request an item with an incoming relationship
	Given I define a test type and call it "__TYPE__"
	And I create a "__TYPE__" item in the "Preview" graph with the following data
	| Title      | Content          | CreatedDate             | ModifiedDate            |
	| First Item | <p>Something</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	And I create an item of "__TYPE__" in the "Preview" graph related by "hasRelationship" to item 1 with the following data
	| Title    | Content               | CreatedDate             | ModifiedDate            |
	| 2nd Item | <p>Something else</p> | 2020-06-17T16:04:41.68Z | 2020-06-17T16:04:41.68Z |
	Given I make a request to the "Preview" content API to retrive item 2
	When I build the expected response for item 2
	Then the response code is 200
	Then the response matches the expectation