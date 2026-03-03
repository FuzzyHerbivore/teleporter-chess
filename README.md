# Teleporter Chess

This is a 3D chess game with simplified rules, started as an exam project for MVC architecture at S4G. I had not tried using Godot with C# instead of GDScript before, so I was curious to try it out.

I underestimated the setup effort somewhat, partly because I stubbornly tried getting the setup with Godot-Mono and VS Code to work on NixOS, which I'm still kinda new to, but once I realized I had fallen into the rabbit hole it was too late. In the end it mostly worked (Debugger didn't work still), but I had to make several cuts in functionality to get things done in a semi-working fashion in the alotted time. But hey, I learned shit, that's the main thing, right?


## Rule Simplifications

- Castling is not included
- King may move into check position
- Pieces can 'teleport' through other pieces


## Architecture

The idea of MVC, is to separate the different responsibilities of code into **Models**, that deal with the business or game logic, **Views** that handle presenting the data the model produces, and **Controllers** that inform the model of activities that trigger an update of its data, which then propagates to the views.
Since the game is very small, I went with one data container `GameData` that contains all the necessary data to update the views and populate controllers with their available actions.

As an exercise, I used TDD to develop the models of the game and to achieve modular testability, I used C# Action delegates that get injected from parent models to their children.

For example, the [Board's model](/TeleporterChess/Model/Board.cs) is completely ignorant of the existence of the [Game model](/TeleporterChess/Model/Game.cs), it just expects to get necessary delegates injected into its constructor to do its job. This approach allows for easy injection of spies into tests, like the `TryMovingSelectedPieceFailsWhenNoPieceIsSelected` test in the [BoardModelTests](/TeleporterChessTests/BoardModelTests.cs).


### To Dos

- [ ] Add `Move` model type to determine legal moves. Must be able to handle both individual positions for movement of kings/knights/pawns, as well as "recursive" movements like those of the queens/bishops/rooks. Consider "delta vector" and make sure directionality is considered, as Pawns may not move backwards.
- [ ] Add collection of Move models to `Piece` model, ensure special cases like Pawns being able to move two tiles during their first move. Ignore 'en passant' and 'promotion' of Pawns for now.
- [ ] Add visual feedback for selection and moves.
- [ ] Implement 'en passant' for Pawns.
- [ ] Implement 'promotion' for Pawns.


## Conclusion

Overall I'm not a huge fan of the MVC-pattern as I have implemented it here, i.e. with one all-encompassing GameData object. Despite the clarity of the unidirectional data-flow I find that the lack of modularity is putting a lot of mental load on me... I have to read a lot of stuff, even when I know I just want to change one aspect of the game.

Splitting up the data to hold the information of a select subset of models/controllers/views related to a particular feature would probably improve this, but that was out of scope for this project.

The approach taken now, reminds me of the [Elm architecture](https://guide.elm-lang.org/architecture/) (which inspired Redux in the React-world) that I toyed with a couple of years ago when Elm the framework made the rounds. That in turn reminded me of the "Good Old Days"<sup>TM</sup>, where we had to re-render entire web pages just because one element changed.

Was an interesting challenge nonetheless.
