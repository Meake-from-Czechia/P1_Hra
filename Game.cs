namespace P1_Hra
{
    public class Game
    {
        public Guid Id { get; private set; }
        private int round { get; set; }
        public List<Player> Players;
        public List<Enemy> Enemies;
        #region Helper views
        private bool ArePlayersAlive => alivePlayers.Count > 0;
        private bool AreEnemiesAlive { get { return aliveEnemies.Count > 0; } }
        private List<Player> alivePlayers { get { return Players.Where(x => x.IsAlive).ToList(); } }
        private List<Enemy> aliveEnemies { get { return Enemies.Where(x => x.IsAlive).ToList(); } }
        #endregion
        public Game()
        {
            Id = Guid.NewGuid();
            round = 1;
            Players = new List<Player>();
            Enemies = new List<Enemy>();
        }
        public GameResult Play()
        {
            Logger.Log("Game has been started.\n");
            do
            {
                Logger.Log($"\nBeginning turn {round}:\n", ConsoleColor.Yellow);
                ExecutePlayersTurn();
                ExecuteEnemiesTurn();
                round++;
            } while (ArePlayersAlive && AreEnemiesAlive);
            if (ArePlayersAlive) return GameResult.Win;
            return GameResult.Lose;
        }
        private void ExecutePlayersTurn()
        {
            foreach (Player player in alivePlayers) foreach (Enemy enemy in aliveEnemies) player.Attack(enemy);
        }

        private void ExecuteEnemiesTurn()
        {
            foreach (Enemy enemy in aliveEnemies) foreach (Player player in alivePlayers) enemy.Attack(player);
        }
    }
}