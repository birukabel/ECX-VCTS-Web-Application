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
    public class SentBackDataAccess
    {
        public IEnumerable<SentBackCasesViewModel> GetSentBackCases(string dbCon, string reporter)
        {
            List<SentBackCasesViewModel> modelList = new List<SentBackCasesViewModel>();
            QualityViolationAttributesModel quality;
            ViolationCaseModel violation;
            SentBackCasesViewModel sentModel;
            using (SqlConnection connection = new SqlConnection(dbCon))
            {
                SqlCommand command = new SqlCommand("spGetAvailableQualityCases", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CaseStatus", "Sent Back");
                command.Parameters.AddWithValue("@ReportedBy", reporter);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    quality = new QualityViolationAttributesModel
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
                    violation = new ViolationCaseModel()
                    {
                        ViolationCaseId = (Guid)reader["ViolationCaseId"],
                        ViolationType = reader["ViolationType"].ToString(),
                        ViolationSummary = reader["ViolationSummary"].ToString(),
                        ViolatorName = reader["ViolatorName"].ToString(),
                        CaseStatus = reader["CaseStatus"].ToString(),
                        ExchangeCenterName = reader["ExchangeCenterName"].ToString(),
                        SupportingDocuments = reader["SupportingDocuments"].ToString()
                    };
                    sentModel = new SentBackCasesViewModel()
                    {
                        qualityModel = quality,
                        violationModel = violation
                    };
                    modelList.Add(sentModel);
                }
            }

            return modelList;
        }

    }
}
