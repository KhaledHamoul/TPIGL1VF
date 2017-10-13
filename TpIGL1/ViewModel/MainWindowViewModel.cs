using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TpIGL1;
using TpIGL1.Views;

namespace TpIGL1.ViewModel
{
    
    class MainWindowViewModel :   INotifyPropertyChanged
    {
        
        public MyICommand ICommandAccueil { get; set; }
        public MyICommand ICommandshowEliminerMotsVides { get; set; }



        public MainWindowViewModel() {
            ICommandAccueil = new MyICommand(showAccueilView);
            ICommandshowEliminerMotsVides = new MyICommand(showEliminerMotsVidesView);
            
            }

        
        private IPageViewModel pageActuelle;
        public IPageViewModel PageActuelle
        {
            get
            {
                return pageActuelle;
            }
            set
            {
                if (pageActuelle != value)
                {
                    pageActuelle = value;
                    RaisePropertyChanged("PageActuelle");
                }

            }
        }

        private void showAccueilView()
        {
            this.PageActuelle = new AccueilViewModel();  
        }

        private void showEliminerMotsVidesView()
        {
            this.PageActuelle = new EliminerMotsVidesViewModel();
        }


        //*************************************************************
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
