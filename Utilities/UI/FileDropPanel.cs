using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities.IO;
using System.IO;
using Utilities.Events;

namespace Utilities.UI
{
    public partial class FileDropPanel : UserControl
    {
        static readonly float[] _dashValues;
        private Pen _whitePen;
        private Brush _blueBrush;
        internal event StringEventHandler FileDropped;

        static FileDropPanel()
        {
            _dashValues = new float[]{ 5 , 5};
        }

        public FileDropPanel()
        {
            InitializeComponent();

            ResizeRedraw = true;
            _whitePen = new Pen(Color.White, 2);
            _blueBrush = new SolidBrush(Color.FromArgb(255, 24, 102, 143));
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Count() > 1 )
            {
                return;
            }

            if (FileDropped != null)
            {
                FileDropped(files[0]);
            }

            this.Hide();
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // check if only one file is over
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Count() == 1)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void OnDragLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FileDropPanel_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.Visible = false;

            Form parent = this.ParentForm;
            parent.AllowDrop = true;
            parent.DragEnter += OnParentDragEnter;
        }

        void OnParentDragEnter(object sender, DragEventArgs e)
        {
            this.Show();
            this.BringToFront();
        }
        
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // sometimes the DragLeave event doesn't gets called.
            // check if user has mouse button down
            if ((e.Button & MouseButtons.Left) == 0)
            {
                this.Hide();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);

            // draw square dashed rectangle
            const int padding = 15; // px
            const int doublePadding = padding * 2;
            
            _whitePen.DashPattern = _dashValues;
            
            // compute the ends of the square
            Rectangle dashedRectange = new Rectangle(padding, padding, e.ClipRectangle.Width - doublePadding, e.ClipRectangle.Height - doublePadding);

            e.Graphics.FillRectangle(_blueBrush, e.ClipRectangle);
            e.Graphics.DrawRectangle(_whitePen, dashedRectange);
        }
    }
}
