using System;
using System.Windows;
using System.Media;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CalculatorQuest
{
    class CalculatorScreen : Window
    {
        [UI]
        private Label _label1 = null;
    
        [UI]
        private Button clearAll = null;

        [UI]
        private Button clearEntry = null;

        [UI]
        private Button del = null;

        [UI]
        private Button time = null;

        [UI]
        private Button devide = null;

        [UI]
        private Button mod = null;

        [UI]
        private Button sign = null;

        [UI]
        private Button less = null;

        [UI]
        private Button more = null;

        [UI]
        private Button nine = null;

        [UI]
        private Button eight = null;

        [UI]
        private Button seven = null;

        [UI]
        private Button six = null;

        [UI]
        private Button five = null;

        [UI]
        private Button four = null;

        [UI]
        private Button three = null;

        [UI]
        private Button two = null;

        [UI]
        private Button one = null;

        [UI]
        private Button zero = null;

        [UI]
        private Button point = null;

        [UI]
        private Button equal = null;

        [UI]
        private Button square = null;

        [UI]
        private Button sqrt = null;

        [UI]
        private Button inverse = null;

        private int _counter;
        private string[] _signs = { "+", "-", "*", "/", "%" };

        public CalculatorScreen() : this(new Builder("CalculatorScreen.glade")) {
        }

        private CalculatorScreen(Builder builder)
            : base(builder.GetRawOwnedObject("CalculatorScreen"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            clearAll.Clicked += clearAll_Clicked;
            clearEntry.Clicked += clearEntry_Clicked;
            del.Clicked += del_Clicked;
            time.Clicked += time_Clicked;
            devide.Clicked += devide_Clicked;
            mod.Clicked += mod_Clicked;
            sign.Clicked += sign_Clicked;
            less.Clicked += less_Clicked;
            more.Clicked += more_Clicked;
            nine.Clicked += nine_Clicked;
            eight.Clicked += eight_Clicked;
            seven.Clicked += seven_Clicked;
            six.Clicked += six_Clicked;
            five.Clicked += five_Clicked;
            four.Clicked += four_Clicked;
            three.Clicked += three_Clicked;
            two.Clicked += two_Clicked;
            one.Clicked += one_Clicked;
            zero.Clicked += zero_Clicked;
            point.Clicked += point_Clicked;
            equal.Clicked += equal_Clicked;
            square.Clicked += square_Clicked;
            sqrt.Clicked += sqrt_Clicked;
            inverse.Clicked += inverse_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void clearAll_Clicked(object sender, EventArgs a)
        {
            _label1.Text = "0";
        }

        private void clearEntry_Clicked(object sender, EventArgs a)
        {
            foreach (string sign in _signs)
            {
                if (_label1.Text[1.._label1.Text.Length].Contains(sign))
                {
                    _label1.Text = _label1.Text[0..(_label1.Text.LastIndexOf(sign) + 1)];
                    return;
                }
            }
            _label1.Text = "0";
        }

        private void del_Clicked(object sender, EventArgs a)
        {
            if (_label1.Text.Length > 1)
            {
                _label1.Text = _label1.Text.Remove(_label1.Text.Length - 1);
            }
            else
            {
                _label1.Text = "0";
            }
        }

        private void time_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "*";
        }

        private void devide_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "/";
        }

        private void mod_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "%";
        }

        private void sign_Clicked(object sender, EventArgs a)
        {
            if (_label1.Text[0] == '-')
            {
                _label1.Text = _label1.Text[1..];
            }
            else
            {
                _label1.Text = "-" + _label1.Text;
            }
        }

        private void less_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "-";
        }

        private void more_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "+";
        }

        private void nine_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "9";
        }

        private void eight_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "8";
        }

        private void seven_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "7";
        }

        private void six_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "6";
        }

        private void five_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "5";
        }

        private void four_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "4";
        }

        private void three_Clicked(object sender, EventArgs a)
        {
            _label1.Text += "3";
        }

        private void two_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text += "2";
        }

        private void one_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text += "1";
        }

        private void zero_Clicked(object sender, EventArgs a)
        {
            _counter++;
            _label1.Text += "0";
        }

        private void point_Clicked(object sender, EventArgs a)
        {
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer("C:\\Users\\emman\\Desktop\\Ynov-B2\\CalculatorQuest\\sound\\raoul.wav");  
            player1.Play();
            _counter++;
            _label1.Text += ",";
        }

        private void equal_Clicked(object sender, EventArgs a)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:\\Users\\emman\\Desktop\\Ynov-B2\\CalculatorQuest\\sound\\amogus.wav");  
            player.Play();
            _label1.Text = Operator(_label1.Text);
        }

        private bool flag;

        private string Operator(string operation)
        {
            foreach (string sign in _signs)
            {
                if (operation.Contains(sign))
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                return "Please enter a valid operation";
            }
            if (operation[operation.Length - 1] == '0' && operation[operation.Length - 2] == '/')
            {
                return "Division by 0 is IMPOSSIBLE";
            }
            else
            {
                return new System.Data.DataTable().Compute(operation, "").ToString();
            }
        }

        private void square_Clicked(object sender, EventArgs a)
        {
            _label1.Text = Math.Pow(double.Parse(_label1.Text), 2).ToString();
        }

        private void sqrt_Clicked(object sender, EventArgs a)
        {
            _label1.Text = Math.Sqrt(double.Parse(_label1.Text)).ToString();
        }

        private void inverse_Clicked(object sender, EventArgs a)
        {
            _label1.Text = (1 / double.Parse(_label1.Text)).ToString();
        }
    }
}