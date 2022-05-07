using System;
using ZamaninEli.Library.Enum;

namespace ZamaninEli.Library.Interface
{
    internal interface IOyun
    {
        event EventHandler KalanSureDegisti;
        bool DevamEdiyorMu { get; }

        void Basla();
        void Bitir();
        void HareketEt(Yon yon);

        void DurdurVeBaslat();

        void AyarlariAc();



    }
}
