using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class CellNote : DevComponents.DotNetBar.Office2007Form
    {
        private System.Windows.Forms.TextBox _txtNote;
        private System.Windows.Forms.Label _lblShadow;
        private System.Windows.Forms.Label _lblGrip;
       

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="notText">Initial text for the CellNote.</param>
        public CellNote(string noteText)
        {
          
            InitializeComponent();

            //
            // Initialize form
            //
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.None;
            TransparencyKey = BackColor;
            NoteText = noteText;
        }
        public CellNote() : this(string.Empty) { }

       

       

        //------------------------------------------------------------------------------------------------------
        #region ** fields

        private Point _ptCell;
        private bool _editing;

        #endregion

        //------------------------------------------------------------------------------------------------------
        #region ** object model

        /// <summary>
        /// Gets or sets the contents of the note.
        /// </summary>
        public string NoteText
        {
            get { return _txtNote.Text; }
            set { _txtNote.Text = value; }
        }
        /// <summary>
        /// Show the note with a connector to the cell.
        /// </summary>
        /// <param name="r">Position of the cell in screen coordinates.</param>
        public void ShowNote(Rectangle r)
        {
            ShowNote(r, false);
        }
        /// <summary>
        /// Hide the note if it is visible.
        /// </summary>
        public void HideNote()
        {
            if (!_editing)
                Visible = false;
        }
        /// <summary>
        /// Show the note with a connector to the cell and allow the user to edit the note.
        /// </summary>
        /// <param name="r">Position of the cell in screen coordinates.</param>
        public void EditNote(Rectangle r)
        {
            ShowNote(r, true);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------
        #region ** private stuff

        private void ShowNote(Rectangle r, bool editMode)
        {
            if (!Visible)
            {
                // position form
                Left = r.Right + 1;
                Top = r.Y - 30;

                // store cell position
                r = RectangleToClient(r);
                _ptCell = new Point(r.Right, r.Top);

                // start showing/editing the note
                _editing = editMode;
                if (editMode)
                {
                    // show the form
                    Show();

                    // move the cursor over the editor
                    Point pt = new Point(_txtNote.Width / 2, _txtNote.Height / 2);
                    Cursor.Position = _txtNote.PointToScreen(pt);

                    // place selection at the end
                    _txtNote.SelectionStart = 32000;
                }
                else
                {
                    // disable editor so it won't get the focus
                    _txtNote.Enabled = false;

                    // show the form
                    Show();

                    // re-enable editor so it doesn't look disabled
                    _txtNote.Enabled = true;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------
        #region ** overrides/event handlers

        override protected void OnPaint(PaintEventArgs e)
        {
            // draw connector from cell to editor
            Point p = _txtNote.Location;
            e.Graphics.DrawLine(Pens.Black, _ptCell, p);
            base.OnPaint(e);
        }

        // hide form when the editor loses focus
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Visible = false;
        }

        // handle resizing the editor
        private Point _ptDown;
        private Size _szDown;
        private void _lblGrip_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _ptDown = Control.MousePosition;
            _szDown = Size;
        }
        private void _lblGrip_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                Point p = Control.MousePosition;
                Size = new Size(
                    _szDown.Width + (p.X - _ptDown.X),
                    _szDown.Height + (p.Y - _ptDown.Y));
            }
        }

        #endregion

        private void CellNote_Load(object sender, EventArgs e)
        {

        }
    }
}