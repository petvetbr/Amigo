using AmigoRepo;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class FluxoCaixaViewModel : ViewModelBase
    {
        FluxoCaixa _FluxoCaixaMes;
        public FluxoCaixa FluxoCaixaMes
        {
            get
            {
                return _FluxoCaixaMes;
            }

            set
            {
                if (_FluxoCaixaMes != value)
                {
                    _FluxoCaixaMes = value;
                    RaisePropertyChanged(nameof(FluxoCaixaMes));
                }
            }
        }
    }
}
