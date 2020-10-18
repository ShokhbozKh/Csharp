namespace IceCream.UserControls
{
    partial class PartnersControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addPartnerButton = new System.Windows.Forms.Button();
            this.editPartnerButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.partners = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addPartnerButton
            // 
            this.addPartnerButton.Location = new System.Drawing.Point(58, 789);
            this.addPartnerButton.Name = "addPartnerButton";
            this.addPartnerButton.Size = new System.Drawing.Size(158, 53);
            this.addPartnerButton.TabIndex = 1;
            this.addPartnerButton.Text = "Добавить";
            this.addPartnerButton.UseVisualStyleBackColor = true;
            // 
            // editPartnerButton
            // 
            this.editPartnerButton.Location = new System.Drawing.Point(269, 789);
            this.editPartnerButton.Name = "editPartnerButton";
            this.editPartnerButton.Size = new System.Drawing.Size(158, 53);
            this.editPartnerButton.TabIndex = 2;
            this.editPartnerButton.Text = "Изменить";
            this.editPartnerButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 789);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(716, 679);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partners,
            this.phoneNumber});
            this.dataGridView1.Location = new System.Drawing.Point(58, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(549, 627);
            this.dataGridView1.TabIndex = 5;
            // 
            // partners
            // 
            this.partners.HeaderText = "Партнеры";
            this.partners.MinimumWidth = 8;
            this.partners.Name = "partners";
            this.partners.Width = 150;
            // 
            // phoneNumber
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.phoneNumber.HeaderText = "Телефон";
            this.phoneNumber.MinimumWidth = 8;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Width = 150;
            // 
            // PartnersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editPartnerButton);
            this.Controls.Add(this.addPartnerButton);
            this.Name = "PartnersControl";
            this.Size = new System.Drawing.Size(968, 900);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addPartnerButton;
        private System.Windows.Forms.Button editPartnerButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn partners;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
    }
}
