using ButtonDeckClient.Arduino;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace ButtonDeckClient.Views.ButtonDeckTest
{
    class ButtonDeckTestViewModel : PropertyChangedViewModel
    {
        public ViewModelProperty<int> HeartbeatValue { get; }
        public ViewModelProperty<int> LEDBrightness { get; }
        public ViewModelProperty<bool> LEDBrightnessGet { get; }
        public IEnumerable<int> Toggles => Enumerable.Range(0, 5);
        public ViewModelProperty<int> SelectedToggle { get; }
        public IEnumerable<int> LEDs => Enumerable.Range(1, 30);
        public ViewModelProperty<int> SelectedLED { get; }
        public ICommandModel SelectColor { get; }
        public ViewModelProperty<Color> LEDColor { get; }
        public ViewModelProperty<ActionTypes> ActionType { get; }
        public ViewModelProperty<bool> AllLEDs { get; }
        public ICommandModel Send { get; }

        public ButtonDeckTestViewModel()
        {
            Messages = new ObservableCollection<string>();
            HeartbeatValue = new ViewModelProperty<int>();
            LEDBrightness = new ViewModelProperty<int>
            {
                Value = 255
            };
            LEDBrightnessGet = new ViewModelProperty<bool>();
            SelectedToggle = new ViewModelProperty<int>();
            SelectedLED = new ViewModelProperty<int>
            {
                Value = 1
            };
            LEDColor = new ViewModelProperty<Color>
            {
                Value = Colors.Blue
            };
            ActionType = new ViewModelProperty<ActionTypes>();
            AllLEDs = new ViewModelProperty<bool>();
            SelectColor = new ActionCommandModel(() => true, OnSelectColor);
            Send = new ActionCommandModel(() => true, OnSend);
        }

        private void OnSelectColor()
        {
            var colorDialog = new ColorDialog();

            var result = colorDialog.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            LEDColor.Value = Color.FromArgb(255, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        }

        private void OnSend()
        {
            switch (ActionType.Value)
            {
                case ActionTypes.Unknown:
                    // Do nothing
                    break;
                case ActionTypes.Heartbeat:
                    Messages.Add($"SEND: Heartbeat: value={HeartbeatValue.Value}");
                    Communication.Heartbeat(HeartbeatValue.Value);
                    break;
                case ActionTypes.LEDBrightness:
                    if (LEDBrightnessGet.Value)
                    {
                        Messages.Add($"SEND: Get LED Brightness");
                        Communication.RequestLedBrightness();
                    }
                    else
                    {
                        Messages.Add($"SEND: Set LED Brightness: value={LEDBrightness.Value}");
                        Communication.SetLedBrightness(LEDBrightness.Value);
                    }
                    break;
                case ActionTypes.ToggleState:
                    Messages.Add($"SEND: Get Toggle State: index={SelectedToggle.Value}");
                    Communication.RequestToggleState(SelectedToggle.Value);
                    break;
                case ActionTypes.LEDColor:
                    Messages.Add($"SEND: Set LED Color: index={SelectedLED.Value};R={LEDColor.Value.R};G={LEDColor.Value.G};B={LEDColor.Value.B}");
                    Communication.SetLedColor(SelectedLED.Value, LEDColor.Value.ToRGB());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ActionType));
            }
        }

        internal void LoadedOnce()
        {
        }

        internal void Connect(ButtonDeckCommunication communication)
        {
            Communication = communication;
            Communication.ToggleStateChanged += Communication_ToggleStateChanged;
            Communication.VersionResponse += Communication_VersionResponse;
            Communication.HeartbeatResponse += Communication_HeartbeatResponse;
            Communication.LEDBrightness += Communication_LEDBrightness;
            Communication.ButtonUp += Communication_ButtonUp;
            Communication.ButtonDown += Communication_ButtonDown;
            Communication.InvalidResponse += Communication_InvalidResponse;
            Communication.AcknowledgedResponse += Communication_AcknowledgedResponse;
        }

        private void Communication_InvalidResponse(object sender, EventArgs e)
        {
            Messages.Add($"RECV: Invalid");
        }

        private void Communication_AcknowledgedResponse(object sender, EventArgs e)
        {
            Messages.Add($"RECV: Acknowledged");
        }

        private void Communication_ButtonDown(object sender, ButtonEventArgs e)
        {
            Messages.Add($"RECV: Button Down: column={e.Column};row={e.Row}");
        }

        private void Communication_ButtonUp(object sender, ButtonEventArgs e)
        {
            Messages.Add($"RECV: Button Up: column={e.Column};row={e.Row}");
        }

        private void Communication_LEDBrightness(object sender, LEDBrightnessEventArgs e)
        {
            Messages.Add($"RECV: LED Brightness: value={e.Value}");
        }

        private void Communication_HeartbeatResponse(object sender, HeartbeatEventArgs e)
        {
            Messages.Add($"RECV: Heartbeat: value={e.Value}");
        }

        private void Communication_VersionResponse(object sender, VersionEventArgs e)
        {
            Messages.Add($"RECV: Version: version={e.Version}");
        }

        private void Communication_ToggleStateChanged(object sender, ToggleStateChangeEventArgs e)
        {
            Messages.Add($"RECV: Toggle State Changed: index={e.Index};new state={e.NewState}");
        }

        private ButtonDeckCommunication Communication { get; set; }

        public ObservableCollection<string> Messages { get; }
    }
}
