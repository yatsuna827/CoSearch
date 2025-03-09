using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSearch
{
    public partial class ResultWindow<T> : Form
    {
        public ResultWindow(
            IList<T> data,
            string title = null,
            int? width = null,
            int? height = null,
            DataGridViewCellFormattingEventHandler onFormatCell = null,
            DataGridViewCellEventHandler onDoubleClickCell = null,
            Action<DataGridViewWrapper<T>> modifier = null) 
        {
            InitializeComponent();

            Text = title ?? string.Empty;
            if (width != null) Width = width.Value;
            if (height != null) Height = height.Value;

            if (onFormatCell != null)
                dataGridView1.CellFormatting += onFormatCell;

            if (onDoubleClickCell != null)
                dataGridView1.CellDoubleClick += onDoubleClickCell;

            var wrapper = new DataGridViewWrapper<T>(dataGridView1);
            modifier?.Invoke(wrapper);
            wrapper.SetData(data);
        }
    }
}
