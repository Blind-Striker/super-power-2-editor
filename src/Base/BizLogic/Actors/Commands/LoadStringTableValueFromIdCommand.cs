namespace SuperPowerEditor.Base.BizLogic.Actors.Commands
{
    public class LoadStringTableValueFromIdCommand
    {
        public LoadStringTableValueFromIdCommand(int stId, string lang)
        {
            StId = stId;
            Lang = lang;
        }

        public int StId { get; }

        public string Lang { get; }
    }
}
