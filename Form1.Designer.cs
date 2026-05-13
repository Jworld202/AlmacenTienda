namespace AlmacenTienda
{
    partial class FrmProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvProductos    = new System.Windows.Forms.DataGridView();
            this.txtBuscar       = new System.Windows.Forms.TextBox();
            this.btnBuscar       = new System.Windows.Forms.Button();
            this.btnGuardar      = new System.Windows.Forms.Button();
            this.btnEliminar     = new System.Windows.Forms.Button();
            this.btnLimpiar      = new System.Windows.Forms.Button();
            this.btnRestarStock  = new System.Windows.Forms.Button();
            this.btnBajoStock    = new System.Windows.Forms.Button();
            this.txtCodigo       = new System.Windows.Forms.TextBox();
            this.txtNombre       = new System.Windows.Forms.TextBox();
            this.txtDescripcion  = new System.Windows.Forms.TextBox();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta  = new System.Windows.Forms.TextBox();
            this.txtStock        = new System.Windows.Forms.TextBox();
            this.nudStockMin     = new System.Windows.Forms.NumericUpDown();
            this.nudStockMax     = new System.Windows.Forms.NumericUpDown();
            this.nudStock        = new System.Windows.Forms.NumericUpDown();
            this.cmbCategoria    = new System.Windows.Forms.ComboBox();
            this.cmbMarca        = new System.Windows.Forms.ComboBox();
            this.cmbProveedor    = new System.Windows.Forms.ComboBox();
            this.lblConteo       = new System.Windows.Forms.Label();
            this.lblModoEdicion  = new System.Windows.Forms.Label();

            // Labels
            var lblBuscar       = new System.Windows.Forms.Label();
            var lblCodigo       = new System.Windows.Forms.Label();
            var lblNombre       = new System.Windows.Forms.Label();
            var lblDescripcion  = new System.Windows.Forms.Label();
            var lblPrecioCompra = new System.Windows.Forms.Label();
            var lblPrecioVenta  = new System.Windows.Forms.Label();
            var lblStock        = new System.Windows.Forms.Label();
            var lblStockMin     = new System.Windows.Forms.Label();
            var lblStockMax     = new System.Windows.Forms.Label();
            var lblCategoria    = new System.Windows.Forms.Label();
            var lblMarca        = new System.Windows.Forms.Label();
            var lblProveedor    = new System.Windows.Forms.Label();
            var pnlFormulario   = new System.Windows.Forms.Panel();
            var pnlBotones      = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();

            // ── FORM ────────────────────────────────────────────────────
            this.Text          = "AlmacenTienda — Gestión de Productos";
            this.Size          = new System.Drawing.Size(1100, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.Load         += new System.EventHandler(this.FrmProductos_Load);

            // ── BUSCAR ──────────────────────────────────────────────────
            lblBuscar.Text     = "Buscar:";
            lblBuscar.Location = new System.Drawing.Point(12, 15);
            lblBuscar.Size     = new System.Drawing.Size(55, 23);

            this.txtBuscar.Location = new System.Drawing.Point(70, 12);
            this.txtBuscar.Size     = new System.Drawing.Size(280, 23);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);

            this.btnBuscar.Text     = "🔍 Buscar";
            this.btnBuscar.Location = new System.Drawing.Point(358, 11);
            this.btnBuscar.Size     = new System.Drawing.Size(95, 25);
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Click   += new System.EventHandler(this.btnBuscar_Click);

            this.btnBajoStock.Text     = "⚠ Bajo Stock";
            this.btnBajoStock.Location = new System.Drawing.Point(460, 11);
            this.btnBajoStock.Size     = new System.Drawing.Size(105, 25);
            this.btnBajoStock.BackColor = System.Drawing.Color.DarkOrange;
            this.btnBajoStock.ForeColor = System.Drawing.Color.White;
            this.btnBajoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajoStock.Click   += new System.EventHandler(this.btnBajoStock_Click);

            this.lblConteo.Text      = "Total: 0 productos";
            this.lblConteo.Location  = new System.Drawing.Point(580, 15);
            this.lblConteo.Size      = new System.Drawing.Size(200, 23);
            this.lblConteo.ForeColor = System.Drawing.Color.Gray;

            // ── DATAGRIDVIEW ─────────────────────────────────────────────
            this.dgvProductos.Location                  = new System.Drawing.Point(12, 45);
            this.dgvProductos.Size                      = new System.Drawing.Size(760, 600);
            this.dgvProductos.AllowUserToAddRows        = false;
            this.dgvProductos.ReadOnly                  = true;
            this.dgvProductos.SelectionMode             = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.AutoSizeColumnsMode       = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor           = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle               = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProductos.RowHeadersVisible         = false;
            this.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvProductos.CellClick                += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // ── PANEL FORMULARIO (derecha) ────────────────────────────────
            int px = 785; // X del panel

            this.lblModoEdicion.Text      = "➕ Modo: NUEVO";
            this.lblModoEdicion.Location  = new System.Drawing.Point(px, 45);
            this.lblModoEdicion.Size      = new System.Drawing.Size(280, 20);
            this.lblModoEdicion.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModoEdicion.ForeColor = System.Drawing.Color.Green;

            int y = 70; int h = 28; int gap = 35;

            lblCodigo.Text      = "Código Barras:";
            lblCodigo.Location  = new System.Drawing.Point(px, y);
            lblCodigo.Size      = new System.Drawing.Size(100, h);
            this.txtCodigo.Location = new System.Drawing.Point(px + 105, y);
            this.txtCodigo.Size     = new System.Drawing.Size(185, h);
            y += gap;

            lblNombre.Text      = "* Nombre:";
            lblNombre.Location  = new System.Drawing.Point(px, y);
            lblNombre.Size      = new System.Drawing.Size(100, h);
            this.txtNombre.Location = new System.Drawing.Point(px + 105, y);
            this.txtNombre.Size     = new System.Drawing.Size(185, h);
            y += gap;

            lblDescripcion.Text      = "Descripción:";
            lblDescripcion.Location  = new System.Drawing.Point(px, y);
            lblDescripcion.Size      = new System.Drawing.Size(100, h);
            this.txtDescripcion.Location = new System.Drawing.Point(px + 105, y);
            this.txtDescripcion.Size     = new System.Drawing.Size(185, 50);
            this.txtDescripcion.Multiline = true;
            y += gap + 20;

            lblPrecioCompra.Text      = "* P. Compra:";
            lblPrecioCompra.Location  = new System.Drawing.Point(px, y);
            lblPrecioCompra.Size      = new System.Drawing.Size(100, h);
            this.txtPrecioCompra.Location = new System.Drawing.Point(px + 105, y);
            this.txtPrecioCompra.Size     = new System.Drawing.Size(185, h);
            y += gap;

            lblPrecioVenta.Text      = "* P. Venta:";
            lblPrecioVenta.Location  = new System.Drawing.Point(px, y);
            lblPrecioVenta.Size      = new System.Drawing.Size(100, h);
            this.txtPrecioVenta.Location = new System.Drawing.Point(px + 105, y);
            this.txtPrecioVenta.Size     = new System.Drawing.Size(185, h);
            y += gap;

            lblStock.Text      = "* Stock:";
            lblStock.Location  = new System.Drawing.Point(px, y);
            lblStock.Size      = new System.Drawing.Size(100, h);
            this.txtStock.Location = new System.Drawing.Point(px + 105, y);
            this.txtStock.Size     = new System.Drawing.Size(185, h);
            this.nudStock.Location = new System.Drawing.Point(px + 105, y);
            this.nudStock.Size     = new System.Drawing.Size(185, h);
            this.nudStock.Maximum  = 99999;
            y += gap;

            lblStockMin.Text      = "Stock Mín:";
            lblStockMin.Location  = new System.Drawing.Point(px, y);
            lblStockMin.Size      = new System.Drawing.Size(100, h);
            this.nudStockMin.Location = new System.Drawing.Point(px + 105, y);
            this.nudStockMin.Size     = new System.Drawing.Size(185, h);
            this.nudStockMin.Maximum  = 99999;
            y += gap;

            lblStockMax.Text      = "Stock Máx:";
            lblStockMax.Location  = new System.Drawing.Point(px, y);
            lblStockMax.Size      = new System.Drawing.Size(100, h);
            this.nudStockMax.Location = new System.Drawing.Point(px + 105, y);
            this.nudStockMax.Size     = new System.Drawing.Size(185, h);
            this.nudStockMax.Maximum  = 99999;
            y += gap;

            lblCategoria.Text      = "Categoría:";
            lblCategoria.Location  = new System.Drawing.Point(px, y);
            lblCategoria.Size      = new System.Drawing.Size(100, h);
            this.cmbCategoria.Location     = new System.Drawing.Point(px + 105, y);
            this.cmbCategoria.Size         = new System.Drawing.Size(185, h);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Items.Add("(Sin categoría)");
            this.cmbCategoria.SelectedIndex = 0;
            y += gap;

            lblMarca.Text      = "Marca:";
            lblMarca.Location  = new System.Drawing.Point(px, y);
            lblMarca.Size      = new System.Drawing.Size(100, h);
            this.cmbMarca.Location     = new System.Drawing.Point(px + 105, y);
            this.cmbMarca.Size         = new System.Drawing.Size(185, h);
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Items.Add("(Sin marca)");
            this.cmbMarca.SelectedIndex = 0;
            y += gap;

            lblProveedor.Text      = "Proveedor:";
            lblProveedor.Location  = new System.Drawing.Point(px, y);
            lblProveedor.Size      = new System.Drawing.Size(100, h);
            this.cmbProveedor.Location     = new System.Drawing.Point(px + 105, y);
            this.cmbProveedor.Size         = new System.Drawing.Size(185, h);
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Items.Add("(Sin proveedor)");
            this.cmbProveedor.SelectedIndex = 0;
            y += gap + 10;

            // ── BOTONES ─────────────────────────────────────────────────
            this.btnGuardar.Text      = "💾 Guardar";
            this.btnGuardar.Location  = new System.Drawing.Point(px, y);
            this.btnGuardar.Size      = new System.Drawing.Size(140, 35);
            this.btnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click    += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.Text      = "🗑 Eliminar";
            this.btnEliminar.Location  = new System.Drawing.Point(px + 150, y);
            this.btnEliminar.Size      = new System.Drawing.Size(140, 35);
            this.btnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Click    += new System.EventHandler(this.btnEliminar_Click);
            y += 45;

            this.btnRestarStock.Text      = "📦 Restar Stock (Venta)";
            this.btnRestarStock.Location  = new System.Drawing.Point(px, y);
            this.btnRestarStock.Size      = new System.Drawing.Size(185, 35);
            this.btnRestarStock.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnRestarStock.ForeColor = System.Drawing.Color.White;
            this.btnRestarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestarStock.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestarStock.Click    += new System.EventHandler(this.btnRestarStock_Click);

            this.btnLimpiar.Text      = "🔄 Limpiar";
            this.btnLimpiar.Location  = new System.Drawing.Point(px + 195, y);
            this.btnLimpiar.Size      = new System.Drawing.Size(95, 35);
            this.btnLimpiar.BackColor = System.Drawing.Color.SlateGray;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Click    += new System.EventHandler(this.btnLimpiar_Click);

            // ── AGREGAR AL FORM ──────────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblBuscar, this.txtBuscar, this.btnBuscar, this.btnBajoStock, this.lblConteo,
                this.dgvProductos,
                this.lblModoEdicion,
                lblCodigo,       this.txtCodigo,
                lblNombre,       this.txtNombre,
                lblDescripcion,  this.txtDescripcion,
                lblPrecioCompra, this.txtPrecioCompra,
                lblPrecioVenta,  this.txtPrecioVenta,
                lblStock,        this.nudStock,
                lblStockMin,     this.nudStockMin,
                lblStockMax,     this.nudStockMax,
                lblCategoria,    this.cmbCategoria,
                lblMarca,        this.cmbMarca,
                lblProveedor,    this.cmbProveedor,
                this.btnGuardar, this.btnEliminar,
                this.btnRestarStock, this.btnLimpiar
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Controles declarados ────────────────────────────────────────────
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRestarStock;
        private System.Windows.Forms.Button btnBajoStock;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.NumericUpDown nudStockMin;
        private System.Windows.Forms.NumericUpDown nudStockMax;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.Label lblModoEdicion;
    }
}
