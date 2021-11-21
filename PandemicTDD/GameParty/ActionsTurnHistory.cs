using PandemicTDD.Actions;
using System.Collections.Generic;
using System.Linq;

namespace PandemicTDD
{
    public class ActionsTurnHistory
    {

        public int PlayedActionsCount { get => PlayedActionsDuringTurn.Count; }

        List<ActionBase> PlayedActionsDuringTurn = new List<ActionBase>();

        public ActionsTurnHistory()
        {
        }

        public void AddAction(ActionBase played)
        {
            PlayedActionsDuringTurn.Add(played);
        }

        public bool AlreadyPlayed<T>() where T : ActionBase
        {
            return (PlayedActionsDuringTurn.Any(i => i is T));
        }
        public void NextTurn()
        {
            PlayedActionsDuringTurn.Clear();
        }
    }
}