using AlmacenTienda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;  // Para mostrar mensajes

namespace AlmacenTienda.DataAccess
{
    public class ProductoDAL
    {
        // Instancia de la clase de conexión (la que creaste antes)
        private ConexionDB conexion = new ConexionDB();

        /// <summary>
        /// MÉTODO 1: Listar todos los productos activos con nombres de categoría y marca
        /// </summary>
        public DataTable ListarProductos()
        {
            string query = @"
                SELECT 
                    p.id_producto AS ID,
                    p.codigo_barras AS 'Código Barras',
                    p.nombre_producto AS Producto,
                    p.precio_venta AS 'Precio Venta',
                    p.stock_actual AS Stock,
                    c.nombre_categoria AS Categoría,
                    m.nombre_marca AS Marca,
                    p.activo AS Activo
                FROM Productos p
                INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                INNER JOIN Marcas m ON p.id_marca = m.id_marca
                WHERE p.activo = 1
                ORDER BY p.nombre_producto";

            return conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// MÉTODO 2: Insertar un nuevo producto
        /// </summary>
        public bool InsertarProducto(Producto p)
        {
            string query = @"
                INSERT INTO Productos (
                    codigo_barras, 
                    nombre_producto, 
                    descripcion, 
                    precio_compra, 
                    precio_venta, 
                    stock_actual, 
                    stock_minimo, 
                    stock_maximo,
                    id_categoria, 
                    id_marca, 
                    id_proveedor, 
                    activo
                ) VALUES (
                    @codigo, 
                    @nombre, 
                    @descrip, 
                    @pCompra, 
                    @pVenta, 
                    @stockAct, 
                    @stockMin, 
                    @stockMax,
                    @idCat, 
                    @idMar, 
                    @idProv, 
                    @activo
                )";

            SqlParameter[] parametros = {
                new SqlParameter("@codigo", string.IsNullOrEmpty(p.CodigoBarras) ? (object)DBNull.Value : p.CodigoBarras),
                new SqlParameter("@nombre", p.NombreProducto),
                new SqlParameter("@descrip", string.IsNullOrEmpty(p.Descripcion) ? (object)DBNull.Value : p.Descripcion),
                new SqlParameter("@pCompra", p.PrecioCompra),
                new SqlParameter("@pVenta", p.PrecioVenta),
                new SqlParameter("@stockAct", p.StockActual),
                new SqlParameter("@stockMin", p.StockMinimo),
                new SqlParameter("@stockMax", p.StockMaximo),
                new SqlParameter("@idCat", p.IdCategoria),
                new SqlParameter("@idMar", p.IdMarca),
                new SqlParameter("@idProv", p.IdProveedor),
                new SqlParameter("@activo", p.Activo)
            };

            int resultado = conexion.EjecutarComando(query, parametros);
            return resultado > 0;
        }

        /// <summary>
        /// MÉTODO 3: Actualizar un producto existente
        /// </summary>
        public bool ActualizarProducto(Producto p)
        {
            string query = @"
                UPDATE Productos SET
                    codigo_barras = @codigo,
                    nombre_producto = @nombre,
                    descripcion = @descrip,
                    precio_compra = @pCompra,
                    precio_venta = @pVenta,
                    stock_actual = @stockAct,
                    stock_minimo = @stockMin,
                    stock_maximo = @stockMax,
                    id_categoria = @idCat,
                    id_marca = @idMar,
                    id_proveedor = @idProv,
                    activo = @activo
                WHERE id_producto = @idProducto";

            SqlParameter[] parametros = {
                new SqlParameter("@idProducto", p.IdProducto),
                new SqlParameter("@codigo", string.IsNullOrEmpty(p.CodigoBarras) ? (object)DBNull.Value : p.CodigoBarras),
                new SqlParameter("@nombre", p.NombreProducto),
                new SqlParameter("@descrip", string.IsNullOrEmpty(p.Descripcion) ? (object)DBNull.Value : p.Descripcion),
                new SqlParameter("@pCompra", p.PrecioCompra),
                new SqlParameter("@pVenta", p.PrecioVenta),
                new SqlParameter("@stockAct", p.StockActual),
                new SqlParameter("@stockMin", p.StockMinimo),
                new SqlParameter("@stockMax", p.StockMaximo),
                new SqlParameter("@idCat", p.IdCategoria),
                new SqlParameter("@idMar", p.IdMarca),
                new SqlParameter("@idProv", p.IdProveedor),
                new SqlParameter("@activo", p.Activo)
            };

            int resultado = conexion.EjecutarComando(query, parametros);
            return resultado > 0;
        }

        /// <summary>
        /// MÉTODO 4: Eliminar (desactivar) un producto
        /// </summary>
        public bool EliminarProducto(int idProducto)
        {
            string query = "UPDATE Productos SET activo = 0 WHERE id_producto = @id";
            SqlParameter[] parametros = { new SqlParameter("@id", idProducto) };

            int resultado = conexion.EjecutarComando(query, parametros);
            return resultado > 0;
        }

        /// <summary>
        /// MÉTODO 5: Buscar productos por nombre o código de barras
        /// </summary>
        public DataTable BuscarProductos(string textoBusqueda)
        {
            string query = @"
                SELECT 
                    p.id_producto AS ID,
                    p.codigo_barras AS 'Código Barras',
                    p.nombre_producto AS Producto,
                    p.precio_venta AS 'Precio Venta',
                    p.stock_actual AS Stock,
                    c.nombre_categoria AS Categoría,
                    m.nombre_marca AS Marca
                FROM Productos p
                INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
                INNER JOIN Marcas m ON p.id_marca = m.id_marca
                WHERE p.activo = 1 
                AND (p.nombre_producto LIKE @busqueda 
                     OR p.codigo_barras LIKE @busqueda)
                ORDER BY p.nombre_producto";

            SqlParameter[] parametros = {
                new SqlParameter("@busqueda", "%" + textoBusqueda + "%")
            };

            return conexion.EjecutarConsulta(query, parametros);
        }

        /// <summary>
        /// MÉTODO 6: Productos con bajo stock (CONSULTA COMPLEJA)
        /// Este es el método que la Persona 3 usará para "Restart Stock"
        /// </summary>
        public DataTable ProductosBajoStock()
        {
            string query = @"
                SELECT 
                    id_producto AS ID,
                    nombre_producto AS Producto,
                    stock_actual AS 'Stock Actual',
                    stock_minimo AS 'Stock Mínimo',
                    (stock_minimo - stock_actual) AS 'Faltante para reabastecer'
                FROM Productos 
                WHERE stock_actual <= stock_minimo 
                AND activo = 1
                ORDER BY (stock_minimo - stock_actual) DESC";

            return conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// MÉTODO 7: Obtener un producto por su ID
        /// </summary>
        public Producto ObtenerProductoPorId(int idProducto)
        {
            string query = "SELECT * FROM Productos WHERE id_producto = @id";
            SqlParameter[] parametros = { new SqlParameter("@id", idProducto) };

            DataTable dt = conexion.EjecutarConsulta(query, parametros);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            Producto p = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"]),
                CodigoBarras = row["codigo_barras"] != DBNull.Value ? row["codigo_barras"].ToString() : "",
                NombreProducto = row["nombre_producto"].ToString(),
                Descripcion = row["descripcion"] != DBNull.Value ? row["descripcion"].ToString() : "",
                PrecioCompra = Convert.ToDecimal(row["precio_compra"]),
                PrecioVenta = Convert.ToDecimal(row["precio_venta"]),
                StockActual = Convert.ToInt32(row["stock_actual"]),
                StockMinimo = Convert.ToInt32(row["stock_minimo"]),
                StockMaximo = Convert.ToInt32(row["stock_maximo"]),
                FechaIngreso = Convert.ToDateTime(row["fecha_ingreso"]),
                IdCategoria = Convert.ToInt32(row["id_categoria"]),
                IdMarca = Convert.ToInt32(row["id_marca"]),
                IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                Activo = Convert.ToBoolean(row["activo"])
            };
            return p;
        }

        /// <summary>
        /// MÉTODO 8: Llamar al Stored Procedure de Productos Más Vendidos
        /// Este es un ejemplo de CONSULTA DIFÍCIL (Stored Procedure)
        /// </summary>
        public DataTable ProductosMasVendidos(int topN = 10, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            // Crear los parámetros del SP
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@topN", topN));

            // Manejar fechas nulas
            if (fechaInicio.HasValue)
                parametros.Add(new SqlParameter("@fechaInicio", fechaInicio.Value));
            else
                parametros.Add(new SqlParameter("@fechaInicio", DBNull.Value));

            if (fechaFin.HasValue)
                parametros.Add(new SqlParameter("@fechaFin", fechaFin.Value));
            else
                parametros.Add(new SqlParameter("@fechaFin", DBNull.Value));

            // Ejecutar el procedimiento almacenado
            return conexion.EjecutarProcedimiento("sp_ProductosMasVendidos", parametros.ToArray());
        }

        /// <summary>
        /// MÉTODO 9: Reporte de valorización de inventario (consulta compleja adicional)
        /// </summary>
        public DataTable ReporteValorizacionInventario()
        {
            string query = @"
        SELECT 
            c.nombre_categoria AS Categoría,
            COUNT(p.id_producto) AS 'Cantidad Productos',
            SUM(p.stock_actual) AS 'Total Unidades',
            SUM(p.stock_actual * p.precio_compra) AS 'Valor a Precio Compra',
            SUM(p.stock_actual * p.precio_venta) AS 'Valor a Precio Venta',
            SUM(p.stock_actual * (p.precio_venta - p.precio_compra)) AS 'Ganancia Potencial'
        FROM Productos p
        INNER JOIN Categorias c ON p.id_categoria = c.id_categoria
        WHERE p.activo = 1
        GROUP BY c.nombre_categoria
        ORDER BY c.nombre_categoria";

            return conexion.EjecutarConsulta(query);
        }
    }
}