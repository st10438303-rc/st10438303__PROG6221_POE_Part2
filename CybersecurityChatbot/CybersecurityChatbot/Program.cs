using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CybersecurityChatbot
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            var app = new System.Windows.Application();
            var mainWindow = new CybersecurityChatbotWPF.MainWindow();
            app.Run(mainWindow);
        }
    }
}
