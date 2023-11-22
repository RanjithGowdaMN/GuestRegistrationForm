using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuestRegistrationDesktopUI.Library.Models
{
	[XmlRoot(ElementName = "CompanyNameList")]
	public class CompanyNameList
	{

		[XmlElement(ElementName = "CompanyNames")]
		public string CompanyNames { get; set; }
	}

	[XmlRoot(ElementName = "ArrayOfCompanyNameList")]
	public class ArrayOfCompanyNameList
	{

		[XmlElement(ElementName = "CompanyNameList")]
		public List<CompanyNameList> CompanyNameList { get; set; }

		[XmlAttribute(AttributeName = "i")]
		public string I { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
