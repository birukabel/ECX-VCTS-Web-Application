using ECX.VCTS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Util
{
    public class NotificationsDataAccess
    {
        DataAccessUtility da = new DataAccessUtility();
        public IEnumerable<ViolationCaseModel> GetCasesListForNotification(string dbCon, string sp)
        {
            
            List<ViolationCaseModel> CasesList = new List<ViolationCaseModel>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ViolationCaseModel violation = new ViolationCaseModel
                    {
                        AssignDate = reader["AssignDate"].ToString(),
                        CaseStatus = reader["CaseStatus"].ToString(),
                        DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        InvestigatorName = reader["InvestigatorName"].ToString(),
                        PenaltyType = reader["PenaltyType"].ToString(),
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        SuspensionEndDate = reader["SuspensionEndDate"].ToString(),
                        BCCDecisionSummary = reader["BCCSummary"].ToString()
                        
                    };
                    DateTime dt1;
                    if (violation.AssignDate != "")
                        dt1 = (Convert.ToDateTime(violation.AssignDate)).Date;
                    else
                        dt1 = DateTime.Now.Date;
                    DateTime dt2; 
                    if(violation.DecisionPassedDate != "")
                        dt2 = (Convert.ToDateTime(violation.DecisionPassedDate)).Date;
                    else
                        dt2 = DateTime.Now.Date;
                    violation.DateDiffOC = Convert.ToInt32((DateTime.Now.Date - dt1).TotalDays);
                    violation.DateDiffPen = Convert.ToInt32((DateTime.Now.Date - dt2).TotalDays);
                    //violation.DateDiffSus = Convert.ToInt32(((Convert.ToDateTime(violation.SuspensionEndDate).Date) - (DateTime.Now.Date)).TotalDays);
                    CasesList.Add(violation);
                }

                connection.Close();
            }

            return CasesList;
        }

        public void ExtendOverdueViolationCase(string dbCon, Guid id)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spExtendOverdueCase", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        

        public void SettlePenaltyPayment(string dbCon, Guid id)
        {
            Guid penid = GetPenaltyId(dbCon, id);
            List<Guid> vids = new List<Guid>(); 
            vids = GetAllCasesforPenalty(dbCon, penid);
            foreach(Guid vid in vids)
            {
                da.AddToHistoryHelper(dbCon, "Penalized", vid);
                using (SqlConnection connection = new SqlConnection(dbCon))
                {
                    SqlCommand command = new SqlCommand("spSettlePayment", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ViolationCaseId", vid);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    connection.Close();
                }
            }
            
        }

        public Guid GetPenaltyId(string dbCon, Guid id)
        {
            Guid pid = Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetPenaltyId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pid = (Guid)reader["BCCDecisionId"];
                }
                connection.Close();
            }
            return pid;
        }

        public List<Guid> GetAllCasesforPenalty(string dbCon, Guid pid)
        {
            List<Guid> ids = new List<Guid>();
            string sp = "spGetAllCasesforPenalty";
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BCCDecisionId", pid);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add((Guid)reader["ViolationCaseId"]);
                }
                connection.Close();
            }

                return ids;
        }

        public void PostWarning(string dbCon, Guid id, string warning)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spPostWarning", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@warning", warning);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
