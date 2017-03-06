using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalcOfXaml
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();
        }

        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        void SelectNum(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.calcText.Text == "0" || currentState < 0)
            {
                this.calcText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.calcText.Text += pressed;

            double number;
            if (double.TryParse(this.calcText.Text, out number))
            {
                this.calcText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void SelectOp(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void SelectClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.calcText.Text = "0";
        }


        /// Operator input and output
        void SelectCalc(object sender, EventArgs e)
        {
            if (currentState == 2)
            {  
                double result = 0;
                switch (mathOperator)
                {
                    case "/":
                        result = firstNumber / secondNumber;
                        break;
                    case "X":
                        result = firstNumber * secondNumber;
                        break;
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    default:
                        break;
                }

                firstNumber = result;
                this.calcText.Text = result.ToString("N0");
                currentState = -1;
            }
        }

        //basic logic, done for completion's sake. 
        void OnButton1Clicked(object sender, EventArgs args)
        {
            Resources["Calctext"] = Resources["Calctext1"];
        }
        void OnButton2Clicked(object sender, EventArgs args)
        {
            Resources["Calctext"] = Resources["Calctext2"];
        }

        void OnResetButtonClicked(object sender, EventArgs args)
        {
            Resources["Calctext"] = null;
        }

        ///// Button Logic/Loop. Was going to use a single button to increment through the styles. 
        //private int num = 0;
        //void OnButtonClicked(object sender, EventArgs e)
        //{

        //    if (num < 2)
        //    {
        //        num++;

        //    }
        //    else
        //    {
        //        num = 0;
        //    }
        //    int
        //    Resources.[baseStyle]

        //}



    }
}
