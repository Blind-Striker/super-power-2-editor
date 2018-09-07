namespace SuperPowerEditor.Base.BizLogic.Actors.Commands
{
    public class GetStringTableValueFromIdCommand
    {
        public GetStringTableValueFromIdCommand(int stId, string lang)
        {
            StId = stId;
            Lang = lang;
        }

        public int StId { get; }

        public string Lang { get; }
    }
}
