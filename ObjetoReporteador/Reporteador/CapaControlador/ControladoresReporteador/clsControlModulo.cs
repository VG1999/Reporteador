﻿using CapaModelo;
using CapaModelo.Clases_Reporteador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaControlador.ControladoresReporteador
{
    public class clsControlModulo
    {
        clsSentencia sentencia = new clsSentencia();
        clsConexion conexion = new clsConexion();
        DataTable tabla;
        OdbcDataAdapter datos;
        public void insertarModulos(clsModulo modulo)
        {
            try
            {
                string sComando = string.Format("INSERT INTO MODULO(nombre_modulo, descripcion_modulo, estado_modulo) VALUES ('{0}','{1}',{2});", modulo.SNombre, modulo.SDescripcion, modulo.IEstado);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }
        public void modificarModulos(clsModulo modulo)
        {
            try
            {
                string sComando = string.Format("UPDATE MODULO SET nombre_modulo='{1}', descripcion_modulo='{2}' WHERE pk_id_modulo={0};", modulo.IIdModulo, modulo.SNombre, modulo.SDescripcion);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public void eliminarModulos(int iIDModulo)
        {
            try
            {
                string sComando = string.Format("UPDATE MODULO SET estado_modulo=0 WHERE pk_id_modulo={0};", iIDModulo.ToString());
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable obtenerTodo()
        {
            try
            {
                string sComando = string.Format("SELECT pk_id_modulo, nombre_modulo, descripcion_modulo FROM MODULO WHERE estado_modulo=1");
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable obtenerDatos(int iIDModulo)
        {
            try
            {
                string sComando = string.Format("SELECT pk_id_modulo, nombre_modulo, descripcion_modulo FROM MODULO WHERE estado_modulo=1 AND pk_id_modulo={0};", iIDModulo.ToString());
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable obtenerCamposCombobox()
        {
            try
            {
                string sComando = string.Format("SELECT pk_id_modulo, nombre_modulo FROM MODULO WHERE estado_modulo=1");
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
