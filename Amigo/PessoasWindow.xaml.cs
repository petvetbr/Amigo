using Amigo.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Amigo
{
    /// <summary>
    /// Interaction logic for PessoasWindow.xaml
    /// </summary>
    public partial class PessoasWindow : Window
    {
        
        public PessoasWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseWindowMessage>(this,"PessoasWindow", _ => Close());
        }
    }
}
