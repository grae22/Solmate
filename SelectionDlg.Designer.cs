namespace SolMate
{
  partial class SelectionDlg
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.uiOptionsBox = new System.Windows.Forms.GroupBox();
      this.uiOptions = new System.Windows.Forms.CheckedListBox();
      this.uiOk = new System.Windows.Forms.Button();
      this.uiCancel = new System.Windows.Forms.Button();
      this.uiNone = new System.Windows.Forms.Button();
      this.uiAll = new System.Windows.Forms.Button();
      this.uiOptionsBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // uiOptionsBox
      // 
      this.uiOptionsBox.Controls.Add(this.uiAll);
      this.uiOptionsBox.Controls.Add(this.uiNone);
      this.uiOptionsBox.Controls.Add(this.uiOptions);
      this.uiOptionsBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiOptionsBox.Location = new System.Drawing.Point(10, 10);
      this.uiOptionsBox.Name = "uiOptionsBox";
      this.uiOptionsBox.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
      this.uiOptionsBox.Size = new System.Drawing.Size(264, 338);
      this.uiOptionsBox.TabIndex = 0;
      this.uiOptionsBox.TabStop = false;
      this.uiOptionsBox.Text = "groupBox1";
      // 
      // uiOptions
      // 
      this.uiOptions.CheckOnClick = true;
      this.uiOptions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiOptions.FormattingEnabled = true;
      this.uiOptions.Location = new System.Drawing.Point(10, 38);
      this.uiOptions.Name = "uiOptions";
      this.uiOptions.Size = new System.Drawing.Size(244, 290);
      this.uiOptions.TabIndex = 0;
      this.uiOptions.SelectedIndexChanged += new System.EventHandler(this.uiOptions_SelectedIndexChanged);
      // 
      // uiOk
      // 
      this.uiOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiOk.Location = new System.Drawing.Point(199, 359);
      this.uiOk.Name = "uiOk";
      this.uiOk.Size = new System.Drawing.Size(75, 29);
      this.uiOk.TabIndex = 1;
      this.uiOk.Text = "OK";
      this.uiOk.UseVisualStyleBackColor = true;
      this.uiOk.Click += new System.EventHandler(this.uiOk_Click);
      // 
      // uiCancel
      // 
      this.uiCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.uiCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.uiCancel.Location = new System.Drawing.Point(118, 359);
      this.uiCancel.Name = "uiCancel";
      this.uiCancel.Size = new System.Drawing.Size(75, 29);
      this.uiCancel.TabIndex = 2;
      this.uiCancel.Text = "Cancel";
      this.uiCancel.UseVisualStyleBackColor = true;
      // 
      // uiNone
      // 
      this.uiNone.Location = new System.Drawing.Point(205, 16);
      this.uiNone.Name = "uiNone";
      this.uiNone.Size = new System.Drawing.Size(49, 21);
      this.uiNone.TabIndex = 1;
      this.uiNone.Text = "None";
      this.uiNone.UseVisualStyleBackColor = true;
      this.uiNone.Click += new System.EventHandler(this.uiNone_Click);
      // 
      // uiAll
      // 
      this.uiAll.Location = new System.Drawing.Point(150, 16);
      this.uiAll.Name = "uiAll";
      this.uiAll.Size = new System.Drawing.Size(49, 21);
      this.uiAll.TabIndex = 2;
      this.uiAll.Text = "All";
      this.uiAll.UseVisualStyleBackColor = true;
      this.uiAll.Click += new System.EventHandler(this.uiAll_Click);
      // 
      // SelectionDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.uiCancel;
      this.ClientSize = new System.Drawing.Size(284, 398);
      this.ControlBox = false;
      this.Controls.Add(this.uiCancel);
      this.Controls.Add(this.uiOk);
      this.Controls.Add(this.uiOptionsBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "SelectionDlg";
      this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 50);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "SelectionDlg";
      this.uiOptionsBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox uiOptionsBox;
    private System.Windows.Forms.Button uiOk;
    private System.Windows.Forms.Button uiCancel;
    private System.Windows.Forms.CheckedListBox uiOptions;
    private System.Windows.Forms.Button uiAll;
    private System.Windows.Forms.Button uiNone;
  }
}