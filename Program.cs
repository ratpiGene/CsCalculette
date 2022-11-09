using System;
using Gtk;

namespace CalculatorQuest
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("org.CalculatorQuest.CalculatorQuest", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = new CalculatorScreen();
            app.AddWindow(win);

            win.Show();
            Application.Run();
        }
    }
}
