using System.Windows.Forms;
using ZamaninEli.Library.Abstarct;
using System.Drawing;

namespace ZamaninEli.Library.Concrete
{
    internal class Gezegen : Cisim
    {
        public Gezegen(int panelUzunlugu, int panelGenisligi) : base(panelUzunlugu, panelGenisligi)
        {
            var gezegenLocation = panelUzunlugu - Height;

            Center = panelGenisligi / 2;
            Top = gezegenLocation;

            HareketMesafesi = Width;
        }
    }
}
