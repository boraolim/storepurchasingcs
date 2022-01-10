namespace ProyectoPuntoVenta
{
    partial class frmReporte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabGestion = new System.Windows.Forms.TabControl();
            this.tabProducto = new System.Windows.Forms.TabPage();
            this.dgdataventa = new System.Windows.Forms.DataGridView();
            this.txtfechafin = new System.Windows.Forms.DateTimePicker();
            this.txtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnconsultarventa = new System.Windows.Forms.Button();
            this.btnexportarventa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCategoria = new System.Windows.Forms.TabPage();
            this.dgdatacompra = new System.Windows.Forms.DataGridView();
            this.btnconsultarcompras = new System.Windows.Forms.Button();
            this.cboproveedor = new System.Windows.Forms.ComboBox();
            this.txtfechafincompra = new System.Windows.Forms.DateTimePicker();
            this.txtfechainiciocompra = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnexportarcompras = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabTienda = new System.Windows.Forms.TabPage();
            this.btnconsultarproducto = new System.Windows.Forms.Button();
            this.cbocategoria = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnexportarproducto = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgdataproducto = new System.Windows.Forms.DataGridView();
            this.tabGestion.SuspendLayout();
            this.tabProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdataventa)).BeginInit();
            this.tabCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdatacompra)).BeginInit();
            this.tabTienda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdataproducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGestion
            // 
            this.tabGestion.Controls.Add(this.tabProducto);
            this.tabGestion.Controls.Add(this.tabCategoria);
            this.tabGestion.Controls.Add(this.tabTienda);
            this.tabGestion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabGestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGestion.Location = new System.Drawing.Point(12, 5);
            this.tabGestion.Name = "tabGestion";
            this.tabGestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabGestion.SelectedIndex = 0;
            this.tabGestion.Size = new System.Drawing.Size(1245, 551);
            this.tabGestion.TabIndex = 1;
            // 
            // tabProducto
            // 
            this.tabProducto.BackColor = System.Drawing.Color.SkyBlue;
            this.tabProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabProducto.Controls.Add(this.dgdataventa);
            this.tabProducto.Controls.Add(this.txtfechafin);
            this.tabProducto.Controls.Add(this.txtfechainicio);
            this.tabProducto.Controls.Add(this.label1);
            this.tabProducto.Controls.Add(this.label9);
            this.tabProducto.Controls.Add(this.label10);
            this.tabProducto.Controls.Add(this.btnconsultarventa);
            this.tabProducto.Controls.Add(this.btnexportarventa);
            this.tabProducto.Controls.Add(this.label3);
            this.tabProducto.Controls.Add(this.label2);
            this.tabProducto.Location = new System.Drawing.Point(4, 25);
            this.tabProducto.Name = "tabProducto";
            this.tabProducto.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducto.Size = new System.Drawing.Size(1237, 522);
            this.tabProducto.TabIndex = 0;
            this.tabProducto.Text = "Ventas";
            // 
            // dgdataventa
            // 
            this.dgdataventa.AllowUserToAddRows = false;
            this.dgdataventa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgdataventa.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdataventa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgdataventa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdataventa.EnableHeadersVisualStyles = false;
            this.dgdataventa.GridColor = System.Drawing.Color.DimGray;
            this.dgdataventa.Location = new System.Drawing.Point(26, 157);
            this.dgdataventa.MultiSelect = false;
            this.dgdataventa.Name = "dgdataventa";
            this.dgdataventa.ReadOnly = true;
            this.dgdataventa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdataventa.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgdataventa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgdataventa.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgdataventa.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgdataventa.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdataventa.RowTemplate.Height = 30;
            this.dgdataventa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdataventa.Size = new System.Drawing.Size(1189, 352);
            this.dgdataventa.TabIndex = 44;
            // 
            // txtfechafin
            // 
            this.txtfechafin.CustomFormat = "dd/MM/yyyy";
            this.txtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafin.Location = new System.Drawing.Point(395, 45);
            this.txtfechafin.Name = "txtfechafin";
            this.txtfechafin.Size = new System.Drawing.Size(187, 23);
            this.txtfechafin.TabIndex = 43;
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.CustomFormat = "dd/MM/yyyy";
            this.txtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicio.Location = new System.Drawing.Point(107, 45);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(187, 23);
            this.txtfechainicio.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Fecha Fin:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "Fecha Inicio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "Reporte de Ventas";
            // 
            // btnconsultarventa
            // 
            this.btnconsultarventa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnconsultarventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconsultarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultarventa.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnconsultarventa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnconsultarventa.Location = new System.Drawing.Point(611, 43);
            this.btnconsultarventa.Name = "btnconsultarventa";
            this.btnconsultarventa.Size = new System.Drawing.Size(134, 25);
            this.btnconsultarventa.TabIndex = 36;
            this.btnconsultarventa.Text = "Consultar";
            this.btnconsultarventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconsultarventa.UseVisualStyleBackColor = false;
            this.btnconsultarventa.Click += new System.EventHandler(this.btnconsultarventa_Click);
            // 
            // btnexportarventa
            // 
            this.btnexportarventa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnexportarventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarventa.Image = global::ProyectoPuntoVenta.Properties.Resources.excel;
            this.btnexportarventa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexportarventa.Location = new System.Drawing.Point(26, 111);
            this.btnexportarventa.Name = "btnexportarventa";
            this.btnexportarventa.Size = new System.Drawing.Size(134, 40);
            this.btnexportarventa.TabIndex = 36;
            this.btnexportarventa.Text = "Exportar";
            this.btnexportarventa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarventa.UseVisualStyleBackColor = false;
            this.btnexportarventa.Click += new System.EventHandler(this.btnexportarventa_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(14, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1215, 84);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1215, 418);
            this.label2.TabIndex = 1;
            // 
            // tabCategoria
            // 
            this.tabCategoria.BackColor = System.Drawing.Color.SkyBlue;
            this.tabCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCategoria.Controls.Add(this.dgdatacompra);
            this.tabCategoria.Controls.Add(this.btnconsultarcompras);
            this.tabCategoria.Controls.Add(this.cboproveedor);
            this.tabCategoria.Controls.Add(this.txtfechafincompra);
            this.tabCategoria.Controls.Add(this.txtfechainiciocompra);
            this.tabCategoria.Controls.Add(this.label4);
            this.tabCategoria.Controls.Add(this.label11);
            this.tabCategoria.Controls.Add(this.label5);
            this.tabCategoria.Controls.Add(this.label6);
            this.tabCategoria.Controls.Add(this.btnexportarcompras);
            this.tabCategoria.Controls.Add(this.label7);
            this.tabCategoria.Controls.Add(this.label8);
            this.tabCategoria.Location = new System.Drawing.Point(4, 25);
            this.tabCategoria.Name = "tabCategoria";
            this.tabCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategoria.Size = new System.Drawing.Size(1237, 522);
            this.tabCategoria.TabIndex = 1;
            this.tabCategoria.Text = "Compras";
            // 
            // dgdatacompra
            // 
            this.dgdatacompra.AllowUserToAddRows = false;
            this.dgdatacompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgdatacompra.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdatacompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgdatacompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdatacompra.EnableHeadersVisualStyles = false;
            this.dgdatacompra.GridColor = System.Drawing.Color.DimGray;
            this.dgdatacompra.Location = new System.Drawing.Point(22, 156);
            this.dgdatacompra.MultiSelect = false;
            this.dgdatacompra.Name = "dgdatacompra";
            this.dgdatacompra.ReadOnly = true;
            this.dgdatacompra.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdatacompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgdatacompra.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgdatacompra.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgdatacompra.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgdatacompra.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdatacompra.RowTemplate.Height = 30;
            this.dgdatacompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdatacompra.Size = new System.Drawing.Size(1189, 352);
            this.dgdatacompra.TabIndex = 56;
            // 
            // btnconsultarcompras
            // 
            this.btnconsultarcompras.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnconsultarcompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconsultarcompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultarcompras.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnconsultarcompras.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnconsultarcompras.Location = new System.Drawing.Point(886, 42);
            this.btnconsultarcompras.Name = "btnconsultarcompras";
            this.btnconsultarcompras.Size = new System.Drawing.Size(134, 25);
            this.btnconsultarcompras.TabIndex = 55;
            this.btnconsultarcompras.Text = "Consultar";
            this.btnconsultarcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconsultarcompras.UseVisualStyleBackColor = false;
            this.btnconsultarcompras.Click += new System.EventHandler(this.btnconsultarcompras_Click);
            // 
            // cboproveedor
            // 
            this.cboproveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboproveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboproveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboproveedor.FormattingEnabled = true;
            this.cboproveedor.Location = new System.Drawing.Point(91, 46);
            this.cboproveedor.Name = "cboproveedor";
            this.cboproveedor.Size = new System.Drawing.Size(189, 23);
            this.cboproveedor.TabIndex = 54;
            // 
            // txtfechafincompra
            // 
            this.txtfechafincompra.CustomFormat = "dd/MM/yyyy";
            this.txtfechafincompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafincompra.Location = new System.Drawing.Point(669, 44);
            this.txtfechafincompra.Name = "txtfechafincompra";
            this.txtfechafincompra.Size = new System.Drawing.Size(187, 23);
            this.txtfechafincompra.TabIndex = 52;
            // 
            // txtfechainiciocompra
            // 
            this.txtfechainiciocompra.CustomFormat = "dd/MM/yyyy";
            this.txtfechainiciocompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainiciocompra.Location = new System.Drawing.Point(381, 44);
            this.txtfechainiciocompra.Name = "txtfechainiciocompra";
            this.txtfechainiciocompra.Size = new System.Drawing.Size(187, 23);
            this.txtfechainiciocompra.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(587, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 49;
            this.label4.Text = "Fecha Fin:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 15);
            this.label11.TabIndex = 50;
            this.label11.Text = "Proveedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 50;
            this.label5.Text = "Fecha Inicio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Reporte de Compras";
            // 
            // btnexportarcompras
            // 
            this.btnexportarcompras.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnexportarcompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarcompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarcompras.Image = global::ProyectoPuntoVenta.Properties.Resources.excel;
            this.btnexportarcompras.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexportarcompras.Location = new System.Drawing.Point(22, 110);
            this.btnexportarcompras.Name = "btnexportarcompras";
            this.btnexportarcompras.Size = new System.Drawing.Size(134, 40);
            this.btnexportarcompras.TabIndex = 47;
            this.btnexportarcompras.Text = "Exportar";
            this.btnexportarcompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarcompras.UseVisualStyleBackColor = false;
            this.btnexportarcompras.Click += new System.EventHandler(this.btnexportarcompras_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(10, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1215, 84);
            this.label7.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(10, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1215, 417);
            this.label8.TabIndex = 44;
            // 
            // tabTienda
            // 
            this.tabTienda.BackColor = System.Drawing.Color.SkyBlue;
            this.tabTienda.Controls.Add(this.dgdataproducto);
            this.tabTienda.Controls.Add(this.btnconsultarproducto);
            this.tabTienda.Controls.Add(this.cbocategoria);
            this.tabTienda.Controls.Add(this.label12);
            this.tabTienda.Controls.Add(this.label13);
            this.tabTienda.Controls.Add(this.btnexportarproducto);
            this.tabTienda.Controls.Add(this.label14);
            this.tabTienda.Controls.Add(this.label15);
            this.tabTienda.Location = new System.Drawing.Point(4, 25);
            this.tabTienda.Name = "tabTienda";
            this.tabTienda.Padding = new System.Windows.Forms.Padding(3);
            this.tabTienda.Size = new System.Drawing.Size(1237, 522);
            this.tabTienda.TabIndex = 2;
            this.tabTienda.Text = "Productos";
            // 
            // btnconsultarproducto
            // 
            this.btnconsultarproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnconsultarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconsultarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultarproducto.Image = global::ProyectoPuntoVenta.Properties.Resources.search16;
            this.btnconsultarproducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnconsultarproducto.Location = new System.Drawing.Point(313, 45);
            this.btnconsultarproducto.Name = "btnconsultarproducto";
            this.btnconsultarproducto.Size = new System.Drawing.Size(134, 25);
            this.btnconsultarproducto.TabIndex = 63;
            this.btnconsultarproducto.Text = "Consultar";
            this.btnconsultarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnconsultarproducto.UseVisualStyleBackColor = false;
            this.btnconsultarproducto.Click += new System.EventHandler(this.btnconsultarproducto_Click);
            // 
            // cbocategoria
            // 
            this.cbocategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbocategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocategoria.FormattingEnabled = true;
            this.cbocategoria.Location = new System.Drawing.Point(92, 47);
            this.cbocategoria.Name = "cbocategoria";
            this.cbocategoria.Size = new System.Drawing.Size(189, 23);
            this.cbocategoria.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 60;
            this.label12.Text = "Categoría:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 20);
            this.label13.TabIndex = 59;
            this.label13.Text = "Reporte de Productos";
            // 
            // btnexportarproducto
            // 
            this.btnexportarproducto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnexportarproducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportarproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportarproducto.Image = global::ProyectoPuntoVenta.Properties.Resources.excel;
            this.btnexportarproducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexportarproducto.Location = new System.Drawing.Point(23, 111);
            this.btnexportarproducto.Name = "btnexportarproducto";
            this.btnexportarproducto.Size = new System.Drawing.Size(134, 40);
            this.btnexportarproducto.TabIndex = 58;
            this.btnexportarproducto.Text = "Exportar";
            this.btnexportarproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportarproducto.UseVisualStyleBackColor = false;
            this.btnexportarproducto.Click += new System.EventHandler(this.btnexportarproducto_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(11, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1215, 84);
            this.label14.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(11, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1215, 417);
            this.label15.TabIndex = 55;
            // 
            // dgdataproducto
            // 
            this.dgdataproducto.AllowUserToAddRows = false;
            this.dgdataproducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgdataproducto.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdataproducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgdataproducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdataproducto.EnableHeadersVisualStyles = false;
            this.dgdataproducto.GridColor = System.Drawing.Color.DimGray;
            this.dgdataproducto.Location = new System.Drawing.Point(23, 157);
            this.dgdataproducto.MultiSelect = false;
            this.dgdataproducto.Name = "dgdataproducto";
            this.dgdataproducto.ReadOnly = true;
            this.dgdataproducto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdataproducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgdataproducto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgdataproducto.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgdataproducto.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgdataproducto.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdataproducto.RowTemplate.Height = 30;
            this.dgdataproducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdataproducto.Size = new System.Drawing.Size(1189, 352);
            this.dgdataproducto.TabIndex = 64;
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1269, 568);
            this.ControlBox = false;
            this.Controls.Add(this.tabGestion);
            this.Name = "frmReporte";
            this.Text = "Reporteria";
            this.Load += new System.EventHandler(this.frmReporte_Load);
            this.tabGestion.ResumeLayout(false);
            this.tabProducto.ResumeLayout(false);
            this.tabProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdataventa)).EndInit();
            this.tabCategoria.ResumeLayout(false);
            this.tabCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdatacompra)).EndInit();
            this.tabTienda.ResumeLayout(false);
            this.tabTienda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdataproducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGestion;
        private System.Windows.Forms.TabPage tabProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnexportarventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabCategoria;
        private System.Windows.Forms.TabPage tabTienda;
        private System.Windows.Forms.DateTimePicker txtfechafin;
        private System.Windows.Forms.DateTimePicker txtfechainicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnconsultarventa;
        private System.Windows.Forms.DateTimePicker txtfechafincompra;
        private System.Windows.Forms.DateTimePicker txtfechainiciocompra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnexportarcompras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboproveedor;
        private System.Windows.Forms.ComboBox cbocategoria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnexportarproducto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgdataventa;
        private System.Windows.Forms.Button btnconsultarcompras;
        private System.Windows.Forms.Button btnconsultarproducto;
        private System.Windows.Forms.DataGridView dgdatacompra;
        private System.Windows.Forms.DataGridView dgdataproducto;
    }
}