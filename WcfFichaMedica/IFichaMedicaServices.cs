﻿using BE.request;
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
         UriTemplate = "getMedicalFiles")]
        DataResponse<List<MedicalFileHeaderResponse>> getMedicalFiles(MedicalFileRequest request);
    }
}
