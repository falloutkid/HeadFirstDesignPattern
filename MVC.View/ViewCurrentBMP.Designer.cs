namespace MVC.View
{
    partial class ViewCurrentBPM
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
            this.label_current_bmp_text = new System.Windows.Forms.Label();
            this.label_current_bmp_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_current_bmp_text
            // 
            this.label_current_bmp_text.AutoSize = true;
            this.label_current_bmp_text.Location = new System.Drawing.Point(13, 18);
            this.label_current_bmp_text.Name = "label_current_bmp_text";
            this.label_current_bmp_text.Size = new System.Drawing.Size(69, 12);
            this.label_current_bmp_text.TabIndex = 0;
            this.label_current_bmp_text.Text = "現行のBPM：";
            // 
            // label_current_bmp_value
            // 
            this.label_current_bmp_value.AutoSize = true;
            this.label_current_bmp_value.Location = new System.Drawing.Point(89, 18);
            this.label_current_bmp_value.Name = "label_current_bmp_value";
            this.label_current_bmp_value.Size = new System.Drawing.Size(23, 12);
            this.label_current_bmp_value.TabIndex = 1;
            this.label_current_bmp_value.Text = "120";
            // 
            // ViewCurrentBPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 42);
            this.ControlBox = false;
            this.Controls.Add(this.label_current_bmp_value);
            this.Controls.Add(this.label_current_bmp_text);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewCurrentBPM";
            this.Text = "ビュー";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_current_bmp_text;
        private System.Windows.Forms.Label label_current_bmp_value;
    }
}