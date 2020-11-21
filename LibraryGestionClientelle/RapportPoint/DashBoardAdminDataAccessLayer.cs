﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LibraryGestionClientelle.RapportPoint
{
   public class DashBoardAdminDataAccessLayer
    {





        public DashBoardClient AfficherSituationGgeneralAdmin( DateTime date1, DateTime date2)
        {
            DashBoardClient objCust = new DashBoardClient();
            //PointFacuration pf = new PointFacuration();
            //PointConversionModel pc = new PointConversionModel();
            //pf = TotlalDesPointFacturePourUnePeriode(CodeClient, date1, date2);
            //pc = TotlalDesPointConvertiePourUnePeriode(CodeClient, date1, date2);

            objCust.PhoneClient = "GENERALE";
            objCust.PseudoClient = "GENERALE";
            objCust.CodeClient = "GENERALE";
            Double SodeRestourne =  SommeDeRestourneSolde(date2);
            Double SodeConversion = SommeDeConversionSolde(date2);
            objCust.BalanseDePoint = (SodeRestourne - SodeConversion);
            objCust.PointConvertie = SommeDeConversion(date1, date2);
            objCust.PointFacture = SommeDeRestourne(date1, date2);
            objCust.PointInitial = (objCust.BalanseDePoint) - objCust.PointFacture + objCust.PointConvertie;

            objCust.PhoneClient = "0";
            return objCust;

        }




        public double SommeDeRestourne(DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    //  Conn.Open();
                    double Montant = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "SELECT        SUM(tFacturation.MontantRistourne) AS SMontantRistourne "+
" FROM tClients INNER JOIN " +
                        "  tFacturation ON tClients.CodeClient = tFacturation.CodeClient "+
" WHERE(tFacturation.DateFacture BETWEEN @da AND @db)";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Parameters.AddWithValue("@da", date1);
                    objCommand.Parameters.AddWithValue("@db", date2);

                    Montant = double.Parse(objCommand.ExecuteScalar().ToString()) ;
                    return Montant;
                }
                catch
                {
                    return 0;
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



        public double SommeDeRestourneSolde( DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    //  Conn.Open();
                    double Montant = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "SELECT        SUM(tFacturation.MontantRistourne) AS SMontantRistourne " +
" FROM tClients INNER JOIN " +
                        "  tFacturation ON tClients.CodeClient = tFacturation.CodeClient " +
" WHERE(tFacturation.DateFacture  <= @db)";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.Text;
                    //objCommand.Parameters.AddWithValue("@da", date1);
                    objCommand.Parameters.AddWithValue("@db", date2);

                    Montant = double.Parse(objCommand.ExecuteScalar().ToString());
                    return Montant;
                }
                catch
                {
                    return 0;
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

        public double SommeDeConversion(DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    //  Conn.Open();
                    double Montant = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "SELECT        SUM(tConversionPoint.PointConvertie) AS SPointConvertie " +
 " FROM tClients INNER JOIN "+
                      "   tConversionPoint ON tClients.CodeClient = tConversionPoint.CodeClient "+
" WHERE(tConversionPoint.DateOperation  BETWEEN @da AND @db)";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Parameters.AddWithValue("@da", date1);
                    objCommand.Parameters.AddWithValue("@db", date2);

                    Montant = double.Parse(objCommand.ExecuteScalar().ToString());
                    return Montant;
                }
                catch
                {
                    return 0;
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


        public double SommeDeConversionSolde( DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    //  Conn.Open();
                    double Montant = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "SELECT        SUM(tConversionPoint.PointConvertie) AS SPointConvertie " +
 " FROM tClients INNER JOIN " +
                      "   tConversionPoint ON tClients.CodeClient = tConversionPoint.CodeClient " +
" WHERE(tConversionPoint.DateOperation   <= @db)";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.Text;
                   // objCommand.Parameters.AddWithValue("@da", date1);
                    objCommand.Parameters.AddWithValue("@db", date2);

                    Montant = double.Parse(objCommand.ExecuteScalar().ToString());
                    return Montant;
                }
                catch
                {
                    return 0;
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