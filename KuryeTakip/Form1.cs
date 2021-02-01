using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryeTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //seçili row
        DataGridViewRow seciliRow = null;

        //kurye takip tab, sağ click event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                seciliRow = row;
                dataGrid.Focus();
                kuryeTakipMenu.Show(Cursor.Position);
            }
        }

        private void menuItemCikar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(seciliRow);
        }

        private void menuItemEkle_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new DataGridViewRow());
        }


        int siparisNum = 1;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
