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
    public class UndertakingDataAccess
    {
        DataAccessUtility da = new DataAccessUtility();
        public IEnumerable<UndertakingOfficerViewModel> GetAllCasesforUndertaking(string dbCon)
        {
            List<UndertakingOfficerViewModel> modelList = new List<UndertakingOfficerViewModel>();
            QualityViolationAttributesModel quality;
            ViolationCaseModel violation;
            UndertakingOfficerViewModel model;
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetCasesforUndertaking", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quality = new QualityViolationAttributesModel()
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
                    };
                    violation = new ViolationCaseModel
                    {
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        CaseStatus = reader["CaseStatus"].ToString(),
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        SupportingDocuments = reader["SupportingDocuments"].ToString()
                    };
                    model = new UndertakingOfficerViewModel();
                    model.qualityModel = quality;
                    model.violationModel = violation;
                    modelList.Add(model);
                }
                reader.Close();
            }
            return modelList;
        }

        public UndertakingOfficerViewModel GetCaseforUndertaking(string dbCon, Guid id)
        {
            List<UndertakingOfficerViewModel> modelList = new List<UndertakingOfficerViewModel>();
            QualityViolationAttributesModel quality;
            ViolationCaseModel violation;
            UndertakingOfficerViewModel model;

            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetCasesforUndertaking", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QualityViolationSAttributeId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    quality = new QualityViolationAttributesModel()
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
                    };
                    violation = new ViolationCaseModel
                    {
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        CaseStatus = reader["CaseStatus"].ToString(),
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        SupportingDocuments = reader["SupportingDocuments"].ToString()
                    };
                    model = new UndertakingOfficerViewModel();
                    model.qualityModel = quality;
                    model.violationModel = violation;
                    modelList.Add(model);
                }
                reader.Close();
            }

            return modelList.FirstOrDefault();
        }

        public void AddUndertakingOfficerRemark(string dbCon, Guid id, string remark)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("[spAddUndertakingOfficerRemark]", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QualityViolationsAttributeId", id);
                command.Parameters.AddWithValue("@UndertakingOfficerRemark", remark);

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

        public void UpdateUndertaking(string dbCon, UndertakingOfficerModel model)
        {
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command  = new SqlCommand("[spUpdateUndertaking]", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@IsSigned", model.IsSigned);
                command.Parameters.AddWithValue("@QualityViolationsAttributeId", model.QualityViolationsAttributeId);
                command.Parameters.AddWithValue("@PreparedBy", model.PreparedBy);
                command.Parameters.AddWithValue("@SignedDate", Convert.ToDateTime(model.SignedDate));
                command.Parameters.AddWithValue("@SignedDocument", model.SignedDocument);
                command.Parameters.AddWithValue("@UploadDate", Convert.ToDateTime(model.UploadDate));

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
