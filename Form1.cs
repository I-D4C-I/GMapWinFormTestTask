using GMap.NET.MapProviders;
using System;
using System.Windows.Forms;

namespace GMapWinForm
{
    public partial class Form1 : Form
    {
        private readonly AppViewModel viewModel;
        private bool isLeftButtonDown = false;


        public Form1()
        {
            InitializeComponent();

            //Строка подключения к базе
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=MapDatabase;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;";

            viewModel = new AppViewModel(gMapControl);
            viewModel.SetConnectionString(connectionString);

        }

        private void gMapControl_Load(object sender, EventArgs e)
        {
            viewModel.InitializeMapControl(GoogleMapProvider.Instance);

            // Загрузка координат из базы данных
            viewModel.LoadCoordinates();

        }


        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftButtonDown = true;
                viewModel.MarkerOverlayDrag();
            }
        }

        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isLeftButtonDown && viewModel.CurrentMarker != null)
                viewModel.MarkerNewPostition(e.X, e.Y);

        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && viewModel.CurrentMarker != null)
            {
                isLeftButtonDown = false;
                viewModel.UpdateMarker();
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gMapControl.Dispose();
        }
    }
}
