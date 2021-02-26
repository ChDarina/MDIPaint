using System;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class CanvasSize : Form
    {
        public int CanvasWidth;
        public int CanvasHeight;
        public CanvasSize()
        {
            InitializeComponent();
        }

        private void CanvasSize_Load(object sender, EventArgs e)
        {
            WidthTB.Text = CanvasWidth.ToString();
            HeightTB.Text = CanvasHeight.ToString();
        }

        private void Width_TextChanged(object sender, EventArgs e)
        {
            CanvasWidth = Convert.ToInt32(WidthTB.Text);
        }

        private void Height_TextChanged(object sender, EventArgs e)
        {
            CanvasHeight = Convert.ToInt32(HeightTB.Text);
        }
    }
}
