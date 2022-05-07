using ZamaninEli.Library.Enum;
using System.Windows.Forms;
using ZamaninEli.Library.Concrete;
using System;

namespace ZamaninEli.Desktop
{
    public partial class OyunForm : Form
    {
        private readonly Oyun _oyun;

      

        public OyunForm()
        {
            InitializeComponent();

            _oyun = new Oyun(uzayPanel,bilgiPanel);


            _oyun.KalanSureDegisti += Oyun_KalanSureDegisti;
            _oyun.MaddeToplandi += Oyun_MaddeToplandi;
            _oyun.GunKazanildi += Oyun_GunKazanildi;
        }

        private void OyunForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if(_oyun.OyunDuraklatildiMi == false)
                        _oyun.HareketEt(Yon.Saga);
                    break;
                case Keys.Left:
                    if (_oyun.OyunDuraklatildiMi == false)
                        _oyun.HareketEt(Yon.Sola);
                    break;
                case Keys.Escape:
                    _oyun.AyarlariAc();
                    break;
                case Keys.P:
                    _oyun.DurdurVeBaslat();
                    break;
                case Keys.Enter:
                    _oyun.Basla();
                    break;
            }
        }
        private void Oyun_KalanSureDegisti(object sender, EventArgs e)
        {
            kalansure.Text = _oyun.KalanSure.ToString();
            if (_oyun.KalanSure <= 0)
                _oyun.Bitir();
        }

        #region Olaylar

        private void Oyun_MaddeToplandi(object sender, EventArgs e)
        {
            kazanilanGunLabel.Text = _oyun.KazanilanGun.ToString();

            oLabel.Text = _oyun.OSayisi.ToString();
            h2Label.Text = _oyun.H2Sayisi.ToString();
            elektrolizorLabel.Text = _oyun.ElektrolizorSayisi.ToString();
        }

        private void Oyun_GunKazanildi(object sender, EventArgs e)
        {
            kazanilanGunLabel.Text = _oyun.KazanilanGun.ToString();
        }

        #endregion



        #region TextBoxlar

        private void oyuncuAdiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SiradakiTexteGec(sender, e);
        }

        private void oyunSuresiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SiradakiTexteGec(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = true;
                _oyun.Basla();
                Focus();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

 

        #endregion

        private void SiradakiTexteGec(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void oyunsuresitextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OyunForm_Load(object sender, EventArgs e)
        {
            _oyun.Basla();
        }
    }
}




