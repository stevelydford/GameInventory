Feature: ReceiveAnItem
	As a player
	I want to open a chest and receive an item
	So that I can use the item in the game

Scenario: Receive item from loot table
	Given I have a player
	And a configured loot table
	When I roll on this loot table
	Then I receive a random item from the loot table

Scenario: Receive item from runtime configurable loot table
	Given I have a player
	And an existing runtime configurable loot table
	When I roll on this loot table
	Then I receive a random item from the loot table