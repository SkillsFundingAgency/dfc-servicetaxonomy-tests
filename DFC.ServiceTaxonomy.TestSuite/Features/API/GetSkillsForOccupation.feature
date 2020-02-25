Feature: GetSkillsForOccupation


@GetAllSkillsForOccuation
Scenario: Unknown occupation is supplied
	Given I make a request to the service taxonomy API "getSkillsForOccupation"
	| dataItem | value                                                                             |
	| uri      | http://data.europa.eu/esco/InvalidOccupation/fb6f5f61-f3b8-40ba-8363-c8d762325ff7 |
    Then the response code is 204



@GetAllSkillsForOccuation
Scenario: No body is supplied
	Given I make a request to the service taxonomy API "getSkillsForOccupation"
    	| dataItem | value  |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"


@GetAllSkillsForOccuation
Scenario: Invalid body is supplied
	Given I make a request to the service taxonomy API "getSkillsForOccupation"
    	| dataItem   | value                                                                      |
    	| occupation | http://data.europa.eu/esco/occupation/b633af32-c8c0-4481-9971-7932ea4b16b5 |
    Then the response code is 400
    And the the response message is "Unable to process supplied parameters"



@GetAllSkillsForOccuation
Scenario: Invalid security header is supplied
    Given I want to supply an invalid security header
	And I make a request to the service taxonomy API "getSkillsForOccupation"
    	| dataItem | value                                                                      |
    	| uri      | http://data.europa.eu/esco/occupation/b633af32-c8c0-4481-9971-7932ea4b16b5 |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to invalid subscription key. Make sure to provide a valid key for an active subscription."
    }
    """


@GetAllSkillsForOccuation
Scenario: Missing security header
    Given I want to fail to send a security header
	And I make a request to the service taxonomy API "getSkillsForOccupation"
    	| dataItem | value                                                                      |
    	| uri      | http://data.europa.eu/esco/occupation/b633af32-c8c0-4481-9971-7932ea4b16b5 |
    Then the response code is 401
    And the response json matches:
	"""
    {
    "statusCode": 401,
    "message": "Access denied due to missing subscription key. Make sure to include subscription key when making requests to an API."
    }
    """

@GetAllSkillsForOccupation
Scenario: Get skills for a valid occupation with no alternate labels
# includes check for occupation specific resuse levels

	Given I make a request to the service taxonomy API "getSkillsForOccupation"
	| dataItem | value                                                                      |
	| uri      | http://data.europa.eu/esco/occupation/d051a141-92cd-4800-b0ee-6c8c31ea5838 |
    Then the response code is 200
    And the response json with element "skills" removed matches:
    """
{
    "occupation": "crane technician",
    "lastModified": "2016-07-05T16:53:42Z",
    "alternativeLabels": [],
    "uri": "http://data.europa.eu/esco/occupation/d051a141-92cd-4800-b0ee-6c8c31ea5838"
}
    """
    And the response json has collection "skills" with an item matching
    """
{
    "relationshipType": "essential",
    "skill": "secure crane",
    "lastModified": "2016-12-20T19:40:50Z",
    "alternativeLabels": [
        "harness crane",
        "attach crane",
        "harness mechanical lifting device",
        "fix crane",
        "anchor mechanical lifting device",
        "fix mechanical lifting device",
        "anchor crane",
        "attach mechanical lifting device"
    ],
    "type": "competency",
    "uri": "http://data.europa.eu/esco/skill/c56d4a15-8454-4544-bb5a-3de6ce1be4e4",
    "skillReusability": "occupation-specific"
}
    """


@GetAllSkillsForOccuation
Scenario: Get skills for a valid occupation
# includes skill with no labels, essential and optional skills, Sector specific cross-sectoral resuse levels, types competency and knowledge
	Given I make a request to the service taxonomy API "getSkillsForOccupation"
	| dataItem | value                                                                      |
	| uri      | http://data.europa.eu/esco/occupation/b633af32-c8c0-4481-9971-7932ea4b16b5 |
    Then the response code is 200
	And the response json matches:
	"""
{
    "skills": [
        {
            "relationshipType": "essential",
            "skill": "woodworking processes",
            "lastModified": "2016-12-20T19:09:23Z",
            "alternativeLabels": [
                "woodwork processes",
                "woodworking procedures",
                "wood working processes",
                "woodworking mechanisms",
                "woodworking measures",
                "woodworking systems"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/0f9098d1-9bcd-453c-a9ec-e8b635705976",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "delegate activities",
            "lastModified": "2016-12-20T19:12:39Z",
            "alternativeLabels": [
                "distribute tasks",
                "delegate tasks",
                "distribute activities",
                "share duties",
                "delegate activities to others",
                "share tasks"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/b00e948c-19be-4951-8cff-60f88f1046e9",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "advise customers on wood products",
            "lastModified": "2016-12-20T21:26:47Z",
            "alternativeLabels": [
                "advise customer on wood products",
                "advise customers on wood merchandise",
                "advise customers on wood artefacts",
                "advising customers on wood products",
                "advise customers on wood items",
                "advise customers on wood goods"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/3b5d16de-6894-4712-aa52-86f1e2c48f0d",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "follow company standards",
            "lastModified": "2016-12-20T19:03:56Z",
            "alternativeLabels": [
                "follow company codes",
                "follow company measures",
                "follow a company standard",
                "follow company rules",
                "following company standards",
                "follow company requirements",
                "follow the company standards"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/f5f5b244-6cea-4fbc-8a50-8f712791bc09",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "analyse production processes for improvement",
            "lastModified": "2016-12-20T19:03:12Z",
            "alternativeLabels": [
                "test production processes for improvement",
                "scrutinise production processes for improvement",
                "analyse a production processes for improvement",
                "investigate production processes for improvement",
                "analyse the production process for improvement",
                "analyse production processes for improvements",
                "search production processes for improvement"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/f1b5800e-b763-4740-9586-3fef30568e81",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "construction products",
            "lastModified": "2016-12-20T20:37:12Z",
            "alternativeLabels": [
                "constructing products",
                "construction brands",
                "construction commodities",
                "construction stock",
                "construction product",
                "construction goods",
                "construction merchandise",
                "a construction product"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/5ac07f1a-6436-4103-b891-c59a7ac505f0",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "manage budgets",
            "lastModified": "2016-10-20T15:06:39Z",
            "alternativeLabels": [],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/21c5790c-0930-4d74-b3b0-84caf5af12ea",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "manage staff",
            "lastModified": "2016-12-20T20:30:17Z",
            "alternativeLabels": [
                "coordinate and monitor employees",
                "manage subordinates",
                "coordinate and monitor subordinates",
                "manage team",
                "coordinate and monitor staff",
                "manage employees"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/339ac029-066a-4985-9f9d-b3d7c8fea0bb",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "manage production systems",
            "lastModified": "2016-12-20T21:26:22Z",
            "alternativeLabels": [
                "run production systems",
                "managing production systems",
                "supervise production systems",
                "oversee production systems",
                "manage production system",
                "direct production systems"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/b3a75400-103f-42c7-b742-be11d161d05b",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "manage factory operations",
            "lastModified": "2016-12-20T21:26:22Z",
            "alternativeLabels": [
                "direct factory operations",
                "run factory operations",
                "managing factory operations",
                "manage factory operation",
                "oversee factory operations",
                "supervise factory operations"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/981a0f1a-ad65-4756-90a5-7e9b3520b96b",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "wood products",
            "lastModified": "2016-12-20T20:42:15Z",
            "alternativeLabels": [
                "wood goods",
                "wood commodities",
                "wood brands",
                "wood product",
                "wood stock",
                "a wood product",
                "wood merchandise"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/c9026b8f-7c5c-44b4-9e59-ae1e72fb29c0",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "sell processed timber in a commercial environment",
            "lastModified": "2016-12-20T17:31:26Z",
            "alternativeLabels": [
                "selling processed timber in a commercial environment",
                "processed timber selling in a commercial environment",
                "selling processed timber in a commercial setting",
                "sell timber and timber-based products in a commercial environment",
                "sell processed timber in a commercial setting"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/04dd3f36-7056-4824-9eee-b0312d4a25b7",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "liaise with managers",
            "lastModified": "2016-12-20T19:08:26Z",
            "alternativeLabels": [
                "liaise with a manager",
                "work with managers",
                "work together with managers",
                "collaborate with managers",
                "cooperate with managers",
                "liaising with managers"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/f14ff4b7-be1e-4b55-b39b-520005f8a97e",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "meet deadlines",
            "lastModified": "2016-12-20T19:02:39Z",
            "alternativeLabels": [
                "achieve deadlines",
                "complete deadlines",
                "make deadlines",
                "meet a deadline",
                "conform with deadlines"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/91abe492-18be-4cce-93c7-0dca07072363",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "develop manufacturing policies",
            "lastModified": "2016-12-20T18:15:34Z",
            "alternativeLabels": [
                "draft manufacturing policies",
                "drafting manufacturing policies",
                "developing of manufacturing policies",
                "manufacturing policies drafting",
                "developing manufacturing policies",
                "manufacturing policies developing"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/764db027-9063-4468-acb3-c73ecfc76f35",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "manage supplies",
            "lastModified": "2016-12-20T20:31:51Z",
            "alternativeLabels": [
                "plan supplies",
                "monitor and control supplies",
                "manage supply chain",
                "supplies management",
                "supply chain management",
                "supplies planning",
                "control and monitor supplies",
                "supplies managing"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/020b3c27-bae1-4b85-9d6f-eccee0f5ed99",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "timber products",
            "lastModified": "2017-01-05T14:55:52Z",
            "alternativeLabels": [
                "types of wood and wood-based products",
                "characteristics of timber products",
                "range of wood and wood-based products",
                "range of timber products",
                "typology of wood and wood-based products",
                "types of timber products",
                "features of wood and wood-based products",
                "characteristics of wood and wood-based products",
                "typology of timber products",
                "features of timber products"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/2336b108-a59b-4ff0-84c4-d838b4d297bd",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "manufacturing processes",
            "lastModified": "2017-01-05T15:52:55Z",
            "alternativeLabels": [
                "manufacturing mechanisms",
                "manufacturing system",
                "manufacturing process",
                "manufacturing procedures",
                "a manufacturing process",
                "process of manufacturing",
                "manufacturing measures"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/3786b61f-f22e-48d1-af8d-ad4c354534db",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "ensure equipment availability",
            "lastModified": "2016-12-20T20:21:05Z",
            "alternativeLabels": [
                "secure equipment availability",
                "assure apparatus availability",
                "provide equipment availability",
                "provide apparatus availability",
                "safeguard apparatus availability",
                "assure equipment availability",
                "secure apparatus availability",
                "safeguard equipment availability"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/69f23426-9279-4fe6-a283-24c2aa4c855d",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "plan health and safety procedures",
            "lastModified": "2017-01-23T14:31:21Z",
            "alternativeLabels": [
                "plan procedures of health and safety",
                "organise health and safety processes",
                "planning health and safety procedures",
                "programme health and safety procedures"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/bb663409-5c88-4e3a-bc16-01aa1c8ce171",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "strive for company growth",
            "lastModified": "2016-12-20T18:10:04Z",
            "alternativeLabels": [
                "work hard for company growth",
                "striving for company growth",
                "crusade for  company growth",
                "strive growth of the company"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/2a2fa8e8-aaf3-4abf-a60b-af6415f1c6d4",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "study prices of wood products",
            "lastModified": "2016-12-20T17:31:14Z",
            "alternativeLabels": [
                "wood product prices monitoring",
                "monitoring prices of wood products",
                "studying prices of wood products",
                "prices of wood products studying",
                "study wood product prices",
                "monitor prices of wood products",
                "monitor wood product prices",
                "prices of wood products monitoring",
                "wood product prices studying"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/3fa84dbb-f9f4-48a5-ab56-18d3ff0e5951",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "carry out purchasing operations in the timber business",
            "lastModified": "2016-12-20T17:31:20Z",
            "alternativeLabels": [
                "purchasing carrying out in the timber business",
                "purchase timber in a commercial environment",
                "purchasing operations carrying out in the timber business",
                "purchase timber-based products in a commercial environment",
                "carrying out purchasing operations in the timber trade",
                "carrying out purchasing operations in the timber business",
                "purchasing timber and timber-based products in a commercial environment",
                "purchasing operations carrying out in the timber trade",
                "carrying out purchasing in the timber business",
                "timber and timber-based products purchasing in a commercial environment"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/8602ff2d-1b18-4205-b4fa-2643c6ce6d22",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "essential",
            "skill": "adhere to organisational guidelines",
            "lastModified": "2016-12-20T18:57:35Z",
            "alternativeLabels": [
                "heed organisational guidelines",
                "adhere to an organisations guidelines",
                "comply to organisational guidelines",
                "adhere to an organisational guideline",
                "observe organisational guidelines",
                "adhering to organisational guidelines",
                "obey organisational guidelines"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/aa238394-8126-4ada-be2f-9dfe065cf314",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "types of wood materials",
            "lastModified": "2017-02-15T12:22:24Z",
            "alternativeLabels": [
                "sorts of wood materials",
                "varieties of wood materials",
                "categories of wood materials",
                "kinds of wood materials",
                "type of wood material"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "types of wood materials",
            "lastModified": "2017-02-15T12:22:24Z",
            "alternativeLabels": [
                "sorts of wood materials",
                "varieties of wood materials",
                "categories of wood materials",
                "kinds of wood materials",
                "type of wood material"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/fb6f5f61-f3b8-40ba-8363-c8d762325ff7",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "oversee quality control",
            "lastModified": "2016-12-21T11:46:15Z",
            "alternativeLabels": [
                "overseeing quality control",
                "control quality control",
                "supervise quality control",
                "oversight of quality control",
                "manage quality control",
                "oversee quality controls",
                "administer quality control"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/5d34adde-0b78-42b4-9d3d-69e9388d8398",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "create manufacturing guidelines",
            "lastModified": "2016-12-20T20:24:40Z",
            "alternativeLabels": [
                "draw up manufacturing guidelines prepare manufacturing guidelines",
                "develop manufacturing guidelines",
                "creating manufacturing guideline",
                "draft manufacturing guidelines",
                "create manufacturing guideline",
                "creating manufacturing guidelines",
                "define manufacturing guidelines"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/37520413-563e-4d99-a14c-1c6dca3cf833",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "essential",
            "skill": "define manufacturing quality criteria",
            "lastModified": "2016-12-20T19:59:16Z",
            "alternativeLabels": [
                "manufacturing standards setting",
                "set manufacturing standards",
                "definition of manufacturing quality criteria",
                "manufacturing quality criteria definition",
                "definition of quality criteria for manufacturing",
                "setting manufacturing standards",
                "defining manufacturing quality criteria",
                "defining quality criteria for manufacturing",
                "define quality criteria for manufacturing",
                "defining of manufacturing quality criteria",
                "setting of manufacturing standards"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/46e1b714-94f4-462d-88e6-31f442708812",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "liaise with shareholders",
            "lastModified": "2016-12-20T18:08:31Z",
            "alternativeLabels": [
                "collaborate with shareholders",
                "liaising with shareholders",
                "cooperate with shareholders",
                "liaise with shareholder",
                "work together with shareholders"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/8f9e8842-94f3-48d5-8d09-c43829bcabc5",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "manage customer service",
            "lastModified": "2016-12-20T18:02:47Z",
            "alternativeLabels": [
                "managing customer service",
                "oversee customer service",
                "supervise customer service"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/c09c5786-a479-46de-b0aa-d5d2d8ccc123",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "align efforts towards business development",
            "lastModified": "2016-12-20T18:06:29Z",
            "alternativeLabels": [
                "align business development efforts",
                "align efforts towards business growth",
                "coordinate efforts towards business development",
                "align effort towards business development",
                "aligning efforts towards business development"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/ee7f90cc-922e-4da7-a7ae-83c2688fed10",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "assess felled timber volume",
            "lastModified": "2016-12-20T17:38:33Z",
            "alternativeLabels": [
                "measure volume of felled timber",
                "measuring volume of felled timber",
                "felled timber volume assessing",
                "measuring felled timber volume",
                "assessing volume of felled timber",
                "assess volume of felled timber",
                "measure felled timber volume",
                "assessing felled timber volume",
                "felled timber volume measuring"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/5cead3a5-92ad-41be-ab53-03d8d0b38d0e",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "quality standards",
            "lastModified": "2017-02-14T11:47:46Z",
            "alternativeLabels": [],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/8d4271ca-c9fd-40b3-875f-15f78332a49e",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "negotiate improvement with suppliers",
            "lastModified": "2016-12-20T19:02:22Z",
            "alternativeLabels": [
                "negotiate improvement with a supplier",
                "negotiate an improvement with suppliers",
                "negotiate improvements with suppliers",
                "improve relations with suppliers",
                "determine improvement with suppliers",
                "agree improvement with suppliers",
                "discuss improvements with suppliers"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/97bcbb41-c42b-4777-ab26-1f8f7dcfafd8",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "check material rescources",
            "lastModified": "2016-12-20T17:45:39Z",
            "alternativeLabels": [
                "check technical and material resources",
                "checking material resources",
                "check materials and resources",
                "check technical resources",
                "check resource materials"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/d1a2437d-7eee-4c13-9104-0bb3dd7b45d6",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "schedule regular machine maintenance",
            "lastModified": "2016-12-20T19:07:20Z",
            "alternativeLabels": [
                "schedule regular machine servicing",
                "schedule regular machine cleaning",
                "schedule regular machine analysis",
                "schedule regular maintenance of machinery",
                "schedule regular machinery maintenance",
                "schedule regular machine repairs"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/a7b9039e-0145-4e3e-bbf8-30151d3e6cc0",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "wear appropriate protective gear",
            "lastModified": "2016-12-20T19:52:20Z",
            "alternativeLabels": [
                "clothe in appropriate protective gear",
                "put on appropriate protective gear",
                "turn out in appropriate protective gear",
                "turn out in necessary safety clothing",
                "don necessary safety clothing",
                "clothe in necessary safety clothing",
                "don appropriate protective gear",
                "put on necessary safety clothing"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/6122d586-5978-431f-8e7a-96e61fc1f3fc",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "check durability of wood materials",
            "lastModified": "2016-12-20T21:27:06Z",
            "alternativeLabels": [
                "check durability of wood material",
                "check durability of wood stuffs",
                "checking durability of wood",
                "check durability of wood resources",
                "check durability of wood",
                "check durability of wood supplies"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/e30f51d6-c590-4e7d-9781-fff916e15ad8",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "prepare production reports",
            "lastModified": "2016-12-20T21:26:36Z",
            "alternativeLabels": [
                "arrange production reports",
                "plan production reports",
                "preparing production reports",
                "organise production reports",
                "ready production reports",
                "prepare production report"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/96d6a0a7-5923-44c1-adec-c76ab617c6d9",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "prospect new customers",
            "lastModified": "2017-02-14T14:26:31Z",
            "alternativeLabels": [
                "prospecting a new customer",
                "identify new customers",
                "seek new customers",
                "find new customers",
                "prospecting new customers",
                "prospect a new customer",
                "look for new customers"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/6d97bf55-6fb6-4795-8282-3ef915ae0bb8",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "recruit personnel",
            "lastModified": "2016-12-20T17:25:36Z",
            "alternativeLabels": [
                "personnel hiring",
                "recruiting personnel",
                "hire personnel",
                "personnel recruiting",
                "hiring personnel"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/65715f7a-c791-416b-b88a-2933a1c81647",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "meet contract specifications",
            "lastModified": "2016-12-20T21:23:21Z",
            "alternativeLabels": [
                "abide by contract specifications",
                "live up to contract specifications",
                "meet contract specification",
                "fulfil contract specifications",
                "meeting contract specifications"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/576b305e-8c25-4546-8a69-87f975783114",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "negotiate terms with suppliers",
            "lastModified": "2016-12-20T19:01:26Z",
            "alternativeLabels": [
                "improve terms with suppliers",
                "negotiate terms with a supplier",
                "agree terms with suppliers",
                "discuss terms with suppliers",
                "determine terms with suppliers"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/5f2efbdf-08a2-49cd-9c06-bd284e4f0fbf",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "engineering processes",
            "lastModified": "2016-09-02T10:02:19Z",
            "alternativeLabels": [],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/72a74f69-5cf1-43c5-99b9-62a444578919",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "company policies",
            "lastModified": "2017-02-15T11:00:40Z",
            "alternativeLabels": [
                "corporation's policies",
                "employer's policies",
                "company policy",
                "policies of a company"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/f75b740c-b36c-495e-bc67-efe347bbc6b5",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "assess felled timber quality",
            "lastModified": "2016-12-20T17:37:12Z",
            "alternativeLabels": [
                "evaluate quality of felled timber",
                "assessing quality of felled timber",
                "felled timber quality evaluating",
                "assess quality of felled timber",
                "evaluating quality of felled timber",
                "assess felled timber quality",
                "assessing felled timber quality",
                "felled timber quality assessing",
                "evaluating felled timber quality",
                "evaluate felled timber quality"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/fa959bf8-31b2-449b-a2d3-ae6ee9f05f3d",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "distinguish wood quality",
            "lastModified": "2016-12-20T21:24:40Z",
            "alternativeLabels": [
                "Identify wood quality",
                "determine wood quality",
                "discern wood quality",
                "distinguishing wood quality"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/a36de838-7fd3-474a-8391-492354b47fc1",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "manage timber stocks",
            "lastModified": "2016-12-20T17:33:45Z",
            "alternativeLabels": [
                "managing timber stocks",
                "control timber stocks",
                "stocks of timber controlling",
                "control stocks of timber",
                "stocks of timber managing",
                "controlling stocks of timber",
                "timber stock controlling",
                "timber stock managing",
                "timber stocks controlling",
                "controlling timber stocks",
                "managing stocks of timber",
                "timber stocks managing",
                "manage stocks of timber"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/c6d43089-8855-4da5-9b8b-ace87281476e",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "evaluate employees work",
            "lastModified": "2016-12-20T17:23:52Z",
            "alternativeLabels": [
                "evaluate team performance",
                "evaluating employees work",
                "evaluating team performance",
                "evaluate employees work",
                "employees work evaluating",
                "team performance evaluating"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/8a98707e-b2ee-48fe-9f36-e47e3555ecf7",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "oversee logistics of finished products",
            "lastModified": "2016-12-20T20:04:15Z",
            "alternativeLabels": [
                "monitor logistics of finished products",
                "oversee finished products' logistics",
                "supervise logistics of finished products, manage logistics of finished products",
                "look after logistics of finished products",
                "ensure logistics of finished products",
                "administer logistcs of finished goods",
                "inspect logistics of finished products",
                "oversee packing, storage and shipment of finished products"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/40f27736-0d98-4446-8234-11646e4f4bc3",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "inspect wood materials",
            "lastModified": "2016-12-20T21:26:45Z",
            "alternativeLabels": [
                "inspect wood supplies",
                "inspect wood",
                "inspect wood resources",
                "inspect wood stuffs",
                "inspecting wood",
                "inspect wood material"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/4c1ff5b1-fec0-4e07-a313-ec3df804a687",
            "skillReusability": "sector-specific"
        },
        {
            "relationshipType": "optional",
            "skill": "train employees",
            "lastModified": "2017-02-15T15:15:17Z",
            "alternativeLabels": [
                "teach employees",
                "train an employee",
                "instruct employees",
                "training employees",
                "upskill employees"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/e54ff029-1ce9-447d-a5b2-eb7283a23e6e",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "environmental legislation in agriculture and forestry",
            "lastModified": "2016-12-20T17:27:43Z",
            "alternativeLabels": [
                "range of environmental legislation in in agriculture and forestry",
                "agriculture and forestry environmental regulation",
                "impact of environmental legislation in in agriculture and forestry",
                "scope of environmental legislation in in agriculture and forestry",
                "implications of environmental regulation in in agriculture and forestry",
                "range of environmental regulation in in agriculture and forestry",
                "impact of environmental regulation in in agriculture and forestry",
                "scope of environmental regulation in in agriculture and forestry",
                "implications of environmental legislation in in agriculture and forestry",
                "agriculture and forestry environmental legislation"
            ],
            "type": "knowledge",
            "uri": "http://data.europa.eu/esco/skill/3419fac9-575d-4492-a018-edff6f4dae26",
            "skillReusability": "cross-sectoral"
        },
        {
            "relationshipType": "optional",
            "skill": "prepare purchasing reportings",
            "lastModified": "2016-12-20T20:38:38Z",
            "alternativeLabels": [
                "prepare a purchasing report",
                "develop purchasing reportings",
                "supply purchasing reportings",
                "arrange purchasing reportings",
                "preparing purchasing reports",
                "purchasing reporting preparation",
                "provide purchasing reportings",
                "plan purchasing reportings"
            ],
            "type": "competency",
            "uri": "http://data.europa.eu/esco/skill/bf987b9a-64f3-44b7-98f1-a60e4585b69b",
            "skillReusability": "sector-specific"
        }
    ],
    "occupation": "wood factory manager",
    "lastModified": "2017-01-04T16:25:03Z",
    "alternativeLabels": [
        "natural wood factory controller",
        "wood factory supervisor",
        "solid wood factory supervisor",
        "timber factory manager",
        "wood factory administrator",
        "solid wood factory controller",
        "solid wood factory manager",
        "wood factory executive",
        "furniture factory manager",
        "natural wood factory manager",
        "wood factory controller",
        "wood factory overseer",
        "natural wood factory supervisor",
        "wood manager",
        "wood factory coordinator"
    ],
    "uri": "http://data.europa.eu/esco/occupation/b633af32-c8c0-4481-9971-7932ea4b16b5"
}
	"""