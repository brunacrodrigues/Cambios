
using Cambios.Modelos;
using Cambios.Servicos;

namespace Cambios
{
    public partial class Form1 : Form
    {
        #region Atributos

        NetworkService _networkService;
        ApiService _apiService;
        List<Rate> Rates;
        DialogService _dialogService;
        DataService _dataService;

        #endregion

        public Form1()
        {
            InitializeComponent();
            _networkService = new NetworkService();
            _apiService = new ApiService();
            _dialogService = new DialogService();
            _dataService = new DataService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load;

            LabelResultado.Text = "A atualizar taxas...";

            var connection = await _networkService.CheckConnection();

            if (!connection.IsSuccess)
            {
                LoadLocalRates();
                load = false;
            }
            else
            {
                await LoadApiRates();
                load = true;
            }

            if (Rates.Count == 0)
            {
                LabelResultado.Text = "Não há ligação à internet" + Environment.NewLine +
                    "e não foram previamente carregadas as taxas." + Environment.NewLine +
                    "Tente mais tarde!";

                LabelStatus.Text = "Primeira inicialização deverá ter ligação à internet.";

                return;
            }

            ComboBoxOrigem.DataSource = Rates;
            ComboBoxOrigem.DisplayMember = "Name";

            ComboBoxDestino.BindingContext = new BindingContext(); // Classe que liga os objetos ao código

            ComboBoxDestino.DataSource = Rates;
            ComboBoxDestino.DisplayMember = "Name";



            LabelResultado.Text = "Taxas atualizadas...";

            if (load)
            {
                LabelStatus.Text = string.Format("Taxas carregadas da internet em {0:F}", DateTime.Now);
            }
            else
            {
                LabelStatus.Text = string.Format("Taxas carregadas da Base de Dados.");
            }

            progressBar1.Value = 100;

            ButtonConverter.Enabled = true;
            ButtonTroca.Enabled = true;
        }

        private void LoadLocalRates()
        {
            Rates = _dataService.GetData();
        }

        private async Task LoadApiRates()
        {
            progressBar1.Value = 0;

            var response = await _apiService.GetRates("http://rates.somee.com", "/api/rates");

            Rates = (List<Rate>)response.Result;

            _dataService.DeleteData();

            _dataService.SaveData(Rates);
        }

        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            if (string.IsNullOrEmpty(TextBoxValor.Text))
            {
                _dialogService.ShowMessage("Erro", "Insira um valor a converter");
                return;
            }

            decimal valor;

            if (!decimal.TryParse(TextBoxValor.Text, out valor))
            {
                _dialogService.ShowMessage("Erro de conversão", "Valor terá que ser numérico");
                return;
            }

            if (ComboBoxOrigem.SelectedItem == null)
            {
                _dialogService.ShowMessage("Erro", "Tem que escolher uma moeda para converter.");
                return;
            }

            if (ComboBoxDestino.SelectedItem == null)
            {
                _dialogService.ShowMessage("Erro", "Tem que escolher uma moeda para converter.");
                return;
            }

            var taxaOrigem = (Rate)ComboBoxOrigem.SelectedItem;
            var taxaDestino = (Rate)ComboBoxDestino.SelectedItem;

            var valorConvertido = valor / (decimal)taxaOrigem.TaxRate * (decimal)taxaDestino.TaxRate;

            LabelResultado.Text = string.Format("{0} {1:C2} = {2} {3:C2}",
                taxaOrigem.Code,
                valor,
                taxaDestino.Code,
                valorConvertido);
        }

        private void ButtonTroca_Click(object sender, EventArgs e)
        {
            Trocar();
        }

        private void Trocar()
        {
            var aux = ComboBoxOrigem.SelectedItem;
            ComboBoxOrigem.SelectedItem = ComboBoxDestino.SelectedItem;
            ComboBoxDestino.SelectedItem = aux;
            Converter();
        }
    }
}
