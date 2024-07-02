using NBitcoin;
using System.Configuration;

namespace bitcoin_GenAddress
{
    public partial class FormMain : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private int _count;
        private int _loadedAddressesCount;
        private int _mnemonicFoundCount;
        private System.Windows.Forms.Timer _reloadTimer;

        public FormMain()
        {
            InitializeComponent();
            InitializeForm();
            
            this.FormClosing += FormMain_FormClosing;
        }

        private void InitializeForm()
        {
            Text = Constants.Title;
            LoadAddresses();
            InitializeComboBoxes();
            LoadConfig();
            InitializeReloadTimer();
        }

        private void InitializeComboBoxes()
        {
            cmbWordCount.Items.AddRange(Constants.WordCounts);
            cmbLanguage.Items.AddRange(Constants.Languages);

            int processorCount = Environment.ProcessorCount;
            for (int i = 1; i <= processorCount; i++)
            {
                cmbProcessorCount.Items.Add(i.ToString());
            }
            cmbProcessorCount.SelectedIndex = 0; // Default to 1 processor
        }

        private void LoadConfig()
        {
            string wordCount = ConfigurationManager.AppSettings["WordCount"] ?? Constants.WordCounts[0];
            string language = ConfigurationManager.AppSettings["Language"] ?? Constants.Languages[0];
            string processorCount = ConfigurationManager.AppSettings["ProcessorCount"] ?? "1";
            cmbWordCount.SelectedItem = wordCount;
            cmbLanguage.SelectedItem = language;
            cmbProcessorCount.SelectedItem = processorCount;

            string reloadInterval = ConfigurationManager.AppSettings["ReloadInterval"] ?? "60000";
            txtReloadInterval.Text = reloadInterval;
        }

        private void SaveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["WordCount"] == null)
            {
                config.AppSettings.Settings.Add("WordCount", cmbWordCount.SelectedItem.ToString());
            }
            else
            {
                config.AppSettings.Settings["WordCount"].Value = cmbWordCount.SelectedItem.ToString();
            }

            if (config.AppSettings.Settings["Language"] == null)
            {
                config.AppSettings.Settings.Add("Language", cmbLanguage.SelectedItem.ToString());
            }
            else
            {
                config.AppSettings.Settings["Language"].Value = cmbLanguage.SelectedItem.ToString();
            }

            if (config.AppSettings.Settings["ProcessorCount"] == null)
            {
                config.AppSettings.Settings.Add("ProcessorCount", cmbProcessorCount.SelectedItem.ToString());
            }
            else
            {
                config.AppSettings.Settings["ProcessorCount"].Value = cmbProcessorCount.SelectedItem.ToString();
            }

            if (config.AppSettings.Settings["ReloadInterval"] == null)
            {
                config.AppSettings.Settings.Add("ReloadInterval", txtReloadInterval.Text);
            }
            else
            {
                config.AppSettings.Settings["ReloadInterval"].Value = txtReloadInterval.Text;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void LoadAddresses()
        {
            string filePath = Constants.File;
            if (File.Exists(filePath))
            {
                var addresses = File.ReadAllLines(filePath);
                _loadedAddressesCount = addresses.Length;
                lblLoadedAddresses.Text = $"Loaded Addresses: {_loadedAddressesCount}";
            }
            else
            {
                lblLoadedAddresses.Text = "Loaded Addresses: 0";
            }
        }

        private void InitializeReloadTimer()
        {
            _reloadTimer = new System.Windows.Forms.Timer
            {
                Interval = int.Parse(txtReloadInterval.Text)
            };
            _reloadTimer.Tick += (s, e) => LoadAddresses();
            _reloadTimer.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null) return;

            if (!ValidateSelections())
            {
                MessageBox.Show("Invalid language or word count selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetControlsEnabled(false);
            _cancellationTokenSource = new CancellationTokenSource();
            int processorCount = int.Parse(cmbProcessorCount.SelectedItem.ToString());
            Task[] tasks = new Task[processorCount];

            for (int i = 0; i < processorCount; i++)
            {
                tasks[i] = Task.Run(() => GenerateBitcoinAddresses(_cancellationTokenSource.Token));
            }

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                SetControlsEnabled(true);
                _cancellationTokenSource = null;
            }, TaskScheduler.FromCurrentSynchronizationContext())
            .ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    MessageBox.Show($"Error: {t.Exception.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            btnStop.Text = "Stopping...";
        }

        private bool ValidateSelections()
        {
            string selectedLanguage = cmbLanguage.SelectedItem?.ToString();
            string selectedWordCount = cmbWordCount.SelectedItem?.ToString();

            if (Constants.Languages.Contains(selectedLanguage) && Constants.WordCounts.Contains(selectedWordCount))
            {
                return true;
            }
            return false;
        }

        private async Task GenerateBitcoinAddresses(CancellationToken cancellationToken)
        {
            string filePath = Constants.File;
            string wordCountString = cmbWordCount.InvokeRequired
                ? (string)cmbWordCount.Invoke(new Func<string>(() => cmbWordCount.SelectedItem?.ToString()))
                : cmbWordCount.SelectedItem?.ToString();
            string languageString = cmbLanguage.InvokeRequired
                ? (string)cmbLanguage.Invoke(new Func<string>(() => cmbLanguage.SelectedItem?.ToString()))
                : cmbLanguage.SelectedItem?.ToString();

            if (!int.TryParse(wordCountString, out int wordCount))
            {
                wordCount = 12;
            }

            Wordlist language = Wordlist.English;

            if (!string.IsNullOrEmpty(languageString))
            {
                var property = typeof(Wordlist).GetProperty(languageString);
                if (property != null)
                {
                    language = (Wordlist)property.GetValue(null, null);
                }
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var key = new Key();
                    var bitcoinAddress = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, NBitcoin.Network.Main).ToString();

                    if (File.Exists(filePath))
                    {
                        var addresses = await File.ReadAllLinesAsync(filePath, cancellationToken);
                        if (Array.Exists(addresses, address => address == bitcoinAddress))
                        {
                            var mnemonic = new Mnemonic(language, (WordCount)wordCount);
                            var privateKey = key.GetWif(NBitcoin.Network.Main).ToString();
                            var publicKey = key.PubKey.ToString();

                            var result = $"{bitcoinAddress}\nMnemonic: {mnemonic}\nPrivate Key: {privateKey}\nPublic Key: {publicKey}\n";
                            await File.AppendAllTextAsync(Constants.Result, result, cancellationToken);

                            _mnemonicFoundCount++;
                            UpdateMnemonicFoundLabel();
                        }
                    }

                    _count++;
                    UpdateCountLabel();
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCountLabel()
        {
            if (lblCount.InvokeRequired)
            {
                lblCount.Invoke(new Action(UpdateCountLabel));
            }
            else
            {
                lblCount.Text = $"Count: {_count}";
            }
        }

        private void UpdateMnemonicFoundLabel()
        {
            if (LbFound.InvokeRequired)
            {
                LbFound.Invoke(new Action(UpdateMnemonicFoundLabel));
            }
            else
            {
                LbFound.Text = $"Mnemonics Found: {_mnemonicFoundCount}";
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetControlsEnabled), enabled);
            }
            else
            {
                cmbWordCount.Enabled = enabled;
                cmbLanguage.Enabled = enabled;
                cmbProcessorCount.Enabled = enabled;
                btnStart.Enabled = enabled;
                txtReloadInterval.Enabled = enabled;
                btnStop.Enabled = !enabled;

                if (enabled)
                {
                    btnStop.Text = "Stop";
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            _cancellationTokenSource?.Cancel(); // Cancel any running tasks on form close
        }
    }
}
