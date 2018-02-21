using BE.request;
using BE.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfFichaMedica
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFichaMedicaServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "login")]
        DataResponse<LoginResponse> login(LoginRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "getEmployees")]
        DataResponse<List<EmployeeResponse>> getEmployees(EmployeeRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "getMedicalFilesHeader")]
        DataResponse<List<MedicalFileHeaderResponse>> getMedicalFilesHeader(MedicalFileHeaderRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "getEvaluationsHeader")]
        DataResponse<List<EvaluationHeaderResponse>> getEvaluationsHeader(EvaluationHeaderRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "showMedicFile")]
        DataResponse<List<MedicFileResponse>> showMedicFileDetail(MedicFileRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "showOsteoMuscularAnalysis")]
        DataResponse<List<OsteoMuscularAnalysisResponse>> showOsteoMuscularAnalysis(OsteoMuscularAnalysisRequest request);
    }
}
