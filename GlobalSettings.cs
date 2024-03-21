using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTickets
{
    public class GlobalSettings
    {
        private static GlobalSettings instance;
        public string FolioId { get; set; }
        public string status { get; set; }
        public int Largo {  get; set; }
        public bool VistaPrevia {  get; set; }
        public decimal Existencia {  get; set; }
        public static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalSettings();
                }
                return instance;
            }
        }
    }
    public class Articulo
    {
        public string Codigo { get; set; }
        public int Saltos { get; set; }
        public string Descripcion { get; set; }
        public decimal Solicitado { get; set; }
        public string Nota { get; set; }

        public decimal Existencia { get; set; }

    }
}
