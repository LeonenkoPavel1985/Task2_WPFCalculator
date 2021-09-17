using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double Value = 0; 
        String Operand; 
        Boolean OperandPressed;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Value = 0;
            Display.Content = "0";
            Equation.Content = "";
        }
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Display.Content = "0";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender; 
            if ((Display.Content.ToString() == "0") || (OperandPressed))
            {
                Display.Content = " ";
            }
            if (B.Content.ToString() == ".")
            {
                if (!Display.Content.ToString().Contains("."))
                {
                    Display.Content = Display.Content.ToString() + B.Content.ToString(); 
                }
            }
            else
            {
                Display.Content = Display.Content.ToString() + B.Content.ToString(); 
            }

            OperandPressed = false;
        }
        private void Button_Operand(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender; 
            if (Value != 0)
            {
                Button_Equals(this, null); 
                Operand = B.Content.ToString(); 
                OperandPressed = true;
                Equation.Content = Value + " " + Operand; 
            }
            else
            {
                Operand = B.Content.ToString();
                Value = Double.Parse(Display.Content.ToString()); 
                OperandPressed = true;
                Equation.Content = Value + " " + Operand;
            }
        }
        private void Button_Equals(object sender, RoutedEventArgs e)
        {
            Equation.Content = " ";
            switch (Operand)
            {
                case "+":
                    Display.Content = Value + Double.Parse(Display.Content.ToString());
                    break;
                case "-":
                    Display.Content = Value - Double.Parse(Display.Content.ToString());
                    break;
                case "×":
                    Display.Content = Value * Double.Parse(Display.Content.ToString());
                    break;
                case "÷":
                    Display.Content = Value / Double.Parse(Display.Content.ToString());
                    break;
                default:
                    break;
            }
            Value = Double.Parse(Display.Content.ToString()); 
            Operand = " "; 
        }
        private void Window_KeyDownPreview(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    Zero.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad1:
                    One.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad2:
                    Two.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad3:
                    Three.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad4:
                    Four.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad5:
                    Five.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad6:
                    Six.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad7:
                    Seven.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad8:
                    Eight.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.NumPad9:
                    Nine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Add:
                    Plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Subtract:
                    Minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Multiply:
                    Multiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Divide:
                    Divide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Enter:
                    Equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
            }
        }
    }
}