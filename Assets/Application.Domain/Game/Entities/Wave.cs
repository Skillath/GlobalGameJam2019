using System.Runtime.Serialization;

namespace GGJ2019.Game.Entities
{
    public class Wave
    {
        [DataMember(Name = "enemies")]
        public Enemy[] Enemies { get; set; }
    }

    public class WaveResult
    {
        public int VegansKilled { get; set; }
        public bool Alive { get; set; }
    }
}
