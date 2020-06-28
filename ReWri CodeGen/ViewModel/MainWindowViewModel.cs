using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ReWri_CodeGen.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
   
        public List<string> Languages { get; set; }
        public string SelectedLanguage { get; set; }
        public List<string> GenerationModes { get; set; }
        public string SelectedGenMode { get;set;}
        public DelegateCommand GenerateClickCommand { get;set;}
        public string TxtInput { get; set;}
        public string TxtOutput { get; set;}

        public MainWindowViewModel()
        {
            Languages=new List<string>() { "C++","Java"};
            GenerationModes = new List<string>() { "Read", "Write" };
            GenerateClickCommand=new DelegateCommand(new Action<object>(GenerateClickMethod));
        }
        private void GenerateClickMethod(object obj)
        {
            GenerateCode();
            RaisePropertyChanged("TxtOutput");
        }
        private string GenerateCode()
        {
            Dictionary<string,CustomVariables> variables = new Dictionary<string, CustomVariables>();
            
            string txt = TxtInput;
            string[] lines = txt.Split("\n");
            int row=1;
           foreach(string line in lines)
            {
                string[] Tokens= line.Split(" "); //maxSliceINT PizzaTypesINTAS
                int col=1;
                foreach(string token in Tokens)         //PizzaTypes1 PizzaType2 PizzaType3
                {
                    
                    if(token.Contains("INT"))
                    {
                        variables.Add(token.Replace("INT",""),new CustomVariables("INT",row,col));
                    }
                    else if(token.Contains("INTA"))
                    {
                        variables.Add(token.Replace("INTA",""), new CustomVariables("INTA",row,col));
                    }
                    col++;
                }
                row++;
            }
           return null;
        }
        
    }
    class CustomVariables
    {
        public CustomVariables(string type,int row,int col)
        {
            Type=type;
            location.row=row;
            location.col=col;
        }
        public string Type { get;set;}
        public Location location { get;set;}
        public class Location
        {
            public int row{get;set; }
            public int col { get; set; }
        }
    }
    
}
