using System;
using System.Windows.Forms;

namespace AlmacenTienda
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmProductos()); // ← Persona 3 abre este form
        }
    }
}
