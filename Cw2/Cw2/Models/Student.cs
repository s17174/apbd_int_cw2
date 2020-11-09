using System;
using System.Xml.Serialization;

namespace Cw2
{   [Serializable]
    [XmlType(Namespace = "Student")]
    public class Student
    {
        private string _id;
        private string _surname;

        [XmlElement(elementName:"Email")]
        public string Email { get; set; }

        [XmlElement(elementName: "First_Name")]
        public string Name { get; set; }

        [XmlElement(elementName: "Type_Of_Study")]
        public string TypeOfStudy { get; set; }

        [XmlElement(elementName: "Name_Of_Study")]
        public string NameOfStudy { get; set; }

        [XmlElement(elementName: "Birth_Day")]
        public string BirthDay { get; set; }

        [XmlElement(elementName: "Mothers_Name")]
        public string MothersName { get; set; }

        [XmlElement(elementName: "Fathers_Name")]
        public string FathersName { get; set; }

        [XmlElement(elementName: "Surname")]
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value ?? throw new ArgumentException();
            }
        }

        [XmlAttribute(attributeName:"Id")]
        public string Id
        {
            get { return _id; }
            set
            {
                _id = "s" + value ?? throw new ArgumentException();
                
            }
        }

        public override string ToString()
        {
            return Name + " " +  Surname + " " + Id;
        }
    }
}
