using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BE.response
{
    [DataContract]
    public class MedicFilePDFResponse
    {
        [DataMember(Order = 1)]
        public String nume_hhcc { get; set; }
        [DataMember(Order = 2)]
        public String tipoevaluacion { get; set; }
        [DataMember(Order = 3)]
        public String operacion { get; set; }

        [DataMember(Order = 4)]
        public String lugar { get; set; }
        [DataMember(Order = 5)]
        public String departamentolugar { get; set; }
        [DataMember(Order = 6)]
        public String provincialugar { get; set; }
        [DataMember(Order = 7)]
        public String distritolugar { get; set; }

        [DataMember(Order = 8)]
        public String razonsocial { get; set; }
        [DataMember(Order = 9)]
        public String actividadeconomica { get; set; }
        [DataMember(Order = 10)]
        public String departamentoemp { get; set; }
        [DataMember(Order = 11)]
        public String provinciaemp { get; set; }
        [DataMember(Order = 12)]
        public String distritoemp { get; set; }
        [DataMember(Order = 13)]
        public String nombretrab { get; set; }
        [DataMember(Order = 14)]
        public String dianac { get; set; }
        [DataMember(Order = 15)]
        public String mesnac { get; set; }
        [DataMember(Order = 16)]
        public String anionac { get; set; }
        [DataMember(Order = 17)]
        public String edad { get; set; }
        [DataMember(Order = 18)]
        public String docidentidad { get; set; }
        [DataMember(Order = 19)]
        public String estadocivil { get; set; }
        [DataMember(Order = 20)]
        public String domicilio { get; set; }
        [DataMember(Order = 21)]
        public String departamentotrab { get; set; }
        [DataMember(Order = 22)]
        public String provinciatrab { get; set; }
        [DataMember(Order =23)]
        public String distritotrab { get; set; }
        [DataMember(Order = 24)]
        public String residencia { get; set; }
        [DataMember(Order = 25)]
        public String tiemporesidencia { get; set; }
        [DataMember(Order = 26)]
        public String nomb_seguro { get; set; }
        [DataMember(Order = 27)]
        public String correo { get; set; }
        [DataMember(Order = 28)]
        public String telefono { get; set; }
        [DataMember(Order = 29)]
        public String gradoinstruccion { get; set; }
        [DataMember(Order = 30)]
        public String nrohijos { get; set; }
        [DataMember(Order = 31)]
        public String nrodependientes { get; set; }
        [DataMember(Order = 32)]
        public String puestotrabajo { get; set; }

        [DataMember(Order = 33)]
        public String ap_alergias { get; set; }
        [DataMember(Order = 34)]
        public String ap_diabetes { get; set; }
        [DataMember(Order = 35)]
        public String ap_ditbc { get; set; }
        [DataMember(Order = 36)]
        public String ap_hepatitis { get; set; }
        [DataMember(Order = 37)]
        public String ap_asma { get; set; }
        [DataMember(Order = 38)]
        public String ap_hta { get; set; }
        [DataMember(Order = 39)]
        public String ap_ets { get; set; }
        [DataMember(Order = 40)]
        public String ap_tifoidea { get; set; }
        [DataMember(Order = 41)]
        public String ap_bronquitis { get; set; }
        [DataMember(Order = 42)]
        public String ap_neoplasias { get; set; }
        [DataMember(Order = 43)]
        public String ap_convulsiones { get; set; }
        [DataMember(Order = 44)]
        public String ap_otro { get; set; }
        [DataMember(Order = 45)]
        public String ap_quemaduras { get; set; }
        [DataMember(Order = 46)]
        public String ap_cirugias { get; set; }
        [DataMember(Order = 47)]
        public String ap_intoxicaciones { get; set; }
        [DataMember(Order = 48)]
        public String ap_alcohol_tipo { get; set; }
        [DataMember(Order = 49)]
        public String ap_alcohol_cantidad { get; set; }
        [DataMember(Order = 50)]
        public String ap_alcohol_frecuencia { get; set; }
        [DataMember(Order = 51)]
        public String ap_tabaco_tipo { get; set; }
        [DataMember(Order = 52)]
        public String ap_tabaco_cantidad { get; set; }
        [DataMember(Order = 53)]
        public String ap_tabaco_frecuencia { get; set; }
        [DataMember(Order = 54)]
        public String ap_medicamentos_tipo { get; set; }
        [DataMember(Order = 55)]
        public String ap_medicamentos_cantidad { get; set; }
        [DataMember(Order = 56)]
        public String ap_medicamentos_frecuencia { get; set; }
        [DataMember(Order = 57)]
        public String ap_otros_tipo { get; set; }
        [DataMember(Order = 58)]
        public String ap_otros_cantidad { get; set; }
        [DataMember(Order = 59)]
        public String ap_otros_frecuencia { get; set; }
        [DataMember(Order = 60)]
        public String apf_padre { get; set; }
        [DataMember(Order = 61)]
        public String apf_madre { get; set; }
        [DataMember(Order = 62)]
        public String apf_hermanos { get; set; }
        [DataMember(Order = 63)]
        public String apf_esposo_a { get; set; }
        [DataMember(Order = 64)]
        public String apf_hijosvivos { get; set; }
        [DataMember(Order = 65)]
        public String apf_hijosfallecidos { get; set; }
        [DataMember(Order = 66)]
        public String al_enfermedadaccidente1 { get; set; }
        [DataMember(Order = 67)]
        public String al_asociadotrabajo1 { get; set; }
        [DataMember(Order = 68)]
        public String al_anio1 { get; set; }
        [DataMember(Order = 69)]
        public String al_diasdescanso1 { get; set; }
        [DataMember(Order = 70)]
        public String al_enfermedadaccidente2 { get; set; }
        [DataMember(Order = 71)]
        public String al_asociadotrabajo2 { get; set; }
        [DataMember(Order = 72)]
        public String al_anio2 { get; set; }
        [DataMember(Order = 73)]
        public String al_diasdescanso2 { get; set; }
        [DataMember(Order = 74)]
        public String al_enfermedadaccidente3 { get; set; }
        [DataMember(Order = 75)]
        public String al_asociadotrabajo3 { get; set; }
        [DataMember(Order = 76)]
        public String al_anio3 { get; set; }
        [DataMember(Order = 77)]
        public String al_diasdescanso3 { get; set; }
        [DataMember(Order = 78)]
        public String anamnesis { get; set; }
        [DataMember(Order = 79)]
        public String ec_talla { get; set; }
        [DataMember(Order = 80)]
        public String ec_peso { get; set; }
        [DataMember(Order = 81)]
        public String ec_imc { get; set; }
        [DataMember(Order = 82)]
        public String ec_abdominal { get; set; }
        [DataMember(Order = 83)]
        public String ec_fresp { get; set; }
        [DataMember(Order = 84)]
        public String ec_fcard { get; set; }
        [DataMember(Order = 85)]
        public String ec_pa { get; set; }
        [DataMember(Order = 86)]
        public String ec_temperatura { get; set; }
        [DataMember(Order = 87)]
        public String ec_estoscopia { get; set; }
        [DataMember(Order = 88)]
        public String ec_estadomental { get; set; }
        [DataMember(Order = 89)]
        public String pielsinhallazgo { get; set; }
        [DataMember(Order = 90)]
        public String pielhallazgo { get; set; }
        [DataMember(Order = 91)]
        public String cabellosinhallazgo { get; set; }
        [DataMember(Order = 92)]
        public String cabellohallazgo { get; set; }
        [DataMember(Order = 93)]
        public String ojoder1_1 { get; set; }
        [DataMember(Order = 94)]
        public String ojoizq1_1 { get; set; }
        [DataMember(Order = 95)]
        public String ojoder1_2 { get; set; }
        [DataMember(Order = 96)]
        public String ojoizq1_2 { get; set; }
        [DataMember(Order = 97)]
        public String ojoder2_1 { get; set; }
        [DataMember(Order = 98)]
        public String ojoizq2_1 { get; set; }
        [DataMember(Order = 99)]
        public String ojoder2_2 { get; set; }
        [DataMember(Order = 100)]
        public String ojoizq2_2 { get; set; }
        [DataMember(Order = 101)]
        public String ojofondo { get; set; }
        [DataMember(Order = 102)]
        public String ojocolor { get; set; }
        [DataMember(Order = 103)]
        public String ojoprofundidad { get; set; }
        [DataMember(Order = 104)]
        public String oidossinhallazgo { get; set; }
        [DataMember(Order = 105)]
        public String oidoshallazgo { get; set; }
        [DataMember(Order = 106)]
        public String narizsinhallazgo { get; set; }
        [DataMember(Order = 107)]
        public String narizhallazgo { get; set; }
        [DataMember(Order = 108)]
        public String bocasinhallazgo { get; set; }
        [DataMember(Order = 109)]
        public String bocahallazgo { get; set; }
        [DataMember(Order = 110)]
        public String faringesinhallazgo { get; set; }
        [DataMember(Order = 111)]
        public String faringehallazgo { get; set; }
        [DataMember(Order = 112)]
        public String cuellosinhallazgo { get; set; }
        [DataMember(Order = 113)]
        public String cuellohallazgo { get; set; }
        [DataMember(Order = 114)]
        public String respiratoriosinhallazgo { get; set; }
        [DataMember(Order = 115)]
        public String respiratoriohallazgo { get; set; }
        [DataMember(Order = 116)]
        public String cardiovascularsinhallazgo { get; set; }
        [DataMember(Order = 117)]
        public String cardiovascularhallazgo { get; set; }
        [DataMember(Order = 118)]
        public String digestivosinhallazgo { get; set; }
        [DataMember(Order = 119)]
        public String digestivohallazgo { get; set; }
        [DataMember(Order = 120)]
        public String locomotorsinhallazgo { get; set; }
        [DataMember(Order = 121)]
        public String locomotorhallazgo { get; set; }
        [DataMember(Order = 122)]
        public String marchasinhallazgo { get; set; }
        [DataMember(Order = 123)]
        public String marchahallazgo { get; set; }
        [DataMember(Order = 124)]
        public String columnasinhallazgo { get; set; }
        [DataMember(Order = 125)]
        public String columnahallazgo { get; set; }
        [DataMember(Order = 126)]
        public String miembrosupsinhallazgo { get; set; }
        [DataMember(Order = 127)]
        public String miembrosuphallazgo { get; set; }
        [DataMember(Order = 128)]
        public String miembroinfsinhallazgo { get; set; }
        [DataMember(Order = 129)]
        public String miembroinfhallazgo { get; set; }
        [DataMember(Order = 130)]
        public String sistemalinfsinhallazgo { get; set; }
        [DataMember(Order = 131)]
        public String sistemalinfhallazgo { get; set; }
        [DataMember(Order = 132)]
        public String sistemanerviososinhallazgo { get; set; }
        [DataMember(Order = 133)]
        public String sistemanerviosohallazgo { get; set; }
        [DataMember(Order = 134)]
        public String conclusionevalpsicologica { get; set; }
        [DataMember(Order = 135)]
        public String conclusionradiografica { get; set; }
        [DataMember(Order = 136)]
        public String hallazgopatologico { get; set; }
        [DataMember(Order = 137)]
        public String conclusionaudiometrica { get; set; }
        [DataMember(Order = 138)]
        public String conclusioespirometrica { get; set; }
        [DataMember(Order = 139)]
        public String conclusioneagudezavisual { get; set; }
        [DataMember(Order = 140)]
        public String conclusionotros { get; set; }
        [DataMember(Order = 141)]
        public String diagnosticomedico1 { get; set; }
        [DataMember(Order = 142)]
        public String diagnosticomedicoval1 { get; set; }
        [DataMember(Order = 143)]
        public String diagnosticomedico2 { get; set; }
        [DataMember(Order = 144)]
        public String diagnosticomedicoval2 { get; set; }
        [DataMember(Order = 145)]
        public String diagnosticomedico3 { get; set; }
        [DataMember(Order = 146)]
        public String diagnosticomedicoval3 { get; set; }
        [DataMember(Order = 147)]
        public String diagnosticomedico4 { get; set; }
        [DataMember(Order = 148)]
        public String diagnosticomedicoval4 { get; set; }
        [DataMember(Order = 149)]
        public String diagnosticomedico5 { get; set; }
        [DataMember(Order = 150)]
        public String diagnosticomedicoval5 { get; set; }
        [DataMember(Order = 151)]
        public String diagnosticomedico6 { get; set; }
        [DataMember(Order = 152)]
        public String diagnosticomedicoval6 { get; set; }
        [DataMember(Order = 153)]
        public String restricciones { get; set; }
        [DataMember(Order = 154)]
        public String recomendaciones { get; set; }
    }
}
