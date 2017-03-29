using System;
using System.Globalization;
using System.Data;
using System.Text;
using System.Net;
using System.Collections;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Runtime.InteropServices;

namespace Common
{
 
	#region "Constants"
	/// <summary>
	/// Constants class
	/// </summary>
	public class Constants
	{
		/// <summary>Date format</summary>
		public static readonly string mstrDateFormat		= System.Configuration.ConfigurationSettings.AppSettings["DateFormat"];
		/// <summary>Currency format</summary>
		public static readonly string mstrFormatCurrency	= System.Configuration.ConfigurationSettings.AppSettings["CurrencyFormat"];
		/// <summary>Number format</summary>
		public static readonly string mstrFormatNumber		= System.Configuration.ConfigurationSettings.AppSettings["NumberFormat"];
				
		/// <summary>
		/// The start string for Tokens in template
		/// </summary>
		public const string TEMPLATE_SEPERATOR_START = "[[";
		/// <summary>
		/// The end string for Toek in template
		/// </summary>
		public const string TEMPLATE_SEPERATOR_END   = "]]";
	}
	#endregion

	#region "Generic Utility Class"
	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	public class Utility
	{
		
		private Utility(){}

		/// <summary>
		/// Encode "'" to "''" values
		/// </summary>
		/// <param name="strInput">input string</param>
		/// <returns>string after replacement</returns>
		
		public static string EncodeQuotes(string strInput)
		{
			return strInput.Replace("'","''");
		}

		#region "Convert Number into Specified Format"

		/// <summary>
		/// Convet the String in to the Formatted Number
		/// </summary>
		/// <param name="strIn">Input String</param>
		/// <param name="strNumtype">Number Type "F" for Float,"D" for Decimal and "I" for Interge</param>
		/// <param name="iprecision">No Of Precision In the Case Of Decimal</param>
		/// <returns>Retrurn Formatted String </returns>
		public static string ConvertNumber(string strIn,string strNumtype,int iprecision)
		{
			string strReturn="";
			double dbVal;
			int iVal;

			dbVal = Convert.ToDouble(strIn);
			iVal = Convert.ToInt32(dbVal);
			NumberFormatInfo nfProvider = new NumberFormatInfo( );
			strNumtype = strNumtype.ToUpper();
			if(strNumtype=="D" &&  iprecision==0)
				strNumtype = "I";
			switch(strNumtype)
			{
				case "I":
					strReturn = iVal.ToString();
					break;
				case "F":
					nfProvider.NumberDecimalDigits = 2;
					nfProvider.NumberDecimalSeparator = ".";
					nfProvider.NumberGroupSeparator="";
					strReturn = dbVal.ToString("N",nfProvider);
					break;
				case "D":
					nfProvider.NumberDecimalDigits = iprecision;
					nfProvider.NumberDecimalSeparator = ".";
					nfProvider.NumberGroupSeparator="";
					strReturn = dbVal.ToString("N",nfProvider);
					break;
				case "C":
					nfProvider.CurrencyDecimalDigits=2;
					nfProvider.CurrencySymbol="$";
					strReturn = dbVal.ToString("C",nfProvider);
					break;
				default:
					strReturn = dbVal.ToString("N",nfProvider);
					break;
			}
			return strReturn;
		}
		
		/// <summary>
		/// Convet the String in to the Formatted Number
		/// </summary>
		/// <param name="strIn">Input String</param>
		/// <param name="strNumtype">Number Type "F" for Float,"D" for Decimal and "I" for Interger and "C" for Currency</param>
		/// <returns>Retrurn Formatted String </returns>
		public static string ConvertNumber(string strIn,string strNumtype)
		{
			string strReturn="";
			double dbVal;
			int iVal;
			dbVal = Convert.ToDouble(strIn);
			iVal = Convert.ToInt32(dbVal);
			NumberFormatInfo nfProvider = new NumberFormatInfo( );
			strNumtype = strNumtype.ToUpper();
			switch(strNumtype)
			{
				case "I":
					strReturn = iVal.ToString();
					break;
				case "F":
					strReturn = ConvertNumber(strIn,"F",0);
					break;
				case "C":
					strReturn = ConvertNumber(strIn,"C",0);
					break;
				default:
					strReturn = ConvertNumber(strIn,"F",0);
					break;
			}
			return strReturn;
		}

		
		#endregion

		# region "Encryption of String Through MD5 Algorithm"		
		/// <summary>
		/// Encrypt the inputed string through MD5 Algorithm
		/// </summary>
		/// <param name="strInputText">string to encrypt</param>
		/// <returns>MD5 encrypted string</returns>
		public static string GetMD5String(string strInputText)
		{
			string strReturnvalue = "";
			byte[] bytHashValue ;
			UTF8Encoding encoder = new UTF8Encoding();
			try
			{				
				MD5 md = new MD5CryptoServiceProvider();
				bytHashValue = md.ComputeHash(encoder.GetBytes(strInputText));
				strReturnvalue = BitConverter.ToString(bytHashValue);
				strReturnvalue = strReturnvalue.Replace("-","");
			}
			catch(Exception e)
			{
				throw e;
			}			
			return strReturnvalue ;
		}				
		# endregion

		# region "Root location From Site Root"		
		/// <summary>
		/// Functionality: This function will evalute the location of the application root from the current location
		/// </summary>
		/// <param name="sRequest">Current Location of the File(Request.FilePath)</param>
		/// <param name="sSiteRoot">Application Root Path (Request.ApplicationPath)</param>
		/// <returns>location of root from current location</returns>
		public static string GetRootLocation(String sRequest,String sSiteRoot)
		{
			String sBack = "";
			sRequest = sRequest.ToLower();
			sSiteRoot = sSiteRoot.ToLower();
			String sAns = sRequest.TrimStart(sSiteRoot.ToCharArray());
			if(sAns.StartsWith("/"))
				sAns = sAns.Substring(1,sAns.Length-1);
			String[] arrSplit = sAns.Split("/".ToCharArray());
			for(int i=1;i<arrSplit.Length;i++)
				sBack += "../";
			return sBack;
		}
		#endregion
					 
		#region "Get the Valid SQL string by replacing any single quote in string with two single quotes"
		/// <summary>
		/// Get the Valid SQL string by replacing any single quote in string with two single quotes.
		/// </summary>
		/// <param name="sValue">string to validate</param>
		/// <returns>valid SQL string</returns>
		public static string GetValidSQLString(string sValue)
		{
			if (sValue != null && sValue.Trim() != "")
			{				
				sValue = sValue.Replace("'","''");
			}
			return sValue;
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Element"></param>
		/// <returns></returns>
		public static string getValidXMLNodeName(string Element)
		{
			string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
			int iIndex;
			int i;
			string strReturn="";
			Element = Element.Replace(" ","_");
			Element = (Element.IndexOf(' ')==0)? Element.Substring(1,Element.Length-1):Element;
			if(Element.Length>0)
				Element = (Element.LastIndexOf(' ')==Element.Length-1)? Element.Substring(0,Element.Length-1):Element;
			for(i= 0;i<Element.Length;i++)
			{
				iIndex = charset.IndexOf(Element[i].ToString());
				if(iIndex>-1)
					strReturn +=  Element[i].ToString();
			}
			return strReturn;
		}
		/// <summary>
		/// get Valid XML String
		/// </summary>
		/// <param name="Element"></param>
		/// <returns></returns>
		public static string getValidXMLString(string Element)
		{
			string charset = "©´«»¡¿ÀàÁáÂâÃãÄÅåÆæÇçÐðÈèÉéÊêËëÌìÍíÎîÏïÑñÒòÓóÔôÕõÖöØøÙùÚúÛûÜüÝýÿÞþß§¶µ¦±·¨¸ªº¬­¯°¹²³¼½¾×÷¢£¤¥...";
	
			//if(String.I . IsNumeric(Trim(Element)) Then
			//	SetEntities = Element
			//	Exit Function
			//Else
			//'Replacing the & with &amp;
			Element = Element.Replace( "&", "&amp;");
			//'Replacing the ' with &apos;
			Element = Element.Replace( "'", "&apos;");
			//'Replacing the > with &gt;
			Element = Element.Replace( ">", "&gt;");
			//'Replacing the < with &lt;
			Element = Element.Replace( "<", "&lt;");
			//'Replacing the " with &quot;
			Element = Element.Replace( "\"\"", "&quot;");
			//'Replacing the null Character with Space
			//Element = Element.Replace(vbNullChar, "");
			//'Replacing the " with &quot;
			//Element = Element.Replace (null, "");
			for(int i = 0;i<charset.Length;i++)
				Element = Element.Replace(charset[i].ToString(),"");
			return Element;
			//End If
		}

		#region "Search the content between two strings"
		/// <summary>
		/// Search the content between two strings
		/// </summary>
		/// <param name="sInput">The string in which content is to be searched</param>
		/// <param name="sStart">Start String</param>
		/// <param name="sEnd">End String</param>
		/// <returns>The string consisting the content between start and end strings</returns>
		public static string SearchSubString(string sInput,string sStart,string sEnd)
		{
			string sReturn = "";
			string sPattern = "(" + sStart + ")([\\w\\W]*?)(" + sEnd + ")";			
			System.Text.RegularExpressions.Regex regSearch = new System.Text.RegularExpressions.Regex(sPattern,System.Text.RegularExpressions.RegexOptions.IgnoreCase);			
			foreach(System.Text.RegularExpressions.Match mtchFound in regSearch.Matches(sInput))
			{
				string sRequired = mtchFound.Value.Trim();
				sRequired = sRequired.Replace(sStart,"").Trim();
				sRequired = sRequired.Replace(sEnd,"").Trim();
				sReturn += sRequired;
			}
			return sReturn;
		}
		#endregion

		#region "Get the Valid string which can be using in JavaScript functions"
		/// <summary>
		/// Get the Valid string which can be using in JavaScript functions
		/// </summary>
		/// <param name="sValue">string to validate</param>
		/// <returns>valid JS string</returns>
		public static string SetValidJsString(string sValue)
		{
			if (sValue != null && sValue.Trim() != "")
			{				
				sValue = sValue.Replace("\\","\\\\");
				sValue = sValue.Replace("\"","\\\"");
				sValue = sValue.Replace("\r\n","\\r\\n");
				sValue = sValue.Replace("\r","\\r");
				sValue = sValue.Replace("\n","\\n");
				sValue = sValue.Replace("\\n","\\n\" +\n\"");
			}
			return sValue;
		}
		#endregion
	
		#region "Export To a Delim Format"		
		private static string ParseToDelim(string strText, string  strRowDelim , string strColDelim)
		{
			Regex objReg = new Regex(@"(>\s+<)",RegexOptions.IgnoreCase);					
			strText = objReg.Replace(strText,"><");
			strText = strText.Replace(System.Environment.NewLine,"");
			strText = strText.Replace("</td></tr><tr><td>",strRowDelim);
			strText = strText.Replace("</td><td>",strColDelim);
			objReg = new Regex(@"<[^>]*>",RegexOptions.IgnoreCase);					
			strText = objReg.Replace(strText,"");				
			strText = System.Web.HttpUtility.HtmlDecode(strText);
			return strText;
		}
		#endregion

		#region "Download File"
		/// <summary>
		/// Download a File From Internet
		/// </summary>
		/// <param name="strURL">File URL to Doanload</param>
		/// <param name="strFileName">File Name for Saving</param>
		public static void DownloadFile(string strURL , string strFileName)
		{
			WebClient objClient = new WebClient();
			objClient.DownloadFile(strURL,strFileName);
			objClient.Dispose();
		}
		#endregion

		#region "Download File(New)"
		/// <summary>
		/// This Function will Download the Specified File.
		/// </summary>
		/// <param name="FilePath">Absolute File FilePath</param>
		public static void DownloadDocument(string FilePath)
		{
			NandanaResult oResult = new NandanaResult();
			string name = Path.GetFileName(FilePath);
			string ext = Path.GetExtension(FilePath);
			//MyFile.PostedFile.
			string type = "";
			try
			{
				if ( ext != null )
				{
					switch( ext.ToLower() )
					{
						case ".doc":
						case ".rtf":
							type = "application/ms-word";
							break;
						case ".xls":
							type = "application/ms-excel";
							break;
						case ".zip":
							type = "application/x-zip";
							break;
						case ".pdf":
							type = "application/pdf";
							break;
						case ".html":
						case ".htm":
						case ".txt":
							type = "text/html";
							break;
						default:
							type = "application/octet-stream";
							break;
					}
				}
			
				System.Web.HttpContext.Current.Response.AppendHeader( "content-disposition",
					"attachment; filename=" + name );
			
				System.Web.HttpContext.Current.Response.ContentType = type;
				System.Web.HttpContext.Current.Response.WriteFile(FilePath);
			}
			catch(Exception e)
			{
				NandanaError.PostError(e);
				System.Web.HttpContext.Current.Response.ContentType = "text/html";
				System.Web.HttpContext.Current.Response.Write("<Font color='red'>Error while downloading the file.</font>");
			}		
			finally
			{
				System.Web.HttpContext.Current.Response.End();    	
			}
		}	
		/// <summary>
		/// This Function will Download the Specified File.
		/// </summary>
		/// <param name="FilePath">Absolute File FilePath</param>
		/// <param name="blAttachment">as Atachment or Not</param>
		public static void DownloadDocument(string FilePath,bool blAttachment)
		{
			NandanaResult oResult = new NandanaResult();
			string strAttachment="";
			if(blAttachment)
				strAttachment = "attachment; ";
			string name = Path.GetFileName(FilePath);
			string ext = Path.GetExtension(FilePath);
			//MyFile.PostedFile.
			string type = "";
			try
			{
				if ( ext != null )
				{
					switch( ext.ToLower() )
					{
						case ".doc":
						case ".rtf":
							type = "application/ms-word";
							break;
						case ".xls":
							type = "application/ms-excel";
							break;
						case ".zip":
							type = "application/x-zip";
							break;
						case ".pdf":
							type = "application/pdf";
							break;
						case ".html":
						case ".htm":
						case ".txt":
							type = "text/html";
							break;
						default:
							type = "application/octet-stream";
							break;
					}
				}
			
				System.Web.HttpContext.Current.Response.AppendHeader( "content-disposition",
					strAttachment + " filename=" + name );
				System.Web.HttpContext.Current.Response.ContentType = type;
				System.Web.HttpContext.Current.Response.WriteFile(FilePath);
			}
			catch(Exception e)
			{
				NandanaError.PostError(e);
				System.Web.HttpContext.Current.Response.ContentType = "text/html";
				System.Web.HttpContext.Current.Response.Write("<Font color='red'>Error while downloading the file.</font>");
			}	
			finally
			{
				System.Web.HttpContext.Current.Response.End();    	
			}
		}	
		#endregion

		#region "Read the Content of File into a String"
		/// <summary>
		/// Reading the Content of a File into a String
		/// </summary>
		/// <param name="sFile">The Real Path of File to read</param>
		/// <returns>Content of file in string or ""(a Blank string) if file is not found</returns>
		public static string readFileContent(string sFile)
		{
			string sFileContent="";
			if(System.IO.File.Exists(sFile))
			{
				//reading the file and storing it in one string
				System.IO.StreamReader srContent = System.IO.File.OpenText(sFile);
				sFileContent = srContent.ReadToEnd();
				srContent.Close();
			}
			return sFileContent;
		}
		#endregion

		#region "Write the Content of String into a File"
		/// <summary>
		/// Write the Content of the string into a File.If File doesnot exists then it will create one
		/// </summary>
		/// <param name="sFile">The Real path of File</param>
		/// <param name="sContent">The content to write</param>
		/// <param name="bOverwrite">if true the previous content will be lost else the content will be appended at the end of the file</param>
		/// <returns>true if successfull in writing the content to file else false</returns>
		public static bool writeToFile(string sFile,string sContent,bool bOverwrite)
		{
			System.IO.StreamWriter swFile = null;
			if(System.IO.File.Exists(sFile))
			{
				if(!bOverwrite)
				{
					swFile = System.IO.File.AppendText(sFile);
					swFile.Write(sContent);
					swFile.Flush();
					swFile.Close();
					return true;
				}
				else
				{
					System.IO.File.Delete(sFile);
					swFile = System.IO.File.CreateText(sFile);
					swFile.Write(sContent);
					swFile.Flush();
					swFile.Close();
					return true;
				}
			}
			else
			{
				string sDir = sFile.Substring(0,sFile.LastIndexOf("\\"));
				if(!System.IO.Directory.Exists(sDir))
					System.IO.Directory.CreateDirectory(sDir);
				swFile = System.IO.File.CreateText(sFile);
				swFile.Write(sContent);
				swFile.Flush();
				swFile.Close();
				return true;
			}

		}
		#endregion

		#region "Send the mail"
		/// <summary>
		/// To Send the Mail
		/// </summary>
		/// <param name="sSMTPServer">SMTPServer Through which the mail will be sent</param>
		/// <param name="smtpUser">SMTPServer User Through which the mail will be sent</param>
		/// <param name="smtpPassword">SMTPServer Password Through which the mail will be sent</param>
		/// <param name="sTo">Address to which the mail is to be sent</param>
		/// <param name="sCC">CC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="sBCC">BCC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="sFrom">Address from which the mail is to be sent</param>
		/// <param name="sSubject">Subject of the mail</param>
		/// <param name="sMsgBody">Message content of the mail</param>
		/// <param name="bHtml">True if the message is to be sent in HTML format else false</param>
		/// <returns>true if mail sent successfully else false</returns>
		public static bool SendMail(string sSMTPServer, string smtpUser, string smtpPassword, string sTo,string sCC,string sBCC,string sFrom,string sSubject,string sMsgBody,bool bHtml) 
		{
			if(sFrom.Length<=0 || sTo.Length<=0 || sSMTPServer.Length<=0)
				return false;			
			try
			{				
				System.Web.Mail.MailMessage objMail = new System.Web.Mail.MailMessage();										
				objMail.From		= sFrom;
				objMail.Subject		= sSubject;
				objMail.Body		= sMsgBody;
				objMail.To			= sTo;
				objMail.Cc			= sCC;
				objMail.Bcc			= sBCC;

				if(bHtml)
					objMail.BodyFormat = System.Web.Mail.MailFormat.Html;
				else
					objMail.BodyFormat = System.Web.Mail.MailFormat.Text;

				System.Web.Mail.SmtpMail.SmtpServer = sSMTPServer;		
		
				/* Authenticate */

				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1); 
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpUser);
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword); 

				System.Web.Mail.SmtpMail.Send(objMail);

				return true;
			}
			catch
			{
				return false;
			}
		}
		#endregion	

		#region "Send the mail with Attachment"
		/// <summary>
		/// To Send the Mail
		/// </summary>
		/// <param name="sSMTPServer">SMTPServer Through which the mail will be sent</param>
		/// <param name="smtpUser">SMTPServer User Through which the mail will be sent</param>
		/// <param name="smtpPassword">SMTPServer Password Through which the mail will be sent</param>
		/// <param name="sTo">Address to which the mail is to be sent</param>
		/// <param name="sCC">CC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="sBCC">BCC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="sFrom">Address from which the mail is to be sent</param>
		/// <param name="sSubject">Subject of the mail</param>
		/// <param name="sMsgBody">Message content of the mail</param>
		/// <param name="bHtml">True if the message is to be sent in HTML format else false</param>
		/// <param name="ilAttachments">List of Attachments</param>
		/// <returns>true if mail sent successfully else false</returns>
		public static bool SendMail(string sSMTPServer, string smtpUser, string smtpPassword, string sTo,string sCC,string sBCC,string sFrom,string sSubject,string sMsgBody,bool bHtml,string[] ilAttachments) 
		{
			if(sFrom.Length<=0 || sTo.Length<=0 || sSMTPServer.Length<=0)
				return false;			
			try
			{				
				System.Web.Mail.MailMessage objMail = new System.Web.Mail.MailMessage();										
				objMail.From		= sFrom;
				objMail.Subject		= sSubject;
				objMail.Body		= sMsgBody;
				objMail.To			= sTo;
				objMail.Cc			= sCC;
				objMail.Bcc			= sBCC;

				if(bHtml)
					objMail.BodyFormat = System.Web.Mail.MailFormat.Html;
				else
					objMail.BodyFormat = System.Web.Mail.MailFormat.Text;

				if(ilAttachments!=null)
				{
					for(int i=0;i<ilAttachments.Length;i++)
					{
						
						System.Web.Mail.MailAttachment attachment = new	System.Web.Mail.MailAttachment(ilAttachments[i]);
						objMail.Attachments.Add(attachment);
					}
				}

				System.Web.Mail.SmtpMail.SmtpServer = sSMTPServer;		

				/* Authenticate */

				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1); 
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", smtpUser);
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", smtpPassword); 

				System.Web.Mail.SmtpMail.Send(objMail);
				GC.Collect();
				return true;
			}
			catch(Exception e)
			{
				string str = e.Message;
				GC.Collect();
				return false;
			}
		}
		#endregion	


		#region "Send the Fax with Attachment"
		/// <summary>
		/// To Send the Fax
		/// </summary>
		/// <param name="sSMTPServer">SMTPServer Through which the mail will be sent</param>
		/// <param name="sTo">Address to which the mail is to be sent</param>
		/// <param name="sCC">CC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="sBCC">BCC Addresses(Semi Colon Separated) to which the mail is to be sent</param>
		/// <param name="faxUserName">Address from which the mail is to be sent</param>
		/// <param name="faxPassword">Fax password</param>
		/// <param name="sSubject">Subject of the mail</param>
		/// <param name="sMsgBody">Message content of the mail</param>
		/// <param name="bHtml">True if the message is to be sent in HTML format else false</param>
		/// <param name="ilAttachments">List of Attachments</param>
		/// <returns>true if mail sent successfully else false</returns>
		public static bool SendFax(string sSMTPServer,string sTo,string sCC,string sBCC,string faxUserName,string faxPassword,string sSubject,string sMsgBody,bool bHtml,string[] ilAttachments) 
		{
			if(faxUserName.Length<=0 || sTo.Length<=0 || sSMTPServer.Length<=0)
				return false;			
			try
			{				
				System.Web.Mail.MailMessage objMail = new System.Web.Mail.MailMessage();										
				objMail.From = faxUserName;
				objMail.Subject = sSubject;
				objMail.Body = sMsgBody;
				objMail.To = sTo;
				objMail.Cc = sCC;
				objMail.Bcc = sBCC;
				if(bHtml)
					objMail.BodyFormat = System.Web.Mail.MailFormat.Html;
				else
					objMail.BodyFormat = System.Web.Mail.MailFormat.Text;
				if(ilAttachments!=null)
				{
					for(int i=0;i<ilAttachments.Length;i++)
					{
						System.Web.Mail.MailAttachment attachment = new	System.Web.Mail.MailAttachment(ilAttachments[i]);
						objMail.Attachments.Add(attachment);
					}
				}

				System.Web.Mail.SmtpMail.SmtpServer = sSMTPServer;		
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1); 
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", faxUserName);
				objMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", faxPassword); 
				System.Web.Mail.SmtpMail.Send(objMail);
				GC.Collect();
				return true;
			}
			catch 
			{
				GC.Collect();
				return false;
			}
		}
		#endregion	

		#region "Reading E-Mail Templates and Replacing the dynamic content into it"
		/// <summary>
		/// Reading E-Mail Templates
		/// </summary>
		/// <param name="bodyContent">The original template contents</param>
		/// <param name="hData">Hashtable containing the Key-Value pair to replace in Template</param>
		/// <returns>The Formatted String,It will return ""(a Blank string) if Template file not found</returns>
		public static string GetTemplate(string bodyContent,Hashtable hData)
		{
			if(bodyContent.Trim().Length > 0)
			{				
				//traversing the hashtable and replacing the values in the string read from file				
				System.Collections.ICollection clKeys = hData.Keys;								
				ArrayList arrKeys = new ArrayList(clKeys);								
				for(int iCount=0;iCount<arrKeys.Count;iCount++)
				{
					string strData = hData[arrKeys[iCount]].ToString();
					string strRaw  = Constants.TEMPLATE_SEPERATOR_START + arrKeys[iCount].ToString() + Constants.TEMPLATE_SEPERATOR_END;
					bodyContent    = bodyContent.Replace(strRaw,strData);
				}
			}			
			return bodyContent;
		}
		#endregion
	
		#region "Modifies Given XML to Empty Tag Less XML"
		/// <summary>
		/// Modifies Given XML to Empty Tag Less XML
		/// </summary>
		/// <param name="strXML">input XML</param>
		/// <returns>Output XML</returns>
		public static string MakeupMenuXML(string strXML)
		{
			strXML = Regex.Replace(strXML,@"\r\n","");
			strXML = Regex.Replace(strXML,@"  ","");
			strXML = Regex.Replace(strXML,@"(<Table)([\w\W]*?)(\d*>)","<menuItem>");
			strXML = Regex.Replace(strXML,@"(</Table)([\w\W]*?)(\d*>)","</menuItem>");
			strXML = Regex.Replace(strXML,@"(<)([a-z]*?)(/>)","");
			strXML = Regex.Replace(strXML,@"(<)([a-z]*?)(>)\s+(</)([a-z]*?)(>)","");				
			return strXML;
		}
		#endregion

		#region "Encode String in Base64"
		/// <summary>
		/// This function will convert string to Base64 encoding.
		/// </summary>
		/// <param name="data">string to convert</param>
		/// <returns>Base64 encoded string</returns>
		public static string base64Encode(string data)
		{
			try
			{
				byte[] encData_byte = new byte[data.Length];
				encData_byte = System.Text.Encoding.UTF8.GetBytes(data);    
				string encodedData = Convert.ToBase64String(encData_byte);
				return encodedData;
			}
			catch(Exception e)
			{
				throw new Exception("Error in base64Encode" + e.Message);
			}
		}
		#endregion
	
		#region "Decode Base64 to string value"
		/// <summary>
		/// This Function will decode the Base64 encoding to string
		/// </summary>
		/// <param name="data">base64 encoded string</param>
		/// <returns>string</returns>
		public static string base64Decode(string data)
		{
			try
			{
				System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();  
				System.Text.Decoder utf8Decode = encoder.GetDecoder();
    
				byte[] todecode_byte = Convert.FromBase64String(data);
				int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);    
				char[] decoded_char = new char[charCount];
				utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);                   
				string result = new String(decoded_char);
				return result;
			}
			catch(Exception e)
			{
				throw new Exception("Error in base64Decode" + e.Message);
			}
		}
		#endregion

		#region Generate Randon Number

		/// <summary>
		/// 
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		public static string RandomNumber(int size)
		{
			string retVal = DateTime.Now.Ticks.ToString();
			retVal = retVal.Substring(retVal.Length - size - 1, size);

			int lBound = 9999;
			int uBound = 999999999;
			// Assumes lBound >= 0 && lBound < uBound
			// returns an int >= lBound and < uBound
			uint urndnum;   
			byte[] rndnum = new Byte[4];   
			if (lBound == uBound-1)  
			{
				// test for degenerate case where only lBound can be returned
				return Convert.ToString(lBound);
			}
                                                              
			uint xcludeRndBase = (uint.MaxValue -
				(uint.MaxValue%(uint)(uBound-lBound)));   
            
			do 
			{      
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
				rng.GetBytes(rndnum);      
				urndnum = System.BitConverter.ToUInt32(rndnum,0);      
			} while (urndnum >= xcludeRndBase);   
            
			retVal = Convert.ToString((urndnum % (uBound-lBound)) + lBound ) + retVal;
			return retVal.Substring(0,size);
		}

		#endregion

	}
	#endregion

	# region "Web Data Compression Class For Page Size Optimisation "	
	/// <summary>
	/// This filter gets rid of all unnecessary whitespace in the output.
	/// use like this in global .asax 
	/// <code>
	/// protected void Application_BeginRequest(Object sender, EventArgs e)
	/// {
	///		System.Web.HttpContext.Current.Response.Filter = new Web.DataCompression(System.Web.HttpContext.Current.Response.Filter);
	///	}
	/// </code>
	/// </summary>	
	public class DataCompression : Stream
	{
		Stream  _sink;
		long  _position;
		private const string ROOT_NODE = "root";
		private const string DATA_NODE = "data";
		private const string VALUE_NODE = "value";
		private const string NAME_ATTRIBUTE = "name";
		/// <summary>
		/// constructor accepting stream object
		/// </summary>
		/// <param name="sink">stream object</param>
		public DataCompression(Stream sink){this._sink =sink;}
		
		// The following members of Stream must be overridden.
		#region " Code that will most likely never change from filter to filter. "
		/// <summary>
		/// blank Implementation 
		/// </summary>
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}
		/// <summary>
		/// blank Implementation 
		/// </summary>
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}
		/// <summary>
		/// blank Implementation 
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}
		/// <summary>
		/// blank Implementation 
		/// </summary>
		public override long Length
		{
			get
			{
				return 0;
			}
		}
		/// <summary>
		/// blank Implementation 
		/// </summary>
		public override long Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position =value;
			}
		}
		/// <summary>
		/// Returns base objects seek method execution
		/// </summary>
		/// <param name="offset">Offset parameter</param>
		/// <param name="origin">origin Count</param>
		/// <returns>Long Seek position</returns>
		public override long Seek(long offset, SeekOrigin origin)
		{return _sink.Seek(offset,origin);}
		/// <summary>
		/// set stream length
		/// </summary>
		/// <param name="value">long value of length</param>
		public override void SetLength(long value)
		{_sink.SetLength(value);}
		/// <summary>
		/// close the stream
		/// </summary>
		public override void Close()
		{_sink.Close ();}
		/// <summary>
		/// Flush the stream
		/// </summary>
		public override void Flush()
		{_sink.Flush();}
		/// <summary>
		/// overrided read method
		/// </summary>
		/// <param name="buffer">buffer of sink variable</param>
		/// <param name="offset">offset value passed</param>
		/// <param name="count">counts as parameter</param>
		/// <returns>value to be returned</returns>
		public override int Read(byte[] buffer, int offset, int count)
		{return _sink.Read(buffer,offset,count);}		
		#endregion
	
		/// <summary>
		/// Write is the method that actually does the filtering.
		/// </summary>
		/// <param name="buffer">buffer value</param>
		/// <param name="offset">stream offset</param>
		/// <param name="count">count of bytes</param>
		public override void Write(byte[] buffer, int offset, int count)
		{
			byte []  data =  new byte[count];
			Buffer.BlockCopy(buffer,offset,data,0,count);
			//Don't use ASCII encoding here.  The .NET IDE replaces
			//some characters, such as ®
			//with a UTF-8 entity.  If you use ASCII encoding,
			//you'll get B. instead of the registered
			//trademark symbol.
			string s = System.Text.Encoding.UTF8.GetString(data);
			s = Regex.Replace(s," <","<",RegexOptions.IgnoreCase);
			s = Regex.Replace(s,"> ",">",RegexOptions.IgnoreCase);
			s = Regex.Replace(s,System.Environment.NewLine+"<","<",RegexOptions.IgnoreCase);
			s = Regex.Replace(s,System.Environment.NewLine+">",">",RegexOptions.IgnoreCase);
			s = Regex.Replace(s,"> ",">",RegexOptions.IgnoreCase);
			s = Regex.Replace(s,"<!--",System.Environment.NewLine+"<!--",RegexOptions.IgnoreCase);			
			s = Regex.Replace(s,"\t"," ",RegexOptions.IgnoreCase);			
			s = Regex.Replace(s,System.Environment.NewLine+System.Environment.NewLine,System.Environment.NewLine,RegexOptions.IgnoreCase);
			s = Regex.Replace(s,@">\s*<","><",RegexOptions.IgnoreCase);	
			s = Regex.Replace(s," "," ",RegexOptions.IgnoreCase);					
			// Finally, we spit out what we have done.
			byte[] outdata = System.Text.Encoding.UTF8.GetBytes(s);
			_sink.Write(outdata, 0, outdata.GetLength(0));
		}
	
		#endregion
	
	#region GetString

		/// <summary>
		/// Returns a string
		/// </summary>
		/// <param name="keyText"></param>
		/// <returns></returns>
		public static string GetString(string keyText)
		{
		
			//Check if keyText is null then return empty string
			if (keyText == null)
			{
				return string.Empty;
			}


				//Refers to default .xml file in case culture specific file not found.
				string filePath = "//webconfig";
				string fileName = "//webconfig"; //"Error.xml";
				XmlDocument xml = new XmlDocument();

				try
				{
					xml.Load(filePath + "\\" + fileName);
				}
				catch
				{
					return keyText;
				}

				//Reads the resource data value for given data name/key.
				XmlNode node = xml.SelectSingleNode(ROOT_NODE + "/" + DATA_NODE + "[@" + NAME_ATTRIBUTE + "=\"" + keyText + "\"]/" + VALUE_NODE);

				if (node != null)
				{
					return node.InnerText;
				}
				else
				{
					return keyText;
				}
			}
			
		#endregion

	}	

}