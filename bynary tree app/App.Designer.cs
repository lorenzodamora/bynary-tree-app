namespace bynary_tree_app
{
	partial class App
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.txt_setPath = new System.Windows.Forms.TextBox();
			this.btn_setPath = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txt_setPath
			// 
			this.txt_setPath.AllowDrop = true;
			this.txt_setPath.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_setPath.Location = new System.Drawing.Point(633, 416);
			this.txt_setPath.Name = "txt_setPath";
			this.txt_setPath.ReadOnly = true;
			this.txt_setPath.Size = new System.Drawing.Size(465, 35);
			this.txt_setPath.TabIndex = 0;
			this.txt_setPath.Text = "Trascina qua il file oppure";
			this.txt_setPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt_setPath.Visible = false;
			this.txt_setPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.SetPath_DragDrop);
			this.txt_setPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.SetPath_DragEnter);
			// 
			// btn_setPath
			// 
			this.btn_setPath.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_setPath.Location = new System.Drawing.Point(772, 375);
			this.btn_setPath.Name = "btn_setPath";
			this.btn_setPath.Size = new System.Drawing.Size(170, 35);
			this.btn_setPath.TabIndex = 1;
			this.btn_setPath.Text = "Scegli file";
			this.btn_setPath.UseVisualStyleBackColor = true;
			this.btn_setPath.Visible = false;
			this.btn_setPath.Click += new System.EventHandler(this.SetPath_Click);
			this.btn_setPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.SetPath_DragDrop);
			this.btn_setPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.SetPath_DragEnter);
			// 
			// App
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_setPath);
			this.Controls.Add(this.txt_setPath);
			this.Name = "App";
			this.Text = "Binary Tree App";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.TextBox txt_setPath;
		private System.Windows.Forms.Button btn_setPath;
	}
}

