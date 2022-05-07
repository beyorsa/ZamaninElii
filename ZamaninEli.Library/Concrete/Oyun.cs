
using System.Windows.Forms;
using System;
using ZamaninEli.Library.Enum;
using ZamaninEli.Library.Interface;
using System.Drawing;
using ZamaninEli.Library.Abstarct;
using System.Collections.Generic;
using System.IO;

namespace ZamaninEli.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _kalanSureTimer = new Timer() { Interval = 1000};
        private readonly Timer _hareketTimer = new Timer() { Interval = 100 };
        private readonly Timer _toplananMaddeTimer = new Timer() { Interval = 200 };
        private int _kalanSure;
        private Gezegen _gezegen;

        private int _H2Sayisi;
        private int _OSayisi;
        private int _ElektrolizorSayisi;

        private int _kazanilanGun;
        
        
        private int _oyunSkoru;

        private int labelSayaci;

        private readonly Panel _uzayPanel;
        private readonly Panel _bilgiPanel;
        
        
        private Label _uzayPanelLabel;
        private object _oyuncuAdiTextBox;

        private static readonly Random Random = new Random();

        private readonly List<ToplananMadde> _toplananMaddeler = new List<ToplananMadde>();

        public Oyun(Panel uzayPanel, Panel bilgiPanel)
        {
            _uzayPanel = uzayPanel;
            _bilgiPanel = bilgiPanel;
        }




        #endregion

        #region Olaylar

        public event EventHandler KalanSureDegisti;
        public event EventHandler MaddeToplandi;
        public event EventHandler GunKazanildi;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }
        public bool OyunDuraklatildiMi { get; set; }
        public int PanelUzunlugu { get; private set; }
        public int PanelGenisligi { get; private set; }

        #endregion

        #region Metotlar


        public int H2Sayisi
        {
            get => _H2Sayisi;
            private set
            {
                _H2Sayisi = value;
                MaddeToplandi?.Invoke(this, EventArgs.Empty);
            }
        }

        public int ElektrolizorSayisi
        {
            get => _ElektrolizorSayisi;
            private set
            {
                _ElektrolizorSayisi = value;
                MaddeToplandi?.Invoke(this, EventArgs.Empty);
            }
        }

        public int OSayisi
        {
            get => _OSayisi;
            private set
            {
                _OSayisi = value;
                MaddeToplandi?.Invoke(this, EventArgs.Empty);
            }
        }


        private void ToplananMaddeTimer_Tick(object sender, EventArgs e)
        {
            ToplananMaddeOlustur();
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            ToplananMaddeleriHareketEttir();
        }


        private void MaddeOlustur(ToplananMadde toplananMadde)
        {
            bool ustUsteGeldiMi;

            ustUsteGeldiMi = ToplananMaddeUstUsteGeliyorMu(toplananMadde);
            if (ustUsteGeldiMi)
            {
                ToplananMaddeOlustur();
                return;
            }

            _toplananMaddeler.Add(toplananMadde);
            _uzayPanel.Controls.Add(toplananMadde);
        }

        private void ToplananMaddeOlustur()
        {
            int sayi = Random.Next(7);


            if (sayi == 1)
            {
                var o = new O(PanelUzunlugu, PanelGenisligi);
                MaddeOlustur(o);
            }
            else if (sayi == 2 || sayi == 3)
            {
                var h2 = new H2(PanelUzunlugu, PanelGenisligi);
                MaddeOlustur(h2);
            }
            else if (sayi == 4 || sayi == 5 || sayi == 6)
            {
                var elektrolizor = new Elektrolizor(PanelUzunlugu, PanelGenisligi);
                MaddeOlustur(elektrolizor);
            }

            if (KalanSure % 10 == 0)
            {
                var soru_isareti = new Soru_isareti(PanelUzunlugu, PanelGenisligi);

                _toplananMaddeler.Add(soru_isareti);
                _uzayPanel.Controls.Add(soru_isareti);
                KalanSure--;

            }
        }
        private bool ToplananMaddeUstUsteGeliyorMu(ToplananMadde toplananMadde)
        {
            foreach (var _toplananMadde in _toplananMaddeler)
            {
                if ((_toplananMadde.Top <= toplananMadde.Bottom && _toplananMadde.Left <= toplananMadde.Right)
                    || _toplananMadde.Top <= toplananMadde.Bottom && _toplananMadde.Right >= toplananMadde.Left)
                {
                    return true;
                }
            }

            return false;
        }

        private void ToplananMaddeleriHareketEttir()
        {
            OyunHiziniHesapla();

            for (int i = _toplananMaddeler.Count - 1; i >= 0; i--)
            {
                if (_toplananMaddeler.Count <= 0) return;


                var toplananMadde = _toplananMaddeler[i];
                toplananMadde.HareketEttir(Yon.Asagi);

                var yereDustuMu = toplananMadde.YereDustuMu();
                var GezegeneDegdiMi = _gezegen.Left <= toplananMadde.Right && _gezegen.Right >= toplananMadde.Left
                                                                       && toplananMadde.Bottom >=
                                                                       (PanelUzunlugu - _gezegen.Height);

                switch (yereDustuMu)
                {
                    case true:

                        {
                            _toplananMaddeler.Remove(toplananMadde);
                            _uzayPanel.Controls.Remove(toplananMadde);
                        }
                        break;

                    case false:
                        if (GezegeneDegdiMi)
                        {
                            if (toplananMadde.GetType().Name == "Elektrolizor")
                            {
                                ElektrolizorSayisi++;
                                _toplananMaddeler.Remove(toplananMadde);
                                _uzayPanel.Controls.Remove(toplananMadde);
                            }
                            else if (toplananMadde.GetType().Name == "H2")
                            {
                                H2Sayisi++;
                                _toplananMaddeler.Remove(toplananMadde);
                                _uzayPanel.Controls.Remove(toplananMadde);
                            }
                            else if (toplananMadde.GetType().Name == "O")
                            {
                                OSayisi++;
                                _toplananMaddeler.Remove(toplananMadde);
                                _uzayPanel.Controls.Remove(toplananMadde);
                            }
                            else if (toplananMadde.GetType().Name == "GizliKutu")
                            {
                                var sayi = Random.Next(100);

                                _uzayPanelLabel.Visible = true;

                                if (sayi >= 0 && sayi < 50)
                                {
                                    ElektrolizorSayisi += 3;
                                    H2Sayisi += 2;
                                    OSayisi += 1;
                                    _uzayPanelLabel.Text = "Tebrikler! Bu ay fazladan 1 iha ürettik.";
                                }
                                else if (sayi >= 50 && sayi < 100)
                                {
                                    if (ElektrolizorSayisi >= 3 && H2Sayisi >= 2 && OSayisi >= 1)
                                    {
                                        ElektrolizorSayisi -= 3;
                                        H2Sayisi -= 2;
                                        OSayisi -= 1;
                                        KazanilanGun--;
                                        _uzayPanelLabel.Text = "Üzgünüz! Yaptığımız 1 iha arıza çıkardı.";
                                    }
                                    else
                                    {
                                        _uzayPanelLabel.Text = "Fabrikada herşey normal gidiyor. Hiçbirşey Değişmedi.";
                                    }
                                }

                                _toplananMaddeler.Remove(toplananMadde);
                                _uzayPanel.Controls.Remove(toplananMadde);
                            }
                        }

                        UrunHesapla();
                        break;
                }
            }
        }





        public void AyarlariAc()
        {
            throw new NotImplementedException();
        }


        public void OyunuDurdur()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Zaman

        public int KalanSure
        {
            get => _kalanSure;
            private set
            {
                _kalanSure = value;

                KalanSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        private void KalanSureTimer_Tick(object sender, EventArgs e)
        {
            KalanSure--;

            if (_uzayPanelLabel.Visible)
            {
                labelSayaci++;
            }

            if (labelSayaci > 2)
            {
                _uzayPanelLabel.Visible = false;
                labelSayaci = 0;
            }

            if (KalanSure < 5)
            {
                _uzayPanel.Controls.Add(_uzayPanelLabel);
                _uzayPanelLabel.Visible = true;
                _uzayPanelLabel.Text = $"Sürenin Bitmesine {KalanSure} Saniye Kaldı !";
            }
        }

        private void ZamanlayicilariBaslat()
        {
            _kalanSureTimer.Start();
            _toplananMaddeTimer.Start();
            _hareketTimer.Start();
        }

        private void ZamanlayicilariDurdur()
        {
            _kalanSureTimer.Stop();
            _toplananMaddeTimer.Stop();
            _hareketTimer.Stop();
        }
        #endregion


        #region Urun/Skor
        public int KazanilanGun
        {
            get => _kazanilanGun;
            set
            {
                _kazanilanGun = value;
                GunKazanildi?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UrunHesapla()
        {
            var oSayisi = OSayisi;
            var h2Sayisi = H2Sayisi;
            var elektrolizorSayisi = ElektrolizorSayisi;
            while (oSayisi >= 1 && h2Sayisi >= 2 && elektrolizorSayisi >= 3)
            {

                for (int i = 0; i < KazanilanGun; i++)
                {
                    oSayisi -= 1;
                    h2Sayisi -= 2;
                    elektrolizorSayisi -= 3;
                }

                if (oSayisi >= 1 && h2Sayisi >= 2 && elektrolizorSayisi >= 3)
                {
                    oSayisi -= 1;
                    h2Sayisi -= 2;
                    elektrolizorSayisi -= 3;
                    KazanilanGun++;
                }
            }
        }
        private void SkorHesapla()
        {
            while (OSayisi >= 1)
            {
                _oyunSkoru += 15;
                OSayisi--;
            }

            while (H2Sayisi >= 1)
            {
                _oyunSkoru += 15;
                H2Sayisi--;
            }

            while (ElektrolizorSayisi >= 1)
            {
                _oyunSkoru += 15;
                ElektrolizorSayisi--;
            }

            while (KazanilanGun >= 1)
            {
                _oyunSkoru += 100;
                KazanilanGun--;
            }
        }
        /*private void SkoruYaz()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (_oyunSkoru > 0)
            {
                using (StreamWriter streamWriter = File.AppendText(path + @"\topfive.txt"))
                {
                    streamWriter.Write(value: $"0◘{_oyuncuAdiTextBox.Text}◘{DateTime.Now}◘{_oyunSkoru}\n");
                }
            }
        }*/

        #endregion

        #region Paneller
        private void Soru_isaretiLabelOlustur()
        {
            _uzayPanelLabel = new Label();
            _uzayPanel.Controls.Add(_uzayPanelLabel);
            _uzayPanelLabel.Location = new Point((_uzayPanel.Width - _bilgiPanel.Width) / 2, 40);
            _uzayPanelLabel.ForeColor = Color.Red;
            _uzayPanelLabel.BackColor = Color.Aqua;
            _uzayPanelLabel.TextAlign = ContentAlignment.TopLeft;
            _uzayPanelLabel.Font = new Font(FontFamily.GenericSansSerif, 15);
            _uzayPanelLabel.AutoSize = true;
        }

        public void PanelleriAyarla()
        {
            if (!DevamEdiyorMu)
            {
                _bilgiPanel.Visible = false;
            }
            else if (DevamEdiyorMu)
            {
                _bilgiPanel.Visible = true;
                Soru_isaretiLabelOlustur();
            }
        }

        private void UzayPaneliTemizle()
        {
            _uzayPanel.Controls.Clear();
            _uzayPanel.Refresh();
            _toplananMaddeler.Clear();
        }

        #endregion


        #region Oyun
        private void ToplayiciOlustur()
        {
            _gezegen = new Gezegen(PanelUzunlugu, PanelGenisligi);
            _uzayPanel.Controls.Add(_gezegen);
        }
        public void Basla()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            OyunDuraklatildiMi = false;

            OyunBaslangıcınıAyarla();
            PanelleriAyarla();
            ZamanlayicilariBaslat();
            ToplayiciOlustur();

        }

        public void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;

            ZamanlayicilariDurdur();
            SkorHesapla();
            //SkoruYaz();
            UzayPaneliTemizle();
            PanelleriAyarla();
        }

        public void DurdurVeBaslat()
        {
            if (_kalanSureTimer.Enabled && DevamEdiyorMu)
            {
                OyunDuraklatildiMi = true;
                ZamanlayicilariDurdur();
                if (KalanSure > 0)
                {
                    _kalanSure--;
                }
            }
            else if (DevamEdiyorMu)
            {
                OyunDuraklatildiMi = false;
                ZamanlayicilariBaslat();
            }
        }

        public void HareketEt(Yon yon)
        {
            if (DevamEdiyorMu)
            {
                _gezegen.HareketEttir(yon);
            }
        }



        private void OyunBaslangıcınıAyarla()
        {
            int oyunSuresi = 120;
            KalanSure = oyunSuresi;

            PanelUzunlugu = _uzayPanel.Height;
            PanelGenisligi = _uzayPanel.Width - _bilgiPanel.Width;

            _oyunSkoru = 0;
            H2Sayisi = 0;
            ElektrolizorSayisi = 0;
            OSayisi = 0;

            KazanilanGun = 0;
        }


        public void OyunHiziniHesapla()
        {
            int baslangicSayisi = 120;

            if (KalanSure <= baslangicSayisi * 0.2)
            {
                _hareketTimer.Interval = 30;
            }
            else if (KalanSure <= baslangicSayisi * 0.3)
            {
                _hareketTimer.Interval = 40;
            }
            else if (KalanSure <= baslangicSayisi * 0.4)
            {
                _hareketTimer.Interval = 50;
            }
            else if (KalanSure <= baslangicSayisi * 0.6)
            {
                _hareketTimer.Interval = 60;
            }
            else if (KalanSure <= baslangicSayisi * 0.8)
            {
                _hareketTimer.Interval = 70;
            }
        }

        #endregion

        public Oyun(Panel uzayPanel, Panel bilgiPanel,TextBox oyuncuAdiTextBox)
        {
            _kalanSureTimer.Tick += KalanSureTimer_Tick;
            _toplananMaddeTimer.Tick += ToplananMaddeTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;

            _uzayPanel = uzayPanel;
            _bilgiPanel = bilgiPanel;
            _oyuncuAdiTextBox = oyuncuAdiTextBox;
        }


    }
}
