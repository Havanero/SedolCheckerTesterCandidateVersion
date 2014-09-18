namespace SedolCheckerGUI
{
    partial class SedolCheckerGUI
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
            this.buttonValidate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxValidationDetails = new System.Windows.Forms.TextBox();
            this.checkBoxUserDefined = new System.Windows.Forms.CheckBox();
            this.checkBoxIsValid = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(260, 16);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(75, 23);
            this.buttonValidate.TabIndex = 3;
            this.buttonValidate.Text = "Validate";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sedol";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(52, 18);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(202, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxValidationDetails);
            this.groupBox1.Controls.Add(this.checkBoxUserDefined);
            this.groupBox1.Controls.Add(this.checkBoxIsValid);
            this.groupBox1.Location = new System.Drawing.Point(15, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // textBoxValidationDetails
            // 
            this.textBoxValidationDetails.Location = new System.Drawing.Point(10, 49);
            this.textBoxValidationDetails.Multiline = true;
            this.textBoxValidationDetails.Name = "textBoxValidationDetails";
            this.textBoxValidationDetails.Size = new System.Drawing.Size(304, 40);
            this.textBoxValidationDetails.TabIndex = 1;
            // 
            // checkBoxUserDefined
            // 
            this.checkBoxUserDefined.AutoSize = true;
            this.checkBoxUserDefined.Location = new System.Drawing.Point(79, 20);
            this.checkBoxUserDefined.Name = "checkBoxUserDefined";
            this.checkBoxUserDefined.Size = new System.Drawing.Size(105, 17);
            this.checkBoxUserDefined.TabIndex = 2;
            this.checkBoxUserDefined.Text = "Is User-Defined?";
            this.checkBoxUserDefined.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsValid
            // 
            this.checkBoxIsValid.AutoSize = true;
            this.checkBoxIsValid.Location = new System.Drawing.Point(7, 20);
            this.checkBoxIsValid.Name = "checkBoxIsValid";
            this.checkBoxIsValid.Size = new System.Drawing.Size(66, 17);
            this.checkBoxIsValid.TabIndex = 0;
            this.checkBoxIsValid.Text = "Is Valid?";
            this.checkBoxIsValid.UseVisualStyleBackColor = true;
            // 
            // SedolCheckerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 167);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonValidate);
            this.Name = "SedolCheckerGUI";
            this.Text = "Sedol Checker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUserDefined;
        private System.Windows.Forms.CheckBox checkBoxIsValid;
        private System.Windows.Forms.TextBox textBoxValidationDetails;
    }
}