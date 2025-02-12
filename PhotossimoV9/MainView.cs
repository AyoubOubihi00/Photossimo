using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;

namespace Photossimo
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ImageImportView imgImportView = new ImageImportView();
            imgImportView.ShowDialog();

            
        }
    }
}