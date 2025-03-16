namespace ChessGame
{
    partial class ChessGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boardTableLayoutPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // boardTableLayoutPanel
            // 
            boardTableLayoutPanel.ColumnCount = 8;
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.Location = new Point(12, 12);
            boardTableLayoutPanel.Name = "boardTableLayoutPanel";
            boardTableLayoutPanel.RowCount = 8;
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            boardTableLayoutPanel.Size = new Size(1160, 1137);
            boardTableLayoutPanel.TabIndex = 0;
            boardTableLayoutPanel.CellPaint += boardTableLayoutPanel_CellPaint;
            boardTableLayoutPanel.MouseClick += boardTableLayoutPanel_MouseClick;
            // 
            // ChessGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1184, 1161);
            Controls.Add(boardTableLayoutPanel);
            Name = "ChessGame";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel boardTableLayoutPanel;
    }
}
