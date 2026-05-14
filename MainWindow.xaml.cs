using System.Windows;

namespace LacoFor;

public partial class MainWindow : Window
{
    public decimal saldoInicial = 1600.00M;
    
    public MainWindow()
    {
        InitializeComponent();
        tbSaldo.Text = $"R$ {saldoInicial}";
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        var quantidadeTexto = tbQuantidade.Text;
        int quantidadeSorteios;

        try
        {
            quantidadeSorteios = Convert.ToInt32(quantidadeTexto);
        }
        catch (FormatException)
        {
            MessageBox.Show("Entrada inválida: Coloque apenas números de 1 para cima!");
            return;
        }
        catch (OverflowException)
        {
            MessageBox.Show("Erro! O número digitado é maior que o número suportado!");
            return;
        }
        
        btnSorteio.IsEnabled = false;

        if (quantidadeSorteios < 1)
        {
            quantidadeSorteios = 1;
        }

        var sorteador = new Random();
        
        for (int contador = 0; contador < quantidadeSorteios; contador++)
        {
            if (saldoInicial >= 10)
            {
                tbResultado.Text = sorteador.Next(0, 40000001).ToString();
                saldoInicial -= 10M;
                tbSaldo.Text = $"R$ {saldoInicial}";
                await Task.Delay(1000);
            }
            else
            {
                MessageBox.Show("Você não tem saldo suficiente para realizar o sorteio!");
                break;
            }
        }

        btnSorteio.IsEnabled = true;
    }
}