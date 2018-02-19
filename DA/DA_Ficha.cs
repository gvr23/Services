using BE.entities;
using BE.request;
using BE.response;
using DA.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class DA_Ficha
    {
        public DataResponse<LoginResponse> login(LoginRequest request)
        {
            GenericResponse genericResponse = new GenericResponse();
            DataResponse<LoginResponse> dataResponse = new DataResponse<LoginResponse>();
            IDataReader reader = null;

            try
            {
                using (DataBase db = new DataBase())
                {
                    db.ProcedureName = "FM_Verify_Credentials";
                    //String password = MD5Hash(request.password);
                    db.AddParameter("@userName", DbType.String, ParameterDirection.Input, request.userName);
                    db.AddParameter("@password", DbType.String, ParameterDirection.Input, request.password);

                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        dataResponse.response = Fill_GenericResponse(reader);
                    }

                    if (dataResponse.response.status == 0)
                    {
                        reader.NextResult();
                        while (reader.Read())
                        {
                            dataResponse.data = Fill_LoginResponse(reader);
                        }
                        
                    }
                    reader.Close();
                }
            }
            catch(Exception e){
                if (reader != null && !reader.IsClosed) reader.Close();
                throw (e);
            }

            return dataResponse;
        }

        #region Mapping
        private GenericResponse Fill_GenericResponse(IDataReader reader)
        {
            GenericResponse genericResponse = new GenericResponse();
            int index;
            index = reader.GetOrdinal("status");
            genericResponse.status = reader.IsDBNull(index) ? -1 : reader.GetInt32(index);
            index = reader.GetOrdinal("message");
            genericResponse.message = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return genericResponse;
        }
        #endregion

        #region Mapping
        private LoginResponse Fill_LoginResponse(IDataReader reader)
        {
            LoginResponse loginResponse = new LoginResponse();
            int index;
            index = reader.GetOrdinal("userId");
            loginResponse.userId = reader.IsDBNull(index) ? 0 : reader.GetInt64(index);
            index = reader.GetOrdinal("userLoginName");
            loginResponse.userLoginName = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("profileId");
            loginResponse.profileId = reader.IsDBNull(index) ? 0 : reader.GetInt32(index);
            index = reader.GetOrdinal("profileType");
            loginResponse.profileType = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return loginResponse;
        }
        #endregion

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
