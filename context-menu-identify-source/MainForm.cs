using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace context_menu_identify_source
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region G L Y P H
            var path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Fonts",
                "glyphs.ttf");
            privateFontCollection.AddFontFile(path);
            var fontFamily = privateFontCollection.Families[0];
            Glyphs = new Font(fontFamily, 22F);
            #endregion G L Y P H

            const int DIM = 60;
            var btnNuevoGrupo = new Button
            {
                Location = new Point(TreDevices.Width - DIM - 4, 0),
                Size = new Size(DIM, DIM),
                ForeColor = Color.DarkSeaGreen,
                Font = Glyphs,
                Text = "\uE800",
                //BorderStyle= BorderStyle.None,
            };
            btnNuevoGrupo.Click += BtnNuevoGrupo_Click;
            TreDevices.AfterLabelEdit += TreDevices_AfterLabelEdit;
            TreDevices.Controls.Add(btnNuevoGrupo);
            TreDevices.Nodes.Add("Devices");
        }

        public static Font Glyphs { get; private set; }
        PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        private void BtnNuevoGrupo_Click(object sender, EventArgs e)
        {
            TreeNode newNode = TreDevices.Nodes[0].Nodes.Add("Nuevo grupo de validación");
            TreDevices.Nodes[0].Expand();
            TreDevices.SelectedNode = newNode;
            newNode.Tag = "IN:0";
            newNode.BeginEdit();
        }

        private void TreDevices_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.ContextMenuStrip = new ContextMenuStrip();
            var itemEntrada = new ToolStripMenuItem
            {
                Text = "Entrada",
                Tag = e.Node,
            };
            e.Node.ContextMenuStrip.Items.Add(itemEntrada);
            itemEntrada.Click += InOutItem_Click;
        }

        private void InOutItem_Click(object sender, EventArgs e)
        {
            if ((sender is ToolStripMenuItem tsmi) && (tsmi.Tag is TreeNode node))
            {
                var item = (ToolStripMenuItem)sender;
                ContextMenuStrip menu = (ContextMenuStrip)item.Owner;

                MessageBox.Show($"Clicked {node.Text}");
            }
        }
    }
}
