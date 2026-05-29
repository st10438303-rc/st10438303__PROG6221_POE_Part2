// Arquivo original: ConsoleUI.cs (Parte 1)
// NOVO ARQUIVO: Helpers/ConsoleUIHelper.cs

using System;
using System.Threading;

namespace CybersecurityChatbotWPF.Helpers
{
    // CLASSE ORIGINAL DA PARTE 1 (mantida intacta)
    public static class ConsoleUI
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝ ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝█████╗  ███████╗ ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══╝  ╚════██║ ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████╗███████║ ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ║
    ║                    CYBERSECURITY AWARENESS                    ║
    ╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("════════════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

        public static void TypeText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(18);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void ShowBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n[Bot]: ");
            Console.ResetColor();
            TypeText(message, ConsoleColor.White);
        }

        public static void ShowUserPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n[You]: ");
            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[!] {message}");
            Console.ResetColor();
        }

        // Método adicional para GUI (retorna string do logo)
        public static string GetLogoAsString()
        {
            return @"
    ╔══════════════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝ ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝█████╗  ███████╗ ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══╝  ╚════██║ ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████╗███████║ ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ║
    ║                    CYBERSECURITY AWARENESS                    ║
    ╚══════════════════════════════════════════════════════════════╝";
        }
    }
}