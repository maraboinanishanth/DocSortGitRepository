using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    internal class ProgressBarEx : ProgressBar
    {
        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

       // private LinearGradientMode GradMode = LinearGradientMode.ForwardDiagonal;
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)(rec.Width * ((double)base.Value / Maximum)) - 4;
            rec.Height -= 4;

            if (rec.Width == 0) rec.Width = -4;
            if (rec.Height == 0) rec.Height = -4;
            brush = new LinearGradientBrush(rec, System.Drawing.ColorTranslator.FromHtml("#19abaa"), System.Drawing.ColorTranslator.FromHtml("#19abaa"), LinearGradientMode.ForwardDiagonal);
            //brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}