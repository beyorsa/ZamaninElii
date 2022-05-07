using System;
using System.Drawing;
using ZamaninEli.Library.Concrete;

namespace ZamaninEli.Library.Abstarct
{
    internal abstract class ToplananMadde : Cisim
    {
        private static readonly Random Random = new Random();
        public ToplananMadde(int panelUzunlugu, int panelGenisligi) : base(panelUzunlugu, panelGenisligi)
        {
            HareketMesafesi = (int)(Height * 0.1);

            Left = Random.Next(panelGenisligi + 1 - Width);
        }

        public bool YereDustuMu()
        {
            if (Bottom >= (PanelUzunlugu))
            {
                return true;

            }
            return false;

        }
    }
}
