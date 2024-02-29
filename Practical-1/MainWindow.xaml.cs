using System;
using System.Windows;
using System.Windows.Controls;

namespace Practical_1
{
    public partial class MainWindow : Window
    {
        private string currentOperator = "";
        private double result = 0;
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

    private void Number_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            if (isNewNumber)
            {
                Display.Text = "";
                isNewNumber = false;
            }

            Display.Text += button.Content.ToString();
        }
    }

    private void Operator_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            currentOperator = button.Content.ToString();
            result = double.Parse(Display.Text);
            isNewNumber = true;
        }
    }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            currentOperator = "";
            result = 0;
            isNewNumber = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondOperand = double.Parse(Display.Text);
            switch (currentOperator)
            {
                case "+":
                    result += secondOperand;
                    break;
                case "-":
                    result -= secondOperand;
                    break;
                case "*":
                    result *= secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                        result /= secondOperand;
                    else
                        MessageBox.Show("Cannot divide by zero!");
                    break;
            }
            Display.Text = result.ToString();
            isNewNumber = true;
        }
    }
}
