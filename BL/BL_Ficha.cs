using BE.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using BE.request;

namespace BL
{
   public class BL_Ficha
    {
        public DataResponse<LoginResponse> login(LoginRequest request)
        {
            return new DA_Ficha().login(request);
        }

        public DataResponse<List<EmployeeResponse>> getEmployees(EmployeeRequest request)
        {
            return new DA_Ficha().getEmployees(request);
        }

        public DataResponse<List<MedicalFileHeaderResponse>> getMedicalFiles(MedicalFileRequest request)
        {
            return new DA_Ficha().getMedicalFiles(request);
        }
    }
}
