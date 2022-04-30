Feature: CreateFreeflow

As a random user, I want the feature to create a freeflow entry 
so that any user can see the entry I created.

Scenario: Create freeflow entry
	Given create a freeflow entry
	Then the freeflow entry should be created successfully