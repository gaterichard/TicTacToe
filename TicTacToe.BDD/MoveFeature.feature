Feature: MoveFeature
	In order to progress the game
	As a player
	I want to be able to make a move

Scenario: Win the game
	Given the board contains an 'X' in cell 0
	And the board contains an 'X' in cell 1
	When player 'X' makes a move into cell 2
	Then player 'X' should win the game.

Scenario: Illegal move
	Given the board contains an 'X' in cell 0
	When player 'O' makes a move into cell 0
	Then the move is invalid
