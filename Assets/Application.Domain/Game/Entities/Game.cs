using System.Runtime.Serialization;

namespace GGJ2019.Game.Entities
{
    [DataContract(Name = "game", Namespace = "")]
    public class Game
    {
        [DataMember(Name = "waves")]
        public Wave[] Waves { get; set; }

        [DataMember(Name = "gametype")]
        public GameType GameType { get; set; }
    }

    [DataContract(Name ="gametype", Namespace ="")]
    public enum GameType : int
    {
        [EnumMember]
        Default = 1,
    }

    public class GameResult
    {
        public int WavesAlive { get; set; }

        public int Score { get; set; }

        public short Stars { get; set; }

        public WaveResult[] WavesResults { get; set; }
    }
}
