namespace ventas2
{
    partial class Busqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Busqueda));
            this.PanelTargetas2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // PanelTargetas2
            // 
            this.PanelTargetas2.AutoSize = true;
            this.PanelTargetas2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTargetas2.BackgroundImage")));
            this.PanelTargetas2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelTargetas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTargetas2.Location = new System.Drawing.Point(0, 0);
            this.PanelTargetas2.Name = "PanelTargetas2";
            this.PanelTargetas2.Size = new System.Drawing.Size(1004, 459);
            this.PanelTargetas2.TabIndex = 0;
            // 
            // Busqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1004, 459);
            this.Controls.Add(this.PanelTargetas2);
            this.Name = "Busqueda";
            this.Text = "Busqueda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelTargetas2;
    }
}