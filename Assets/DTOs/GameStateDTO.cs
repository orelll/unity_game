using System.Collections.Generic;

namespace unity_game_master.Assets.DTOs
{
    public class GameStateDTO
    {
        public int GemsCount { get; set; }
        public int HPState { get; set; }
        public PointDTO Position { get; set; }
        public IList<PointDTO> Gems { get; set; }
        public IList<PointDTO> Frogs { get; set; }
    }
}