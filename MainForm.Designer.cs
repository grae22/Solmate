namespace SolMate
{
  partial class MainForm
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.uiSearch = new System.Windows.Forms.Button();
      this.uiFilter = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.uiPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.uiSolutions = new System.Windows.Forms.ListBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.uiClean = new System.Windows.Forms.Button();
      this.uiBuild = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.uiSearch);
      this.groupBox1.Controls.Add(this.uiFilter);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.uiPath);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(324, 103);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Search Options:";
      // 
      // uiSearch
      // 
      this.uiSearch.Location = new System.Drawing.Point(226, 35);
      this.uiSearch.Name = "uiSearch";
      this.uiSearch.Size = new System.Drawing.Size(75, 46);
      this.uiSearch.TabIndex = 4;
      this.uiSearch.Text = "Search";
      this.uiSearch.UseVisualStyleBackColor = true;
      this.uiSearch.Click += new System.EventHandler(this.uiSearch_Click);
      // 
      // uiFilter
      // 
      this.uiFilter.Location = new System.Drawing.Point(61, 61);
      this.uiFilter.Name = "uiFilter";
      this.uiFilter.Size = new System.Drawing.Size(149, 20);
      this.uiFilter.TabIndex = 3;
      this.uiFilter.Text = "TTMine_Manager";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(23, 64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Filter:";
      // 
      // uiPath
      // 
      this.uiPath.Location = new System.Drawing.Point(61, 35);
      this.uiPath.Name = "uiPath";
      this.uiPath.Size = new System.Drawing.Size(149, 20);
      this.uiPath.TabIndex = 1;
      this.uiPath.Text = "c:\\dev\\main\\source\\";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(23, 38);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(32, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Path:";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.uiSolutions);
      this.groupBox2.Location = new System.Drawing.Point(12, 121);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
      this.groupBox2.Size = new System.Drawing.Size(534, 338);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Solutions:";
      // 
      // uiSolutions
      // 
      this.uiSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uiSolutions.FormattingEnabled = true;
      this.uiSolutions.Location = new System.Drawing.Point(10, 23);
      this.uiSolutions.Name = "uiSolutions";
      this.uiSolutions.Size = new System.Drawing.Size(514, 305);
      this.uiSolutions.TabIndex = 0;
      this.uiSolutions.SelectedIndexChanged += new System.EventHandler(this.uiSolutions_SelectedIndexChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.uiBuild);
      this.groupBox3.Controls.Add(this.uiClean);
      this.groupBox3.Location = new System.Drawing.Point(346, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(120, 103);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Options:";
      // 
      // uiClean
      // 
      this.uiClean.Location = new System.Drawing.Point(22, 30);
      this.uiClean.Name = "uiClean";
      this.uiClean.Size = new System.Drawing.Size(75, 23);
      this.uiClean.TabIndex = 0;
      this.uiClean.Text = "Clean";
      this.uiClean.UseVisualStyleBackColor = true;
      this.uiClean.Click += new System.EventHandler(this.uiClean_Click);
      // 
      // uiBuild
      // 
      this.uiBuild.Enabled = false;
      this.uiBuild.Location = new System.Drawing.Point(22, 58);
      this.uiBuild.Name = "uiBuild";
      this.uiBuild.Size = new System.Drawing.Size(75, 23);
      this.uiBuild.TabIndex = 1;
      this.uiBuild.Text = "Build";
      this.uiBuild.UseVisualStyleBackColor = true;
      this.uiBuild.Click += new System.EventHandler(this.uiBuild_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(558, 471);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "MainForm";
      this.Text = "Solmate (solution cleaner)";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox uiFilter;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox uiPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ListBox uiSolutions;
    private System.Windows.Forms.Button uiSearch;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button uiClean;
    private System.Windows.Forms.Button uiBuild;
  }
}

