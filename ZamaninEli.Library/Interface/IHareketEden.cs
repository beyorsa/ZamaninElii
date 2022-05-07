using System.Drawing;
using ZamaninEli.Library.Enum;

namespace ZamaninEli.Library.Interface
{
    internal interface IHareketEden
    {
        int PanelUzunlugu { get; }
        int PanelGenisligi { get; }
        int HareketMesafesi { get; }

        /// <summary>
        /// Cismi istenilen yönde hareket ettirir.
        /// </summary>
        /// <param name="yon">Hangi yöne hareket edileceği.</param>
        /// <returns>Cisim duvara çarparsa true döndürür.</returns>
        bool HareketEttir(Yon yon);
    }
}
