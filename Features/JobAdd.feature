Feature: AddJob

@mytag
Scenario: Add new job 
Given I navigate to site
And I log in to site
And I navigate to site's section
When I add job information and save changes and verify whether the job is added
Then I delete added job and verify the job is deleted
