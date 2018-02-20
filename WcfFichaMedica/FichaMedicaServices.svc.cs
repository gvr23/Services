﻿using BE.request;
using BE.response;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfFichaMedica
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FichaMedicaServices : IFichaMedicaServices
    {
        public DataResponse<LoginResponse> login(LoginRequest request)
        {
            return new BL_Ficha().login(request);
        }

        public DataResponse<List<EmployeeResponse>> getEmployees(EmployeeRequest request)
        {
            return new BL_Ficha().getEmployees(request);   
        }

        public DataResponse<List<MedicalFileHeaderResponse>> getMedicalFilesHeader(MedicalFileHeaderRequest request)
        {
            return new BL_Ficha().getMedicalFilesHeader(request);
        }

        public DataResponse<List<EvaluationHeaderResponse>> getEvaluationsHeader(EvaluationHeaderRequest request)
        {
            return new BL_Ficha().getEvaluationsHeader(request);
        }

        public DataResponse<List<MedicFilePDFResponse>> showMedicFilePDF(MedicFilePDFRequest request)
        {
            return new BL_Ficha().showMedicFilePDF(request);
        }
    }
}
