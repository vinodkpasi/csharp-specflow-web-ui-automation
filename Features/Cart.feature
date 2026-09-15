Feature: Cart Feature
    As a user of the application
	In want to verify the cart feature
Background: 
	Given User Navigate to the application url

Scenario: Initial cart count feature
	Then Verify cart icon is displayed
	And Verify initially cart is displayed with 0 items added


	Scenario: Cart page feature
	Given User open the cart
	Then Verify that page title should be "Amazon.in Shopping Cart"
	Then Cart header is displayed as "Your Amazon Cart is empty"
	And Verify cart is displayed with 0 items added