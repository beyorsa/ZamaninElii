

using System;
using System.Drawing;
using System.Windows.Forms;
using ZamaninEli.Library.Enum;
using ZamaninEli.Library.Interface;

namespace ZamaninEli.Library.Abstarct
{
    internal abstract class Cisim : PictureBox, IHareketEden
    {
        public int PanelUzunlugu { get; }
        public int PanelGenisligi { get; }
        public int HareketMesafesi { get; protected set; }

        public new int Right
        {
            get => base.Right;
            set => Left = value - Width;
        }
        public new int Bottom
        {
            get => base.Bottom;
            set => Top = value - Height;
        }
        public int Center
        {
            get => Left + Width / 2;
            set => Left = value - Width / 2;
        }

        public int Middle
        {
            get => Top + Height / 2;
            set => Top = value - Height / 2;
        }



        public Cisim(int panelUzunlugu, int panelGenisligi)
        {
            Image = Image.FromFile($@"../../Gorseller\{GetType().Name}.png");
            PanelUzunlugu = panelUzunlugu;
            PanelGenisligi = panelGenisligi;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public bool HareketEttir(Yon yon)
        {
            switch (yon)
            {
                case Yon.Saga:
                    SagaHareketEttir();
                    break;
                case Yon.Sola:
                    SolaHareketEttir();
                    break;
                case Yon.Asagi:
                    AsagiHareketEttir();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(yon), yon, null);
            }

            return false;
        }

        private bool SolaHareketEttir()
        {
            if (Left == 0) return true;

            var yeniLeft = Left - HareketMesafesi;
            var tasacakMi = yeniLeft < 0;

            Left = tasacakMi ? 0 : yeniLeft;

            return Left == 0;

        }

        private bool SagaHareketEttir()
        {
            if (Right == PanelGenisligi) return true;

            var yeniRight = Right + HareketMesafesi;
            var tasacakMi = yeniRight > PanelGenisligi;

            Right = tasacakMi ? PanelGenisligi : yeniRight;

            return Right == PanelGenisligi;
        }

        private bool AsagiHareketEttir()
        {
            if (Bottom == PanelUzunlugu) return true;

            var yeniBottom = Bottom + HareketMesafesi;
            var tasacakMi = yeniBottom > PanelUzunlugu;

            Bottom = tasacakMi ? PanelUzunlugu : yeniBottom;

            return Bottom == PanelUzunlugu;
        }
    }
}
