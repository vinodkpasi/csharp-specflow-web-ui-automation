Feature: Home Feature
    As a user of the application
	In want to navigate and verify the home page

Scenario: Home page feature
	Given User Navigate to the application url
	Then Verify that page title should be "Online Shopping site in India: Shop Online for Mobiles, Books, Watches, Shoes and More - Amazon.in"
	Then Verify cart icon is displayed
	And search box and search button is displayed