using System;
using System.ComponentModel; 

namespace PropertyGridSample
{
	// This is a special type converter which will be associated with the Employee class.
	// It converts an Employee object to string representation for use in a property grid.
	internal class ParameterConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
            /*
			if( destType == typeof(string) && value is Parameter )
			{
				// Cast the value to an Employee type
				Parameter emp = (Parameter)value;

                // Return department and department role separated by comma.
                return "lol";//emp.Department + ", " + emp.Role;
			}
            */
			return base.ConvertTo(context,culture,value,destType);
		}
	}

	// This is a special type converter which will be associated with the EmployeeCollection class.
	// It converts an EmployeeCollection object to a string representation for use in a property grid.
	internal class ParameterCollectionConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType )
		{
			if( destType == typeof(string) && value is ParameterCollection )
			{
				// Return department and department role separated by comma.
				return "Company's employee data";
			}
			return base.ConvertTo(context,culture,value,destType);
		}
	}

}
