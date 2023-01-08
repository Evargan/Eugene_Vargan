Feature: 1)UploadFile

A short summary of the feature

@tag1
Scenario: Upload file to dropbox
	Given I check if file with this name exists(upload)
	When I upload file
	Then I check if file is uploaded
