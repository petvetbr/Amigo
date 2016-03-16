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
using System;

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
            SimpleIoc.Default.Register<EmprestimoCaixaTransporteViewModel>();
            SimpleIoc.Default.Register<ServicoCaixaTransportesViewModel>();
            SimpleIoc.Default.Register<AnimalViewModel>();
            SimpleIoc.Default.Register<UsuarioViewModel>();

        }

        private string _currentPessoasVMKey;
        private string _currentFluxoCaixaVMKey;
        private string _currentCaixaTransporteVMKey;
        private string _currentEmprestimoCaixaTransporteVMKey;
        private string _currentMensalidadesVMKey;
        private string _currentServicoCaixaTransporteVMKey;
        private string _currentAnimalVMKey;
        private string _currentUsuarioVMKey;


        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AnimalViewModel Animal
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentAnimalVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentAnimalVMKey);
                }
                _currentAnimalVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<AnimalViewModel>(_currentAnimalVMKey);
            }
        }
        public FluxoCaixaViewModel FluxoCaixa
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentFluxoCaixaVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentFluxoCaixaVMKey);
                }
                _currentFluxoCaixaVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<FluxoCaixaViewModel>(_currentFluxoCaixaVMKey);
            }
        }
        public MensalidadesViewModel Mensalidades
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentMensalidadesVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentMensalidadesVMKey);
                }
                _currentMensalidadesVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<MensalidadesViewModel>(_currentMensalidadesVMKey);
            }
        }
        public PessoasViewModel Pessoas
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentPessoasVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentPessoasVMKey);
                }
                _currentPessoasVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<PessoasViewModel>(_currentPessoasVMKey);
            }
        }
        public CaixaTransporteViewModel CaixaTransporte
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentCaixaTransporteVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentCaixaTransporteVMKey);
                }
                _currentCaixaTransporteVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<CaixaTransporteViewModel>(_currentCaixaTransporteVMKey);
            }
        }
        public EmprestimoCaixaTransporteViewModel EmprestimoCaixaTransporte
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentEmprestimoCaixaTransporteVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentEmprestimoCaixaTransporteVMKey);
                }
                _currentEmprestimoCaixaTransporteVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<EmprestimoCaixaTransporteViewModel>(_currentEmprestimoCaixaTransporteVMKey);
            }
        }
        public ServicoCaixaTransportesViewModel ServicoCaixaTransportes
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentServicoCaixaTransporteVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentServicoCaixaTransporteVMKey);
                }
                _currentServicoCaixaTransporteVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<ServicoCaixaTransportesViewModel>(_currentServicoCaixaTransporteVMKey);
            }
        }
        public UsuarioViewModel Usuario
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentUsuarioVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentUsuarioVMKey);
                }
                _currentUsuarioVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<UsuarioViewModel>(_currentUsuarioVMKey);
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}