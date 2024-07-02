# Bitcoin Address Generator

Bitcoin Address Generator is a tool designed to generate Bitcoin addresses using various parameters. It supports different languages and address types, and it is capable of generating addresses using multiple processors.

## Features
- Generate Bitcoin addresses in different languages
- Support for multiple address types: Legacy, SegWit, Bech32
- Configurable word counts for mnemonic phrases
- Multi-threaded processing

## Required Framework and Libraries
For the Bitcoin Address Generator application, you need to install the following frameworks and libraries:
- .NET Framework 8.0: This can be installed via the Visual Studio installer or through the .NET Framework Developer Pack.

## NuGetPackages
- NBitcoin: A .NET library for Bitcoin. It includes tools for generating addresses, creating transactions, and more.
- Newtonsoft.Json: A popular high-performance JSON framework for .NET, used for parsing and handling JSON data.

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/AfaaNet/bitcoin_GenAddress.git

2. Open the solution file bitcoin_GenAddress.sln in Visual Studio.

3. Restore the NuGet packages.

## Usage
1. Configure the application by modifying the app.config file:

- WordCount: The number of words in the mnemonic (default: Twelve).
- Language: The language for the mnemonic (default: English).
- ProcessorCount: The number of processors to use (default: 1).
- ReloadInterval: The interval to reload addresses in milliseconds (default: 60000).

2. Load bitcoin address into address.txt

3. Run the application:

- Press the Start button to begin generating addresses.
- Press the Stop button to halt the generation process.

4. Generated addresses and mnemonics will be saved in the result.txt file.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.

## Author 
- Afaa

## Contact
For any inquiries, please contact the author at the GitHub repository: AfaaNet


