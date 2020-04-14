using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace AppSinc
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();
            string url = String.Empty;

            if (ativos.IsChecked.Value)
                url = $"https://jsonplaceholder.typicode.com/todos/?completed=true";
            else
                url = $"https://jsonplaceholder.typicode.com/todos";

            var content = client.DownloadString(url);

            var data = JsonConvert.DeserializeObject<IEnumerable<Todos>>(content);

            UsuarioGrid.ItemsSource = data;

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await RecuperarDados();
        }

        public async Task RecuperarDados()
        {
            var client = new HttpClient();
            string url = String.Empty;

            if (ativos.IsChecked.Value)
                url = $"https://jsonplaceholder.typicode.com/todos/?completed=true";
            else
                url = $"https://jsonplaceholder.typicode.com/todos";

            var result = await client.GetAsync(url);

            var content = await result.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IEnumerable<Todos>>(content);

            UsuarioGrid.ItemsSource = data;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UsuarioGrid.ItemsSource = null;
        }
    }
}
