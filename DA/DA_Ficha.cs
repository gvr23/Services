using BE.entities;
using BE.request;
using BE.response;
using BE.utils;
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
        private LoginResponse Fill_LoginResponse(IDataReader reader)
        {
            LoginResponse loginResponse = new LoginResponse();
            int index;
            index = reader.GetOrdinal("userId");
            loginResponse.userId = reader.IsDBNull(index) ? -1 : reader.GetInt64(index);
            index = reader.GetOrdinal("userLoginName");
            loginResponse.userLoginName = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("profileId");
            loginResponse.profileId = reader.IsDBNull(index) ? -1 : reader.GetInt32(index);
            index = reader.GetOrdinal("profileType");
            loginResponse.profileType = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return loginResponse;
        }
        #endregion

        public DataResponse<List<EmployeeResponse>> getEmployees(EmployeeRequest request)
        {
            DataResponse<List<EmployeeResponse>> dataResponse = new DataResponse<List<EmployeeResponse>>();
            dataResponse.response = new GenericResponse();
            List<EmployeeResponse> employeeFiles = new List<EmployeeResponse>();
            IDataReader reader = null;

            using (DataBase db = new DataBase())
                try {
                    db.ProcedureName = "FM_Employees";
                    db.AddParameter("@locationCode", DbType.String, ParameterDirection.Input, request.locationCode);
                    db.AddParameter("@idNumber", DbType.String, ParameterDirection.Input, request.idNumber);
                    db.AddParameter("@employeeFullName", DbType.String, ParameterDirection.Input, request.employeeFullName);

                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        employeeFiles.Add(Fill_Employee_Response(reader));
                    }
                    reader.Close();

                    dataResponse.data = employeeFiles;
                    if(dataResponse.data.Count > 0)
                    {
                        dataResponse.response.status = Constants.RESULT_OK;
                        dataResponse.response.message = "Este usuario existe";
                    }
                    else
                    {
                        dataResponse.response.status = Constants.RESULT_EMPTY;
                        dataResponse.response.message = "No existe este usuario";
                    }
                }
                catch (Exception e)
                {
                    if (reader != null && !reader.IsClosed) reader.Close();
                    dataResponse.response.status = Constants.RESULT_FAILED;
                    dataResponse.response.message = e.Message;
                }
            return dataResponse;
        }
        #region
        private EmployeeResponse Fill_Employee_Response(IDataReader reader)
        {
            EmployeeResponse employeeResponse = new EmployeeResponse();
            int index;
            index = reader.GetOrdinal("name");
            employeeResponse.name = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("location");
            employeeResponse.location = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("email");
            employeeResponse.email = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("historyNumber");
            employeeResponse.historyNumber = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("dniNumber");
            employeeResponse.dniNumber = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("standing");
            employeeResponse.standing = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("employeeId");
            employeeResponse.employeeId = reader.IsDBNull(index) ? -1 : reader.GetInt64(index);

            return employeeResponse;
        }
        #endregion

        public DataResponse<List<MedicalFileHeaderResponse>> getMedicalFiles(MedicalFileRequest request)
        {
            DataResponse<List<MedicalFileHeaderResponse>> dataResponse = new DataResponse<List<MedicalFileHeaderResponse>>();
            dataResponse.response = new GenericResponse();
            List<MedicalFileHeaderResponse> medicalFileList = new List<MedicalFileHeaderResponse>();
            IDataReader reader = null;

            using (DataBase db = new DataBase())
                try
                {
                    db.ProcedureName = "FM_getMedicalFiles";
                    db.AddParameter("@dniNumber", DbType.String, ParameterDirection.Input, request.dniNumber);
                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        medicalFileList.Add(Fill_MedicalFileHeader_Response(reader));
                    }
                    reader.Close();

                    dataResponse.data = medicalFileList;
                    if (dataResponse.data.Count > 0)
                    {
                        dataResponse.response.status = Constants.RESULT_OK;
                        dataResponse.response.message = "Existen records para este usuario";
                    }
                    else
                    {
                        dataResponse.response.status = Constants.RESULT_EMPTY;
                        dataResponse.response.message = "No existen records para este usuario";

                    }
                }
                catch (Exception e)
                {
                    if (reader != null && !reader.IsClosed) reader.Close();
                    dataResponse.response.status = Constants.RESULT_FAILED;
                    dataResponse.response.message = e.Message;
                }

            return dataResponse;
        }
        #region
        private MedicalFileHeaderResponse Fill_MedicalFileHeader_Response(IDataReader reader)
        {
            MedicalFileHeaderResponse medicalFileHeaderResponse = new MedicalFileHeaderResponse();
            int index;
            index = reader.GetOrdinal("idMedicalFile");
            medicalFileHeaderResponse.idMedicalFile = reader.IsDBNull(index) ? -1 : reader.GetInt64(index);
            index = reader.GetOrdinal("documentNumber");
            medicalFileHeaderResponse.documentNumber = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("firstNames");
            medicalFileHeaderResponse.firstNames = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("lastNames");
            medicalFileHeaderResponse.lastNames = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("historyNumber");
            medicalFileHeaderResponse.historyNumber = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("locationShortName");
            medicalFileHeaderResponse.locationShortName = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("creationDate");
            medicalFileHeaderResponse.creationDate = reader.IsDBNull(index) ? DateTime.MinValue : reader.GetDateTime(index);

            return medicalFileHeaderResponse;
        }
        #endregion


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
