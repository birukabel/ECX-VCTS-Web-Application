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
    public class InvestigatorDataAccess
    {
        DataAccessUtility da = new DataAccessUtility();
        public List<AvailableQualityCasesViewModel> GetAvailCases(string dbCon)
        {
            List<AvailableQualityCasesViewModel> AvailCases = new List<AvailableQualityCasesViewModel>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("[spGetAvailableQualityCases]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CaseStatus", "Signed");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AvailableQualityCasesViewModel Avail = new AvailableQualityCasesViewModel();
                    ViolationCaseModel violation = new ViolationCaseModel
                    {
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        SupportingDocuments = reader["SupportingDocuments"].ToString(),
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        ReportDate = reader["ReportDate"].ToString()

                    };
                    QualityViolationAttributesModel quality = new QualityViolationAttributesModel
                    {
                        ArrivalDate = reader["ArrivalDate"].ToString(),
                        DispatchNumber = reader["DispatchNumber"].ToString(),
                        DriverName = reader["DriverName"].ToString(),
                        GRNReference = reader["GRNReference"].ToString(),
                        LaboratoryDecision = reader["LaboratoryDecision"].ToString(),
                        LabResultComment = reader["LabResultComment"].ToString(),
                        MemberRepresentativeName = reader["MemberRepresentativeName"].ToString(),
                        NumberofAdultratedBags = Convert.ToInt32(reader["NumberofAdultratedBags"]),
                        QualityGradeResult = reader["QualityGradeResult"].ToString(),
                        QualitySubCategory = reader["QualitySubCategory"].ToString(),
                        QualityViolationsAttributeId = (Guid)reader["QualityViolationSAttributeId"],
                        SamplerName = reader["SamplerName"].ToString(),
                        SamplingInspectorName = reader["SamplingInspectorName"].ToString(),
                        SamplingTicketComment = reader["SamplingTicketComment"].ToString(),
                        TotalNumberofBags = Convert.ToInt32(reader["TotalNumberofBags"]),
                        TrailerPlateNumber = reader["TrailerPlateNumber"].ToString(),
                        TruckPlateNumber = reader["TruckPlateNumber"].ToString(),
                        UndertakingOfficerRemark = reader["UndertakingOfficerRemark"].ToString()
                    };
                    Avail.ViolationCase = violation;
                    Avail.QualityCase = quality;
                    AvailCases.Add(Avail);
                }
            }
            return AvailCases;
        }

        public AvailableQualityCasesViewModel GetCase(string dbCon, List<AvailableQualityCasesViewModel> avilList, Guid id)
        {
            AvailableQualityCasesViewModel model = new AvailableQualityCasesViewModel();
            foreach (AvailableQualityCasesViewModel m in avilList)
                if (m.ViolationCase.ViolationCaseId == id)
                    model = m;
            return model;
        }

        public void AcceptedCase(string dbCon, AvailableQualityCasesViewModel model, string XStatus)
        {
            da.AddToHistoryHelper(dbCon, "Under Investigation", model.ViolationCase.ViolationCaseId);
            da.UpdateInvestigatorName(dbCon, model.ViolationCase.ViolationCaseId, model.InvestigatorName, "Under Investigation");
        }

        public OwnedCasesViewModel GetAllOwnedCases(string dbCon, string invName="NONE")
        {
            OwnedCasesViewModel OwnedCases = new OwnedCasesViewModel
            {
                OthersModel = new List<OthersViewModel>(),
                QualityModel = new List<QualityViewModel>(),
                SurveillanceModel = new List<SurveillanceViewModel>(),
                TradeModel = new List<TradeViewModel>()
            };
            List<object> objListOthers = GetAllCasesForViews(dbCon, 'o', "spGetAllOtherCasesAssigned", invName);
            List<object> objListQuality = GetAllCasesForViews(dbCon, 'q', "spGetAllQualityCasesAssigned", invName);
            List<object> objListSurv = GetAllCasesForViews(dbCon, 's', "spGetAllSurveillanceCasesAssigned", invName);
            List<object> objListTrade = GetAllCasesForViews(dbCon, 't', "spGetAllTradeCasesAssigned", invName);

            foreach (OthersViewModel others in objListOthers)
                OwnedCases.OthersModel.Add(others);
            foreach (QualityViewModel quality in objListQuality)
                OwnedCases.QualityModel.Add(quality);
            foreach (SurveillanceViewModel surv in objListSurv)
                OwnedCases.SurveillanceModel.Add(surv);
            foreach (TradeViewModel trade in objListTrade)
                OwnedCases.TradeModel.Add(trade);

            return OwnedCases;
        }

        public void UpdateInvestigatorSummary(string dbCon, RecommendCasesViewModel recommend, string sp)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CaseStatus", "Preparing Charge");
                command.Parameters.AddWithValue("@ViolationCaseId", recommend.RecommendId);
                command.Parameters.AddWithValue("@InvestigatorSummary", recommend.InvestigatorSummary);

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

        public void SendInvestigatorDecision(string dbCon, Guid id, string sp, string summary, string document)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@InvestigatorSummary", summary);
                command.Parameters.AddWithValue("@Investigatordocuments", document);

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

        private List<object> GetAllCasesForViews(string dbCon, char type, string sp, string employee)
        {
            List<Object> objList = new List<Object>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InvestigatorName", employee);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                switch (type)
                {
                    case 'o':
                        while (reader.Read())
                        {
                            OthersViewModel others = new OthersViewModel
                            {
                                OthersModel = new OtherViolationAttributesModel
                                {
                                    Evidences = reader["Evidences"].ToString(),
                                    FurtherComment = reader["FurtherComment"].ToString(),
                                    Incident = reader["Incident"].ToString(),
                                    OtherViolationAttributesId = (Guid)reader["OtherViolationAttributesId"],
                                    ViolationDate = reader["ViolationDate"].ToString(),
                                    Witnesses = reader["Witnesses"].ToString()
                                },
                                ViolationModel = new ViolationCaseModel
                                {
                                    ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                                    SupportingDocuments = reader["SupportingDocuments"].ToString(),
                                    ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                    ViolationSummary = reader["ViolationSummary"].ToString(),
                                    ViolationType = reader["ViolationType"].ToString(),
                                    ViolatorName = reader["ViolatorName"].ToString(),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    ReportDate = reader["ReportDate"].ToString()
                                }
                            }; objList.Add(others);
                        }
                        break;
                    case 's':
                        while (reader.Read())
                        {
                            SurveillanceViewModel surveillance = new SurveillanceViewModel
                            {
                                SurveillanceModel = new SurveillanceViolationAttributesModel
                                {
                                    BuyMemberName = reader["BuyMemberName"].ToString(),
                                    Evidences = reader["Evidences"].ToString(),
                                    FurtherComment = reader["FurtherComment"].ToString(),
                                    FurtherExplanation = reader["FurtherExplanation"].ToString(),
                                    Incident = reader["Incident"].ToString(),
                                    SellMemberName = reader["SellMemberName"].ToString(),
                                    SurveillanceViolationAttributesId = (Guid)reader["SurveillanceViolationAttributesId"],
                                    TypeOfAlert = reader["TypeOfAlert"].ToString(),
                                    ViolationDate = reader["ViolationDate"].ToString(),
                                    Witnesses = reader["Witnesses"].ToString()
                                },
                                ViolationModel = new ViolationCaseModel
                                {
                                    ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                                    SupportingDocuments = reader["SupportingDocuments"].ToString(),
                                    ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                    ViolationSummary = reader["ViolationSummary"].ToString(),
                                    ViolationType = reader["ViolationType"].ToString(),
                                    ViolatorName = reader["ViolatorName"].ToString(),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    ReportDate = reader["ReportDate"].ToString()
                                }

                            }; objList.Add(surveillance);
                        }
                        break;
                    case 't':
                        while (reader.Read())
                        {
                            TradeViewModel trade = new TradeViewModel
                            {
                                TradeModel = new TradeViolationAttributesModel
                                {
                                    BuyClientName = reader["BuyClientName"].ToString(),
                                    BuyMemberName = reader["BuyMemberName"].ToString(),
                                    BuyRepresentativeName = reader["BuyRepresentativeName"].ToString(),
                                    BuyTicketNumber = reader["BuyTicketNumber"].ToString(),
                                    CancellationReason = reader["CancellationReason"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    FurtherExplanation = reader["FurtherExplanation"].ToString(),
                                    ProductionYear = Convert.ToInt32(reader["ProductionYear"]),
                                    SellClientName = reader["SellClientName"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    SellMemberName = reader["SellMemberName"].ToString(),
                                    SellRepresentativeName = reader["SellRepresentativeName"].ToString(),
                                    SellTicketNumber = reader["SellTicketNumber"].ToString(),
                                    Symbol = reader["Symbol"].ToString(),
                                    TradePrice = Convert.ToDouble(reader["TradePrice"]),
                                    TradeType = reader["TradeType"].ToString(),
                                    TradeViolationAttributesId = (Guid)reader["TradeViolationAttributeId"],
                                    WareHouse = reader["WareHouse"].ToString(),
                                    ViolationDate = reader["ViolationDate"].ToString()
                                },
                                ViolationModel = new ViolationCaseModel
                                {
                                    ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                                    SupportingDocuments = reader["SupportingDocuments"].ToString(),
                                    ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                    ViolationSummary = reader["ViolationSummary"].ToString(),
                                    ViolationType = reader["ViolationType"].ToString(),
                                    ViolatorName = reader["ViolatorName"].ToString(),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    ReportDate = reader["ReportDate"].ToString()
                                }
                            }; objList.Add(trade);
                        }
                        break;
                    case 'q':
                        while (reader.Read())
                        {
                            QualityViewModel model = new QualityViewModel
                            {
                                QualityModel = new QualityViolationAttributesModel
                                {
                                    ArrivalDate = reader["ArrivalDate"].ToString(),
                                    DispatchNumber = reader["DispatchNumber"].ToString(),
                                    DriverName = reader["DriverName"].ToString(),
                                    GRNReference = reader["GRNReference"].ToString(),
                                    LaboratoryDecision = reader["LaboratoryDecision"].ToString(),
                                    LabResultComment = reader["LabResultComment"].ToString(),
                                    MemberRepresentativeName = reader["MemberRepresentativeName"].ToString(),
                                    NumberofAdultratedBags = Convert.ToInt32(reader["NumberofAdultratedBags"]),
                                    QualityGradeResult = reader["QualityGradeResult"].ToString(),
                                    QualitySubCategory = reader["QualitySubCategory"].ToString(),
                                    QualityViolationsAttributeId = (Guid)reader["QualityViolationSAttributeId"],
                                    SamplerName = reader["SamplerName"].ToString(),
                                    SamplingInspectorName = reader["SamplingInspectorName"].ToString(),
                                    SamplingTicketComment = reader["SamplingTicketComment"].ToString(),
                                    TotalNumberofBags = Convert.ToInt32(reader["TotalNumberofBags"]),
                                    TrailerPlateNumber = reader["TrailerPlateNumber"].ToString(),
                                    TruckPlateNumber = reader["TruckPlateNumber"].ToString()
                                },
                                ViolationModel = new ViolationCaseModel
                                {
                                    ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                                    SupportingDocuments = reader["SupportingDocuments"].ToString(),
                                    ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                    ViolationSummary = reader["ViolationSummary"].ToString(),
                                    ViolationType = reader["ViolationType"].ToString(),
                                    ViolatorName = reader["ViolatorName"].ToString(),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    ReportDate = reader["ReportDate"].ToString()
                                }
                            };
                            objList.Add(model);
                        }
                        break;
                }
                reader.Close();
            }

            return objList;
        }
    }
}
