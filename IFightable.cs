namespace P1_Hra
{
    public interface IFightable
    {
        public void Attack(GameEntity gameEntity);
        public void Defend(int damage);
    }
}