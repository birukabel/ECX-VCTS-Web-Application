using ECX.VCTS.Models;
using ECX.VCTS.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Util
{
    public class DataAccessUtility
    {
        public List<Object> GetAllViolationCases(string dbCon, char type, string sp)
        {
            List<Object> objList = new List<Object>();
            //SqlCommand command;
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                switch (type)
                {
                    case 'q':
                        while (reader.Read())
                        {
                            QualityViolationAttributesModel model = new QualityViolationAttributesModel
                            {
                                //ViolationCaseId = (Guid)reader["ViolationCaseId"],
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
                            };
                            objList.Add(model);
                        }
                        break;
                    case 't':
                        while (reader.Read())
                        {
                            TradeViolationAttributesModel model = new TradeViolationAttributesModel
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
                                TradeViolationAttributesId = (Guid)reader["TradeViolationAttributesId"],
                                //ViolationCaseId = (Guid)reader["ViolationDate"],
                                WareHouse = reader["WareHouse"].ToString(),
                                ViolationDate = reader["ViolationDate"].ToString()
                            };
                            objList.Add(model);
                        }
                        break;
                    case 's':
                        while (reader.Read())
                        {
                            SurveillanceViolationAttributesModel model = new SurveillanceViolationAttributesModel
                            {
                                BuyMemberName = reader["BuyMemberName"].ToString(),
                                Evidences = reader["Evidences"].ToString(),
                                FurtherComment = reader["FurtherComment"].ToString(),
                                FurtherExplanation = reader["FurtherExplanation"].ToString(),
                                Incident = reader["Incident"].ToString(),
                                SellMemberName = reader["SellMemberName"].ToString(),
                                SurveillanceViolationAttributesId = (Guid)reader["SurveillanceViolationAttributesId"],
                                TypeOfAlert = reader["TypeOfAlert"].ToString(),
                                //ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                ViolationDate = reader["ViolationDate"].ToString()
                            };
                            objList.Add(model);
                        }
                        break;
                    case 'o':
                        //objList = new List<OtherViolationAttributesModel>();
                        while (reader.Read())
                        {
                            OtherViolationAttributesModel model = new OtherViolationAttributesModel
                            {
                                Evidences = reader["Evidences"].ToString(),
                                FurtherComment = reader["FurtherComment"].ToString(),
                                Incident = reader["Incident"].ToString(),
                                Witnesses = reader["Witnesses"].ToString(),
                                //ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                OtherViolationAttributesId = (Guid)reader["OtherViolationAttributesId"],
                                ViolationDate = reader["ViolationDate"].ToString()
                            };
                            objList.Add(model);
                        }
                        break;
                    case 'v':
                        while (reader.Read())
                        {
                            ViolationCaseModel model = new ViolationCaseModel
                            {
                                ViolationCaseId = (Guid)reader["ViolationCaseId"],
                                ViolationType = reader["ViolationType"].ToString(),
                                ViolationSummary = reader["ViolationSummary"].ToString(),
                                ViolatorName = reader["ViolatorName"].ToString(),
                                CaseStatus = reader["CaseStatus"].ToString(),
                                ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                                SupportingDocuments = reader["SupportingDocuments"].ToString()
                            };
                            objList.Add(model);
                        }
                        break;
                    case 'u':
                        while (reader.Read())
                        {
                            UndertakingOfficerModel model = new UndertakingOfficerModel
                            {
                                ComplianceUndertakingId = (Guid)reader["ComplianceUndertakingId"],
                                PreparedBy = reader["PreparedBy"].ToString(),
                                SignedDate = reader["SignedDate"].ToString(),
                                SignedDocument = reader["SignedDocument"].ToString(),
                                UploadDate = reader["UploadDate"].ToString()
                            };
                        }
                        break;

                }
                reader.Close();
            }
            return objList;
        }

        internal IEnumerable<string> GetAllGRNRefs(string dbCon)
        {
            List<string> AllGRNs = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("Get_GRNNumbers", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        AllGRNs.Add(reader["GRN_Number"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return AllGRNs;
        }

        internal QualityViolationAttributesModel GetAllGRNData(string dbCon, string GRN)
        {
            List<QualityViolationAttributesModel> AllGRNs = new List<QualityViolationAttributesModel>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("Get_GRNByGRNNumber", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GRN_Number", GRN);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        QualityViolationAttributesModel qual = new QualityViolationAttributesModel
                        {
                            ArrivalDate = reader["ArrivalDate"].ToString(),
                            DispatchNumber = reader["DispatchNumber"].ToString(),
                            GRNReference = GRN,
                            TrailerPlateNumber = reader["TrailerPlateNumber"].ToString(),
                            TruckPlateNumber = reader["TruckPlateNumber"].ToString(),
                            TotalNumberofBags = Convert.ToInt32(reader["TotalNumberOfBags"]),
                            SamplerName = reader["SamplerName"].ToString(),
                            SamplingInspectorName = reader["SamplingInspector"].ToString(),
                            SamplingTicketComment = reader["sampleticketcomment"].ToString(),
                            QualityGradeResult = reader["GradeRecived"].ToString()
                        };
                        AllGRNs.Add(qual);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return AllGRNs.FirstOrDefault();
        }

        public static IEnumerable<string> GetCenterNamesByViolationType(MySetting setting, string violationType = "None")
        {
            List<string> NamesList = new List<string>();

            if (violationType == "Quality")
            {
                using (SqlConnection connection = new SqlConnection(setting.ECXLookupConnectionstring))
                {
                    SqlCommand command = new SqlCommand("spGetAllActiveWarehouse", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        WarehouseModel warehouse = new WarehouseModel
                        {
                            GUID = (Guid)reader["GUID"],
                            Description = reader["Description"].ToString()
                        };
                        warehouse.DescGuid = warehouse.Description + " [" + warehouse.GUID + "]";
                        NamesList.Add(warehouse.Description);
                    }
                    connection.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(setting.DefaultConnectionstring))
                {
                    SqlCommand command = new SqlCommand("spGetAllActiveTradingCenters", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TradingCenterModel TradingCenter = new TradingCenterModel
                        {
                            TradingCenterId = Convert.ToInt32(reader["TradingCenterId"]),
                            TradingCenterName = reader["TradingCenterName"].ToString()
                        };
                        NamesList.Add(TradingCenter.TradingCenterName);
                    }
                    connection.Close();
                }
            }

            return NamesList;
        }

        public List<object> GetAllCasesForAssignment(string dbCon, char type, string sp, string cs = "Waiting")
        {
            List<Object> objList = new List<Object>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CaseStatus", cs);
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

        public List<Guid> GetAllIdentifiers(string dbCon, string tableName = "history")
        {
            List<Guid> idList = new List<Guid>();

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlDataReader reader = null;
                SqlCommand command = null;
                switch (tableName)
                {
                    case "history":
                        command = new SqlCommand("spGetAllFromHistory", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ViolationCaseHistory history = new ViolationCaseHistory
                            {
                                CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                                StatusName = reader["StatusName"].ToString(),
                                ViolationCaseHistoryId = (Guid)reader["ViolationCaseHistoryId"],
                                ViolationCaseId = (Guid)reader["ViolationCaseId"]
                            };
                            idList.Add(history.ViolationCaseHistoryId);
                        }
                        break;
                    case "undertaking":
                        command = new SqlCommand("spGetAllUndertakens", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UndertakingOfficerModel model = new UndertakingOfficerModel
                            {
                                SignedDate = reader["SignedDate"].ToString(),
                                UploadDate = reader["UploadDate"].ToString(),
                                SignedDocument = reader["SignedDocument"].ToString(),
                                ComplianceUndertakingId = (Guid)reader["ComplianceUndertakingId"],
                                PreparedBy = reader["PreparedBy"].ToString(),
                                QualityViolationsAttributeId = (Guid)reader["QualityViolationsAttributeId"]
                            };
                            //model.QualityModel.;
                            idList.Add(model.ComplianceUndertakingId);
                        }
                        break;
                }
                reader.Close();
            }

            return idList;
        }

        public void AddCaseToHistory(string dbCon, ViolationCaseHistory history)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddCaseToHistory", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseHistoryId", history.ViolationCaseHistoryId);
                command.Parameters.AddWithValue("@ViolationCaseId", history.ViolationCaseId);
                command.Parameters.AddWithValue("@StatusName", history.StatusName);
                command.Parameters.AddWithValue("@CreateDate", DateTime.Now);

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

        public void UpdateCaseStatus(string dbCon, Guid id, string status)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spUpdateCaseStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@CaseStatus", status);

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

        public void UpdateInvestigatorName(string dbCon, Guid id, string investigator, string status)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spUpdateInvestigatorName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@InvestigatorName", investigator);
                command.Parameters.AddWithValue("@CaseStatus", status);

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

        public CasesAssignmentViewModel GetAllCasesToAssign(string dbCon)
        {
            CasesAssignmentViewModel Cases = new CasesAssignmentViewModel();
            List<object> objList = GetAllCasesForAssignment(dbCon, 'o', "spGetAllOtherCasesToAssign", "Waiting Manager");
            List<OthersViewModel> OtherList = new List<OthersViewModel>();
            foreach (OthersViewModel model in objList)
                OtherList.Add(model);
            List<SurveillanceViewModel> SurveillanceList = new List<SurveillanceViewModel>();
            objList = GetAllCasesForAssignment(dbCon, 's', "spGetAllSurveillanceCasesToAssign", "Waiting Manager");
            foreach (SurveillanceViewModel model in objList)
                SurveillanceList.Add(model);
            List<TradeViewModel> TradeList = new List<TradeViewModel>();
            objList = GetAllCasesForAssignment(dbCon, 't', "spGetAllTradeCasesToAssign", "Waiting Manager");
            foreach (TradeViewModel model in objList)
                TradeList.Add(model);
            Cases.OthersModel = OtherList;
            Cases.SurveillanceModel = SurveillanceList;
            Cases.TradeModel = TradeList;

            return Cases;
        }

        public ViolationCaseModel GetViolationModel(string dbCon, Guid id)
        {
            ViolationCaseModel violation = null;
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllViolationCases", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        violation = new ViolationCaseModel
                    {
                        
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        SupportingDocuments = reader["SupportingDocuments"].ToString(),
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        CaseStatus = reader["CaseStatus"].ToString(),
                        ReportDate = reader["ReportDate"].ToString()
                        };
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        //return View();
                    }
   
                    
                }
            }

            return violation;
        }

        public List<object> GetAllCasesForViews(string dbCon, char type, string sp)
        {
            List<Object> objList = new List<Object>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@InvestigatorName", investigatorName);
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

        public Guid UniqueIdentifier(List<Guid> idList)
        {
            bool found = false;
            Guid id = Guid.NewGuid();
            while (!found)
            {
                if (idList.Contains(id)) id = Guid.NewGuid();
                else found = true;
            }

            return id;
        }

        public object GetCaseForView(string dbCon, Guid id, char type, string sp, string invName = null)
        {
            List<object> objList = new List<object>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@InvestigatorName", invName);
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
            }

            return objList.FirstOrDefault();
        }

        public void AddToHistoryHelper(string dbCon, string status, Guid violId)
        {
            List<Guid> idList = GetAllIdentifiers(dbCon);
            Guid historyId = UniqueIdentifier(idList);
            ViolationCaseHistory history = new ViolationCaseHistory();
            history.StatusName = status;
            history.ViolationCaseHistoryId = historyId;
            history.ViolationCaseId = violId;
            AddCaseToHistory(dbCon, history);
        }

        public static IEnumerable<string> GetAllPenaltyTypes(string dbCon)
        {
            List<string> PenaltyTypes = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllPenaltyTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["PenaltyType"].ToString();

                    if (pt != "Free")
                        PenaltyTypes.Add(pt);
                }
                connection.Close();
            }
            return PenaltyTypes;
        }

        public static IEnumerable<string> GetAllCaseStatus(string dbCon)
        {
            List<string> StatusTypes = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllCaseStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["StatusName"].ToString();

                    StatusTypes.Add(pt);
                }
                connection.Close();
            }

            return StatusTypes;
        }

        public static IEnumerable<string> GetAllCenters(string dbCon)
        {
            List<string> Centers = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllExchangeCenters", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["ExchangeCenterName"].ToString();

                    Centers.Add(pt);
                }
                connection.Close();
            }


            return Centers;
        }

        public static IEnumerable<string> GetWarehouses(string dbCon)
        {
            List<string> Centers = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllActiveWarehouse", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    WarehouseModel warehouse = new WarehouseModel
                    {
                        GUID = (Guid)reader["GUID"],
                        Description = reader["Description"].ToString()
                    };
                    warehouse.DescGuid = warehouse.Description + " [" + warehouse.GUID + "]";
                    Centers.Add(warehouse.Description);
                }
                connection.Close();
            }


            return Centers;
        }

        public static IEnumerable<string> GetAllQualitySubCategories(string dbCon)
        {
            List<string> SubCategories = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllQualitySubCategories", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["SubCategoryName"].ToString();

                    SubCategories.Add(pt);
                }
                connection.Close();
            }
            return SubCategories;
        }

        public static IEnumerable<string> GetAllTradeTypes(string dbCon)
        {
            List<string> TradeTypes = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllTradeTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["TradeType"].ToString();

                    TradeTypes.Add(pt);
                }
                connection.Close();
            }

            return TradeTypes;
        }

        public static IEnumerable<string> GetAllViolationTypes(string dbCon)
        {
            List<string> ViolationTypes = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllViolationTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pt = "";
                    pt = reader["ViolationType"].ToString();

                    ViolationTypes.Add(pt);
                }
                connection.Close();
            }

            return ViolationTypes;
        }

        public IEnumerable<string> GetAllInvestigators(string dbCon)
        {
            List<string> Investigators = new List<string>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllInvestigators", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Investigators.Add(reader["InvestigatorName"].ToString());
                }
            }

            return Investigators;
        }

        public void AddOrRemoveInvestigator(string dbCon, string sp, string InvestigatorName)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@InvestigatorName", InvestigatorName);
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

        public IEnumerable<string> GetViolators(string dbCon)
        {
            List<string> employees = new List<string>();
            List<ViolationActors> actors = GetAllViolators(dbCon).ToList();
            foreach (ViolationActors actor in actors)
                employees.Add(actor.ActorNameId);
            return employees;
        }

        public IEnumerable<ViolationActors> GetAllViolators(string dbCon)
        {
            List<ViolationActors> Violators = new List<ViolationActors>();
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("GetAllActorsData", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ViolationActors viols = new ViolationActors
                    {
                        Id = (Guid)reader["Id"],
                        ActorGroup = reader["ActorGroup"].ToString(),
                        IdNO = reader["IdNO"].ToString(),
                        ISNMDT = Convert.ToBoolean(reader["ISNMDT"]),
                        Name = reader["Name"].ToString()
                    };
                    viols.ActorNameId = viols.Name + " [" + viols.IdNO + "]";
                    Violators.Add(viols);
                }
            }

            return Violators;
        }

        public void AddOrRemoveViolator(string dbCon, string sp, string ViolatorName)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolatorName", ViolatorName);
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

        public ViolationCaseModel GetViolation(string dbCon, Guid id)
        {
            ViolationCaseModel model = new ViolationCaseModel();

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAllViolationCases", connection);
                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.AssignDate = reader["AssignDate"].ToString();
                    model.CaseStatus = reader["CaseStatus"].ToString();
                    model.DecisionPassedDate = reader["DecisionPassedDate"].ToString();
                    model.ExchangeCenterName = reader["ExchangeCenterName"].ToString();
                    model.InvestigatorName = reader["InvestigatorName"].ToString();
                    model.PenaltyType = reader["PenaltyType"].ToString();
                    model.ViolationCaseId = (Guid)reader["ViolationCaseId"];
                    model.ViolationSummary = reader["ViolationSummary"].ToString();
                    model.ViolationType = reader["ViolationType"].ToString();
                    model.ViolatorName = reader["ViolatorName"].ToString();
                    model.ReportDate = reader["ReportDate"].ToString();
                }
                connection.Close();
            }
            return model;
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();
            //if(some.GetType().FullName.Equals("ViolationCasesTrackingSystem."))
            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {

                    Value = element.ToString(),
                    Text = element.ToString()

                });

            }

            return selectList;
        }
    }
}
