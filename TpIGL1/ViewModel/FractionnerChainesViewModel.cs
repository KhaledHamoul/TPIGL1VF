using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIGL1.Traitements;

namespace TpIGL1.ViewModel
{
    class FractionnerChainesViewModel : IPageViewModel, INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
