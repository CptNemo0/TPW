namespace Pola
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NazwaFigury = new System.Windows.Forms.Label();
            this.ListaFigur = new System.Windows.Forms.ListBox();
            this.PrePole = new System.Windows.Forms.Label();
            this.Pole = new System.Windows.Forms.Label();
            this.policz_button = new System.Windows.Forms.Button();
            this.w1tb = new System.Windows.Forms.TextBox();
            this.w1 = new System.Windows.Forms.Label();
            this.w2 = new System.Windows.Forms.Label();
            this.w2tb = new System.Windows.Forms.TextBox();
            this.w3tb = new System.Windows.Forms.TextBox();
            this.w3 = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NazwaFigury
            // 
            this.NazwaFigury.AutoSize = true;
            this.NazwaFigury.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NazwaFigury.Location = new System.Drawing.Point(206, 36);
            this.NazwaFigury.Name = "NazwaFigury";
            this.NazwaFigury.Size = new System.Drawing.Size(105, 21);
            this.NazwaFigury.TabIndex = 1;
            this.NazwaFigury.Text = "Nazwa Figury\r\n";
            // 
            // ListaFigur
            // 
            this.ListaFigur.FormattingEnabled = true;
            this.ListaFigur.ItemHeight = 15;
            this.ListaFigur.Items.AddRange(new object[] {
            "Prostokąt",
            "Kwadrat",
            "Równoległobok",
            "Koło",
            "Trójkąt"});
            this.ListaFigur.Location = new System.Drawing.Point(38, 12);
            this.ListaFigur.Name = "ListaFigur";
            this.ListaFigur.Size = new System.Drawing.Size(99, 79);
            this.ListaFigur.TabIndex = 2;
            this.ListaFigur.SelectedIndexChanged += new System.EventHandler(this.ListaFigur_SelectedIndexChanged);
            // 
            // PrePole
            // 
            this.PrePole.AutoSize = true;
            this.PrePole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrePole.Location = new System.Drawing.Point(152, 310);
            this.PrePole.Name = "PrePole";
            this.PrePole.Size = new System.Drawing.Size(42, 21);
            this.PrePole.TabIndex = 3;
            this.PrePole.Text = "Pole:";
            // 
            // Pole
            // 
            this.Pole.AutoSize = true;
            this.Pole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Pole.Location = new System.Drawing.Point(197, 310);
            this.Pole.Name = "Pole";
            this.Pole.Size = new System.Drawing.Size(51, 21);
            this.Pole.TabIndex = 4;
            this.Pole.Text = "wynik";
            // 
            // policz_button
            // 
            this.policz_button.Location = new System.Drawing.Point(274, 162);
            this.policz_button.Name = "policz_button";
            this.policz_button.Size = new System.Drawing.Size(75, 61);
            this.policz_button.TabIndex = 5;
            this.policz_button.Text = "Oblicz Pole";
            this.policz_button.UseVisualStyleBackColor = true;
            this.policz_button.Click += new System.EventHandler(this.policz_button_Click);
            // 
            // w1tb
            // 
            this.w1tb.Location = new System.Drawing.Point(165, 149);
            this.w1tb.Name = "w1tb";
            this.w1tb.Size = new System.Drawing.Size(100, 23);
            this.w1tb.TabIndex = 6;
            this.w1tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.w1tb_KeyPress);
            // 
            // w1
            // 
            this.w1.AutoSize = true;
            this.w1.Location = new System.Drawing.Point(38, 152);
            this.w1.Name = "w1";
            this.w1.Size = new System.Drawing.Size(57, 15);
            this.w1.TabIndex = 7;
            this.w1.Text = "Wymiar 1";
            // 
            // w2
            // 
            this.w2.AutoSize = true;
            this.w2.Location = new System.Drawing.Point(38, 193);
            this.w2.Name = "w2";
            this.w2.Size = new System.Drawing.Size(57, 15);
            this.w2.TabIndex = 8;
            this.w2.Text = "Wymiar 2";
            // 
            // w2tb
            // 
            this.w2tb.Location = new System.Drawing.Point(165, 190);
            this.w2tb.Name = "w2tb";
            this.w2tb.Size = new System.Drawing.Size(100, 23);
            this.w2tb.TabIndex = 9;
            // 
            // w3tb
            // 
            this.w3tb.Location = new System.Drawing.Point(165, 235);
            this.w3tb.Name = "w3tb";
            this.w3tb.Size = new System.Drawing.Size(100, 23);
            this.w3tb.TabIndex = 10;
            // 
            // w3
            // 
            this.w3.AutoSize = true;
            this.w3.Location = new System.Drawing.Point(38, 238);
            this.w3.Name = "w3";
            this.w3.Size = new System.Drawing.Size(57, 15);
            this.w3.TabIndex = 11;
            this.w3.Text = "Wymiar 3";
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.error_label.Location = new System.Drawing.Point(113, 276);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(181, 21);
            this.error_label.TabIndex = 12;
            this.error_label.Text = "\"Wpisz poprawne dane!\"";
            this.error_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.w3);
            this.Controls.Add(this.w3tb);
            this.Controls.Add(this.w2tb);
            this.Controls.Add(this.w2);
            this.Controls.Add(this.w1);
            this.Controls.Add(this.w1tb);
            this.Controls.Add(this.policz_button);
            this.Controls.Add(this.Pole);
            this.Controls.Add(this.PrePole);
            this.Controls.Add(this.ListaFigur);
            this.Controls.Add(this.NazwaFigury);
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "Pola Figur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label NazwaFigury;
        private ListBox ListaFigur;
        private Label PrePole;
        private Label Pole;
        private Button policz_button;
        private TextBox w1tb;
        private Label w1;
        private Label w2;
        private TextBox w2tb;
        private TextBox w3tb;
        private Label w3;
        private Label error_label;
    }
}