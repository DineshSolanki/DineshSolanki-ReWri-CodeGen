using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReWri_CodeGen.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        //Send a msg to client while the property is changed
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
