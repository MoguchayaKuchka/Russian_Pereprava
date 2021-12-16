
namespace Russian_Pereprava
{
    partial class Rus_per
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
            this.Go_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Go_btn
            // 
            this.Go_btn.Location = new System.Drawing.Point(1262, 600);
            this.Go_btn.Name = "Go_btn";
            this.Go_btn.Size = new System.Drawing.Size(97, 58);
            this.Go_btn.TabIndex = 9;
            this.Go_btn.Text = "ЖАТЬ СЮДА";
            this.Go_btn.UseVisualStyleBackColor = true;
            this.Go_btn.Click += new System.EventHandler(this.Go_btn_Click);
            // 
            // Rus_per
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Russian_Pereprava.Properties.Resources.background_new;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.Go_btn);
            this.DoubleBuffered = true;
            this.Name = "Rus_per";
            this.Text = "Русские вперёд";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Go_btn_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Go_btn_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Go_btn;
    }
}

