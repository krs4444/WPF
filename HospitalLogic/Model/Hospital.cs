using System.Collections.Generic;
using System.Xml.Serialization;

namespace HospitalLogic.Model
{
    [XmlRoot]
    public class Hospital
    {
        [XmlElement("Patient")]
        public List<Patient> Patients { get; set; }
    }
}
