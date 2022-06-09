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
    public class VCTSReportsDataAccess
    {
        public List<object> GetAllCasesForReporting(string dbCon, char type, string sp)
        {
            List<object> objList = new List<object>();

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            }; objList.Add(others);
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            };
                            objList.Add(model);
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            }; objList.Add(trade);
                        }
                        break;
                }
            }

            return objList;
        }

        public List<object> GetDataforReporting(string dbCon, char type, string sp, VCTSReportsViewModel reportModel)
        {
            List<object> objList = new List<object>();

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationType", reportModel.ViolationType);
                command.Parameters.AddWithValue("@CaseStatus", reportModel.CaseStatus);
                command.Parameters.AddWithValue("@ExchangeCenterName", reportModel.ExchangeCenterName);
                command.Parameters.AddWithValue("@ViolatorName", reportModel.ViolatorName);
                command.Parameters.AddWithValue("@InvestigatorName", reportModel.InvestigatorName);
                command.Parameters.AddWithValue("@DateFrom", reportModel.DateFrom);
                command.Parameters.AddWithValue("@DateTo", reportModel.DateTo);

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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            }; objList.Add(others);
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            };
                            objList.Add(model);
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
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
                                    AmountPenalized = Convert.ToDouble(reader["AmountPenalized"]),
                                    CaseStatus = reader["CaseStatus"].ToString(),
                                    DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                                    InvestigatorName = reader["InvestigatorName"].ToString(),
                                    InvestigatorDocument = reader["InvestigatorDocuments"].ToString(),
                                    InvestigatorSummary = reader["InvestigatorSummary"].ToString(),
                                    ManagerRemark = reader["ManagerRemark"].ToString()
                                }
                            }; objList.Add(trade);
                        }
                        break;
                }
            }

            return objList;
        }

        public DataTable AddOtherCasesColumns(List<OthersViewModel> others)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Exchange Center", typeof(string));
            dt.Columns.Add("Violator Name", typeof(string));
            dt.Columns.Add("Case Status", typeof(string));
            dt.Columns.Add("Violation Type", typeof(string));
            dt.Columns.Add("Investigator Name", typeof(string));
            dt.Columns.Add("Investigator Summary", typeof(string));
            dt.Columns.Add("Violation Summary", typeof(string));
            dt.Columns.Add("Violation Date", typeof(string));
            dt.Columns.Add("Incident", typeof(string));
            dt.Columns.Add("Further Comment", typeof(string));

            foreach (OthersViewModel other in others)
            {
                dt.Rows.Add(
                    other.ViolationModel.ExchangeCenterName,
                    other.ViolationModel.ViolatorName,
                    other.ViolationModel.CaseStatus,
                    other.ViolationModel.ViolationType,
                    other.ViolationModel.InvestigatorName,
                    other.ViolationModel.InvestigatorSummary,
                    other.ViolationModel.ViolationSummary,
                    DateTime.Parse(other.OthersModel.ViolationDate),
                    other.OthersModel.Incident,
                    other.OthersModel.FurtherComment
                    );
            }

            return dt;
        }

        public DataTable AddQualityCasesColumns(List<QualityViewModel> quality)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Exchange Center", typeof(string));
            dt.Columns.Add("Violator Name", typeof(string));
            dt.Columns.Add("Case Status", typeof(string));
            dt.Columns.Add("Violation Type", typeof(string));
            dt.Columns.Add("Investigator Name", typeof(string));
            dt.Columns.Add("Investigator Summary", typeof(string));
            dt.Columns.Add("Violation Summary", typeof(string));
            dt.Columns.Add("Arrival Date", typeof(string));
            dt.Columns.Add("GRN Reference", typeof(string));
            dt.Columns.Add("Sub Type", typeof(string));
            dt.Columns.Add("Dispatch Number", typeof(string));
            dt.Columns.Add("Laboratory Decision", typeof(string));
            dt.Columns.Add("Lab Result Comment", typeof(string));
            dt.Columns.Add("Member Rep Name", typeof(string));
            dt.Columns.Add("Quality Grade Result", typeof(string));
            dt.Columns.Add("Total No of Bags", typeof(Int32));
            dt.Columns.Add("No of Adultrated Bags", typeof(Int32));
            dt.Columns.Add("Sampler Name", typeof(string));
            dt.Columns.Add("Sampling Insp. Name", typeof(string));
            dt.Columns.Add("Sampling Ticket Comment", typeof(string));
            dt.Columns.Add("Driver Name", typeof(string));
            dt.Columns.Add("Truck Plate No", typeof(string));
            dt.Columns.Add("Trailer Plate No", typeof(string));

            foreach (QualityViewModel qua in quality)
            {
                dt.Rows.Add(
                    qua.ViolationModel.ExchangeCenterName,
                    qua.ViolationModel.ViolatorName,
                    qua.ViolationModel.CaseStatus,
                    qua.ViolationModel.ViolationType,
                    qua.ViolationModel.InvestigatorName,
                    qua.ViolationModel.InvestigatorSummary,
                    qua.ViolationModel.ViolationSummary,
                    DateTime.Parse(qua.QualityModel.ArrivalDate),
                    qua.QualityModel.GRNReference,
                    qua.QualityModel.QualitySubCategory,
                    qua.QualityModel.DispatchNumber,
                    qua.QualityModel.LaboratoryDecision,
                    qua.QualityModel.LabResultComment,
                    qua.QualityModel.MemberRepresentativeName,
                    qua.QualityModel.QualityGradeResult,
                    qua.QualityModel.TotalNumberofBags,
                    qua.QualityModel.NumberofAdultratedBags,
                    qua.QualityModel.SamplerName,
                    qua.QualityModel.SamplingInspectorName,
                    qua.QualityModel.SamplingTicketComment,
                    qua.QualityModel.DriverName,
                    qua.QualityModel.TruckPlateNumber,
                    qua.QualityModel.TrailerPlateNumber
                    );
            }

            return dt;
        }

        public DataTable AddSurveillanceCasesColumns(List<SurveillanceViewModel> surveillance)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Exchange Center", typeof(string));
            dt.Columns.Add("Violator Name", typeof(string));
            dt.Columns.Add("Case Status", typeof(string));
            dt.Columns.Add("Violation Type", typeof(string));
            dt.Columns.Add("Investigator Name", typeof(string));
            dt.Columns.Add("Investigator Summary", typeof(string));
            dt.Columns.Add("Violation Summary", typeof(string));
            dt.Columns.Add("Violation Date", typeof(string));
            dt.Columns.Add("Incident", typeof(string));
            dt.Columns.Add("Buy Mem Name", typeof(string));
            dt.Columns.Add("Sell Mem. Name", typeof(string));
            dt.Columns.Add("Further Comment", typeof(string));
            dt.Columns.Add("Further Explanation", typeof(string));
            dt.Columns.Add("Type of Alert", typeof(string));

            foreach (SurveillanceViewModel surv in surveillance)
            {
                dt.Rows.Add(
                    surv.ViolationModel.ExchangeCenterName,
                    surv.ViolationModel.ViolatorName,
                    surv.ViolationModel.CaseStatus,
                    surv.ViolationModel.ViolationType,
                    surv.ViolationModel.InvestigatorName,
                    surv.ViolationModel.InvestigatorSummary,
                    surv.ViolationModel.ViolationSummary,
                    DateTime.Parse(surv.SurveillanceModel.ViolationDate),
                    surv.SurveillanceModel.Incident,
                    surv.SurveillanceModel.BuyMemberName,
                    surv.SurveillanceModel.SellMemberName,
                    surv.SurveillanceModel.FurtherComment,
                    surv.SurveillanceModel.FurtherExplanation,
                    surv.SurveillanceModel.TypeOfAlert
                    );
            }

            return dt;
        }

        public DataTable AddTradeCasesColumns(List<TradeViewModel> trade)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Exchange Center", typeof(string));
            dt.Columns.Add("Violator Name", typeof(string));
            dt.Columns.Add("Case Status", typeof(string));
            dt.Columns.Add("Violation Type", typeof(string));
            dt.Columns.Add("Investigator Name", typeof(string));
            dt.Columns.Add("Investigator Summary", typeof(string));
            dt.Columns.Add("Violation Summary", typeof(string));
            dt.Columns.Add("Violation Date", typeof(string));
            dt.Columns.Add("Buy Client Name", typeof(string));
            dt.Columns.Add("Buy Mem Name", typeof(string));
            dt.Columns.Add("Buy Rep Name", typeof(string));
            dt.Columns.Add("Buy Ticket No", typeof(string));
            dt.Columns.Add("Cancel Reason", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Further Exp", typeof(string));
            dt.Columns.Add("Prod Yr", typeof(Int32));
            dt.Columns.Add("Sell Client Name", typeof(string));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Sell Mem Name", typeof(string));
            dt.Columns.Add("Sell Rep Name", typeof(string));
            dt.Columns.Add("Sell Ticket No", typeof(string));
            dt.Columns.Add("Symbol", typeof(string));
            dt.Columns.Add("Trade Price", typeof(double));
            dt.Columns.Add("Trade Type", typeof(string));

            foreach (TradeViewModel tr in trade)
            {
                dt.Rows.Add(
                    tr.ViolationModel.ExchangeCenterName,
                    tr.ViolationModel.ViolatorName,
                    tr.ViolationModel.CaseStatus,
                    tr.ViolationModel.ViolationType,
                    tr.ViolationModel.InvestigatorName,
                    tr.ViolationModel.InvestigatorSummary,
                    tr.ViolationModel.ViolationSummary,
                    DateTime.Parse(tr.TradeModel.ViolationDate),
                    tr.TradeModel.BuyClientName,
                    tr.TradeModel.BuyMemberName,
                    tr.TradeModel.BuyRepresentativeName,
                    tr.TradeModel.BuyTicketNumber,
                    tr.TradeModel.CancellationReason,
                    tr.TradeModel.Description,
                    tr.TradeModel.FurtherExplanation,
                    tr.TradeModel.ProductionYear,
                    tr.TradeModel.SellClientName,
                    tr.TradeModel.Quantity,
                    tr.TradeModel.SellMemberName,
                    tr.TradeModel.SellRepresentativeName,
                    tr.TradeModel.SellTicketNumber,
                    tr.TradeModel.Symbol,
                    tr.TradeModel.TradePrice,
                    tr.TradeModel.TradeType
                    );
            }

            return dt;
        }

        public List<AnnualEnforcementStatusViewModel> GetAllCasesforEnforcement(string dbCon, string sp)
        {
            List<AnnualEnforcementStatusViewModel> EnforcementList = new List<AnnualEnforcementStatusViewModel>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AnnualEnforcementStatusViewModel model = new AnnualEnforcementStatusViewModel
                    {
                        DateOfViolation = reader["ReportDate"].ToString(),
                        DecisionPassedDate = reader["DecisionPassedDate"].ToString(),
                        DecisionSummary = reader["BCCSummary"].ToString(),
                        EnforcementStatus = reader["Enforcement"].ToString(),
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        ViolationCaseId = (Guid)reader["ViolationCaseId"]
                    };
                }
            }

                return EnforcementList;
        }
    }
}
