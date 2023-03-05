namespace Pola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            w1tb.Enabled = false;
            w2tb.Enabled = false;
            w3tb.Enabled = false;
        }

        private void ListaFigur_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ListaFigur.SelectedIndex)
            {
                case 0:
                    NazwaFigury.Text = "Prostok¹t";
                    w1.Enabled = true;
                    w2.Enabled = true;
                    w3.Enabled = false;
                    w1tb.Enabled = true;
                    w2tb.Enabled = true;
                    w3tb.Enabled = false;
                    w1.Text = "D³ugoœæ boku a";
                    w2.Text = "D³ugoœæ boku b";
                    w3.Text = "Wy³¹czony";
                    w1tb.Text = "";
                    w2tb.Text = "";
                    w3tb.Text = "";
                    error_label.Visible = false;
                    break;
                case 1:
                    NazwaFigury.Text = "Kwadrat";
                    w1.Enabled = true;
                    w2.Enabled = false;
                    w3.Enabled = false;
                    w1tb.Enabled = true;
                    w2tb.Enabled = false;
                    w3tb.Enabled = false;
                    w1.Text = "D³ugoœæ przekatnej d";
                    w2.Text = "Wy³¹czony";
                    w3.Text = "Wy³¹czony";
                    w1tb.Text = "";
                    w2tb.Text = "";
                    w3tb.Text = "";
                    error_label.Visible = false;
                    break;
                case 2:
                    NazwaFigury.Text = "Równoleg³obok";
                    w1.Enabled = true;
                    w2.Enabled = true;
                    w3.Enabled = false;
                    w1tb.Enabled = true;
                    w2tb.Enabled = true;
                    w3tb.Enabled = false;
                    w1.Text = "D³ugoœæ boku a";
                    w2.Text = "D³ugoœæ wysokoœci h";
                    w3.Text = "Wy³¹czony";
                    w1tb.Text = "";
                    w2tb.Text = "";
                    w3tb.Text = "";
                    error_label.Visible = false;
                    break;
                case 3:
                    NazwaFigury.Text = "Ko³o";
                    w1.Enabled = true;
                    w2.Enabled = false;
                    w3.Enabled = false;
                    w1tb.Enabled = true;
                    w2tb.Enabled = false;
                    w3tb.Enabled = false;
                    w1.Text = "D³ugoœæ promienia";
                    w2.Text = "Wy³¹czony";
                    w3.Text = "Wy³¹czony";
                    w1tb.Text = "";
                    w2tb.Text = "";
                    w3tb.Text = "";
                    error_label.Visible = false;
                    break;
                case 4:
                    NazwaFigury.Text = "Trójk¹t";
                    w1.Enabled = true;
                    w2.Enabled = true;
                    w3.Enabled = true;
                    w1tb.Enabled = true;
                    w2tb.Enabled = true;
                    w3tb.Enabled = true;
                    w1.Text = "D³ugoœæ boku a";
                    w2.Text = "D³ugoœæ boku b";
                    w3.Text = "D³ugoœæ boku c";
                    w1tb.Text = "";
                    w2tb.Text = "";
                    w3tb.Text = "";
                    error_label.Visible = false;
                    break;
            }
        }

        private void policz_button_Click(object sender, EventArgs e)
        {
            error_label.Visible = false;
            Figura figura = new Figura();
            switch (ListaFigur.SelectedIndex)
            {
                case 0:
                    try
                    {
                        Pole.Text = figura.prostokat(Convert.ToDouble(w1tb.Text), Convert.ToDouble(w2tb.Text)).ToString("0.0000");
                    }
                    catch
                    {
                        error_label.Visible = true;
                    }
                    break;
                case 1:
                    try
                    {
                        Pole.Text = figura.kwadrat(Convert.ToDouble(w1tb.Text)).ToString("0.0000");
                    }
                    catch
                    {
                        error_label.Visible = true;
                    }
                    break;
                case 2:
                    try
                    {
                        Pole.Text = figura.prostokat(Convert.ToDouble(w1tb.Text), Convert.ToDouble(w2tb.Text)).ToString("0.0000");
                    }
                    catch
                    {
                        error_label.Visible = true;
                    }
                    break;
                case 3:
                    try
                    {
                        Pole.Text = figura.kolo(Convert.ToDouble(w1tb.Text)).ToString("0.0000");
                    }
                    catch
                    {
                        error_label.Visible = true;
                    }
                    break;
                case 4:
                    try
                    {
                        Pole.Text = figura.trojkat(Convert.ToDouble(w1tb.Text), Convert.ToDouble(w2tb.Text), Convert.ToDouble(w3tb.Text)).ToString("0.0000");
                    }
                    catch
                    {
                        error_label.Visible = true;
                        error_label.Enabled = true;
                    }
                    break;
            }
        }

        private void w1tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control character (e.g. Backspace, Delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // If not, set the Handled property of the KeyPressEventArgs to true to prevent the character from being entered.
                e.Handled = true;
            }
        }
    }
}