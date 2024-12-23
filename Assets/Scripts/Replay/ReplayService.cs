using Command.AbstractCommand;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Replay
{
    public class ReplayService
    {
        private Stack<ICommand> replayCommandStack;

        public ReplayState ReplayState { get; private set; }

        public ReplayService() => SetReplayState(ReplayState.DEACTIVATED);

        public void SetReplayState(ReplayState stateToSet) => ReplayState = stateToSet;

        public void SetCommandStack(Stack<ICommand> commandsToSet) => replayCommandStack = new Stack<ICommand>(commandsToSet);

        public IEnumerator ExecuteNext()
        {
            yield return new WaitForSeconds(1);

            if (replayCommandStack.Count > 0)
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
        }
    }

    public enum ReplayState
    {
        DEACTIVATED,
        ACTIVATED
    }
}