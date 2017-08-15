using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace Common
{
    
	/// <summary>
	/// Provides a secure means for transfering data within a query string.
	/// </summary>
	[Serializable]
	public sealed class SecureQueryString : NameValueCollection
	{
		private static DateTime _expireTime = DateTime.MaxValue;
		private static bool SequreQS		= true;

		private SecureQueryString() : base()
		{
		}

		/// <summary>
		/// Returns the encrypted query string.
		/// </summary>
		public string EncryptedString
		{
			get { return HttpUtility.UrlEncode(encrypt(serialize())); }
		}

		/// <summary>
		/// Returns the encrypted query string.
		/// </summary>
		public static string GetEncryptedString(NameValueCollection objCol)
		{
			return HttpUtility.UrlEncode(serialize(objCol));
			//return HttpUtility.UrlEncode(encrypt(serialize(objCol)));			
		}

		/// <summary>
		/// Extract DecryptedQuerystring from Encrypted Query string		
		/// </summary>
		/// <param name="strEncryptedString">Encrypted Query string</param>
		/// <returns>safe Query string</returns>
		public static string GetDecryptedString(string strEncryptedString)
		{
			return decrypt(HttpUtility.UrlDecode(strEncryptedString));
		}

		/// <summary>
		/// Extracts Decrypted String
		/// </summary>
		/// <param name="objCol">name Valus Collection</param>
		/// <returns>New Name value Collection</returns>
		public static NameValueCollection GetDecryptedString(NameValueCollection objCol)
		{
			if (!SequreQS)
				return Copy(objCol);			

			NameValueCollection objNewCol = new NameValueCollection();			
			string strvalue = objCol["ID"];
			if (strvalue != null && strvalue.Length > 0)
			{
				string strQuery = SecureQueryString.serialize(objCol, "ID");
				if (strvalue.Length > 0)
					objNewCol = deserialize(decrypt(strvalue) + strQuery);
			}
			else
				objNewCol = Copy(objCol);
			return objNewCol;
		}

		/// <summary>
		/// get Encrypted Query string from 
		/// </summary>
		/// <param name="strQueryString">generated Query string</param>
		/// <returns>Encrypted query string</returns>	
		public static string GetEncryptedString(string strQueryString)
		{
			//return strQueryString;
			if (!SequreQS)
				return strQueryString;
			string[] strQueryArray = strQueryString.Split("?".ToCharArray());
			string strQS = strQueryString;
			if (strQueryArray.Length > 1)
			{
				strQS = encrypt(strQueryArray[1]);
				strQS = strQueryArray[0] + "?ID=" + strQS;
			}
			return strQS;
		}

		/// <summary>
		/// The timestamp in which the EncryptedString should expire
		/// </summary>
		public DateTime ExpireTime
		{
			get { return _expireTime; }
		}

		/// <summary>
		/// Returns the EncryptedString property.
		/// </summary>
		public override string ToString()
		{
			return EncryptedString;
		}

		/// <summary>
		/// Encrypts a serialized query string 
		/// </summary>
		private static string encrypt(string serializedQueryString)
		{
			byte[] buffer = Encoding.ASCII.GetBytes(serializedQueryString);
			if (SequreQS)
				return Convert.ToBase64String(buffer);
			else
				return serializedQueryString;

		}

		/// <summary>
		/// Decrypts a serialized query string
		/// </summary>
		private static string decrypt(string encryptedQueryString)
		{
			if (encryptedQueryString == null)
				return string.Empty;

			if (SequreQS)
			{
				try
				{
					byte[] buffer = Convert.FromBase64String(encryptedQueryString);
					return Encoding.ASCII.GetString(buffer);
				}
				catch (System.FormatException)
				{
					return "fuseaction=FormatException";
				}
			}
			else
				return encryptedQueryString;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="decryptedQueryString"></param>
		/// <returns></returns>
		public static NameValueCollection deserialize(string decryptedQueryString)
		{
			NameValueCollection objNewcol = new NameValueCollection();
			try
			{
				decryptedQueryString = decryptedQueryString.Replace("&amp;", "&");
				string[] nameValuePairs = decryptedQueryString.Split('&');
				for (int iCnt = 0; iCnt < nameValuePairs.Length; iCnt++)
				{
					string[] nameValue = nameValuePairs[iCnt].Split('=');
					if (nameValue.Length == 2)
					{
						objNewcol.Add(nameValue[0], nameValue[1]);
					}
				}
			}
			catch (NullReferenceException)
			{
			}
			return objNewcol;
		}

		/// <summary>
		/// Serializes the underlying NameValueCollection as a QueryString
		/// </summary>		
		private string serialize()
		{
			StringBuilder sb = new StringBuilder();
			foreach (string key in base.AllKeys)
			{
				if (key != null)
				{
					sb.Append(key);
					sb.Append('=');
					sb.Append(base[key]);
					sb.Append('&');
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Serializing object (Query string) to string 
		/// </summary>
		/// <param name="objCol">Query string Object</param>
		/// <returns>Query string as a Return Statement</returns>
		public static string serialize(NameValueCollection objCol)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string key in objCol.AllKeys)
			{
				if (key != null)
				{
					sb.Append(key);
					sb.Append('=');
					sb.Append(objCol[key]);
					sb.Append('&');
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Serializing object (Query string) to string 
		/// </summary>
		/// <param name="objCol">Query string Object</param>
		/// <param name="strEscape">Escaped Key collection as string</param>
		/// <returns>Query string as a Return Statement</returns>		
		public static string serialize(NameValueCollection objCol, string strEscape)
		{
			string[] strRemove = strEscape.Split(",".ToCharArray());
			StringBuilder sb = new StringBuilder();
			foreach (string strLocal in strRemove)
			{
				if (strLocal.Length > 0)
					foreach (string key in objCol.AllKeys)
					{
						if (key != null)
							if (String.Compare(strLocal, key, false, CultureInfo.CurrentCulture) != 0)
							{
								sb.Append(key);
								sb.Append('=');
								sb.Append(objCol[key]);
								sb.Append('&');
							}
					}
			}
			return sb.ToString();
		}

		/// <summary>
		/// serializing Collection to Other Collection by removing Specified Entry
		/// </summary>
		/// <param name="objCol">Collection Object</param>
		/// <param name="strExcludes">Comma Separated value</param>
		/// <returns>Collection Object</returns>
		public static NameValueCollection serializeCollection(NameValueCollection objCol, string strExcludes)
		{
			string[] strRemove = strExcludes.Split(",".ToCharArray());
			foreach (string strLocal in strRemove)
			{
				if (strLocal.Length > 0)
					foreach (string key in objCol.AllKeys)
						if (key != null)
							if (string.Compare(strLocal, key, false, CultureInfo.CurrentCulture) == 0)
								objCol.Remove(key);
			}
			return objCol;
		}

		/// <summary>
		/// serializing Collection to Other Collection by Keeping Specified Entry
		/// </summary>
		/// <param name="objReqCol">Collection Object</param>
		/// <param name="strIncludes">Comma Separated value</param>
		/// <returns>Collection Object</returns>
		public static NameValueCollection serializeCollectionForInclude(NameValueCollection objReqCol, string strIncludes)
		{
			NameValueCollection objCol = Copy(objReqCol);
			string strLocalInclude = "ñ" + strIncludes.ToLower(CultureInfo.CurrentCulture) + "ñ";
			foreach (string key in objCol.AllKeys)
				if (key != null)
					if (strLocalInclude.IndexOf(key.ToLower(CultureInfo.CurrentCulture)) < 0)
						objCol.Remove(key);
			return objCol;
		}

		/// <summary>
		/// Copies complete collection to give new collection
		/// </summary>
		/// <param name="objCol">input Collection</param>
		/// <returns>output Collection</returns>
		public static NameValueCollection Copy(NameValueCollection objCol)
		{
			NameValueCollection objNewCol = new NameValueCollection();
			foreach (string strLocal in objCol.AllKeys)
				if (strLocal != null)
					objNewCol.Add(strLocal, objCol[strLocal]);

			return objNewCol;
		}

	}

	/// <summary>
	/// Thrown when a queryString has expired and is therefore no longer valid.
	/// </summary>
	[Serializable]
	public class ExpiredQueryStringException : System.Exception
	{
		/// <summary>
		/// Public constructor For Expiried Query String 
		/// </summary>
		public ExpiredQueryStringException() : base()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		public ExpiredQueryStringException(string s) : base(s)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		public ExpiredQueryStringException(string s, Exception e) : base(s, e)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="si"></param>
		/// <param name="sc"></param>
		protected ExpiredQueryStringException(SerializationInfo si, StreamingContext sc) : base(si, sc)
		{
		}
	}
}
