
using MinimalTelegramBot.StateMachine.Abstractions;

namespace DragonBot.States
{
    internal class SaveTrainingSessionForUserState : State
    {
        private Dictionary<string, string> cashSessionsId = new Dictionary<string, string>();
        public SaveTrainingSessionForUserState(int stateId) : base(stateId)
        {
        }

        public static SaveTrainingSessionForUserState State
{
            get { return new SaveTrainingSessionForUserState(9); }
        }

        public void SetTrainingSessionsId(Dictionary<string , string > trainingSessionsId )
        {
            foreach (var kvp in trainingSessionsId)
            {
                cashSessionsId[kvp.Key] = kvp.Value;
            }
        }
        public Dictionary<string, string> GetTrainingSessionsId() { return cashSessionsId; }    
    }
}
