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
    public class ReporterDataAccess
    {
        DataAccessUtility da = new DataAccessUtility();

        public void ReportViolation(string dbCon, ViolationReporterViewModel vrvm, string reporter)
        {
            List<ViolationCaseModel> cases = new List<ViolationCaseModel>();
            List<object> objList = da.GetAllViolationCases(dbCon, 'v', "spGetAllViolationCases").ToList();
            foreach (ViolationCaseModel violation in objList)
            {
                cases.Add(violation);
            }
            List<Guid> idList = new List<Guid>();
            ViolationCaseModel violationModel = vrvm.violationCases;
            Guid caseId;

            if (cases.Count > 0)
            {
                foreach (ViolationCaseModel model in cases)
                {
                    idList.Add(model.ViolationCaseId);
                }

                caseId = da.UniqueIdentifier(idList);
            }

            else
            {
                caseId = new Guid();
            }

            violationModel.ViolationCaseId = caseId;

            if (violationModel.ViolationType == "Quality")
                violationModel.CaseStatus = "Waiting";
            else violationModel.CaseStatus = "Waiting Manager";

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToViolationCase", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", violationModel.ViolationCaseId);
                command.Parameters.AddWithValue("@ExchangeCenterName", violationModel.ExchangeCenterName);
                command.Parameters.AddWithValue("@ViolationType", violationModel.ViolationType);
                command.Parameters.AddWithValue("@CaseStatus", violationModel.CaseStatus);
                command.Parameters.AddWithValue("@ViolationSummary", violationModel.ViolationSummary);
                command.Parameters.AddWithValue("@SupportingDocuments", violationModel.SupportingDocuments);
                command.Parameters.AddWithValue("@ViolatorName", violationModel.ViolatorName);
                command.Parameters.AddWithValue("@ReportedBy", reporter);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }

            if (violationModel.ViolationType == "Quality") AddQualityParameterValues(dbCon, vrvm.qualityModel, violationModel.ViolationCaseId);
            else if (violationModel.ViolationType == "Trade") AddTradeParameterValues(dbCon, vrvm.tradeModel, violationModel.ViolationCaseId, violationModel.ExchangeCenterName);
            else if (violationModel.ViolationType == "Surveillance") AddSurveillanceParameterValues(dbCon, vrvm.surveillanceModel, violationModel.ViolationCaseId, violationModel.SupportingDocuments);
            else if (violationModel.ViolationType == "Other") AddOtherParameterValues(dbCon, vrvm.othersModel, violationModel.ViolationCaseId, violationModel.SupportingDocuments);
        }

        public void AddQualityParameterValues(string dbCon, QualityViolationAttributesModel model, Guid id)
        {
            List<Object> objList = da.GetAllViolationCases(dbCon, 'q', "spGetAllQualityAttributes");
            List<QualityViolationAttributesModel> qualityList = new List<QualityViolationAttributesModel>();
            foreach (QualityViolationAttributesModel quality in objList)
            {
                qualityList.Add(quality);
            }
            List<Guid> idList = new List<Guid>();
            foreach (QualityViolationAttributesModel qualityModel in qualityList)
            {
                idList.Add(qualityModel.QualityViolationsAttributeId);
            }
            model.QualityViolationsAttributeId = da.UniqueIdentifier(idList);
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToQualityViolationCases", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@QualityViolationsAttributeId", model.QualityViolationsAttributeId);
                command.Parameters.AddWithValue("@ArrivalDate", Convert.ToDateTime(model.ArrivalDate));
                command.Parameters.AddWithValue("@DispatchNumber", model.DispatchNumber);
                command.Parameters.AddWithValue("@DriverName", model.DriverName);
                command.Parameters.AddWithValue("@GRNReference", model.GRNReference);
                command.Parameters.AddWithValue("@LaboratoryDecision", model.LaboratoryDecision);
                command.Parameters.AddWithValue("@LabResultComment", model.LabResultComment);
                command.Parameters.AddWithValue("@MemberRepresentativeName", model.MemberRepresentativeName);
                command.Parameters.AddWithValue("@NumberofAdultratedBags", model.NumberofAdultratedBags);
                command.Parameters.AddWithValue("@QualityGradeResult", model.QualityGradeResult);
                command.Parameters.AddWithValue("@QualitySubCategory", model.QualitySubCategory);
                command.Parameters.AddWithValue("@SamplerName", model.SamplerName);
                command.Parameters.AddWithValue("@SamplingInspectorName", model.SamplingInspectorName);
                command.Parameters.AddWithValue("@SamplingTicketComment", model.SamplingTicketComment);
                command.Parameters.AddWithValue("@TotalNumberofBags", model.TotalNumberofBags);
                command.Parameters.AddWithValue("@TrailerPlateNumber", model.TrailerPlateNumber);
                command.Parameters.AddWithValue("@TruckPlateNumber", model.TruckPlateNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }
            AddtoUndertaking(dbCon, model.QualityViolationsAttributeId);
        }

        public void AddtoUndertaking(string dbCon, Guid qualityId)
        {
            List<object> objList = da.GetAllViolationCases(dbCon, 'u', "spGetAllUndertakens").ToList();
            List<UndertakingOfficerModel> underList = new List<UndertakingOfficerModel>();
            foreach (UndertakingOfficerModel under in objList)
            {
                underList.Add(under);
            }
            List<Guid> idList = new List<Guid>();
            foreach (UndertakingOfficerModel unModel in underList)
            {
                idList.Add(unModel.ComplianceUndertakingId);
            }
            UndertakingOfficerModel model = new UndertakingOfficerModel();
            model.ComplianceUndertakingId = da.UniqueIdentifier(idList);
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToUndertakings", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ComplianceUndertakingId", model.ComplianceUndertakingId);
                command.Parameters.AddWithValue("@QualityViolationsAttributeId", qualityId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }
        }

        public void AddTradeParameterValues(string dbCon, TradeViolationAttributesModel model, Guid id, string center)
        {
            List<Object> objList = da.GetAllViolationCases(dbCon, 't', "spGetAllTradeAttributes");
            List<TradeViolationAttributesModel> tradeList = new List<TradeViolationAttributesModel>();
            foreach (TradeViolationAttributesModel trade in objList)
            {
                tradeList.Add(trade);
            }
            List<Guid> idList = new List<Guid>();
            foreach (TradeViolationAttributesModel tradeModel in tradeList)
            {
                idList.Add(tradeModel.TradeViolationAttributesId);
            }
            model.TradeViolationAttributesId = da.UniqueIdentifier(idList);
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToTradeViolationCases", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@TradeViolationAttributeId", model.TradeViolationAttributesId);
                command.Parameters.AddWithValue("@ViolationDate", Convert.ToDateTime(model.ViolationDate));
                command.Parameters.AddWithValue("@BuyClientName", model.BuyClientName);
                command.Parameters.AddWithValue("@BuyMemberName", model.BuyMemberName);
                command.Parameters.AddWithValue("@BuyRepresentativeName", model.BuyRepresentativeName);
                command.Parameters.AddWithValue("@BuyTicketNumber", model.BuyTicketNumber);
                command.Parameters.AddWithValue("@CancellationReason", model.CancellationReason);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@FurtherExplanation", model.FurtherExplanation);
                command.Parameters.AddWithValue("@ProductionYear", model.ProductionYear);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@SellClientName", model.SellClientName);
                command.Parameters.AddWithValue("@SellMemberName", model.SellMemberName);
                command.Parameters.AddWithValue("@SellRepresentativeName", model.SellRepresentativeName);
                command.Parameters.AddWithValue("@SellTicketNumber", model.SellTicketNumber);
                command.Parameters.AddWithValue("@TradePrice", model.TradePrice);
                command.Parameters.AddWithValue("@TradeType", model.TradeType);
                command.Parameters.AddWithValue("@WareHouse", center);
                command.Parameters.AddWithValue("@Symbol", model.Symbol);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }
        }
        public void AddSurveillanceParameterValues(string dbCon, SurveillanceViolationAttributesModel model, Guid id, string documents)
        {
            List<Object> objList = da.GetAllViolationCases(dbCon, 's', "spGetAllSurveillanceAttributes");
            List<SurveillanceViolationAttributesModel> survList = new List<SurveillanceViolationAttributesModel>();
            foreach (SurveillanceViolationAttributesModel surv in objList)
            {
                survList.Add(surv);
            }
            List<Guid> idList = new List<Guid>();
            foreach (SurveillanceViolationAttributesModel surModel in survList)
            {
                idList.Add(surModel.SurveillanceViolationAttributesId);
            }
            model.SurveillanceViolationAttributesId = da.UniqueIdentifier(idList);
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToSurveillanceViolationCases", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@SurveillanceViolationAttributesId", model.SurveillanceViolationAttributesId);
                command.Parameters.AddWithValue("@ViolationDate", Convert.ToDateTime(model.ViolationDate));
                command.Parameters.AddWithValue("@Evidences", documents);
                command.Parameters.AddWithValue("@Witnesses", model.Witnesses);
                command.Parameters.AddWithValue("@SellMemberName", model.SellMemberName);
                command.Parameters.AddWithValue("@BuyMemberName", model.BuyMemberName);
                command.Parameters.AddWithValue("@FurtherComment", model.FurtherComment);
                command.Parameters.AddWithValue("@FurtherExplanation", model.FurtherExplanation);
                command.Parameters.AddWithValue("@Incident", model.Incident);
                command.Parameters.AddWithValue("@TypeOfAlert", model.TypeOfAlert);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }
        }

        public void AddOtherParameterValues(string dbCon, OtherViolationAttributesModel model, Guid id, string documents)
        {
            List<Object> objList = da.GetAllViolationCases(dbCon, 'o', "spGetAllOtherAttributes");
            List<OtherViolationAttributesModel> otherList = new List<OtherViolationAttributesModel>();
            foreach (OtherViolationAttributesModel other in objList)
            {
                otherList.Add(other);
            }
            List<Guid> idList = new List<Guid>();
            foreach (OtherViolationAttributesModel otmodel in otherList)
            {
                idList.Add(otmodel.OtherViolationAttributesId);
            }
            model.OtherViolationAttributesId = da.UniqueIdentifier(idList);
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spAddToOtherViolationCases", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", id);
                command.Parameters.AddWithValue("@OtherViolationAttributesId", model.OtherViolationAttributesId);
                command.Parameters.AddWithValue("@Evidences", documents);
                command.Parameters.AddWithValue("@FurtherComment", model.FurtherComment);
                command.Parameters.AddWithValue("@Incident", model.Incident);
                command.Parameters.AddWithValue("@ViolationDate", Convert.ToDateTime(model.ViolationDate));
                command.Parameters.AddWithValue("@Witnesses", model.Witnesses);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
                connection.Close();
            }
        }

        public void AddSentBackReport(string dbCon, SentBackCasesViewModel sentBack)
        {
            da.AddToHistoryHelper(dbCon, "Sent Back", sentBack.violationModel.ViolationCaseId);
            Guid qid = sentBack.qualityModel.QualityViolationsAttributeId;
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spUpdateSentBackViolationCase", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ViolationCaseId", sentBack.violationModel.ViolationCaseId);
                command.Parameters.AddWithValue("@ViolationSummary", sentBack.violationModel.ViolationSummary);
                command.Parameters.AddWithValue("@SupportingDocuments", sentBack.violationModel.SupportingDocuments);
                command.Parameters.AddWithValue("@ViolatorName", sentBack.violationModel.ViolatorName);
                command.Parameters.AddWithValue("@ExchangeCenterName", sentBack.violationModel.ExchangeCenterName);

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
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spUpdateSentBackQualityAttributes", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ViolationCaseId", sentBack.violationModel.ViolationCaseId);
                command.Parameters.AddWithValue("@QualityViolationsAttributeId", sentBack.qualityModel.QualityViolationsAttributeId);
                command.Parameters.AddWithValue("@ArrivalDate", Convert.ToDateTime(sentBack.qualityModel.ArrivalDate));
                command.Parameters.AddWithValue("@DispatchNumber", sentBack.qualityModel.DispatchNumber);
                command.Parameters.AddWithValue("@DriverName", sentBack.qualityModel.DriverName);
                command.Parameters.AddWithValue("@GRNReference", sentBack.qualityModel.GRNReference);
                command.Parameters.AddWithValue("@LaboratoryDecision", sentBack.qualityModel.LaboratoryDecision);
                command.Parameters.AddWithValue("@LabResultComment", sentBack.qualityModel.LabResultComment);
                command.Parameters.AddWithValue("@MemberRepresentativeName", sentBack.qualityModel.MemberRepresentativeName);
                command.Parameters.AddWithValue("@NumberofAdultratedBags", sentBack.qualityModel.NumberofAdultratedBags);
                command.Parameters.AddWithValue("@QualityGradeResult", sentBack.qualityModel.QualityGradeResult);
                command.Parameters.AddWithValue("@QualitySubCategory", sentBack.qualityModel.QualitySubCategory);
                command.Parameters.AddWithValue("@SamplerName", sentBack.qualityModel.SamplerName);
                command.Parameters.AddWithValue("@SamplingInspectorName", sentBack.qualityModel.SamplingInspectorName);
                command.Parameters.AddWithValue("@SamplingTicketComment", sentBack.qualityModel.SamplingTicketComment);
                command.Parameters.AddWithValue("@TotalNumberofBags", sentBack.qualityModel.TotalNumberofBags);
                command.Parameters.AddWithValue("@TrailerPlateNumber", sentBack.qualityModel.TrailerPlateNumber);
                command.Parameters.AddWithValue("@TruckPlateNumber", sentBack.qualityModel.TruckPlateNumber);

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
    }
}
