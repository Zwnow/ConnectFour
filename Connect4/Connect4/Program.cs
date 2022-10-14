using Connect4;


Console.WriteLine("Welcome to Connect 4!\n\nThe rules are simple!\nThere are two players that repeatedly take turns after each other.\n" +
                  "The games board consists out of six rows and seven columns.\nOn your turn you can place a chip with the goal to connect four of your chips\n" +
                  "either horizontally, vertically or diagonal. Once a player achieved that, the other player loses the game.\n\n\n" +
                  "Press any key to stat the game...\n\n\n");
Console.ReadLine();


Board board = new Board();

bool foundWinner = false;
string winner = "";
board.FillField();
Player a = new Player("A");
Player b = new Player("B");

while(foundWinner == false)
{ 
    a.TakeTurn(board);
    if(a.Won == true)
    {
        foundWinner = true;
        winner = a.Name;
        break;
    }
    b.TakeTurn(board);
    if (b.Won == true)
    {
        foundWinner = true;
        winner = b.Name;
        break;
    }
}
Console.WriteLine($"Congrats, Player {winner} has won the Game!");