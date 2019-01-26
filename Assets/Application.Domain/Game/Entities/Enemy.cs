namespace GGJ2019.Game.Entities
{
    public class Enemy
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public EnemyType Type { get; set; }
    }

    public enum EnemyType
    {
        VeganRed,
        VeganBlue,
        VeganGreen,
    }
}
