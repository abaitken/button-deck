using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ButtonDeckClient.Views.ButtonDeckTest
{
    /// <summary>
    /// Interaction logic for ButtonDeckTestWindow.xaml
    /// </summary>
    internal partial class ButtonDeckTestWindow : Window
    {
        public ButtonDeckTestWindow()
        {
            ViewModel = new ButtonDeckTestViewModel();
            Loaded += ButtonDeckTestWindow_Loaded;
            InitializeComponent();
        }

        private void ButtonDeckTestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= ButtonDeckTestWindow_Loaded;
            ViewModel.LoadedOnce();
        }

        public ButtonDeckTestViewModel ViewModel
        {
            get { return (ButtonDeckTestViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
