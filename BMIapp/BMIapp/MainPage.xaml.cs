using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace BMIapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        float currentResult = 0;
        void CalculateBMI(object sender, EventArgs e)
        {
            float result = float.Parse(weight.Text) / (float.Parse(height.Text)/100 * float.Parse(height.Text)/100) ;

            Result.Text = result.ToString("F2") + " BMI";
            if(result <= 18.5f)
            {
                Result.Text += "\n Masz niedowage";
            }
            else
            {
                if (result <= 24.9f)
                {
                    Result.Text += "\n Masz prawidłową wagę";
                }
                else
                {
                    if (result <= 29.9f)
                    {
                        Result.Text += "\n Masz nadwagę";
                    }
                    else
                    {
                        if (result <= 34.9f)
                        {
                            Result.Text += "\n Masz poważną niedowage";
                        }
                        else
                        {
                            Result.Text += "\n Masz otyłość";
                        }
                    }
                }     
            }
            currentResult = result;
        }
        void SaveRecord(object s, EventArgs e)
        {
            bool isMan = true;

            if (gender.IsChecked) isMan = false;
            App.database.Add(new BMIResult() { Date = DateTime.Now, Weight = float.Parse(weight.Text), Height = float.Parse(height.Text), BMI = currentResult, Gender = isMan });
        }
    }
}
