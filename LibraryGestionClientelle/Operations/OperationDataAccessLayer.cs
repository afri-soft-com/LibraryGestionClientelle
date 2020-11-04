using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryGestionClientelle.Operations
{
    public class OperationDataAccessLayer
    {
        public void AjouterOperation(OperationModel Op)
        {
            string s = " INSERT INTO tOperation" +
                " (NumOperation, Libelle,  CodeEtatdeBesoin,NomUt, DateOp, DateSysteme) " +
                " VALUES(@a, @b, @c, @d, @da, @db)";

            string[] r = { Op.NumOperation, Op.Libelle, Op.CodeEtatdeBesoin, Op.NomUt, };

            DateTime[] d = { Op.DateOp, DateTime.Now };
            ClassRequette req = new ClassRequette();

            req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnexion(), s, r, d);
        }


        public void SupprimmeerOperation(string  Op)
        {
            string s = " delete FROM tOperation " +
                " WHERE NumOperation=@a  ";
              

            string[] r = { Op };


            DateTime[] d = {  DateTime.Now };
            ClassRequette req = new ClassRequette();

            req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnexion(), s, r, d);
        }

        public int DernierOperation()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    int dernier_operation = 0;
                    string s = "select ISNULL(max(NumOpSource), 0) as NumOpSource from tOperation";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    //SqlDataReader _Reader = objCommand.ExecuteReader();

                    //while (_Reader.Read())
                    //{
                    //            dernier_operation = Convert.ToInt32(_Reader["dernierOperation"]);
                    //}
                    dernier_operation = int.Parse(objCommand.ExecuteScalar().ToString());

                    return dernier_operation;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
}
                }
        }
    }
}
