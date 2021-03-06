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
    public class clsControlAplicativo
    {
        clsSentencia sentencia = new clsSentencia();
        clsConexion conexion = new clsConexion();
        private DataTable tabla;
        private OdbcDataAdapter datos;
        public void insertarAplicativo(clsAplicativo aplicativo)
        {
            try
            {
                string sComando = string.Format("INSERT INTO APLICATIVO(fk_id_modulo, nombre_aplicativo, descripcion_aplicativo, estado_aplicativo) VALUES ({0},'{1}','{2}',{3});", aplicativo.IModulo, aplicativo.SNombre, aplicativo.SDescripcion,aplicativo.IEstado);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }
        public void modificarAplicativo(clsAplicativo aplicativo)
        {
            try
            {
                string sComando = string.Format("UPDATE APLICATIVO SET fk_id_modulo={1}, nombre_aplicativo='{2}', descripcion_aplicativo='{3}' WHERE pk_id_aplicativo={0};", aplicativo.IIdAplicativo, aplicativo.IModulo, aplicativo.SNombre, aplicativo.SDescripcion);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Modificar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        public void eliminarAplicativo(int iIDApp)
        {
            try
            {
                string sComando = string.Format("UPDATE APLICATIVO SET estado_aplicativo=0 WHERE pk_id_aplicativo={0};", iIDApp.ToString());
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
                string sComando = string.Format("SELECT pk_id_aplicativo, fk_id_modulo, nombre_aplicativo, descripcion_aplicativo FROM APLICATIVO WHERE estado_aplicativo=1");
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
        public DataTable obtenerCamposCombobox(string sCampo1, string sCampo2, string sTabla, string sEstado)
        {
            try
            {
                string sComando = string.Format("SELECT "+sCampo1 +" ,"+sCampo2+" FROM "+sTabla+" WHERE "+sEstado+"=1");
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
                string sComando = string.Format("SELECT pk_id_aplicativo, fk_id_modulo, nombre_aplicativo, descripcion_aplicativo FROM APLICATIVO WHERE estado_aplicativo=1 AND pk_id_aplicativo={0};", iIDModulo.ToString());
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
