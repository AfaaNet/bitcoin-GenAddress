using System.Configuration;

namespace bitcoin_GenAddress
{
    internal static class Program
    {

        // Field
        public static string Name = $"Bitcoin";
        public static string Version = "1.0.0";
        public static string Title = $"{Name} - {Version}";
        public static string Description = $"Bruteforce Seed Generator";
        public static string Author = $"Afaa";
        public static string Publisher = $"MultiVerse";
        public static string Subtitle = $"Bitcoin Crypto ToolKit";
        public static string GitHub = "https://github.com/AfaaNet";

        // Path
        public static readonly string File = "address.txt";
        public static readonly string Result =  "result.txt";

        // Address
        public static readonly string[] Languages = ["English", "Japanese", "Spanish", "ChineseSimplified", "ChineseTraditional", "French", "PortugueseBrazil"];
        public static readonly string[] WordCounts = ["Twelve", "Fifteen", "Eighteen", "TwentyOne", "TwentyFour"];
        public static readonly string[] AddressTypes = ["Legacy", "SegWit", "Bech32"];

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string language = ConfigurationManager.AppSettings["Language"] ?? "English";

            Application.Run(new FormMain());
        }
    }
}