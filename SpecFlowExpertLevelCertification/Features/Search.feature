Feature: Search and add to cart Feature
    As a user of the application
	In want to search the product and add to the cart
Background: 
	Given User Navigate to the application url

	Scenario: Search product 
	Given User enter "Samsung mobile" in the search box
	And User click on the search button 
	Then Search result should be displayed

    Scenario: Add to the cart 
	Given User search the "Samsung mobile"
	And User open the first search result 
	When User click on the add to the cart button
	Then Verify cart is displayed with 1 items added
	
	Scenario: Cart product details
	Given User search the "Samsung mobile" and add the first result to the cart
	When User open the cart
	Then Verify the product name and price
