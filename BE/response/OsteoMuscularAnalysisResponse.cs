using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
   public class OsteoMuscularAnalysisResponse
    {
        [DataMember(Order = 1)]
        public String nume_hhcc { get; set; }

        [DataMember(Order = 2)]
        public String nombreTrabajador { get; set; }

        [DataMember(Order = 3)]
        public String ps_molestiaspiernaspies { get; set; }

        [DataMember(Order = 4)]
        public String ps_molestiashombroderecho { get; set; }

        [DataMember(Order = 5)]
        public String ps_molestiasmuslos { get; set; }

        [DataMember(Order = 6)]
        public String ps_molestiascuello { get; set; }

        [DataMember(Order = 7)]
        public String ps_molestiasnalgas { get; set; }

        [DataMember(Order = 8)]
        public String ps_tirantescosquilleomanos { get; set; }

        [DataMember(Order = 9)]
        public String ps_molestiaslumbares { get; set; }

        [DataMember(Order = 10)]
        public String ps_cordinacionfuerzamanos { get; set; }

        [DataMember(Order = 11)]
        public String ps_molestiasdorsalesaltas { get; set; }

        [DataMember(Order = 12)]
        public String ps_doloresmanos { get; set; }

        [DataMember(Order = 13)]
        public String pp_molestiaslumbosacras { get; set; }

        [DataMember(Order = 14)]
        public String pp_molestiaspiernas { get; set; }

        [DataMember(Order = 15)]
        public String pp_molestiasnalgas { get; set; }

        [DataMember(Order = 16)]
        public String pp_molestiastobillos { get; set; }

        [DataMember(Order = 17)]
        public String pp_molestiasmuslos { get; set; }

        [DataMember(Order = 18)]
        public String pp_molestiasrodilla { get; set; }

        [DataMember(Order = 19)]
        public String pp_molestiasdorsalesbaja { get; set; }

        [DataMember(Order = 20)]
        public String pp_molestiaspies { get; set; }

        [DataMember(Order = 21)]
        public String pp_observaciones { get; set; }

        [DataMember(Order = 22)]
        public String eg_hombro { get; set; }

        [DataMember(Order = 23)]
        public String eg_codo { get; set; }

        [DataMember(Order = 24)]
        public String eg_munieca { get; set; }

        [DataMember(Order = 25)]
        public String eg_cadera { get; set; }

        [DataMember(Order = 26)]
        public String eg_rodilla { get; set; }

        [DataMember(Order = 27)]
        public String eg_tobillo { get; set; }

        [DataMember(Order = 28)]
        public String eg_columnaVertebral { get; set; }

        [DataMember(Order = 29)]
        public String eg_columnaCervical { get; set; }

        [DataMember(Order = 30)]
        public String eg_columnaDorsal { get; set; }

        [DataMember(Order = 31)]
        public String eg_columnaLumbar { get; set; }

        [DataMember(Order = 32)]
        public String ma_cc_flexioextension { get; set; }

        [DataMember(Order = 33)]
        public String ma_cc_inclinacion { get; set; }

        [DataMember(Order = 34)]
        public String ma_cc_rotacion { get; set; }

        [DataMember(Order = 35)]
        public String ma_cd_flexion { get; set; }

        [DataMember(Order = 36)]
        public String ma_cd_rotacion { get; set; }

        [DataMember(Order = 37)]
        public String ma_cl_extensionflexion { get; set; }

        [DataMember(Order = 38)]
        public String ma_cl_inclinacion { get; set; }

        [DataMember(Order = 39)]
        public String ef_cv_dorsalnormal { get; set; }

        [DataMember(Order = 40)]
        public String ef_cv_dorsalconcavidadderecha { get; set; }

        [DataMember(Order = 41)]
        public String ef_cv_dorsalconcavidadizquierda { get; set; }

        [DataMember(Order = 42)]
        public String ef_cv_lumbarnormal { get; set; }

        [DataMember(Order = 43)]
        public String ef_cv_lumbarconcavidadderecha { get; set; }

        [DataMember(Order = 44)]
        public String ef_cv_lumbarconcavidadizquierda { get; set; }

        [DataMember(Order = 45)]
        public String ef_cvdap_cervicalnormal { get; set; }

        [DataMember(Order = 46)]
        public String ef_cvdap_cervicalconcavidadderecha { get; set; }

        [DataMember(Order = 47)]
        public String ef_cvdap_cervicalconcavidadizquierda { get; set; }

        [DataMember(Order = 48)]
        public String ef_cvdap_dorsalnormal { get; set; }

        [DataMember(Order = 49)]
        public String ef_cvdap_dorsalconcavidadderecha { get; set; }

        [DataMember(Order = 50)]
        public String ef_cvdap_dorsalconcavidadizquierda { get; set; }

        [DataMember(Order = 51)]
        public String ef_cvdap_lumbarnormal { get; set; }

        [DataMember(Order = 52)]
        public String ef_cvdap_lumbarconcavidadderecha { get; set; }

        [DataMember(Order = 53)]
        public String ef_cvdap_lumbarconcavidadizquierda { get; set; }

        [DataMember(Order = 54)]
        public String ef_hallasgoosteomuscular { get; set; }

        [DataMember(Order = 55)]
        public String ef_recomendaciones { get; set; }
    }
}
