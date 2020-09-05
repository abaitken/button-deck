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
                    break;
                case ActionTypes.LEDBrightness:
                    break;
                case ActionTypes.ToggleState:
                    break;
                case ActionTypes.LEDColor:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ActionType));
            }
        }

        internal void LoadedOnce()
        {
        }

        internal void Connect(string portName)
        {
        }

        public ObservableCollection<string> Messages { get; }
    }
}
