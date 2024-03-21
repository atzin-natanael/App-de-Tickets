using FirebirdSql.Data.FirebirdClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppTickets
{
    public partial class Form1 : Form
    {
        List<Articulo> Articulos = new();
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        public string Descripcion(string codigo)
        {
            FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                con.Open();
                string query3 = "SELECT * FROM ARTICULOS WHERE ARTICULO_ID = '" + codigo + "';";
                FbCommand command3 = new FbCommand(query3, con);
                FbDataReader reader3 = command3.ExecuteReader();

                // Iterar sobre los registros y mostrar los valores
                if (reader3.Read())
                {
                    return reader3.GetString(1);
                }
                else
                {
                    return "Artículo sin descripción";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return "Artículo sin descripción";
            }
            finally
            {
                con.Close();
            }
        }
        public bool Ubicacion(string codigo)
        {
            FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                con.Open();
                string query4 = "SELECT * FROM NIVELES_ARTICULOS WHERE ARTICULO_ID = " + codigo + ";";
                FbCommand command4 = new FbCommand(query4, con);
                FbDataReader reader4 = command4.ExecuteReader();
                // Iterar sobre los registros y mostrar los valores
                while (reader4.Read())
                {
                    string columna3 = reader4.GetString(3);
                    if (columna3 != "")
                    {
                        if (columna3[0] == 'I' && columna3[1] == 'S' && columna3[2] == 'L' && columna3[3] == 'A')
                            return true;
                    }

                }
                reader4.Close();
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public decimal Existencia(string codigo)
        {
            FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                con.Open();
                FbCommand command = new FbCommand("EXIVAL_ART", con);
                command.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                command.Parameters.Add("V_ARTICULO_ID", FbDbType.Integer).Value = codigo;
                command.Parameters.Add("V_ALMACEN_ID", FbDbType.Integer).Value = 108404;
                command.Parameters.Add("V_FECHA", FbDbType.Date).Value = DateTime.Today;
                command.Parameters.Add("V_ES_ULTIMO_COSTO", FbDbType.Char).Value = 'S';
                command.Parameters.Add("V_SUCURSAL_ID", FbDbType.Integer).Value = 0;

                // Parámetro de salida
                FbParameter paramARTICULO = new FbParameter("ARTICULO_ID", FbDbType.Numeric);
                paramARTICULO.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramARTICULO);
                FbParameter paramEXISTENCIA = new FbParameter("EXISTENCIAS", FbDbType.Numeric);
                paramEXISTENCIA.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramEXISTENCIA);
                // Ejecutar el procedimiento almacenado
                command.ExecuteNonQuery();
                int Existencia = Convert.ToInt32(command.Parameters[6].Value);

                FbCommand command2 = new FbCommand("EXIVAL_ART", con);
                command2.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                command2.Parameters.Add("V_ARTICULO_ID", FbDbType.Integer).Value = codigo;
                command2.Parameters.Add("V_ALMACEN_ID", FbDbType.Integer).Value = 108403;
                command2.Parameters.Add("V_FECHA", FbDbType.Date).Value = DateTime.Today;
                command2.Parameters.Add("V_ES_ULTIMO_COSTO", FbDbType.Char).Value = 'S';
                command2.Parameters.Add("V_SUCURSAL_ID", FbDbType.Integer).Value = 0;

                // Parámetro de salida
                FbParameter paramARTICULO2 = new FbParameter("ARTICULO_ID", FbDbType.Numeric);
                paramARTICULO2.Direction = ParameterDirection.Output;
                command2.Parameters.Add(paramARTICULO2);
                FbParameter paramEXISTENCIA2 = new FbParameter("EXISTENCIAS", FbDbType.Numeric);
                paramEXISTENCIA2.Direction = ParameterDirection.Output;
                command2.Parameters.Add(paramEXISTENCIA2);
                // Ejecutar el procedimiento almacenadoienda
                command2.ExecuteNonQuery();
                decimal ExistenciaTienda = Convert.ToInt32(command2.Parameters[6].Value);
                //MessageBox.Show("ALMACÉN: "+ Existencia.ToString() +"\n TIENDA: "+ ExistenciaTienda.ToString());
                //if (GlobalSettings.Instance.ExistenciaQuery == false)
                //{
                //    var customMessageBox = new Mensaje();
                //    // Establece el mensaje que deseas mostrar
                //    customMessageBox.SetMensaje("TIENDA: " + ExistenciaTienda.ToString(), "existencia");
                //    // Muestra el formulario como un cuadro de diálogo modal
                //    customMessageBox.ShowDialog();
                //}
                //else
                return ExistenciaTienda;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int Saltos(string Nota)
        {
            string texto = Nota;

            string[] lineas = texto.Split('\n');
            if (texto == string.Empty)
                return 0;
            return lineas.Length;
        }
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (Txt_Pedido.Text == string.Empty)
            {
                DialogResult result = MessageBox.Show("Pedido no ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            Articulos.Clear();
            string Folio_Mod = Txt_Pedido.Text;
            if (Folio_Mod[1] == 'O' || Folio_Mod[1] == 'E' || Folio_Mod[1] == 'A' || Folio_Mod[1] == 'M')
            {
                int cont = 9 - Folio_Mod.Length;
                string prefix = Folio_Mod.Substring(0, 2);
                string suffix = Folio_Mod.Substring(2);
                string patch = "";
                for (int i = 0; i < cont; i++)
                {
                    patch = patch + "0";
                }
                Folio_Mod = prefix + patch + suffix;
            }
            else if (Folio_Mod[0] == 'P')
            {
                int cont = 9 - Folio_Mod.Length;
                string prefix = Folio_Mod.Substring(0, 1);
                string suffix = Folio_Mod.Substring(1);
                string patch = "";
                for (int i = 0; i < cont; i++)
                {
                    patch = patch + "0";
                }
                Folio_Mod = prefix + patch + suffix;
            }

            FbConnection con = new FbConnection("User=SYSDBA;" + "Password=C0r1b423;" + "Database=D:\\Microsip datos\\PAPELERIA CORIBA CORNEJO.fdb;" + "DataSource=192.168.0.11;" + "Port=3050;" + "Dialect=3;" + "Charset=UTF8;");
            try
            {
                // Crear un nuevo hilo y asignarle un método que se ejecutará en paralelo
                // Iniciar la ejecución del hilo

                con.Open();
                string query0 = "SELECT * FROM DOCTOS_VE WHERE FOLIO = '" + Folio_Mod + "' AND TIPO_DOCTO = 'P';";
                FbCommand command = new FbCommand(query0, con);
                bool Find = false;
                // Objeto para leer los datos obtenidos
                FbDataReader reader0 = command.ExecuteReader();
                if (reader0.Read())
                {
                    GlobalSettings.Instance.status = reader0.GetString(18);
                    GlobalSettings.Instance.FolioId = reader0.GetString(0);
                    Find = true;
                }
                else
                {
                    Find = false;
                }
                reader0.Close();
                if (Find == false)
                {
                    MessageBox.Show("FOLIO NO ENCONTRADO");
                    return;
                }
                if (GlobalSettings.Instance.status == "S")
                {
                    MessageBox.Show("Este pedido ya está facturado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (GlobalSettings.Instance.status == "C")
                {
                    MessageBox.Show("Este pedido está cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query1 = "SELECT * FROM DOCTOS_VE_DET  WHERE DOCTO_VE_ID =" + GlobalSettings.Instance.FolioId + ";";
                FbCommand command1 = new FbCommand(query1, con);
                FbDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    string Code = reader1.GetString(3);
                    bool validar = Ubicacion(Code);
                    string descripcion = Descripcion(Code);
                    decimal existencia = Existencia(Code);
                    int saltos = Saltos(reader1.GetString(18));
                    if (validar == true)
                    {
                        Articulo variables = new Articulo
                        {
                            Codigo = reader1.GetString(2),
                            Descripcion = descripcion,
                            Solicitado = reader1.GetDecimal(4),
                            Existencia = existencia,
                            Saltos = saltos,
                            Nota = reader1.GetString(18)
                        };
                        Articulos.Add(variables);

                    }

                }
                Lb_articulos.Text = "Total de artículos: " + Articulos.Count;
                reader1.Close();
                //MessageBox.Show(Txt_Pedido.Text);
                if (GlobalSettings.Instance.VistaPrevia == false)
                    Imprimir();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdió la conexión :( , contacta a 06 o intenta de nuevo", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                con.Close();
            }
        }
        public void Imprimir()
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                printDocument1.Print();
                Articulos.Clear();
                DialogResult result = MessageBox.Show("¡SE HA MANDADO A IMPRIMIR!\n¿Deseas realizar otra impresión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Txt_Pedido.Select(0, Txt_Pedido.Text.Length);
                    Txt_Pedido.Focus();
                }
                else
                {
                    this.Close();
                }
            }
           
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font = new Font("Arial", 20, FontStyle.Bold))
            {
                e.Graphics.DrawString(Txt_Pedido.Text, font, Brushes.Black, new PointF(90, 0));

            }
            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString(DateTime.Now.ToString(" yyyy-MM-dd"), font, Brushes.Black, new PointF(200, 0));

            }
            Image originalImage = Image.FromFile("C:\\Img\\logo.png");
            Image resizedImage = new Bitmap(originalImage, new Size(60, 35));
            e.Graphics.DrawImage(resizedImage, new PointF(0, 0));
            int j = 40;
            for (int i = 0; i < Articulos.Count; ++i)
            {
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                {
                    if (i > 0)
                        e.Graphics.DrawString("_____________________________________________________________", font, Brushes.Black, new PointF(0, j - 25));
                    if (Articulos[i].Existencia == 0)
                        e.Graphics.DrawString(Articulos[i].Codigo, new Font("Arial", 10, FontStyle.Strikeout), Brushes.Black, new PointF(0, j));
                    else
                        e.Graphics.DrawString(Articulos[i].Codigo, font, Brushes.Black, new PointF(0, j));
                    if (Articulos[i].Solicitado.ToString().Length > 3)
                        e.Graphics.DrawString(Articulos[i].Solicitado.ToString(), font, Brushes.Black, new PointF(252, j));
                    else
                        e.Graphics.DrawString(Articulos[i].Solicitado.ToString(), font, Brushes.Black, new PointF(260, j));

                }

                Rectangle DestinationRectangle = new Rectangle(51, j, 220, 50);
                using (StringFormat sf = new StringFormat())
                {
                    if (Articulos[i].Existencia == 0)
                        e.Graphics.DrawString(Articulos[i].Descripcion, new Font("Arial", 8, FontStyle.Strikeout), Brushes.Black, DestinationRectangle, sf);
                    else
                        e.Graphics.DrawString(Articulos[i].Descripcion, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, DestinationRectangle, sf);
                }
                using (Font font = new Font("Arial", 7, FontStyle.Regular))
                {
                    if (Articulos[i].Saltos >= 1)
                    {
                        e.Graphics.DrawString(Articulos[i].Nota, font, Brushes.Black, new PointF(51, j + 30));
                        j += Articulos[i].Saltos * 5;
                    }
                    else
                        j -= 20;
                }

                j += 70;
            }
            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString("      ___________       ___________  ", font, Brushes.Black, new PointF(0, j + 70));
                e.Graphics.DrawString("          Entregó                Recibió    ", font, Brushes.Black, new PointF(0, j + 90));

            }
            
        }

        private void Btn_VistaPrevia_Click(object sender, EventArgs e)
        {
            GlobalSettings.Instance.VistaPrevia = true;
            BtnImprimir_Click(sender, e);
            // Crear un nuevo tamaño de página
            // Actualizar el control PrintPreviewControl
            GlobalSettings.Instance.Largo = 150;
            GlobalSettings.Instance.Largo += Articulos.Count * 55;
            for (int i = 0; i < Articulos.Count; ++i)
            {
                GlobalSettings.Instance.Largo += Articulos[i].Saltos * 10;
            }
            //MessageBox.Show((GlobalSettings.Instance.Largo).ToString());
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("CustomSize", 300, GlobalSettings.Instance.Largo);
            printPreviewControl1.InvalidatePreview();
            printPreviewControl1.Document = printDocument1;
            GlobalSettings.Instance.VistaPrevia = false;

            Btn_Imprimir.Focus();

        }

        private void Txt_Pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLower(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void Txt_Pedido_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows al presionar Enter
                Btn_VistaPrevia.Focus();
            }
        }

    }
}