======================================================

      TIC-TAC-TOE
	
  Randomly played Tic-Tac-Toe game written in C#

=======================================================

Tic-Tac-Toe game in C#. Uses Ninject IoC, SpecFlow, nUnit and MOQ.

The main flow of the game, of each player taking a turn is encapulsated within the GameEngine.

IMoveStrategy interface allows the implementation of various movement implementations. It makes use of the strategy pattern to encapsulate the moving logic.
The spec indicates a player should make a random move including a 1 second wait. This is encapulated in the RandonOneSecondMoveStrategy

The Board class represents the board, current played turns and holds logic for calculating the boards state - inplay, win or draw.
Internally the board holds an array of characters to represent the turns played.

The GameEngine renders the output to the screen using the IGameDisplay interface. I've provided a ConsoleGameDisplay implementation to meet the spec.

Classes:

GameEngine
- Represents the workflow of the game, 1. Prompt user to start a game. 2. Render the board. 3. Have moves played until the game is resolved.
- Uses chain of responsibility pattern.

GameEngineTests
- Tests the game engine displays the prompt to the user to start the game.
- Tests moves are made until the board is resolved.
- Tests a game output is displayed.


IMove
- Represents the interface to making a move.

RandomOneSecondMove
- The logic for a random move by a player with a one second wait.


IGameDisplay
- Interface for displaying the board and welcome message.

ConsoleGameDisplay
- Console Game Display. This is used to render the board to a console output.

Board
- represents the state of the game board. The board internally holds a char array.

New Game Board:
0  1  2
3  4  5
6  7  8

Game In Motion:
O  X  O
3  X  X
O  O  8

The board above would be stored in the array as, O,X,O,3,X,X,O,O,8 reading from left to right, top to bottom.

With this setup we can observe that the winning positions of the game can be represented:
board[0] == board[1] && board[1] == board[2]
board[3] == board[4] && board[4] == board[5]
...

BoardTests
- Unit tests for the board class. Tests all the winning conditions, draw and inplay conditions. Tests that the board can be updated and that an illegal move exception is thrown when an invalid move is made.

