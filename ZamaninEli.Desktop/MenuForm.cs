using ZamaninEli.Library.Enum;
using ZamaninEli.Library.Concrete;
using System.Windows.Forms;

namespace ZamaninEli.Desktop
{
    public partial class MenuForm : Form
    {
        private Oyun _oyun;
        private Panel uzayPanel;

        public MenuForm()
        {
            InitializeComponent();
            _oyun = new Oyun(uzayPanel);
        }

        private void OyunuBaslat_Click(object sender, System.EventArgs e)
        {
            OyunForm oyunForm = new OyunForm();
            oyunForm.ShowDialog();
            _oyun.Basla();
        }

        private void HikayeAc_Click(object sender, System.EventArgs e)
        {
            HikayeForm hikayeForm = new HikayeForm();
            hikayeForm.ShowDialog();
        }

        private void Top5_Click(object sender, System.EventArgs e)
        {
            Top5Form top5Form = new Top5Form();
            top5Form.ShowDialog();
        }
    }
}
