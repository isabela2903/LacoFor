using System.Windows;

namespace LacoFor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        var quantidadeTexto = tbQuantidade.Text;
        var quantidadeSorteios = Convert.ToInt32(quantidadeTexto);

        if (quantidadeSorteios < 1)
        {
            quantidadeSorteios = 1;
        }

        var sorteador = new Random();
        
        for (int contador = 0; contador < quantidadeSorteios; contador++)
        {
            tbResultado.Text = sorteador.Next(0, 40000001).ToString();
            await Task.Delay(1000);
        }
    }
}