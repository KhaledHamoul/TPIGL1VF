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
        public MyICommand ICommandJoindre { get; set; }
        public MyICommand ICommandFractionner { get; set; }
        public MyICommand ICommandMinMaj { get; set; }
        public MyICommand ICommandNmbrOccurence { get; set; }
        public MyICommand ICommandPermutation { get; set; }


        public MainWindowViewModel() {
            showAccueilView();
            ICommandAccueil = new MyICommand(showAccueilView);
            ICommandshowEliminerMotsVides = new MyICommand(showEliminerMotsVidesView);
            ICommandFractionner = new MyICommand(showFractionnerView);
            ICommandJoindre = new MyICommand(showJoindreView);
            ICommandMinMaj = new MyICommand(showMinMajView);
            ICommandNmbrOccurence = new MyICommand(showNmbrOccurenceView);
            ICommandPermutation = new MyICommand(showPermutationView);

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

        private void showFractionnerView()
        {
            this.PageActuelle = new FractionnerChainesViewModel();
        }
        private void showJoindreView()
        {
            this.PageActuelle = new JoindreChainesViewModel();
        }
        private void showMinMajView()
        {
            this.PageActuelle = new MajMinTextViewModel();
        }
        private void showNmbrOccurenceView()
        {
            this.PageActuelle = new NmbrOccurencesMotViewModel();
        }
        private void showPermutationView()
        {
            this.PageActuelle = new PermutationCharsViewModel();
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
