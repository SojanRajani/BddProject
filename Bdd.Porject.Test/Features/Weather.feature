Feature: Weather
	In order to check weather
	Fetch Google weather info and
	Assert with Open weather

@AssertingTemperatures
Scenario Outline: Compare the two weather api ouputs
	Given Call Google home URL
	Then Find the search box
	Then Enter search box text
	Then Find and click the search button
	Then Read the result Temperature
	Then Call the Open weather Api
	And Compare the temperatures