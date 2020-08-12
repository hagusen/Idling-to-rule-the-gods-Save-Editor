using System;
using System.ComponentModel;

namespace PropertyGridSample
{

	public class ParameterGroup
	{
		ParameterCollection Parameters = new ParameterCollection(); 
		Parameter[] paras = new Parameter[2];

		public ParameterGroup()
		{	
			// Instantiate test data objects and fill employee collection

			Parameter emp1 = new Parameter();
			
			emp1.Name = "Sales";
			emp1.Value = "234";
			this.Parameters.Add(emp1);

			Parameter emp2 = new Parameter();
			
			emp2.Name = "Accounting";
			emp2.Value = "534";
			this.Parameters.Add(emp2);

			paras[0] = emp1;
			paras[1] = emp2;
		}

		[TypeConverter(typeof(ParameterCollectionConverter))]
		public ParameterCollection Employees
		{
			get { return Parameters; }
		}
	}
}
