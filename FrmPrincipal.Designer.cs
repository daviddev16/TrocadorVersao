

partial class FrmPrincipal
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.cmbBxSelecaoVersao = new System.Windows.Forms.ComboBox();
            this.btnSelecionarVersao = new System.Windows.Forms.Button();
            this.lsBxLog = new System.Windows.Forms.ListBox();
            this.cmbBxZShop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbBxSelecaoVersao
            // 
            this.cmbBxSelecaoVersao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxSelecaoVersao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBxSelecaoVersao.FormattingEnabled = true;
            this.cmbBxSelecaoVersao.Location = new System.Drawing.Point(12, 23);
            this.cmbBxSelecaoVersao.Name = "cmbBxSelecaoVersao";
            this.cmbBxSelecaoVersao.Size = new System.Drawing.Size(75, 21);
            this.cmbBxSelecaoVersao.TabIndex = 0;
            // 
            // btnSelecionarVersao
            // 
            this.btnSelecionarVersao.Location = new System.Drawing.Point(12, 50);
            this.btnSelecionarVersao.Name = "btnSelecionarVersao";
            this.btnSelecionarVersao.Size = new System.Drawing.Size(169, 29);
            this.btnSelecionarVersao.TabIndex = 1;
            this.btnSelecionarVersao.Text = "Alterar Versão";
            this.btnSelecionarVersao.UseVisualStyleBackColor = true;
            this.btnSelecionarVersao.Click += new System.EventHandler(this.btnSelecionarVersao_Click);
            // 
            // lsBxLog
            // 
            this.lsBxLog.FormattingEnabled = true;
            this.lsBxLog.Location = new System.Drawing.Point(187, 23);
            this.lsBxLog.Name = "lsBxLog";
            this.lsBxLog.Size = new System.Drawing.Size(321, 56);
            this.lsBxLog.TabIndex = 2;
            // 
            // cmbBxZShop
            // 
            this.cmbBxZShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBxZShop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBxZShop.FormattingEnabled = true;
            this.cmbBxZShop.Items.AddRange(new object[] {
            "wshop.exe",
            "ishop.exe"});
            this.cmbBxZShop.Location = new System.Drawing.Point(93, 23);
            this.cmbBxZShop.Name = "cmbBxZShop";
            this.cmbBxZShop.Size = new System.Drawing.Size(88, 21);
            this.cmbBxZShop.TabIndex = 3;
            this.cmbBxZShop.SelectedIndexChanged += new System.EventHandler(this.cmbBxZShop_SelectedIndexChanged);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 102);
            this.Controls.Add(this.cmbBxZShop);
            this.Controls.Add(this.lsBxLog);
            this.Controls.Add(this.btnSelecionarVersao);
            this.Controls.Add(this.cmbBxSelecaoVersao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox cmbBxSelecaoVersao;
    private System.Windows.Forms.Button btnSelecionarVersao;
    private System.Windows.Forms.ListBox lsBxLog;
    private System.Windows.Forms.ComboBox cmbBxZShop;
}

