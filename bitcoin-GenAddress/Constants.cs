namespace bitcoin_GenAddress
{
    public static class Constants
    {
        // Field
        public static string Name = $"Bitcoin";
        public static string Description = $"Address generator";
        public static string Version = "1.0.0";
        public static string Title = $"{Name} - {Description} -{Version}";
        public static string Author = $"Afaa";
        public static string Publisher = $"MultiVerse";
        public static string Subtitle = $"Bitcoin Crypto ToolKit";
        public static string GitHub = "https://github.com/AfaaNet";

        // Path
        public static readonly string File = "address.txt";
        public static readonly string Result = "result.txt";

        // Address
        public static readonly string[] Languages = { "English", "Japanese", "Spanish", "ChineseSimplified", "ChineseTraditional", "French", "PortugueseBrazil" };
        public static readonly string[] WordCounts = { "Twelve", "Fifteen", "Eighteen", "TwentyOne", "TwentyFour" };
        public static readonly string[] AddressTypes = { "Legacy", "SegWit", "Bech32" };
    }
}
