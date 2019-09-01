using HospitalLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HospitalLogic.ViewModel
{
    public static class PatientDataSource
    {
        public static Task<List<Patient>> GetPatientsAsync()
        {
            return Task.Run(() =>
            {
                var xmlDeserializer = new XmlSerializer(typeof(Hospital));

                Hospital hospital;

                using (var pStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("HospitalLogic.Data.patients.xml"))
                {
                    hospital = (Hospital)xmlDeserializer.Deserialize(pStream);
                }

                return hospital.Patients;
            });
        }
    }
}
