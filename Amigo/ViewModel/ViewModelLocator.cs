/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Amigo"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Amigo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PessoasViewModel>();
            SimpleIoc.Default.Register<MensalidadesViewModel>();
            SimpleIoc.Default.Register<FluxoCaixaViewModel>();
            SimpleIoc.Default.Register<CaixaTransporteViewModel>();

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public FluxoCaixaViewModel FluxoCaixa
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FluxoCaixaViewModel>();
            }
        }
        public MensalidadesViewModel Mensalidades
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MensalidadesViewModel>();
            }
        }
        public PessoasViewModel Pessoas
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PessoasViewModel>();
            }
        }
        public CaixaTransporteViewModel CaixaTransporte
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CaixaTransporteViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}