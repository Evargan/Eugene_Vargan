Feature: 2)GetMetaData

A short summary of the feature

@tag2
Scenario: Get file's meta data
	Given I check if file with this name exists(getdata)
	When I get file's meta data
	Then I check if I recieved file's data
