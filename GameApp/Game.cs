using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameApp
{
    public class Game
    {
        private readonly int _minimumPalyers;
        private readonly int _numberOfGames;
        private IDictionary<Player,string> _playerSelection;
        private IDictionary<Player, int> _playerToGameWon;

        public Player Winner { get; set; }

        public Game(int minimumPlayers, int numberOfGames)
        {
            _minimumPalyers = minimumPlayers;
            _numberOfGames = numberOfGames;
            Rules = new List<Rule>();
            Players = new List<Player>();
            _playerSelection = new Dictionary<Player, string>();
            _playerToGameWon = new Dictionary<Player, int>();
        }

        public void PlayGame()
        {
            _playerSelection.Clear();
            int currentPlay = 0;
            if(Players.Count < _minimumPalyers)
            {
                throw new NotSupportedException($"Minimum of {_minimumPalyers} need to be available");
            }

            if(!this.Rules.Any())
            {
                throw new InvalidOperationException($"Minimum of {_minimumPalyers} need to be available");
            }

            while(currentPlay < _numberOfGames)
            {
                _playerSelection.Clear();
                foreach (var player in Players)
                {
                    var selection = player.GetSelection();
                    _playerSelection.Add(player, selection);
                    
                }
                Winner = EvaluateWinner();
                if (currentPlay == 2 && HasAnyBodyWon())
                {
                    break;
                }
                currentPlay++;
            }

        }

        public bool IsInRule(string status)
        {
            foreach(var rule in Rules)
            {
                if (rule.Winner == status)
                {
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        public Player EvaluateWinner()
        {
            Player winner = null;
            foreach(var plySel in _playerSelection)
            {
                if(IsInRule(plySel.Value))
                {
                    if(!_playerToGameWon.ContainsKey(plySel.Key))
                    {
                        _playerToGameWon.Add(plySel.Key, 1);
                    }
                    else
                    {
                        _playerToGameWon[plySel.Key]++;
                        if(_playerToGameWon[plySel.Key] == _numberOfGames-1)
                        {
                            winner = plySel.Key;
                            break;
                        }
                    }

                }
            }
            Winner = winner;
            var _winner = _playerToGameWon.Where(x => x.Value == _playerToGameWon.Values.Max()).ToList();
            if(_winner != null && _winner.Any())
            {
                Winner = _winner.FirstOrDefault().Key;
            }
            else
            {
                Winner = null;
            }
            return Winner;
        }

        public bool HasAnyBodyWon()
        {
            if (EvaluateWinner() != null) return true;
            return false;
        }

        public List<Rule> Rules { get; set; }

        public List<Player> Players { get; set; }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }

        public void AddRules(List<Rule> rules)
        {
            Rules.AddRange(rules);
        }

        public void AddPlayers(List<Player> players)
        {
            Players.AddRange(players);
        }
    }
}
