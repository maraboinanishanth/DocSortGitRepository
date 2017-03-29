  using System;
using System.Text.RegularExpressions;
using System.Data;

namespace Common
{
 	/// <summary>
	/// functions for validation using Regular Expression.
	/// </summary>
	public class RegExValidator
	{
		private RegExValidator()
		{
			//
			// TODO: Add constructor logic here 
			//
		}
		/// <summary>
		/// Function to Validate Date field
		/// </summary>
		/// <param name="strIn">Date in string</param>
		/// <returns>true if date field else false</returns>
		public static bool IsValidDate(string strIn)
		{

			if((strIn == null)||strIn.Length==0)
				return true;
			//Will match the following date formats: Preceded by a Space, Left-parentheses, or at the beginning of a line.  Followed by a Space, Right-parentheses, or Colon(:), word boundary or End of line.  Can have / or - as separator.  Accepts 2 digit year 00-99 or 4 digit years 1900-2099 (can modify to accept any range)
			//return Regex.IsMatch(strIn, @"(^|\s|\()((([1-9]){1}|([0][1-9]){1}|([1][012]){1}){1}[\/-]((2[0-9]){1}|(3[01]){1}|([01][1-9]){1}|([1-9]){1}){1}[\/-](((19|20)([0-9][0-9]){1}|([0-9][0-9]){1})){1}(([\s|\)|:])|(^|\s|\()((([0-9]){1}|([0][1-9]){1}|([1][012]){1}){1}[\/-](([11-31]){1}|([01][1-9]){1}|([1-9]){1}){1}[\/-](((19|20)([0-9][0-9]){1}|([0-9][0-9]){1})){1}(([\s|\)|:|$|\&gt;])){1}){1}){1}){1}");
				
			// DateTime Validator. This RE validates both dates and/or times patterns. Days in Feb. are also validated for Leap years.
			return Regex.IsMatch(strIn, @"^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$");
			
			//This RE validate Dates in the MMM dd, yyyy format from Jan 1, 1600 to Dec 31, 9999. The format is as follows: The name or 3 letter abbreivation, without a period, of the month, then a space then the day value then a comma then a space finally the year
			//return Regex.IsMatch(strIn, @"^((31(?!\ (Apr(il)?|June?|(Sept|Nov)(ember)?)))|((30|29)(?!\ Feb(ruary)?))|(29(?=\ Feb(ruary)?\ (((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])\ (Jan(uary)?|Feb(ruary)?|Ma(r(ch)?|y)|Apr(il)?|Ju((ly?)|(ne?))|Aug(ust)?|Oct(ober)?|(Sept|Nov|Dec)(ember)?)\ ((1[6-9]|[2-9]\d)\d{2})$");

			//This RE validates dates in the dd MMM yyyy format. Spaces separate the values. Month value is either the full name of the month or the 3 letter abbrieviation without a period. Days for the month are validated for all month, including Feb in leap years
			//return Regex.IsMatch(strIn, @"^(?:(((Jan(uary)?|Ma(r(ch)?|y)|Jul(y)?|Aug(ust)?|Oct(ober)?|Dec(ember)?)\ 31)|((Jan(uary)?|Ma(r(ch)?|y)|Apr(il)?|Ju((ly?)|(ne?))|Aug(ust)?|Oct(ober)?|(Sept|Nov|Dec)(ember)?)\ (0?[1-9]|([12]\d)|30))|(Feb(ruary)?\ (0?[1-9]|1\d|2[0-8]|(29(?=,\ ((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))))\,\ ((1[6-9]|[2-9]\d)\d{2}))");
			
			//YYYY/MM/DD hh:mm:ss format DateTime Regex
			//return Regex.IsMatch(strIn, @"^(?ni:(?=\d)((?'year'((1[6-9])|([2-9]\d))\d\d)(?'sep'[/.-])(?'month'0?[1-9]|1[012])\2(?'day'((?<!(\2((0?[2469])|11)\2))31)|(?<!\2(0?2)\2)(29|30)|((?<=((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(16|[2468][048]|[3579][26])00)\2\3\2)29)|((0?[1-9])|(1\d)|(2[0-8])))(?:(?=\x20\d)\x20|$))?((?<time>((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2}))?)$");

			// Validates a date expression (or empty value) in CCYYMMDD format, checking a leap year from 00000101 A.D. to 99991231 
			//return Regex.IsMatch(strIn, @"^(((\d{4}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|((\d{2}[02468][048]|\d{2}[13579][26]))0229)){0,8}$");
 
		}
		/// <summary>
		/// Validate Weekday
		/// </summary>
		/// <param name="strIn">Weekday</param>
		/// <returns>true if weekday value else false</returns>
		public static bool IsValidWeekday(string strIn)
		{
			return Regex.IsMatch(strIn, @"^(Sun|Mon|(T(ues|hurs))|Fri)(day|\.)?$|Wed(\.|nesday)?$|Sat(\.|urday)?$|T((ue?)|(hu?r?))\.?$");
		}
		/// <summary>
		/// Valdiate Date in SQL ANSI format
		/// </summary>
		/// <param name="strIn">Date</param>
		/// <returns>true if valid SQL ANSI date</returns>
		public static bool IsValidSQLDate(string strIn)
		{
			//Matches ANSI SQL date format YYYY-mm-dd hh:mi:ss am/pm. You can use / - or space for date delimiters
			return Regex.IsMatch(strIn, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$");
		}
		/// <summary>
		/// Valdiate string as Email Address
		/// </summary>
		/// <param name="strIn">Email Address</param>
		/// <returns>true if valid email address</returns>
		public static bool IsValidEmail(string strIn)
		{
			// Return true if strIn is in valid e-mail format.
			//
			//return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
			//return Regex.IsMatch(strIn, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
			return Regex.IsMatch(strIn, @"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]+$");
		}
		/// <summary>
		///  Validate Integer
		/// </summary>
		/// <param name="strIn">Numeric Value</param>
		/// <returns>true if valid integer value</returns>
		public static bool IsValidInt(string strIn)
		{
			if(strIn == null) 
				return false;
			return Regex.IsMatch(strIn,"^[1-9]+[0-9]*$");

		}
		/// <summary>
		///  Validate Numeric value
		/// </summary>
		/// <param name="strIn">Numeric Value</param>
		/// <returns>true if valid numeric value</returns>
		public static bool IsValidNumeric(string strIn)
		{
			//return Regex.IsMatch(strIn, @"^(\-)?1000([.][0]{1,3})?$|^(\-)?\d{1,3}$|^(\-)?\d{1,3}([.]\d{1,3})$|^(\-)?([.]\d{1,3})$");
			//return Regex.IsMatch(strIn, @"'^0|[1-9][0-9]*|[1-9][0-9]*[.][0-9]{1,2}$'");
			if(RegExValidator.ValidateIsNull(strIn))
				return Regex.IsMatch(strIn, @"^(\d|-)?(\d|,)*\.?\d*$");
			else
				return true;
			//return Regex.IsMatch(strIn, @"^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$");
		}
		//validate US SSN AAA-GG-SSSS or AAA GG SSSS
		//^(?!000)([0-6]\d{2}|7([0-6]\d|7[012]))([ -])?(?!00)\d\d\3(?!0000)\d{4}$
		//(^|\s)\d{3}(-?|[\. ])\d{2}\2\d{4}($|\s|[;:,!\.\?])

		// phone number
		//Regular expression for validating US telephone numbers with OPTIONAL area code, and OPTIONAL extension. Matches various permutations of formatting characters (parenthesis, space, dash).
		//^(?:(?<1>[(])?(?<AreaCode>[2-9]\d{2})(?(1)[)])(?(1)(?<2>[ ])|(?:(?<3>[-])|(?<4>[ ])))?)?(?<Prefix>[1-9]\d{2})(?(AreaCode)(?:(?(1)(?(2)[- ]|[-]?))|(?(3)[-])|(?(4)[- ]))|[- ]?)(?<Suffix>\d{4})(?:[ ]?[xX]?(?<Ext>\d{2,4}))?$
		//tel no check
		//((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})

		//US Zip Code + 4 digit extension Postal Code
		//^[0-9]{5}([- /]?[0-9]{4})?$
		
		//Regular expression for US (ZIP and ZIP+4) and Canadian postal codes. It allows 5 digits for the first US postal code and requires that the +4, if it exists, is four digits long. Canadain postal codes can contain a space and take form of A1A 1A1.
		//^((\d{5}-\d{4})|(\d{5})|([AaBbCcEeGgHhJjKkLlMmNnPpRrSsTtVvXxYy]\d[A-Za-z]\s?\d[A-Za-z]\d))$
		//This expression matches three different formats of postal codes: 5 digit US ZIP code, 5 digit US ZIP code + 4, and 6 digit alphanumeric Canadian Postal Code. The first one must be 5 numeric digits. The ZIP+4 must be 5 numeric digits, a hyphen, and 
		//^\d{5}-\d{4}|\d{5}|[A-Z]\d[A-Z] \d[A-Z]\d$

		/// <summary>
		/// Validate MaxLength of the string value
		/// </summary>
		/// <param name="strItem">String </param>
		/// <param name="iLen">Max allowed Length</param>
		/// <param name="bTruncate">Truncate Option</param>
		/// <returns>true if length less than iLen. If bTruncate is true then trunctatd string written in the strItem</returns>
		public static bool IsValidMaxLenth(ref string strItem,int iLen,bool bTruncate)
		{
			bool bValidate = false;
			if ((strItem==null) ||(strItem.Length<=iLen))
				bValidate = true;
			else if (bTruncate) 
			{
				strItem= strItem.Substring(0,iLen);
				bValidate = true;
			}
			return bValidate;
		}
		/// <summary>
		/// Checks whether object is null or not and returns false if null
		/// </summary>
		/// <param name="oItem">oItem object to check</param>
		/// <returns>true if object is not null, else false</returns>
		public static bool ValidateIsNull(object oItem)
		{
			bool bReturn = true;
			if(oItem == null) // Object is null
				bReturn = false;
			else if(oItem.GetType() == typeof(System.String)) // if object is not null but length of the string is 0;
			{
				string sItem = ((string)oItem).Trim();
				if(sItem.Length==0)
					bReturn = false;
			}
			else if(oItem.GetType() == typeof(int))
			{
				if ((int)oItem==0)
					bReturn = false;
			}
			return bReturn;
		}
		/// <summary>
		/// Compare Two strings 
		/// </summary>
		/// <param name="strIn">String to be compared</param>
		/// <param name="strValue">string to compared with</param>
		/// <returns>true if both strings are same</returns>
		public static bool Compare(string strIn, string strValue)
		{
			if(strIn==null || strValue ==null)
				return false;
			if(strIn == strValue)
				return true;
			return false;
		}
		/// <summary>
		/// Compare Two strings without case
		/// </summary>
		/// <param name="strIn">String to be compared</param>
		/// <param name="strValue">string to compared with</param>
		/// <returns>true if both strings are same</returns>
		public static bool CompareNoCase(string strIn, string strValue)
		{
			if(strIn==null || strValue ==null)
				return false;
			if(strIn.ToLower() == strValue.ToLower())
				return true;
			return false;
		}
	}

	/// <summary>
	/// Different Regular Expression Patterns
	/// </summary>
	public class RegExPatterns
	{
		/// <summary>Generalize Date RegEx</summary>
		public static string DATE = @"^(?:(?:(?:0[13578]|1[02])([\/|\-|\.]?)31)\1|(?:(?:0[1,3-9]|1[0-2])([\/|\-|\.]?)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)\d{2})$|^(?:02([\/|\-|\.]?)29\3(?:(?:(?:1[6-9]|[2-9]\d)(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:(?:0[1-9])|(?:1[0-2]))([\/|\-|\.]?)(?:0[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)\d{2})$";
		/// <summary>UK Postcode RegEx</summary> 
		public static string ZIP_UKCOMP = @"(?:(?:A[BL]|B[ABDHLNRST]?|" +
			@"C[ABFHMORTVW]|D[ADEGHLNTY]|E[CHNX]?|F[KY]|G[LUY]?|" +
			@"H[ADGPRSUX]|I[GMPV]|JE|K[ATWY]|L[ADELNSU]?|M[EKL]?|" +
			@"N[EGNPRW]?|O[LX]|P[AEHLOR]|R[GHM]|S[AEGKLMNOPRSTWY]?|" +
			@"T[ADFNQRSW]|UB|W[ACDFNRSV]?|YO|ZE)" +
			@"\d(?:\d|[A-Z])? \d[A-Z]{2})";

		/// <summary>A simpler expression that does not check for valid postcode areas RegEx</summary> 
		public static string ZIP_UK =@"(?:[A-Z]{1,2}\d(?:\d|[A-Z])? \d[A-Z]{2})";

		/// <summary>Zip or Zip+4 RegEx</summary> 
		public static string ZIP_US = @"(?:\d{5}(?:-\d{4})?)";

		/// <summary>Canadian postal codes RegEx</summary> 
		public static string Zip_CA = @"(?:[A-Z]\d[A-Z] \d[A-Z]\d)";

		/// <summary>Most European postal codes RegEx</summary> 
		public string ZIP_EU = "(?:NL-\\d{4}(?: [A-Z][A-Z])|" +
			"(?:IS|FO)\\d{3}|" +
			"(?:A|B|CH|CY|DK|EE|H|L|LT|LV|N)-\\d{4}|" +
			"(?:BA|DE?|E|FR?|FIN?|HR|I|SI|YU)-\\d{5}|" +
			"(?:CZ|GR|S|SK)-\\d{3} \\d{2}|PL-\\d\\d-\\d{3}|" +
			"PT-\\d{4}(?:-\\d{3})?"+
			")";
        
		
		/// <summary>A simpler expression that doesn't check the postcode format against the country code</summary> 
		public static string ZIP = "(?:NL[- ]\\d{4} [A-Z][A-Z]|(?:[A-Z]{1,2}[- ])?\\d{2,3}(?:\\d\\d?| \\d\\d|\\d-\\d{3}))";

		/// <summary>US States RegEx</summary> 
		public static string STATES_US = "(:?A[KLRZ]|C[AOT]|D[CE]|FL|" +
			"GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])";
		
		/// <summary>Australian States RegEx</summary> 
		public static string STATES_AU = "(?:ACT|NSW|NT|QLD|SA|TAS|VIC|WA)";
		
		/// <summary>Canadian Provinces RegEx</summary> 
		public static string PROVINCES_CA = "(?:AB|BC|MB|N[BLTSU]|ON|PE|QC|SK|YT)";
		
		/// <summary>US + CA RegEx</summary> 
		public static string ZIP_USCA = "^\\d{5}-\\d{4}|\\d{5}|[A-Z]\\d[A-Z] \\d[A-Z]\\d$";
		
		/// <summary>Canonical phone number RegEx</summary> 
		public static string PHONE_INTL = "(?:\\+\\d{1,4} ?(?:\\(\\d{0,5}\\))?(?:\\d+[-. ])*\\d{2,})";
	}
}

