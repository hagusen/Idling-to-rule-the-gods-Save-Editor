using System;
using System.Text;
using System.ComponentModel;

namespace PropertyGridSample
{

	[TypeConverter(typeof(ParameterConverter))]
	public class Parameter
	{
		private string name = "";
		private string value = "";

		public Parameter()
		{
		}
        [Browsable(false)]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        
        [Category("Required")]
		public string Value
		{
			get { return value; }
			set { this.value = value; }
		}


	}

}
