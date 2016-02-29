namespace CodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TableNames = new System.Windows.Forms.CheckedListBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.DataTableNames = new System.Windows.Forms.ComboBox();
            this.DBGroup = new System.Windows.Forms.GroupBox();
            this.SettingGroup = new System.Windows.Forms.GroupBox();
            this.SNTBool = new System.Windows.Forms.ComboBox();
            this.EFBool = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNamespace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGenerator = new System.Windows.Forms.Button();
            this.TxtExtends = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DBGroup.SuspendLayout();
            this.SettingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableNames
            // 
            this.TableNames.CheckOnClick = true;
            this.TableNames.FormattingEnabled = true;
            this.TableNames.ImeMode = System.Windows.Forms.ImeMode.On;
            this.TableNames.Location = new System.Drawing.Point(3, 48);
            this.TableNames.Name = "TableNames";
            this.TableNames.Size = new System.Drawing.Size(202, 260);
            this.TableNames.TabIndex = 0;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(133, 17);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(62, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // DataTableNames
            // 
            this.DataTableNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTableNames.FormattingEnabled = true;
            this.DataTableNames.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DataTableNames.Location = new System.Drawing.Point(5, 20);
            this.DataTableNames.Name = "DataTableNames";
            this.DataTableNames.Size = new System.Drawing.Size(121, 20);
            this.DataTableNames.TabIndex = 2;
            this.DataTableNames.SelectedIndexChanged += new System.EventHandler(this.DataTableNames_SelectedIndexChanged);
            // 
            // DBGroup
            // 
            this.DBGroup.Controls.Add(this.DataTableNames);
            this.DBGroup.Controls.Add(this.TableNames);
            this.DBGroup.Controls.Add(this.BtnRefresh);
            this.DBGroup.Location = new System.Drawing.Point(1, 1);
            this.DBGroup.Name = "DBGroup";
            this.DBGroup.Size = new System.Drawing.Size(212, 316);
            this.DBGroup.TabIndex = 3;
            this.DBGroup.TabStop = false;
            this.DBGroup.Text = "Data Bases";
            // 
            // SettingGroup
            // 
            this.SettingGroup.Controls.Add(this.TxtExtends);
            this.SettingGroup.Controls.Add(this.label6);
            this.SettingGroup.Controls.Add(this.SNTBool);
            this.SettingGroup.Controls.Add(this.EFBool);
            this.SettingGroup.Controls.Add(this.label5);
            this.SettingGroup.Controls.Add(this.label4);
            this.SettingGroup.Controls.Add(this.TxtClassName);
            this.SettingGroup.Controls.Add(this.label3);
            this.SettingGroup.Controls.Add(this.TxtNamespace);
            this.SettingGroup.Controls.Add(this.label2);
            this.SettingGroup.Controls.Add(this.TxtSavePath);
            this.SettingGroup.Controls.Add(this.label1);
            this.SettingGroup.Controls.Add(this.BtnGenerator);
            this.SettingGroup.Location = new System.Drawing.Point(219, 1);
            this.SettingGroup.Name = "SettingGroup";
            this.SettingGroup.Size = new System.Drawing.Size(343, 316);
            this.SettingGroup.TabIndex = 4;
            this.SettingGroup.TabStop = false;
            this.SettingGroup.Text = "Setting";
            // 
            // SNTBool
            // 
            this.SNTBool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SNTBool.FormattingEnabled = true;
            this.SNTBool.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SNTBool.Items.AddRange(new object[] {
            "True",
            "False"});
            this.SNTBool.Location = new System.Drawing.Point(132, 198);
            this.SNTBool.Name = "SNTBool";
            this.SNTBool.Size = new System.Drawing.Size(121, 20);
            this.SNTBool.TabIndex = 10;
            // 
            // EFBool
            // 
            this.EFBool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EFBool.FormattingEnabled = true;
            this.EFBool.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.EFBool.Items.AddRange(new object[] {
            "False",
            "True"});
            this.EFBool.Location = new System.Drawing.Point(132, 162);
            this.EFBool.Name = "EFBool";
            this.EFBool.Size = new System.Drawing.Size(121, 20);
            this.EFBool.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Support Null Type：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Encapsulate FieId：";
            // 
            // TxtClassName
            // 
            this.TxtClassName.Location = new System.Drawing.Point(87, 94);
            this.TxtClassName.Name = "TxtClassName";
            this.TxtClassName.Size = new System.Drawing.Size(230, 21);
            this.TxtClassName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Class Name：";
            // 
            // TxtNamespace
            // 
            this.TxtNamespace.Location = new System.Drawing.Point(87, 56);
            this.TxtNamespace.Name = "TxtNamespace";
            this.TxtNamespace.Size = new System.Drawing.Size(230, 21);
            this.TxtNamespace.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Namespace：";
            // 
            // TxtSavePath
            // 
            this.TxtSavePath.Location = new System.Drawing.Point(87, 20);
            this.TxtSavePath.Name = "TxtSavePath";
            this.TxtSavePath.Size = new System.Drawing.Size(230, 21);
            this.TxtSavePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Save Path：";
            // 
            // BtnGenerator
            // 
            this.BtnGenerator.Location = new System.Drawing.Point(104, 281);
            this.BtnGenerator.Name = "BtnGenerator";
            this.BtnGenerator.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerator.TabIndex = 0;
            this.BtnGenerator.Text = "Generator";
            this.BtnGenerator.UseVisualStyleBackColor = true;
            this.BtnGenerator.Click += new System.EventHandler(this.BtnGenerator_Click);
            // 
            // TxtExtends
            // 
            this.TxtExtends.Location = new System.Drawing.Point(87, 131);
            this.TxtExtends.Name = "TxtExtends";
            this.TxtExtends.Size = new System.Drawing.Size(230, 21);
            this.TxtExtends.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Extends：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 321);
            this.Controls.Add(this.SettingGroup);
            this.Controls.Add(this.DBGroup);
            this.Name = "MainForm";
            this.Text = "CodeGenerator";
            this.DBGroup.ResumeLayout(false);
            this.SettingGroup.ResumeLayout(false);
            this.SettingGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TableNames;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.ComboBox DataTableNames;
        private System.Windows.Forms.GroupBox DBGroup;
        private System.Windows.Forms.GroupBox SettingGroup;
        private System.Windows.Forms.TextBox TxtNamespace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGenerator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SNTBool;
        private System.Windows.Forms.ComboBox EFBool;
        private System.Windows.Forms.TextBox TxtExtends;
        private System.Windows.Forms.Label label6;
    }
}

