using System.Runtime.Serialization;

namespace GGJ2019.Game.Entities
{
    [DataContract(Name = "game", Namespace = "")]
    public class Game
    {
        [DataMember(Name = "waves")]
        public Wave[] Waves { get; set; }

        public GameType GameType { get; }
    }

    public enum GameType
    {
        Default,
    }

    public class GameResult
    {
        public int WavesAlive { get; set; }

        public int Score { get; set; }

        public short Stars { get; set; }

        public WaveResult[] WavesResults { get; set; }
    }
}
