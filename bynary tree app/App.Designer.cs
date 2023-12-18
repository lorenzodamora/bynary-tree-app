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
			this.components = new System.ComponentModel.Container();
			this.txt_setPath = new System.Windows.Forms.TextBox();
			this.btn_setPath = new System.Windows.Forms.Button();
			this.btn_resetPaths = new System.Windows.Forms.Button();
			this.btn_f1 = new System.Windows.Forms.Button();
			this.btn_f2 = new System.Windows.Forms.Button();
			this.btn_create = new System.Windows.Forms.Button();
			this.btn_calcola = new System.Windows.Forms.Button();
			this.tip_soloCsv = new System.Windows.Forms.ToolTip(this.components);
			this.btn_sort = new System.Windows.Forms.Button();
			this.brn_reload = new System.Windows.Forms.Button();
			this.btn_resetPunti = new System.Windows.Forms.Button();
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
			this.txt_setPath.TabIndex = 9;
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
			// btn_resetPaths
			// 
			this.btn_resetPaths.Font = new System.Drawing.Font("Times New Roman", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_resetPaths.Location = new System.Drawing.Point(12, 414);
			this.btn_resetPaths.Name = "btn_resetPaths";
			this.btn_resetPaths.Size = new System.Drawing.Size(122, 24);
			this.btn_resetPaths.TabIndex = 0;
			this.btn_resetPaths.Text = "Nuovo Percorso";
			this.btn_resetPaths.UseVisualStyleBackColor = true;
			this.btn_resetPaths.Visible = false;
			this.btn_resetPaths.Click += new System.EventHandler(this.ResetPaths_Click);
			// 
			// btn_f1
			// 
			this.btn_f1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_f1.Location = new System.Drawing.Point(225, 182);
			this.btn_f1.Name = "btn_f1";
			this.btn_f1.Size = new System.Drawing.Size(139, 58);
			this.btn_f1.TabIndex = 4;
			this.btn_f1.Text = "Crea Binary Tree Folder Dal File";
			this.btn_f1.UseVisualStyleBackColor = true;
			this.btn_f1.Visible = false;
			this.btn_f1.Click += new System.EventHandler(this.F1_Click);
			// 
			// btn_f2
			// 
			this.btn_f2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_f2.Location = new System.Drawing.Point(298, 263);
			this.btn_f2.Name = "btn_f2";
			this.btn_f2.Size = new System.Drawing.Size(139, 58);
			this.btn_f2.TabIndex = 10;
			this.btn_f2.Text = "Crea File dal Binary Tree Folder";
			this.btn_f2.UseVisualStyleBackColor = true;
			this.btn_f2.Visible = false;
			this.btn_f2.Click += new System.EventHandler(this.F2_Click);
			// 
			// btn_create
			// 
			this.btn_create.Font = new System.Drawing.Font("Times New Roman", 10F);
			this.btn_create.Location = new System.Drawing.Point(772, 322);
			this.btn_create.Name = "btn_create";
			this.btn_create.Size = new System.Drawing.Size(139, 47);
			this.btn_create.TabIndex = 11;
			this.btn_create.Text = "Genera file";
			this.btn_create.UseVisualStyleBackColor = true;
			this.btn_create.Visible = false;
			this.btn_create.Click += new System.EventHandler(this.Create_Click);
			// 
			// btn_calcola
			// 
			this.btn_calcola.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_calcola.Location = new System.Drawing.Point(370, 182);
			this.btn_calcola.Name = "btn_calcola";
			this.btn_calcola.Size = new System.Drawing.Size(139, 58);
			this.btn_calcola.TabIndex = 12;
			this.btn_calcola.Text = "Ricalcola ndiretti, ndown, pPosseduti";
			this.btn_calcola.UseVisualStyleBackColor = true;
			this.btn_calcola.Visible = false;
			this.btn_calcola.Click += new System.EventHandler(this.Calcola_Click);
			// 
			// btn_sort
			// 
			this.btn_sort.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_sort.Location = new System.Drawing.Point(515, 182);
			this.btn_sort.Name = "btn_sort";
			this.btn_sort.Size = new System.Drawing.Size(139, 58);
			this.btn_sort.TabIndex = 13;
			this.btn_sort.Text = "Ordina file per id";
			this.btn_sort.UseVisualStyleBackColor = true;
			this.btn_sort.Visible = false;
			this.btn_sort.Click += new System.EventHandler(this.Sort_Click);
			// 
			// brn_reload
			// 
			this.brn_reload.Font = new System.Drawing.Font("Times New Roman", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.brn_reload.Location = new System.Drawing.Point(140, 414);
			this.brn_reload.Name = "brn_reload";
			this.brn_reload.Size = new System.Drawing.Size(72, 24);
			this.brn_reload.TabIndex = 14;
			this.brn_reload.Text = "Reload";
			this.brn_reload.UseVisualStyleBackColor = true;
			this.brn_reload.Click += new System.EventHandler(this.Reload_Click);
			// 
			// btn_resetPunti
			// 
			this.btn_resetPunti.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_resetPunti.Location = new System.Drawing.Point(515, 118);
			this.btn_resetPunti.Name = "btn_resetPunti";
			this.btn_resetPunti.Size = new System.Drawing.Size(139, 58);
			this.btn_resetPunti.TabIndex = 15;
			this.btn_resetPunti.Text = "Reset tutti punti";
			this.btn_resetPunti.UseVisualStyleBackColor = true;
			this.btn_resetPunti.Visible = false;
			this.btn_resetPunti.Click += new System.EventHandler(this.ResetPunti_Click);
			// 
			// App
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_resetPunti);
			this.Controls.Add(this.brn_reload);
			this.Controls.Add(this.btn_sort);
			this.Controls.Add(this.btn_calcola);
			this.Controls.Add(this.btn_create);
			this.Controls.Add(this.btn_f2);
			this.Controls.Add(this.btn_f1);
			this.Controls.Add(this.btn_resetPaths);
			this.Controls.Add(this.btn_setPath);
			this.Controls.Add(this.txt_setPath);
			this.Name = "App";
			this.Text = "Binary Tree App";
			this.Load += new System.EventHandler(this.App_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.TextBox txt_setPath;
		private System.Windows.Forms.Button btn_setPath;
		private System.Windows.Forms.Button btn_resetPaths;
		private System.Windows.Forms.Button btn_f1;
		private System.Windows.Forms.Button btn_f2;
		private System.Windows.Forms.Button btn_create;
		private System.Windows.Forms.Button btn_calcola;
		private System.Windows.Forms.ToolTip tip_soloCsv;
		private System.Windows.Forms.Button btn_sort;
		private System.Windows.Forms.Button brn_reload;
		private System.Windows.Forms.Button btn_resetPunti;
	}
}
