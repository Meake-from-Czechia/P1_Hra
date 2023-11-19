namespace P1_Hra
{
    public class Player : GameEntity, IHealable
    {
        public int Armor { get; set; }
        public Player(int health, int damage, int armor) : base(health, damage)
        {
            Armor = armor;
        }
        public override void Attack(GameEntity gameEntity)
        {
            Logger.Log($"Player attacked enemy for {this.Damage} damage.\n", ConsoleColor.Red);
            gameEntity.Defend(Damage);
            if (!gameEntity.IsAlive) Heal(25);
        }
        public override void Defend(int damage)
        {
            if (damage <= Armor)
            {
                Armor -= damage;
                Logger.Log($"Player defended for {damage} damage. They now have {Armor} armor.\n", ConsoleColor.Blue);
                return;
            }
            Health -= damage - Armor;
            Armor = 0;
            Logger.Log($"Player defended for {damage} damage. They now have {Health} health. They don't have anymore armor.\n", ConsoleColor.Blue);
        }
        public void Heal(int healAmount)
        {
            if (healAmount + Health > 100)
            {
                Health = 100;
                Logger.Log($"Player healed. They now have {Health} health.\n", ConsoleColor.Green);
                return;
            }
            Health += healAmount;
            Logger.Log($"Player healed. They now have {Health} health.\n", ConsoleColor.Green);
        }
    }
}