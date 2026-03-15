// See https://aka.ms/new-console-template for more information
using SnakeAndLadder;
Console.WriteLine("Snake and Ladder Game!");
ISnakeLadderConfiguration config = new SnakeLadderConfiguration();
var ladderList = config.GetLadders();
var snakeList = config.GetSnakes();
var playerQueue = config.GetPlayers();
var game = new GameBoard(100, ladderList, snakeList, playerQueue, new Dice(1));
game.StartGame();