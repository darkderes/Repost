using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Bonaterra
{
	/// <summary>
	/// Description uof coneccion.
	/// </summary>
	public class coneccion
	{
		public coneccion()
		{
		}
		MySqlConnection conn;
        static string database = "";
        static string server = "";
        static string user = "";
        static string pass = "";
        public string DB = "";
        public string SER = "";
        public string USR = "";
        public string contraseña = "";

		public void crearConeccion()
		{
            database = "bonaterra_packing";
            server = "186.67.22.124";
            user = "admin";
            pass = "manager";
			try
			{
             String connStr = "Server='"+server+"';database='"+database+"';Uid='"+user+"';Pwd='"+pass+"'";
	    	 conn = new MySqlConnection(connStr);
	    	 conn.Open();		 
			}
			catch
			{
				MessageBox.Show("Imposible Conectar con DataBase, Please Contacte al administrador de Sistemas","Chapalele",MessageBoxButtons.OK,MessageBoxIcon.Warning);	
			}
	    }
	     public void Open()
	    { 	
		    crearConeccion();
    	    conn.Open();
        }
	    public MySqlConnection getConexion()
	    {
		return this.conn;
    	}
    	public void cerrarConexion()
    	{
		conn.Close();
    	}

}
}