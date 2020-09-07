using ButtonDeckClient.Arduino;
using ButtonDeckClient.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient
{
    class ActionRouter
    {
        public ActionRouter(ILogger logger, ButtonDeckCommunication communication)
        {
            _logger = CategoryLogger.Create(nameof(ActionRouter), logger);
            Communication = communication;
            Communication.ToggleStateChanged += Communication_ToggleStateChanged;
            Communication.VersionResponse += Communication_VersionResponse;
            Communication.HeartbeatResponse += Communication_HeartbeatResponse;
            Communication.LEDBrightness += Communication_LEDBrightness;
            Communication.ButtonUp += Communication_ButtonUp;
            Communication.ButtonDown += Communication_ButtonDown;
            Communication.InvalidResponse += Communication_InvalidResponse;
            Communication.AcknowledgedResponse += Communication_AcknowledgedResponse;
            Deck = ButtonDeckInformation.Default;
            Initialise();
        }

        class ToggleState
        {
            public bool Value { get; set; }
        }

        private ToggleState[] _toggleStates;

        private void Initialise()
        {
            _toggleStates = new ToggleState[Deck.ToggleButtonCount];
            for (int i = 0; i < Deck.ToggleButtonCount; i++)
                Communication.RequestToggleState(i);
        }

        private readonly ILogger _logger;

        private ButtonDeckCommunication Communication { get; }
        private ButtonDeckInformation Deck { get; }

        private void Communication_InvalidResponse(object sender, EventArgs e)
        {
        }

        private void Communication_AcknowledgedResponse(object sender, EventArgs e)
        {
        }

        private void Communication_ButtonDown(object sender, ButtonEventArgs e)
        {
        }

        private void Communication_ButtonUp(object sender, ButtonEventArgs e)
        {
        }

        private void Communication_LEDBrightness(object sender, LEDBrightnessEventArgs e)
        {
        }

        private void Communication_HeartbeatResponse(object sender, HeartbeatEventArgs e)
        {
        }

        private void Communication_VersionResponse(object sender, VersionEventArgs e)
        {
        }

        private void Communication_ToggleStateChanged(object sender, ToggleStateChangeEventArgs e)
        {
            // TODO : Handle index outside of range
            if (e.Index >= _toggleStates.Length)
            {
                _logger.WriteLine($"Invalid toggle state index {e.Index}");
                return;
            }

            if(_toggleStates[e.Index] == null)
            {
                // TODO : Init
            }
            else
            {
                // TODO : Find actions for this toggle button
                // Actions like: When switched Off, When switched On
            }
        }
    }
}
