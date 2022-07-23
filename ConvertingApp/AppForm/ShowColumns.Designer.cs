namespace ConvertingApp.AppForm
{
    partial class ShowColumns
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgColumns = new System.Windows.Forms.DataGridView();
            this.dgNew = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Newdg = new System.Windows.Forms.DataGridView();
            this.Targets = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Origins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Newdg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(974, 558);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(112, 45);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(824, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgColumns
            // 
            this.dgColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColumns.Location = new System.Drawing.Point(193, 58);
            this.dgColumns.Name = "dgColumns";
            this.dgColumns.RowHeadersWidth = 62;
            this.dgColumns.RowTemplate.Height = 33;
            this.dgColumns.Size = new System.Drawing.Size(721, 50);
            this.dgColumns.TabIndex = 2;
            // 
            // dgNew
            // 
            this.dgNew.AllowUserToAddRows = false;
            this.dgNew.AllowUserToDeleteRows = false;
            this.dgNew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Origin,
            this.Target});
            this.dgNew.Location = new System.Drawing.Point(193, 131);
            this.dgNew.MultiSelect = false;
            this.dgNew.Name = "dgNew";
            this.dgNew.RowHeadersWidth = 62;
            this.dgNew.RowTemplate.Height = 33;
            this.dgNew.Size = new System.Drawing.Size(721, 114);
            this.dgNew.TabIndex = 3;
            this.dgNew.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgColumns_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Origin
            // 
            this.Origin.HeaderText = "Origin";
            this.Origin.MinimumWidth = 8;
            this.Origin.Name = "Origin";
            this.Origin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Origin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Target
            // 
            this.Target.HeaderText = "Target";
            this.Target.MinimumWidth = 8;
            this.Target.Name = "Target";
            this.Target.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Target.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Newdg
            // 
            this.Newdg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Newdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Newdg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Targets,
            this.Origins});
            this.Newdg.Location = new System.Drawing.Point(193, 286);
            this.Newdg.Name = "Newdg";
            this.Newdg.RowHeadersWidth = 62;
            this.Newdg.RowTemplate.Height = 33;
            this.Newdg.Size = new System.Drawing.Size(721, 181);
            this.Newdg.TabIndex = 4;
            // 
            // Targets
            // 
            this.Targets.HeaderText = "Targets";
            this.Targets.MinimumWidth = 8;
            this.Targets.Name = "Targets";
            // 
            // Origins
            // 
            this.Origins.HeaderText = "Origins";
            this.Origins.MinimumWidth = 8;
            this.Origins.Name = "Origins";
            // 
            // ShowColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 650);
            this.Controls.Add(this.Newdg);
            this.Controls.Add(this.dgNew);
            this.Controls.Add(this.dgColumns);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Name = "ShowColumns";
            this.Text = "ShowColumns";
            this.Load += new System.EventHandler(this.ShowColumns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Newdg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNext;
        private Button btnCancel;
        private DataGridView dgColumns;
        private DataGridView dgNew;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewComboBoxColumn Origin;
        private DataGridViewComboBoxColumn Target;
        private DataGridView Newdg;
        private DataGridViewComboBoxColumn Targets;
        private DataGridViewTextBoxColumn Origins;
    }
}