using ButtonDeckClient.Arduino;
using OBS.WebSocket.NET;

namespace ButtonDeckClient.Workflows
{
    public interface ICommandContext
    {
        ButtonDeckInformation ButtonDeckInformation { get; }
        IButtonDeckCommunication ButtonDeck { get; }
        ObsWebSocketApi OBS { get; }
        // TODO : Current workflow
        // TODO : Workflow source (button, toggle, another workflow?)
    }
}
