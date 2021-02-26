using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class MainForm : Form
    {
        public static Color CurColor = Color.Black;
        public static int CurWidth = 3;
        public static string typePen = "pen";
        public static int numWorks = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutPaint frmAbout = new AboutPaint();
            frmAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas frmChild = new Canvas();
            frmChild.MdiParent = this;
            Save.Enabled = true;
            SaveAs.Enabled = true;
            numWorks++;
            frmChild.Show();
        }

        private void рисунокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSize cs = new CanvasSize();
            cs.CanvasWidth = ((Canvas)ActiveMdiChild).CanvasWidth;
            cs.CanvasHeight = ((Canvas)ActiveMdiChild).CanvasHeight;
            if (cs.ShowDialog() == DialogResult.OK)
            {
                ((Canvas)ActiveMdiChild).CanvasWidth = cs.CanvasWidth;
                ((Canvas)ActiveMdiChild).CanvasHeight = cs.CanvasHeight;
            }
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Blue;
        }

        private void зелёныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Green;
        }

        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                CurColor = cd.Color;
        }

        private void txtBrushSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurWidth = int.Parse(txtBrushSize.Text);
            }
            catch
            {
                MessageBox.Show("Значение должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы ()*.*|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                Save.Enabled = true;
                SaveAs.Enabled = true;
                numWorks++;
                frmChild.Show();
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).SaveAs();
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        public void SetStatusText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }
        private void Disable()
        {
            Pen.Checked = false;
            Line.Checked = false;
            Ellipse.Checked = false;
            Star.Checked = false;
            Eraser.Checked = false;
            toolStripLabel3.Visible = false;
            Peaks.Visible = false;
        }

        private void PlusSize_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).PlusScale();
        }

        private void MinusSize_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).MinusScale();
        }

        private void Pen_Click(object sender, EventArgs e)
        {
            Disable();
            Inst.Text = Pen.Text;
            Pen.Checked = true;
        }

        private void Eraser_Click(object sender, EventArgs e)
        {
            Disable();
            Inst.Text = Eraser.Text;
            Eraser.Checked = true;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            Disable();
            Inst.Text = Line.Text;
            Line.Checked = true;
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            Disable();
            Inst.Text = Ellipse.Text;
            Ellipse.Checked = true;
        }

        private void Star_Click(object sender, EventArgs e)
        {
            Disable();
            toolStripLabel3.Visible = true;
            Peaks.Visible = true;
            Inst.Text = Star.Text;
            Star.Checked = true;
        }

        private void Peaks_TextChanged(object sender, EventArgs e)
        {
            int peaks;
            try
            {
                peaks = int.Parse(Peaks.Text);
                ((Canvas)ActiveMdiChild).PeaksStar(peaks);
            }
            catch
            {
                MessageBox.Show("Значение должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).Save();
        }
    }
}
