using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LibraryGestionClientelle.RapportPoint
{
    public class DashBoardDattaAcceessLayer
    {



        public DashBoardClient totalAficherDashBoardCleient(string CodeClient, DateTime date1, DateTime date2)
        {
            DashBoardClient objCust = new DashBoardClient();
            PointFacuration pf  = new PointFacuration() ;
            PointConversionModel pc = new PointConversionModel();
            pf = TotlalDesPointFacturePourUnePeriode(CodeClient, date1, date2);
            pc = TotlalDesPointConvertiePourUnePeriode(CodeClient, date1, date2);

            objCust.PhoneClient = pf.PhoneClient;
            objCust.PseudoClient = pf.PseudoClient;
            objCust.CodeClient = pf.CodeClient;

            objCust.BalanseDePoint = (pf.SommeFact - pc.SommePoint);
            objCust.PointConvertie = pc.SpointConvertie;
            objCust.PointFacture = pf.SommeFact;
            objCust.PointInitial = (pf.SommeFact - pc.SommePoint) - pf.SommeFact + pc.SpointConvertie;

            objCust.PhoneClient = "0";
            return objCust;

        }
        public class PointFacuration
        {
            public string PhoneClient { get; set; }
            public string PseudoClient { get; set; }


            public string CodeClient { get; set; }

            public double SMontantRistourne { get; set; }
            public double SommeFact { get; set; }
        }

        public class PointConversionModel
        {
           

            public double SpointConvertie { get; set; }
            public double SommePoint { get; set; }
        }
        public PointFacuration TotlalDesPointFacturePourUnePeriode(string CodeClient, DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    Conn.Open();
                    PointFacuration objCust = new PointFacuration();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();


                    String s1 = "SommeDePointFacturePourUnePeriode";

                    SqlCommand objCommand = new SqlCommand(s1, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CodeClient", CodeClient);
                    objCommand.Parameters.AddWithValue("@Date1", date1);
                    objCommand.Parameters.AddWithValue("@Date2", date2);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                       
                        objCust.PseudoClient = _Reader["PseudoClient"].ToString();
                        objCust.PhoneClient = _Reader["PhoneClient"].ToString();
                        objCust.CodeClient = _Reader["CodeClient"].ToString();
                        // objCust.MontantApayer = _Reader["NoRccm"].ToString();
                        try { objCust.SMontantRistourne = Convert.ToDouble(_Reader["SMontantRistourne"]); } catch { objCust.SMontantRistourne = 0; }
                        try { objCust.SommeFact = Convert.ToDouble(_Reader["SommeFact"]); } catch { objCust.SommeFact = 0; }
                       // try { objCust.SommePaye = Convert.ToDouble(_Reader["SommePaye"]); } catch { objCust.SommePaye = 0; }

                      


                       // _list.Add(objCust);
                    }

                    return objCust;
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


        public PointConversionModel TotlalDesPointConvertiePourUnePeriode(string CodeClient, DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    Conn.Open();
                    PointConversionModel objCust = new PointConversionModel();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();


                    String s1 = "SommeDesPointConvertiePourUnePeriode";

                    SqlCommand objCommand = new SqlCommand(s1, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CodeClient", CodeClient);
                    objCommand.Parameters.AddWithValue("@Date1", date1);
                    objCommand.Parameters.AddWithValue("@Date2", date2);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {

                        //objCust.PseudoClient = _Reader["PseudoClient"].ToString();
                        //objCust.PhoneClient = _Reader["PhoneClient"].ToString();
                        // objCust.MontantApayer = _Reader["NoRccm"].ToString();
                        try { objCust.SpointConvertie = Convert.ToDouble(_Reader["SpointConvertie"]); } catch { objCust.SpointConvertie = 0; }
                        try { objCust.SommePoint = Convert.ToDouble(_Reader["SommePoint"]); } catch { objCust.SommePoint = 0; }
                        // try { objCust.SommePaye = Convert.ToDouble(_Reader["SommePaye"]); } catch { objCust.SommePaye = 0; }




                        // _list.Add(objCust);
                    }

                    return objCust;
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
