Feature: SkillsGapForOccupations


@Ignore
Scenario: Skills gap analysis where common skills exists
    Given I request skills gap anaylsis for occupations "123" and "234"
	Then 

@Ignore
Scenario: Skills gap analysis where no common skills exists

@Ignore
Scenario: Skills gap where a skill is essential for Occupation 1 and optional for Occupation 2

@Ignore
Scenario: Skills gap where a skill is optional for Occupation 1 and essential for Occupation 2

@Ignore
Scenario: Skills gap where a skill is essential for Occupation 1 and  Occupation 2

@Ignore
Scenario: Skills gap where a skill is optional for Occupation 1 and  Occupation 2

@Ignore
Scenario: Skills gap where a skill is essential for Occupation 1 and not related to Occupation 2

@Ignore
Scenario: Skills gap where a skill is optional for Occupation 1 and not related to Occupation 2

@Ignore
Scenario: Skills gap where a skill with transverse reusability is identified as a gap

@Ignore
Scenario: Skills gap where a skill with cross sectoral reusability is identified as a gap

@Ignore
Scenario: Skills gap where a skill with sector secific reusability is identified as a gap

@Ignore
Scenario: Skills gap where a skill with occupation secific reusability is identified as a gap

@Ignore
Scenario: Skills gap analysis where first occupation is invalid

@Ignore
Scenario: Skills gap analysis where second occupation is invalid

@Ignore
Scenario: Skills gap analysis where both occupations are invalid

@Ignore
Scenario: Missing security header

@Ignore
Scenario: Invalid security header




	#Given I get a list of skills from esco
	#And I request all skills from the NCS API
	#Then the skills returned by each service match
	#And the alternate labels listed for first Skill returned matches esco data
	#And the alternate labels listed for mid Skill returned matches esco data
	#And the alternate labels listed for last Skill returned matches esco data
