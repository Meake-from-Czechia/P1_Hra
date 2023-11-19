namespace P1_Hra
{
    public class Enemy : GameEntity
    {
        public bool IsBoss { get; set; }
        public Enemy(int health, int damage, bool isBoss = false) : base(health, damage)
        {
            IsBoss = isBoss;
        }
        public override void Attack(GameEntity gameEntity)
        {
            Logger.Log($"Enemy attacked for {this.Damage} damage.\n", ConsoleColor.Red);
            gameEntity.Defend(IsBoss ? Convert.ToInt32(Damage * 1.5) : Damage);
        }
        public override void Defend(int damage)
        {
            Health -= IsBoss ? Convert.ToInt32(damage * 0.75) : damage;
            Logger.Log($"Enemy defended for {(IsBoss ? damage * 0.75 : damage)} damage. They now have {Health} health.\n", ConsoleColor.Blue);
        }
    }
}