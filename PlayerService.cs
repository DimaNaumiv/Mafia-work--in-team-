using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MafiaGame
{
    public class PlayerService
    {
        private readonly GameContext _context;

        public PlayerService()
        {
            _context = new GameContext();
            _context.Database.EnsureCreated();
        }

        public void AddPlayer(string name, string role, bool state)
        {
            var player = new Player { Name = name, Role = role, State = state };
            _context.Players.Add(player);
            _context.SaveChanges();
        }
        public void ChengeState(string name,bool tf)
        {
            Player player = _context.Players.Where(n=>n.Name==name).FirstOrDefault();
            _context.Update(player).Property(s=>s.State).CurrentValue =tf;
            _context.SaveChanges(); 
        }
        public List<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public List<Player> GetMafias()
        {
            return _context.Players.Where(p => p.Role == "The Mafia").ToList();
        }
        public void End()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
