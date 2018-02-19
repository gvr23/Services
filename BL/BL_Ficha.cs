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
    }
}
