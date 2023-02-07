Have you considered just using the `Tag` property of `itemEntrada`?

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

[![screenshot][1]][1]

  [1]: https://i.stack.imgur.com/GNOjb.png