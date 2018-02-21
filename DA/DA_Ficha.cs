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
        //login
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
        //login

        //employees
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
        //employees

        //medicalFilesHeader
        public DataResponse<List<MedicalFileHeaderResponse>> getMedicalFilesHeader(MedicalFileHeaderRequest request)
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
                    dataResponse.data = medicalFileList;
                    reader.Close();

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
        //medicalFilesHeader

        //evaluationsHeader
        public DataResponse<List<EvaluationHeaderResponse>> getEvaluationsHeader(EvaluationHeaderRequest request)
        {
            DataResponse <List<EvaluationHeaderResponse>> dataResponse = new DataResponse<List<EvaluationHeaderResponse>>();
            dataResponse.response = new GenericResponse();
            List<EvaluationHeaderResponse> evaluationsHeaderList = new List<EvaluationHeaderResponse>();
            IDataReader reader = null;

            using (DataBase db = new DataBase())
                try
                {
                    db.ProcedureName = "FM_getEvaluationsHeader";
                    db.AddParameter("@idMedicFile", DbType.Int64, ParameterDirection.Input, request.idMedicFile);
                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        evaluationsHeaderList.Add(Fill_EvaluationHeader_Response(reader));
                    }
                    dataResponse.data = evaluationsHeaderList;
                    reader.Close();
                    if (dataResponse.data.Count > 0)
                    {
                        dataResponse.response.status = Constants.RESULT_OK;
                        dataResponse.response.message = "Existen evaluaciones para esta ficha";
                    }
                    else
                    {
                        dataResponse.response.status = Constants.RESULT_EMPTY;
                        dataResponse.response.message = "No existen evaluaciones para esta ficha";

                    }
                }
                catch(Exception e)
                {
                    if (reader != null && !reader.IsClosed) reader.Close();
                    dataResponse.response.status = Constants.RESULT_FAILED;
                    dataResponse.response.message = e.Message;
                }
            return dataResponse;
        }
        #region
        private EvaluationHeaderResponse Fill_EvaluationHeader_Response(IDataReader reader)
        {
            EvaluationHeaderResponse evaluationHeaderResponse = new EvaluationHeaderResponse();
            int index;
            index = reader.GetOrdinal("evaluationId");
            evaluationHeaderResponse.evaluationId = reader.IsDBNull(index) ? -1 : reader.GetInt64(index);
            index = reader.GetOrdinal("creationDate");
            evaluationHeaderResponse.creationDate = reader.IsDBNull(index) ? DateTime.MinValue : reader.GetDateTime(index);
            index = reader.GetOrdinal("modifiedDate");
            evaluationHeaderResponse.modifiedDate = reader.IsDBNull(index) ? DateTime.MinValue : reader.GetDateTime(index);
            index = reader.GetOrdinal("evaluationStatus");
            evaluationHeaderResponse.evaluationStatus = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return evaluationHeaderResponse;
        }
        #endregion
        //evaluationsHeader

        //showMedicFilePDF
        public DataResponse<List<MedicFileResponse>> showMedicFileDetail(MedicFileRequest request)
        {
            DataResponse<List<MedicFileResponse>> dataResponse = new DataResponse<List<MedicFileResponse>>();
            dataResponse.response = new GenericResponse();
            List<MedicFileResponse> medicFilefList = new List<MedicFileResponse>();
            IDataReader reader = null;

            using (DataBase db = new DataBase())
                try
                {
                    db.ProcedureName = "FM_MedicFilesDetail";
                    db.AddParameter("@nume_hhcc", DbType.String, ParameterDirection.Input, request.historyNumber);
                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        medicFilefList.Add(Fill_MedicFile_Response(reader));
                    }
                    dataResponse.data = medicFilefList;
                    reader.Close();

                    if (dataResponse.data.Count > 0)
                    {
                        dataResponse.response.status = Constants.RESULT_OK;
                        dataResponse.response.message = "Existen archivos para esta ficha";
                    }
                    else
                    {
                        dataResponse.response.status = Constants.RESULT_EMPTY;
                        dataResponse.response.message = "No existen archivos para esta ficha";

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
        public MedicFileResponse Fill_MedicFile_Response(IDataReader reader)
        {
            MedicFileResponse medicFilePdfResponse = new MedicFileResponse();
            int index;
            index = reader.GetOrdinal("nume_hhcc");
            medicFilePdfResponse.nume_hhcc = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("tipoevaluacion");
            medicFilePdfResponse.tipoevaluacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("nomb_operacion");
            medicFilePdfResponse.operacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("nomb_lugar");
            medicFilePdfResponse.lugar = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("departamentoFicha");
            medicFilePdfResponse.departamentolugar = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("provinciaFicha");
            medicFilePdfResponse.provincialugar = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("distritoFicha");
            medicFilePdfResponse.distritolugar = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            index = reader.GetOrdinal("razonsocial");
            medicFilePdfResponse.razonsocial = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("actividadeconomica");
            medicFilePdfResponse.actividadeconomica = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("departamentoEmpresa");
            medicFilePdfResponse.departamentoemp = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("provinciaEmpresa");
            medicFilePdfResponse.provinciaemp = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("distritoEmpresa");
            medicFilePdfResponse.distritoemp = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            index = reader.GetOrdinal("nombreTrabajador");
            medicFilePdfResponse.nombretrab = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diaNac");
            medicFilePdfResponse.dianac = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("mesNac");
            medicFilePdfResponse.mesnac = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("anioNac");
            medicFilePdfResponse.anionac = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("edad");
            medicFilePdfResponse.edad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("documentoidentidad");
            medicFilePdfResponse.docidentidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("estadocivil");
            medicFilePdfResponse.estadocivil = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("domiciliofiscal");
            medicFilePdfResponse.domicilio = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("departamentoTrabajador");
            medicFilePdfResponse.departamentotrab = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("provinciaTrabajador");
            medicFilePdfResponse.provinciatrab = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("distritoTrabajador");
            medicFilePdfResponse.distritotrab = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("residenciatrabajo");
            medicFilePdfResponse.residencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("tiemporesidencia");
            medicFilePdfResponse.tiemporesidencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("id_tiposeguro");
            medicFilePdfResponse.nomb_seguro = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("correo");
            medicFilePdfResponse.correo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("telefono");
            medicFilePdfResponse.telefono = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("gradoinstruccion");
            medicFilePdfResponse.gradoinstruccion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("nrohijos");
            medicFilePdfResponse.nrohijos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("nrodependientes");
            medicFilePdfResponse.nrodependientes = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("puestotrabajo");
            medicFilePdfResponse.puestotrabajo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_alergias");
            medicFilePdfResponse.ap_alergias = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_diabetes");
            medicFilePdfResponse.ap_diabetes = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_ditbc");
            medicFilePdfResponse.ap_ditbc = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_hepatitis");
            medicFilePdfResponse.ap_hepatitis = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_asma");
            medicFilePdfResponse.ap_asma = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_hta");
            medicFilePdfResponse.ap_hta = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_ets");
            medicFilePdfResponse.ap_ets = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_tifoidea");
            medicFilePdfResponse.ap_tifoidea = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_bronquitis");
            medicFilePdfResponse.ap_bronquitis = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_neoplasias");
            medicFilePdfResponse.ap_neoplasias = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_convulsiones");
            medicFilePdfResponse.ap_convulsiones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_otro");
            medicFilePdfResponse.ap_otro = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_quemaduras");
            medicFilePdfResponse.ap_quemaduras = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_cirugias");
            medicFilePdfResponse.ap_cirugias = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_intoxicaciones");
            medicFilePdfResponse.ap_intoxicaciones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_alcohol_tipo");
            medicFilePdfResponse.ap_alcohol_tipo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_alcohol_cantidad");
            medicFilePdfResponse.ap_alcohol_cantidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_alcohol_frecuencia");
            medicFilePdfResponse.ap_alcohol_frecuencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_tabaco_tipo");
            medicFilePdfResponse.ap_tabaco_tipo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_tabaco_cantidad");
            medicFilePdfResponse.ap_tabaco_cantidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_tabaco_frecuencia");
            medicFilePdfResponse.ap_tabaco_frecuencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_medicamentos_tipo");
            medicFilePdfResponse.ap_medicamentos_tipo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_medicamentos_cantidad");
            medicFilePdfResponse.ap_medicamentos_cantidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_medicamentos_frecuencia");
            medicFilePdfResponse.ap_medicamentos_frecuencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_otros_tipo");
            medicFilePdfResponse.ap_otros_tipo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_otros_cantidad");
            medicFilePdfResponse.ap_otros_cantidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ap_otros_frecuencia");
            medicFilePdfResponse.ap_otros_frecuencia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_padre");
            medicFilePdfResponse.apf_padre = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_madre");
            medicFilePdfResponse.apf_madre = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_hermanos");
            medicFilePdfResponse.apf_hermanos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_esposo_a");
            medicFilePdfResponse.apf_esposo_a = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_hijosvivos");
            medicFilePdfResponse.apf_hijosvivos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("apf_hijosfallecidos");
            medicFilePdfResponse.apf_hijosfallecidos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_enfermedadaccidente1");
            medicFilePdfResponse.al_enfermedadaccidente1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_asociadotrabajo1");
            medicFilePdfResponse.al_asociadotrabajo1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_anio1");
            medicFilePdfResponse.al_asociadotrabajo1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_diasdescanso1");
            medicFilePdfResponse.al_diasdescanso1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_enfermedadaccidente2");
            medicFilePdfResponse.al_enfermedadaccidente2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_asociadotrabajo2");
            medicFilePdfResponse.al_asociadotrabajo2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_anio2");
            medicFilePdfResponse.al_anio2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_diasdescanso2");
            medicFilePdfResponse.al_diasdescanso2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_enfermedadaccidente3");
            medicFilePdfResponse.al_enfermedadaccidente3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_asociadotrabajo3");
            medicFilePdfResponse.al_asociadotrabajo3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_anio3");
            medicFilePdfResponse.al_anio3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("al_diasdescanso3");
            medicFilePdfResponse.al_diasdescanso3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("anamnesis");
            medicFilePdfResponse.anamnesis = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_tallamts");
            medicFilePdfResponse.ec_talla = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_pesokg");
            medicFilePdfResponse.ec_peso = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_imckgml2");
            medicFilePdfResponse.ec_imc = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_perimetroabdominal");
            medicFilePdfResponse.ec_abdominal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_fresp");
            medicFilePdfResponse.ec_fresp = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_fcard");
            medicFilePdfResponse.ec_fcard = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_pa");
            medicFilePdfResponse.ec_pa = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_temperatura");
            medicFilePdfResponse.ec_temperatura = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_ectoscopia");
            medicFilePdfResponse.ec_estoscopia = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ec_estadomental");
            medicFilePdfResponse.ec_estadomental = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_piel_sinhallazgo");
            medicFilePdfResponse.pielsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_piel_hallazgo");
            medicFilePdfResponse.pielhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cabello_sinhallazgo");
            medicFilePdfResponse.bocasinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cabello_hallazgo");
            medicFilePdfResponse.cabellohallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_lejos_od");
            medicFilePdfResponse.ojoder1_1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_lejos_oi");
            medicFilePdfResponse.ojoizq1_1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_lejoscorrectores_od");
            medicFilePdfResponse.ojoder1_2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_lejoscorrectores_oi");
            medicFilePdfResponse.ojoizq1_2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_cerca_od");
            medicFilePdfResponse.ojoder2_1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_cerca_oi");
            medicFilePdfResponse.ojoizq2_1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_cercacorrecores_od");
            medicFilePdfResponse.ojoizq2_2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_cercacorrecores_oi");
            medicFilePdfResponse.ojoizq2_2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_fondo");
            medicFilePdfResponse.ojofondo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_visoncolores");
            medicFilePdfResponse.ojocolor = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_ojo_visionprofundidad");
            medicFilePdfResponse.ojoprofundidad = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_oidos_sinhallazgo");
            medicFilePdfResponse.oidossinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_oidos_hallazgo");
            medicFilePdfResponse.oidoshallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_nariz_sinhallazgo");
            medicFilePdfResponse.narizsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_nariz_hallazgo");
            medicFilePdfResponse.narizhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_boca_sinhallazgo");
            medicFilePdfResponse.bocasinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_boca_hallazgo");
            medicFilePdfResponse.bocahallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_faringe_sinhallazgo");
            medicFilePdfResponse.faringesinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_faringe_hallazgo");
            medicFilePdfResponse.faringehallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cuello_sinhallazgo");
            medicFilePdfResponse.cuellosinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cuello_hallazgo");
            medicFilePdfResponse.cuellohallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_aprespiratorio_sinhallazgo");
            medicFilePdfResponse.respiratoriosinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_aprespiratorio_hallazgo");
            medicFilePdfResponse.respiratoriohallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_apcardiovascular_sinhallazgo");
            medicFilePdfResponse.cardiovascularsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_apcardiovascular_hallazgo");
            medicFilePdfResponse.cardiovascularhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_apdigestivo_sinhallazgo");
            medicFilePdfResponse.digestivosinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_apdigestivo_hallazgo");
            medicFilePdfResponse.digestivohallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_aplocomotor_sinhallazgo");
            medicFilePdfResponse.locomotorsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_aplocomotor_hallazgo");
            medicFilePdfResponse.locomotorhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_marcha_sinhallazgo");
            medicFilePdfResponse.marchasinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_marcha_hallazgo");
            medicFilePdfResponse.marchahallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_columna_sinhallazgo");
            medicFilePdfResponse.columnasinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_columna_hallazgo");
            medicFilePdfResponse.columnahallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_miembsup_sinhallazgo");
            medicFilePdfResponse.miembrosupsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_miembsup_hallazgo");
            medicFilePdfResponse.miembrosuphallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_miembinf_sinhallazgo");
            medicFilePdfResponse.miembroinfsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_miembinf_hallazgo");
            medicFilePdfResponse.miembroinfhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_sistlinfat_sinhallazgo");
            medicFilePdfResponse.sistemalinfsinhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_sistlinfat_hallazgo");
            medicFilePdfResponse.sistemalinfhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_sistnerv_sinhallazgo");
            medicFilePdfResponse.sistemalinfhallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_sistnerv_hallazgo");
            medicFilePdfResponse.sistemanerviosohallazgo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusionevalpsicologica");
            medicFilePdfResponse.conclusionevalpsicologica = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusionradiografica");
            medicFilePdfResponse.conclusionradiografica = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("hallazgopatologico");
            medicFilePdfResponse.hallazgopatologico = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusionaudiometrica");
            medicFilePdfResponse.conclusionaudiometrica = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusioespirometrica");
            medicFilePdfResponse.conclusioespirometrica = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusioneagudezavisual");
            medicFilePdfResponse.conclusioneagudezavisual = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("conclusionotros");
            medicFilePdfResponse.conclusionotros = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico1");
            medicFilePdfResponse.diagnosticomedico1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval1");
            medicFilePdfResponse.diagnosticomedicoval1 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico2");
            medicFilePdfResponse.diagnosticomedico2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval2");
            medicFilePdfResponse.diagnosticomedicoval2 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico3");
            medicFilePdfResponse.diagnosticomedico3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval3");
            medicFilePdfResponse.diagnosticomedicoval3 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico4");
            medicFilePdfResponse.diagnosticomedico4 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval4");
            medicFilePdfResponse.diagnosticomedicoval4 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico5");
            medicFilePdfResponse.diagnosticomedico5 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval5");
            medicFilePdfResponse.diagnosticomedicoval5 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedico6");
            medicFilePdfResponse.diagnosticomedico6 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("diagnosticomedicoval6");
            medicFilePdfResponse.diagnosticomedicoval6 = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("restricciones");
            medicFilePdfResponse.restricciones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("recomendaciones");
            medicFilePdfResponse.recomendaciones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return medicFilePdfResponse;
        }
        #endregion
        //showMedicFilePDF

        //showOsteomuscularAnalysis
        public DataResponse<List<OsteoMuscularAnalysisResponse>> showOsteoMuscularAnalysis(OsteoMuscularAnalysisRequest request)
        {
            DataResponse<List<OsteoMuscularAnalysisResponse>> dataResponse = new DataResponse<List<OsteoMuscularAnalysisResponse>>();
            dataResponse.response = new GenericResponse();
            List<OsteoMuscularAnalysisResponse> osteoMuscularAnalysisList = new List<OsteoMuscularAnalysisResponse>();
            IDataReader reader = null;

            using (DataBase db = new DataBase())
                try
                {
                    db.ProcedureName = "FM_OsteoMuscularAnalysis";
                    db.AddParameter("@nume_hhcc", DbType.String, ParameterDirection.Input, request.historyNumber);
                    reader = db.GetDataReader();

                    while (reader.Read())
                    {
                        osteoMuscularAnalysisList.Add(Fill_OsteoMuscularAnalasysis(reader));
                    }
                    dataResponse.data = osteoMuscularAnalysisList;
                    reader.Close();

                    if (dataResponse.data.Count > 0)
                    {
                        dataResponse.response.status = Constants.RESULT_OK;
                        dataResponse.response.message = "Existen examenes osteo musculares para esta ficha";
                    }
                    else
                    {
                        dataResponse.response.status = Constants.RESULT_EMPTY;
                        dataResponse.response.message = "No existen examenes osteo musculares para esta ficha";

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
        private OsteoMuscularAnalysisResponse Fill_OsteoMuscularAnalasysis(IDataReader reader)
        {
            OsteoMuscularAnalysisResponse osteoMuscularAnalysis = new OsteoMuscularAnalysisResponse();
            int index;

            index = reader.GetOrdinal("nume_hhcc");
            osteoMuscularAnalysis.nume_hhcc = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("nombreTrabajador");
            osteoMuscularAnalysis.nombreTrabajador = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiaspiernaspies");
            osteoMuscularAnalysis.ps_molestiaspiernaspies = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiashombroderecho");
            osteoMuscularAnalysis.ps_molestiashombroderecho = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiasmuslos");
            osteoMuscularAnalysis.ps_molestiasmuslos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiascuello");
            osteoMuscularAnalysis.ps_molestiascuello = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiasnalgas");
            osteoMuscularAnalysis.ps_molestiasnalgas = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_tirantescosquilleomanos");
            osteoMuscularAnalysis.ps_tirantescosquilleomanos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_molestiaslumbares");
            osteoMuscularAnalysis.ps_molestiaslumbares = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_cordinacionfuerzamanos");
            osteoMuscularAnalysis.ps_cordinacionfuerzamanos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ps_doloresmanos");
            osteoMuscularAnalysis.ps_doloresmanos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiaslumbosacras");
            osteoMuscularAnalysis.pp_molestiaslumbosacras = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiaspiernas");
            osteoMuscularAnalysis.pp_molestiaspiernas = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiastobillos");
            osteoMuscularAnalysis.pp_molestiastobillos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiasmuslos");
            osteoMuscularAnalysis.pp_molestiasmuslos = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiasrodilla");
            osteoMuscularAnalysis.pp_molestiasrodilla = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiasdorsalesbaja");
            osteoMuscularAnalysis.pp_molestiasdorsalesbaja = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_molestiaspies");
            osteoMuscularAnalysis.pp_molestiaspies = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("pp_observaciones");
            osteoMuscularAnalysis.pp_observaciones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_hombro");
            osteoMuscularAnalysis.eg_hombro = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_codo");
            osteoMuscularAnalysis.eg_codo = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_munieca");
            osteoMuscularAnalysis.eg_munieca = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_cadera");
            osteoMuscularAnalysis.eg_cadera = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_rodilla");
            osteoMuscularAnalysis.eg_rodilla = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_columnaVertebral");
            osteoMuscularAnalysis.eg_columnaVertebral = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_columnaCervical");
            osteoMuscularAnalysis.eg_columnaCervical = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("eg_columnaDorsal");
            osteoMuscularAnalysis.eg_columnaDorsal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cc_flexioextension");
            osteoMuscularAnalysis.ma_cc_flexioextension = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cc_inclinacion");
            osteoMuscularAnalysis.ma_cc_inclinacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cc_rotacion");
            osteoMuscularAnalysis.ma_cc_rotacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cd_flexion");
            osteoMuscularAnalysis.ma_cd_flexion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cd_rotacion");
            osteoMuscularAnalysis.ma_cd_rotacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cl_extensionflexion");
            osteoMuscularAnalysis.ma_cl_extensionflexion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ma_cl_inclinacion");
            osteoMuscularAnalysis.ma_cl_inclinacion = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_dorsalnormal");
            osteoMuscularAnalysis.ef_cv_dorsalnormal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_dorsalconcavidadderecha");
            osteoMuscularAnalysis.ef_cv_dorsalconcavidadderecha = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_dorsalconcavidadizquierda");
            osteoMuscularAnalysis.ef_cv_dorsalconcavidadizquierda = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_lumbarnormal");
            osteoMuscularAnalysis.ef_cv_lumbarnormal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_lumbarconcavidadderecha");
            osteoMuscularAnalysis.ef_cv_lumbarconcavidadderecha = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cv_lumbarconcavidadizquierda");
            osteoMuscularAnalysis.ef_cv_lumbarconcavidadizquierda = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_cervicalnormal");
            osteoMuscularAnalysis.ef_cvdap_cervicalnormal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_cervicalconcavidadderecha");
            osteoMuscularAnalysis.ef_cvdap_cervicalconcavidadderecha = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_cervicalconcavidadizquierda");
            osteoMuscularAnalysis.ef_cvdap_cervicalconcavidadizquierda = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_dorsalnormal");
            osteoMuscularAnalysis.ef_cvdap_dorsalnormal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_dorsalconcavidadderecha");
            osteoMuscularAnalysis.ef_cvdap_dorsalconcavidadderecha = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_dorsalconcavidadizquierda");
            osteoMuscularAnalysis.ef_cvdap_dorsalconcavidadizquierda = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_lumbarnormal");
            osteoMuscularAnalysis.ef_cvdap_lumbarnormal = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_lumbarconcavidadderecha");
            osteoMuscularAnalysis.ef_cvdap_lumbarconcavidadderecha = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_cvdap_lumbarconcavidadizquierda");
            osteoMuscularAnalysis.ef_cvdap_lumbarconcavidadizquierda = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_hallasgoosteomuscular");
            osteoMuscularAnalysis.ef_hallasgoosteomuscular = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);
            index = reader.GetOrdinal("ef_recomendaciones");
            osteoMuscularAnalysis.ef_recomendaciones = reader.IsDBNull(index) ? String.Empty : reader.GetString(index);

            return osteoMuscularAnalysis;
        }
        //showOsteomuscularAnalysis

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
