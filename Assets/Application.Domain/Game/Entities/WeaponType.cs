namespace GGJ2019.Game.Entities
{
    public class Weapon
    {
        public WeaponType WeaponType { get; set; }
        public int Cost { get; set; }
    }

    public enum WeaponType
    {
        Bean,
        Carrot,
        Watermelon,
    }
}
