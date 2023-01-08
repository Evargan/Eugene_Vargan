Feature: 3)DeleteFile

A short summary of the feature

@tag3
Scenario: delete file from dropbox
	Given I check if file with this name exists(delete)
	When I delete file
	Then I check if file is deleted
