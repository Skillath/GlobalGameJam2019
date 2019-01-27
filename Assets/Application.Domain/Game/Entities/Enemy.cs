using System.Runtime.Serialization;

namespace GGJ2019.Game.Entities
{
    public class Enemy
    {
        [DataMember(Name = "cell")]
        public int Cell { get; set; }
        [DataMember(Name = "type")]
        public EnemyType Type { get; set; }
    }

    [DataContract(Name = "enemytype", Namespace = "")]
    public enum EnemyType : int
    {
        [EnumMember]
        VeganRed = 0,
        [EnumMember]
        VeganBlue = 1,
        [EnumMember]
        VeganGreen = 2,
    }
}
