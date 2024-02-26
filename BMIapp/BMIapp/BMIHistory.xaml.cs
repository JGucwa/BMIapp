using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMIHistory : ContentPage
    {
        public BMIHistory()
        {
            InitializeComponent();
         
            Historylst.ItemsSource = App.database.GetAll();
        }
    }
}