using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonDeckClient.Views.Main
{
    internal abstract class ProgrammerProfileMenuItem : PropertyChangedViewModel
    {
        public abstract string Name { get; }
        public abstract bool IsChecked { get; set; }
        public abstract bool IsEnabled { get; }
        public abstract ICommandModel SetValueCommand { get; }
    }


    internal class ProgrammerProfileSelectionItem : ProgrammerProfileMenuItem
    {
        private readonly MainViewModel _parent;

        public ProgrammerProfileSelectionItem(MainViewModel parent, string name)
        {
            _parent = parent;
            Name = name;
            SetValueCommand = new ActionCommandModel(() => true, () => IsChecked = true);
            _parent.CurrentProgrammerProfile.PropertyChanged += CurrentProgrammerProfile_PropertyChanged;
        }

        private void CurrentProgrammerProfile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            PropertyHasChanged(nameof(IsChecked));
        }

        public override string Name { get; }

        public override bool IsChecked
        {
            get { return Name.Equals(_parent.CurrentProgrammerProfile.Value); }
            set
            {
                if (!value)
                    return;

                _parent.CurrentProgrammerProfile.Value = Name;
            }
        }


        public override ICommandModel SetValueCommand { get; }
        public override bool IsEnabled => true;
    }

    internal class NoProfilesAvailable : ProgrammerProfileMenuItem
    {
        public static readonly ProgrammerProfileMenuItem Value = new NoProfilesAvailable();

        public NoProfilesAvailable()
        {
            Name = "No profiles available";
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
