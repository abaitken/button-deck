using System;

namespace ButtonDeckClient.Views.Main
{
    internal abstract class SerialPortMenuItem : PropertyChangedViewModel
    {
        public abstract string Name { get; }
        public abstract bool IsChecked { get; set; }
        public abstract bool IsEnabled { get; }
        public abstract ICommandModel SetValueCommand { get; }
    }


    internal class SerialPortSelectionItem : SerialPortMenuItem
    {
        private readonly MainViewModel _parent;

        public SerialPortSelectionItem(MainViewModel parent, string name)
        {
            _parent = parent;
            Name = name;
            SetValueCommand = new ActionCommandModel(() => true, () => IsChecked = true);
            _parent.CurrentSerialPort.PropertyChanged += CurrentSerialPort_PropertyChanged;
        }

        private void CurrentSerialPort_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PropertyHasChanged(nameof(IsChecked));
        }

        public override string Name { get; }

        public override bool IsChecked
        {
            get { return Name.Equals(_parent.CurrentSerialPort.Value); }
            set
            {
                if (!value)
                    return;

                _parent.CurrentSerialPort.Value = Name;
            }
        }


        public override ICommandModel SetValueCommand { get; }
        public override bool IsEnabled => true;
    }

    internal class NoPortsAvailable : SerialPortMenuItem
    {
        public static readonly SerialPortMenuItem Value = new NoPortsAvailable();

        public NoPortsAvailable()
        {
            Name = "No ports available";
            SetValueCommand = new EmptyCommandModel();
        }

        public override string Name { get; }

        public override bool IsChecked
        {
            get { return false; }
            set
            {
                throw new InvalidOperationException();
            }
        }


        public override ICommandModel SetValueCommand { get; }
        public override bool IsEnabled => false;
    }
}
