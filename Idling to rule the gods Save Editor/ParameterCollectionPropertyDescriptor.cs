using System;
using System.Text;
using System.ComponentModel;

namespace PropertyGridSample
{
	/// <summary>
	/// Summary description for CollectionPropertyDescriptor.
	/// </summary>
	public class ParameterCollectionPropertyDescriptor : PropertyDescriptor
	{
		private ParameterCollection collection = null;
		private int index = -1;

		public ParameterCollectionPropertyDescriptor(ParameterCollection coll, int idx) : 
			base( "#"+idx.ToString(), null )
		{
			this.collection = coll;
			this.index = idx;
		} 

		public override AttributeCollection Attributes
		{
			get 
			{ 
				return new AttributeCollection(null);
			}
		}

		public override bool CanResetValue(object component)
		{
			return true;
		}

		public override Type ComponentType
		{
			get 
			{ 
				return this.collection.GetType();
			}
		}

		public override string DisplayName {
            get {
                Parameter para = this.collection[index];
                return para.Name;
            }


        }
        /*
		public override string Description
		{
			get
			{

				Parameter emp = this.collection[index]; 
				StringBuilder sb = new StringBuilder();
				sb.Append(emp.LastName);
				sb.Append(",");
				sb.Append(emp.FirstName);
				sb.Append(",");
				sb.Append(emp.Age);
				sb.Append(" years old, working for ");
				sb.Append(emp.Department);
				sb.Append(" as ");
				sb.Append(emp.Role);
			
				return sb.ToString();
			}
		}
        */

        public override object GetValue(object component)
		{
			return this.collection[index];
		}

		public override bool IsReadOnly
		{
			get { return false;  }
		}

		public override string Name
		{
			get { return "#"+index.ToString(); }
		}

		public override Type PropertyType
		{
			get { return this.collection[index].GetType(); }
		}

		public override void ResetValue(object component)
		{
		}

		public override bool ShouldSerializeValue(object component)
		{
			return true;
		}

		public override void SetValue(object component, object value)
		{
			// this.collection[index] = value;
		}
	}
}
