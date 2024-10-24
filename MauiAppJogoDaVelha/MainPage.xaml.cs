namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        int jogadas = 0; // Contador de jogadas

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;

            if (vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            }
            else
            {
                btn.Text = "O";
                vez = "X";
            }

            jogadas++; 

            // Verificando se X ganhou
            if (VerificarVitoria("X"))
            {
                DisplayAlert("Parabéns!", "O -X- ganhou!", "OK");
                Zerar();
                return;
            }

            // Verificando se O ganhou
            if (VerificarVitoria("O"))
            {
                DisplayAlert("Parabéns!", "O -O- ganhou!", "OK");
                Zerar();
                return;
            }

            // Verificando se deu velha (empate)
            if (jogadas == 9) // Só checa empate quando todos os 9 botões foram clicados
            {
                DisplayAlert("Ih, deu velha!", "Ninguém ganhou!", "OK");
                Zerar();
            }
        }

        bool VerificarVitoria(string jogador)
        {
            return
                (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) || // linha 1
                (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) || // linha 2
                (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) || // linha 3
                (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) || // coluna 1
                (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) || // coluna 2
                (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) || // coluna 3
                (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) || // diagonal 1
                (btn30.Text == jogador && btn21.Text == jogador && btn12.Text == jogador);   // diagonal 2
        }

        void Zerar()
        {
            btn10.Text = "";
            btn11.Text = "";
            btn12.Text = "";
            btn20.Text = "";
            btn21.Text = "";
            btn22.Text = "";
            btn30.Text = "";
            btn31.Text = "";
            btn32.Text = "";

            btn10.IsEnabled = true;
            btn11.IsEnabled = true;
            btn12.IsEnabled = true;
            btn20.IsEnabled = true;
            btn21.IsEnabled = true;
            btn22.IsEnabled = true;
            btn30.IsEnabled = true;
            btn31.IsEnabled = true;
            btn32.IsEnabled = true;

            jogadas = 0; // Reinicia o contador de jogadas
            vez = "X"; // Reinicia a vez
        }
    }
}
