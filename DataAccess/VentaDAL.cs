using AlmacenTienda.DataAccess;
using AlmacenTienda.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AlmacenTiendaApp.DataAccess
{
    public class VentaDAL
    {
        private ConexionDB conexion = new ConexionDB();

        /// <summary>
        /// Registrar una venta COMPLETA con TRANSACCIÓN
        /// Esto asegura que si algo falla, NO se guarde nada
        /// </summary>
        public bool RegistrarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            // Usamos using para asegurar que la conexión se cierre automáticamente
            using (SqlConnection conn = conexion.GetConnection())
            {
                conn.Open();

                // 1. Iniciar la transacción
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    // 2. Insertar el encabezado de la venta
                    string sqlVenta = @"
                        INSERT INTO Salidas_Venta (
                            id_cliente, 
                            id_empleado, 
                            subtotal, 
                            impuesto, 
                            total_venta, 
                            metodo_pago, 
                            estado,
                            fecha_venta,
                            numero_ticket
                        ) VALUES (
                            @idCliente, 
                            @idEmpleado, 
                            @subtotal, 
                            @impuesto, 
                            @total, 
                            @metodo, 
                            @estado,
                            @fechaVenta,
                            @numeroTicket
                        );
                        SELECT SCOPE_IDENTITY();";  // Esto devuelve el ID de la venta recién insertada

                    SqlCommand cmdVenta = new SqlCommand(sqlVenta, conn, transaccion);

                    // Agregar parámetros
                    cmdVenta.Parameters.AddWithValue("@idCliente", venta.IdCliente.HasValue ? (object)venta.IdCliente.Value : DBNull.Value);
                    cmdVenta.Parameters.AddWithValue("@idEmpleado", venta.IdEmpleado);
                    cmdVenta.Parameters.AddWithValue("@subtotal", venta.Subtotal);
                    cmdVenta.Parameters.AddWithValue("@impuesto", venta.Impuesto);
                    cmdVenta.Parameters.AddWithValue("@total", venta.TotalVenta);
                    cmdVenta.Parameters.AddWithValue("@metodo", venta.MetodoPago);
                    cmdVenta.Parameters.AddWithValue("@estado", venta.Estado);
                    cmdVenta.Parameters.AddWithValue("@fechaVenta", venta.FechaVenta);
                    cmdVenta.Parameters.AddWithValue("@numeroTicket", string.IsNullOrEmpty(venta.NumeroTicket) ? (object)DBNull.Value : venta.NumeroTicket);

                    // Ejecutar y obtener el ID generado
                    int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                    // 3. Insertar cada detalle de la venta
                    string sqlDetalle = @"
                        INSERT INTO Detalle_Venta (
                            id_venta, 
                            id_producto, 
                            cantidad, 
                            precio_unitario, 
                            descuento
                        ) VALUES (
                            @idVenta, 
                            @idProducto, 
                            @cantidad, 
                            @precioUnitario, 
                            @descuento
                        )";

                    foreach (var detalle in detalles)
                    {
                        SqlCommand cmdDetalle = new SqlCommand(sqlDetalle, conn, transaccion);
                        cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                        cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@descuento", detalle.Descuento);

                        cmdDetalle.ExecuteNonQuery();
                    }

                    // 4. ¡TODO SALIÓ BIEN! Confirmar la transacción
                    transaccion.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    // 5. Algo salió mal: DESHACER todo
                    transaccion.Rollback();

                    // Guardar el error para depuración
                    System.Windows.Forms.MessageBox.Show("Error al registrar venta: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Listar todas las ventas con información del cliente y empleado
        /// </summary>
        public DataTable ListarVentas()
        {
            string query = @"
                SELECT 
                    v.id_venta AS ID,
                    v.fecha_venta AS Fecha,
                    c.nombre_completo AS Cliente,
                    e.nombre_empleado + ' ' + e.apellido_empleado AS Vendedor,
                    v.total_venta AS Total,
                    v.metodo_pago AS 'Método Pago',
                    v.estado AS Estado
                FROM Salidas_Venta v
                LEFT JOIN Clientes c ON v.id_cliente = c.id_cliente
                INNER JOIN Empleados e ON v.id_empleado = e.id_empleado
                ORDER BY v.fecha_venta DESC";

            return conexion.EjecutarConsulta(query);
        }

        /// <summary>
        /// Obtener los detalles de una venta específica
        /// </summary>
        public DataTable ObtenerDetallesVenta(int idVenta)
        {
            string query = @"
                SELECT 
                    dv.id_detalle_venta,
                    p.nombre_producto AS Producto,
                    dv.cantidad AS Cantidad,
                    dv.precio_unitario AS 'Precio Unitario',
                    dv.descuento AS Descuento,
                    (dv.cantidad * dv.precio_unitario * (1 - dv.descuento/100)) AS Subtotal
                FROM Detalle_Venta dv
                INNER JOIN Productos p ON dv.id_producto = p.id_producto
                WHERE dv.id_venta = @idVenta";

            SqlParameter[] parametros = { new SqlParameter("@idVenta", idVenta) };
            return conexion.EjecutarConsulta(query, parametros);
        }

        /// <summary>
        /// Reporte de ventas por período
        /// </summary>
        public DataTable ReporteVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            string query = @"
                SELECT 
                    CAST(v.fecha_venta AS DATE) AS Fecha,
                    COUNT(*) AS 'Cantidad Ventas',
                    SUM(v.total_venta) AS 'Total Vendido'
                FROM Salidas_Venta v
                WHERE v.fecha_venta BETWEEN @inicio AND @fin
                GROUP BY CAST(v.fecha_venta AS DATE)
                ORDER BY Fecha DESC";

            SqlParameter[] parametros = {
                new SqlParameter("@inicio", fechaInicio),
                new SqlParameter("@fin", fechaFin)
            };

            return conexion.EjecutarConsulta(query, parametros);
        }
    }
}
