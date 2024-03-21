namespace AppTickets
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
            Lb_Titulo = new Label();
            Txt_Pedido = new TextBox();
            label1 = new Label();
            Btn_Imprimir = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            printPreviewControl1 = new PrintPreviewControl();
            Btn_VistaPrevia = new Button();
            Lb_articulos = new Label();
            SuspendLayout();
            // 
            // Lb_Titulo
            // 
            Lb_Titulo.Anchor = AnchorStyles.Top;
            Lb_Titulo.AutoSize = true;
            Lb_Titulo.FlatStyle = FlatStyle.Flat;
            Lb_Titulo.Font = new Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Lb_Titulo.ForeColor = Color.FromArgb(64, 0, 64);
            Lb_Titulo.Location = new Point(126, -1);
            Lb_Titulo.Name = "Lb_Titulo";
            Lb_Titulo.Size = new Size(293, 32);
            Lb_Titulo.TabIndex = 0;
            Lb_Titulo.Text = "Impresora de Tickets";
            Lb_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Txt_Pedido
            // 
            Txt_Pedido.Anchor = AnchorStyles.Top;
            Txt_Pedido.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Txt_Pedido.Location = new Point(173, 45);
            Txt_Pedido.Name = "Txt_Pedido";
            Txt_Pedido.Size = new Size(132, 29);
            Txt_Pedido.TabIndex = 1;
            Txt_Pedido.KeyDown += Txt_Pedido_KeyDown;
            Txt_Pedido.KeyPress += Txt_Pedido_KeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(69, 48);
            label1.Name = "label1";
            label1.Size = new Size(82, 22);
            label1.TabIndex = 2;
            label1.Text = "Pedido:";
            // 
            // Btn_Imprimir
            // 
            Btn_Imprimir.Anchor = AnchorStyles.Top;
            Btn_Imprimir.BackColor = Color.DarkSlateBlue;
            Btn_Imprimir.Cursor = Cursors.Hand;
            Btn_Imprimir.FlatStyle = FlatStyle.Flat;
            Btn_Imprimir.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Btn_Imprimir.ForeColor = SystemColors.Control;
            Btn_Imprimir.Location = new Point(330, 43);
            Btn_Imprimir.Name = "Btn_Imprimir";
            Btn_Imprimir.Size = new Size(107, 35);
            Btn_Imprimir.TabIndex = 3;
            Btn_Imprimir.Text = "Imprimir";
            Btn_Imprimir.UseVisualStyleBackColor = false;
            Btn_Imprimir.Click += BtnImprimir_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Anchor = AnchorStyles.Top;
            printPreviewControl1.AutoZoom = false;
            printPreviewControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            printPreviewControl1.Location = new Point(69, 146);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(368, 440);
            printPreviewControl1.TabIndex = 4;
            printPreviewControl1.Zoom = 0.9D;
            // 
            // Btn_VistaPrevia
            // 
            Btn_VistaPrevia.Anchor = AnchorStyles.Top;
            Btn_VistaPrevia.BackColor = Color.DarkSlateBlue;
            Btn_VistaPrevia.Cursor = Cursors.Hand;
            Btn_VistaPrevia.FlatStyle = FlatStyle.Flat;
            Btn_VistaPrevia.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_VistaPrevia.ForeColor = SystemColors.Control;
            Btn_VistaPrevia.Location = new Point(330, 105);
            Btn_VistaPrevia.Name = "Btn_VistaPrevia";
            Btn_VistaPrevia.Size = new Size(107, 35);
            Btn_VistaPrevia.TabIndex = 5;
            Btn_VistaPrevia.Text = "Vista Previa";
            Btn_VistaPrevia.UseVisualStyleBackColor = false;
            Btn_VistaPrevia.Click += Btn_VistaPrevia_Click;
            // 
            // Lb_articulos
            // 
            Lb_articulos.Anchor = AnchorStyles.Top;
            Lb_articulos.AutoSize = true;
            Lb_articulos.FlatStyle = FlatStyle.Flat;
            Lb_articulos.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Lb_articulos.Location = new Point(69, 116);
            Lb_articulos.Name = "Lb_articulos";
            Lb_articulos.Size = new Size(0, 19);
            Lb_articulos.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(579, 599);
            Controls.Add(Lb_articulos);
            Controls.Add(Btn_VistaPrevia);
            Controls.Add(printPreviewControl1);
            Controls.Add(Btn_Imprimir);
            Controls.Add(label1);
            Controls.Add(Txt_Pedido);
            Controls.Add(Lb_Titulo);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Developed by Atzin Not Found";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lb_Titulo;
        private TextBox Txt_Pedido;
        private Label label1;
        private Button Btn_Imprimir;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private PrintPreviewControl printPreviewControl1;
        private Button Btn_VistaPrevia;
        private Label Lb_articulos;
    }
}