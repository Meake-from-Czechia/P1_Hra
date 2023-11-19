namespace P1_Hra
{
    internal class Program
    {
        static void Main()
        {
            Player player1 = new(100, 10, 10);
            Player player2 = new(30, 50, 20);
            Enemy enemy1 = new(100, 10);
            Enemy enemy2 = new(100, 10, true);
            Game game = new();

            game.Players.Add(player1);
            game.Players.Add(player2);
            game.Enemies.Add(enemy1);
            game.Enemies.Add(enemy2);

            GameResult result = game.Play();
            Logger.Log(result == GameResult.Win ? "Game has been won.\n" : "Game has been lost.\n",
                result == GameResult.Win ? ConsoleColor.Green : ConsoleColor.Red);
        }
    }
}