using System;

namespace Common
{
 
	/// <summary>
	/// Base Class to be implemented for all the record classes.
	/// This provides basic functions for validation and formatting which will be overwritten
	/// </summary>
	public class NandanaRecord
	{
		/// <summary>Separator for multiple fields </summary>
		protected string Separator="<br>";
		/// <summary>Multiple date fields having error.</summary>
		public string ErrorDateFields="";
		/// <summary>Multiple Numeric fields having error.</summary>
		public string ErrorNumericFields="";
		/// <summary>Multiple Maxlength violation fields .</summary>
		public string ErrorMaxLengthFields="";
		/// <summary>Multiple Mandatory fields having vialoation.</summary>
		public string ErrorMandatoryFields="";
		/// <summary>Error Desc.</summary>
		public string ErrorDescription;
		/// <summary>virtual function for validating date fields in the record class</summary>
		public virtual void ValidateDates(){}
		/// <summary>virtual function for validating numeric fields in the record class</summary>
		public virtual void ValidateNumeric(){}
		/// <summary>virtual function for validating maxlength of the fields in the record class</summary>
		public virtual void ValidateMaxLength(){}
		/// <summary>virtual function for validating mandatory fields in the record class</summary>
		public virtual void ValidateMandatory(){}
		/// <summary>virtual function for formatting for display </summary>
		public virtual void FormatForDisplay(){}
		/// <summary>virtual function for formatting for DB updates</summary>
		public virtual void FormatForDB(){}
		/// <summary>
		/// Function to validate UI Rules for ContactInfo Record
		/// </summary>
		/// <returns>Error String </returns>
		public virtual NandanaResult ValidateRules()
		{
			ValidateMandatory();
			ValidateDates();
			ValidateNumeric();
			ValidateMaxLength();
			ErrorDescription="";
			
			if(ErrorMandatoryFields.Length>0)
				ErrorDescription+= "The following fields are mandatory.<br>"+ErrorMandatoryFields;
			if(ErrorDateFields.Length>0) 
				ErrorDescription+= "The following date fields are invalid.<br>"+ErrorDateFields;
			if(ErrorNumericFields.Length>0) 
				ErrorDescription+= "The following numeric fields are invalid.<br>"+ErrorNumericFields;
			if(ErrorMaxLengthFields.Length>0) 
				ErrorDescription+= "The following fields have more no. of characters specified.<br>"+ErrorMaxLengthFields;

			if (ErrorDescription.Length>0)
				return (new NandanaResult(NandanaError.ErrorType.ERR_INVALID_DATA,ErrorDescription,null));
			return (new NandanaResult());
		
		}
	}
}

