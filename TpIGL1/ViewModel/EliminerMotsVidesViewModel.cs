using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIGL1.Traitements;

namespace TpIGL1.ViewModel
{
    class EliminerMotsVidesViewModel : IPageViewModel, INotifyPropertyChanged
    {
        public MyICommand ICommand { get; set; }
        public EliminerMotsVidesViewModel()
        {
            ICommand = new MyICommand(eliminerMotsVide);
        }
        

        private string inputText = string.Empty;
        public string InputText
        {
            get { return inputText; }
            set
            {
                if (inputText != value) inputText = value;
            }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                if (result != value) result = value;
            }
        }


        private void eliminerMotsVide()
        {

            StringHelper.EliminerMotsVides(ref inputText);
            Result = InputText;
            RaisePropertyChanged("Result");
        }
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
