using ZamaninEli.Library.Enum;
using ZamaninEli.Library.Concrete;
using System.Windows.Forms;

namespace ZamaninEli.Desktop
{
    public partial class MenuForm : Form
    {
        private Oyun _oyun;
        private Panel uzayPanel;
        private Panel bilgiPanel;

        public MenuForm()
        {
            InitializeComponent();
            
            _oyun = new Oyun(uzayPanel,bilgiPanel);
        }

        private void OyunuBaslat_Click(object sender, System.EventArgs e)
        {
            OyunForm oyunForm = new OyunForm();
            oyunForm.ShowDialog();
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
