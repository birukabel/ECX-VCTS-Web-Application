using ECX.VCTS.Models;
using ECX.VCTS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Util
{
    public class ManagerDataAccess
    {
        DataAccessUtility da = new DataAccessUtility();
        public void AssignInvestigatorToCases(string dbCon, CasesAssignmentViewModel cases)
        {
            List<Guid> CasesIdList = new List<Guid>();

            foreach (OthersViewModel vcm in cases.OthersModel)
            {
                CasesIdList.Add(vcm.ViolationModel.ViolationCaseId);
            }
            foreach (SurveillanceViewModel vcm in cases.SurveillanceModel)
            {
                CasesIdList.Add(vcm.ViolationModel.ViolationCaseId);
            }
            foreach (TradeViewModel vcm in cases.TradeModel)
            {
                CasesIdList.Add(vcm.ViolationModel.ViolationCaseId);
            }
            foreach (Guid violId in CasesIdList)
            {
                List<Guid> idList = da.GetAllIdentifiers(dbCon);
                Guid historyId = da.UniqueIdentifier(idList);
                ViolationCaseHistory history = new ViolationCaseHistory();
                history.StatusName = "Witing Manager";
                history.ViolationCaseHistoryId = historyId;
                history.ViolationCaseId = violId;
                da.AddCaseToHistory(dbCon, history);
                da.UpdateInvestigatorName(dbCon, violId, cases.InvestigatorName, "Under Investigation");
            }

        }

        public CasesToDropViewModel GetAllCasesToDrop(string dbCon, string invName)
        {
            CasesToDropViewModel toDropCases = new CasesToDropViewModel
            {
                OthersModel = new List<OthersViewModel>(),
                QualityModel = new List<QualityViewModel>(),
                SurveillanceModel = new List<SurveillanceViewModel>(),
                TradeModel = new List<TradeViewModel>()
            };

            List<object> objListOthers = da.GetAllCasesForViews(dbCon, 'o', "spGetAllOtherJoined");
            List<object> objListQuality = da.GetAllCasesForViews(dbCon, 'q', "spGetAllQualityJoined");
            List<object> objListSurv = da.GetAllCasesForViews(dbCon, 's', "spGetAllSurveillanceJoined");
            List<object> objListTrade = da.GetAllCasesForViews(dbCon, 't', "spGetAllTradeJoined");

            foreach (OthersViewModel others in objListOthers)
                toDropCases.OthersModel.Add(others);
            foreach (QualityViewModel quality in objListQuality)
                toDropCases.QualityModel.Add(quality);
            foreach (SurveillanceViewModel surv in objListSurv)
                toDropCases.SurveillanceModel.Add(surv);
            foreach (TradeViewModel trade in objListTrade)
                toDropCases.TradeModel.Add(trade);

            return toDropCases;
        }

        public List<BCCCasesViewModel> GetAllBCCCases(string dbCon)
        {
            List<BCCCasesViewModel> modelList = new List<BCCCasesViewModel>();


            List<object> objListOthers = da.GetAllCasesForViews(dbCon, 'o', "spGetAllPassBCCOther");
            List<object> objListQuality = da.GetAllCasesForViews(dbCon, 'q', "spGetAllPassBCCQuality");
            List<object> objListSurv = da.GetAllCasesForViews(dbCon, 's', "spGetAllPassBCCSurveillance");
            List<object> objListTrade = da.GetAllCasesForViews(dbCon, 't', "spGetAllPassBCCTrade");

            foreach (OthersViewModel other in objListOthers)
            {
                BCCCasesViewModel model = new BCCCasesViewModel
                {
                    ViolationCaseId = other.ViolationModel.ViolationCaseId,
                    ViolationCenterName = other.ViolationModel.ExchangeCenterName,
                    ViolationSummary = other.ViolationModel.ViolationSummary,
                    DecisionViolationType = other.ViolationModel.ViolationType,
                    DecisionViolatorName = other.ViolationModel.ViolatorName
                };
                modelList.Add(model);
            }

            foreach (QualityViewModel quality in objListQuality)
            {
                BCCCasesViewModel model = new BCCCasesViewModel
                {
                    ViolationCaseId = quality.ViolationModel.ViolationCaseId,
                    ViolationCenterName = quality.ViolationModel.ExchangeCenterName,
                    ViolationSummary = quality.ViolationModel.ViolationSummary,
                    DecisionViolationType = quality.ViolationModel.ViolationType,
                    DecisionViolatorName = quality.ViolationModel.ViolatorName
                };
                modelList.Add(model);
            }

            foreach (SurveillanceViewModel surv in objListSurv)
            {
                BCCCasesViewModel model = new BCCCasesViewModel
                {
                    ViolationCaseId = surv.ViolationModel.ViolationCaseId,
                    ViolationCenterName = surv.ViolationModel.ExchangeCenterName,
                    ViolationSummary = surv.ViolationModel.ViolationSummary,
                    DecisionViolationType = surv.ViolationModel.ViolationType,
                    DecisionViolatorName = surv.ViolationModel.ViolatorName
                };
                modelList.Add(model);
            }

            foreach (TradeViewModel trade in objListTrade)
            {
                BCCCasesViewModel model = new BCCCasesViewModel
                {
                    ViolationCaseId = trade.ViolationModel.ViolationCaseId,
                    ViolationCenterName = trade.ViolationModel.ExchangeCenterName,
                    ViolationSummary = trade.ViolationModel.ViolationSummary,
                    DecisionViolationType = trade.ViolationModel.ViolationType,
                    DecisionViolatorName = trade.ViolationModel.ViolatorName
                };
                modelList.Add(model);
            }


            return modelList;
        }

        public PassBCCDecisionViewModel GetAllCasesForBCCDecision(string dbCon)
        {
            PassBCCDecisionViewModel PassDecision = new PassBCCDecisionViewModel
            {
                OthersModel = new List<OthersViewModel>(),
                QualityModel = new List<QualityViewModel>(),
                SurveillanceModel = new List<SurveillanceViewModel>(),
                TradeModel = new List<TradeViewModel>()
            };
            List<object> objListOthers = da.GetAllCasesForViews(dbCon, 'o', "spGetAllPassBCCOther");
            List<object> objListQuality = da.GetAllCasesForViews(dbCon, 'q', "spGetAllPassBCCQuality");
            List<object> objListSurv = da.GetAllCasesForViews(dbCon, 's', "spGetAllPassBCCSurveillance");
            List<object> objListTrade = da.GetAllCasesForViews(dbCon, 't', "spGetAllPassBCCTrade");

            foreach (OthersViewModel other in objListOthers)
                PassDecision.OthersModel.Add(other);
            foreach (QualityViewModel quality in objListQuality)
                PassDecision.QualityModel.Add(quality);
            foreach (SurveillanceViewModel surv in objListSurv)
                PassDecision.SurveillanceModel.Add(surv);
            foreach (TradeViewModel trade in objListTrade)
                PassDecision.TradeModel.Add(trade);
            return PassDecision;
        }

        public void UpdateManagerRemark(string dbCon, Guid id, string remark, string sp)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("ManagerRemark", remark);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        public void PassBCCDecision(string dbCon, BCCCasesListClass model)
        {
            Guid PenId = GetUniquePenaltyId(dbCon);
            foreach (BCCCasesViewModel vm in model.BCCCasesList)
            {
                Guid caseId = vm.ViolationCaseId;
                
                switch (model.DecisionPenaltyType)
                {
                    case "Dismissed":
                        
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleDismissedPenalties(dbCon, caseId, model.BCCSummary, PenId);
                        break;
                    case "Financial":
                        
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleFinancialPenalties(dbCon, caseId, model.DecisionAmountPenalized, 
                            model.DecisionPassedDate, model.BCCSummary, PenId);
                        break;
                    case "Suspension":
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleSuspensionPenalties(dbCon, caseId, model.SuspensionBeginingDate,
                            model.SuspensionEndingDate, model.BCCSummary, PenId);
                        break;
                    case "Termination":
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleTerminationPenalties(dbCon, caseId, 
                            model.TerminationDate, model.BCCSummary, PenId);
                        break;
                }
            }
        }

        public void PassBCCDecision(string dbCon, PassBCCDecisionViewModel model)
        {
            if (model.OthersModel.Count > 0)
            {
                if (model.DecisionPenaltyType == "Dismissed")
                {
                    foreach (OthersViewModel viewModel in model.OthersModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleDismissedPenalties(dbCon, caseId);
                    }
                }
                else if (model.DecisionPenaltyType == "Financial")
                {
                    foreach (OthersViewModel viewModel in model.OthersModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleFinancialPenalties(dbCon, caseId, model.DecisionAmountPenalized, model.DecisionPassedDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Suspension")
                {
                    foreach (OthersViewModel viewModel in model.OthersModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleSuspensionPenalties(dbCon, caseId, model.SuspensionBeginingDate, model.SuspensionEndingDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Termination")
                {
                    foreach (OthersViewModel viewModel in model.OthersModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleTerminationPenalties(dbCon, caseId, model.TerminationDate);
                    }
                }
            }

            if (model.QualityModel.Count > 0)
            {
                if (model.DecisionPenaltyType == "Dismissed")
                {
                    foreach (QualityViewModel viewModel in model.QualityModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleDismissedPenalties(dbCon, caseId);
                    }
                }
                else if (model.DecisionPenaltyType == "Financial")
                {
                    foreach (QualityViewModel viewModel in model.QualityModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleFinancialPenalties(dbCon, caseId, model.DecisionAmountPenalized, model.DecisionPassedDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Suspension")
                {
                    foreach (QualityViewModel viewModel in model.QualityModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleSuspensionPenalties(dbCon, caseId, model.SuspensionBeginingDate, model.SuspensionEndingDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Termination")
                {
                    foreach (QualityViewModel viewModel in model.QualityModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleTerminationPenalties(dbCon, caseId, model.TerminationDate);
                    }
                }
            }
            if (model.SurveillanceModel.Count > 0)
            {
                if (model.DecisionPenaltyType == "Dismissed")
                {
                    foreach (SurveillanceViewModel viewModel in model.SurveillanceModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleDismissedPenalties(dbCon, caseId);
                    }
                }
                else if (model.DecisionPenaltyType == "Financial")
                {
                    foreach (SurveillanceViewModel viewModel in model.SurveillanceModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleFinancialPenalties(dbCon, caseId, model.DecisionAmountPenalized, model.DecisionPassedDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Suspension")
                {
                    foreach (SurveillanceViewModel viewModel in model.SurveillanceModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleSuspensionPenalties(dbCon, caseId, model.SuspensionBeginingDate, model.SuspensionEndingDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Termination")
                {
                    foreach (SurveillanceViewModel viewModel in model.SurveillanceModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleTerminationPenalties(dbCon, caseId, model.TerminationDate);
                    }
                }
            }
            if (model.TradeModel.Count > 0)
            {
                if (model.DecisionPenaltyType == "Dismissed")
                {
                    foreach (TradeViewModel viewModel in model.TradeModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleDismissedPenalties(dbCon, caseId);
                    }
                }
                else if (model.DecisionPenaltyType == "Financial")
                {
                    foreach (TradeViewModel viewModel in model.TradeModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleFinancialPenalties(dbCon, caseId, model.DecisionAmountPenalized, model.DecisionPassedDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Suspension")
                {
                    foreach (TradeViewModel viewModel in model.TradeModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleSuspensionPenalties(dbCon, caseId, model.SuspensionBeginingDate, model.SuspensionEndingDate);
                    }
                }
                else if (model.DecisionPenaltyType == "Termination")
                {
                    foreach (TradeViewModel viewModel in model.TradeModel)
                    {
                        Guid caseId = viewModel.ViolationModel.ViolationCaseId;
                        da.AddToHistoryHelper(dbCon, "Sent To BCC", caseId);
                        HandleTerminationPenalties(dbCon, caseId, model.TerminationDate);
                    }
                }
            }
        }

        public void HandleDismissedPenalties(string dbCon, Guid id, string bccsum="None", Guid pid=new Guid())
        {
            string strdpr = "spAddFreeOfPenalty";
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(strdpr, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@BCCSummary", bccsum);
                command.Parameters.AddWithValue("@BCCDecisionId", pid);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }
        public void HandleFinancialPenalties(string dbCon, Guid id, double amount, string effdate, string bccsum="None", Guid pid=new Guid())
        {
            string strdpr = "spAddFinancialPenalty";
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(strdpr, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@DeciosionEffectiveDate", effdate);
                command.Parameters.AddWithValue("@AmountPenalized", Convert.ToDecimal(amount));
                command.Parameters.AddWithValue("@BCCSummary", bccsum);
                command.Parameters.AddWithValue("@BCCDecisionId", pid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }
        public void HandleSuspensionPenalties(string dbCon, Guid id, 
            string beginDate, string endDate, string bccsum="None", Guid pid=new Guid())
        {
            string strdpr = "spAddSuspensionPenalty";
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(strdpr, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@SuspensionBeginingDate", Convert.ToDateTime(beginDate));
                command.Parameters.AddWithValue("@SuspensionEndDate", Convert.ToDateTime(endDate));
                command.Parameters.AddWithValue("@BCCSummary", bccsum);
                command.Parameters.AddWithValue("@BCCDecisionId", pid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }
        public void HandleTerminationPenalties(string dbCon, Guid id, string terminationDate, 
            string bccsum = "None", Guid pid=new Guid())
        {
            string strdpr = "spAddTerminationPenalty";
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(strdpr, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@TerminationDate", Convert.ToDateTime(terminationDate));
                command.Parameters.AddWithValue("@BCCSummary", bccsum);
                command.Parameters.AddWithValue("@BCCDecisionId", pid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                connection.Close();
            }
        }

        public List<Guid> AllPenaltyIds(string con)
        {
            List<Guid> ids = new List<Guid>();
            string strdpr = "spGetAllPenaltyIds";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(strdpr, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!DBNull.Value.Equals(reader["BCCDecisionId"]))
                        ids.Add((Guid)reader["BCCDecisionId"]);
                }
            }

            return ids;
        }

        public Guid GetUniquePenaltyId(string con)
        {
            Guid id = Guid.NewGuid();
            List<Guid> ids = new List<Guid>();
            bool isUnique = true;
            ids = AllPenaltyIds(con);
            while (isUnique)
            {
                foreach(Guid uid in ids)
                {
                    if (uid == id) { isUnique = false; break; }
                }
                if (!isUnique)
                {
                    id = Guid.NewGuid();
                    isUnique = true;
                }
                else
                {
                    isUnique = false;
                }
            }

            return id;
        }

    }
}
