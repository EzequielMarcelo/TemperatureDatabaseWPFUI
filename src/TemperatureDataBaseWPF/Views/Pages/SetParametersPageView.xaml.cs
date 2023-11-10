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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TemperatureDataBaseWPF.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace TemperatureDataBaseWPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for SetParametersPageView.xaml
    /// </summary>
    public partial class SetParametersPageView : INavigableView<SetParametersPageViewModel>
    {
        public SetParametersPageViewModel ViewModel { get; }

        public SetParametersPageView(SetParametersPageViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }        
    }
}
