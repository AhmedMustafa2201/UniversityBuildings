using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UniversityBuildings.Mine
{
    public static class EncUrl
    {
        public static MvcHtmlString EncodedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    htmlAttributesString += " " + d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            StringBuilder ancor = new StringBuilder();
            ancor.Append("<a ");
            if (htmlAttributesString != string.Empty)
            {
                ancor.Append(htmlAttributesString);
            }
            ancor.Append(" href='");
            if (controllerName != string.Empty)
            {
                ancor.Append("/" + controllerName);
            }

            if (actionName != "Index")
            {
                ancor.Append("/" + actionName);
            }
            if (queryString != string.Empty)
            {
                ancor.Append("?c=" + Encrypt(queryString));
            }
            ancor.Append("'");
            ancor.Append(">");
            ancor.Append(linkText);
            ancor.Append("</a>");
            return new MvcHtmlString(ancor.ToString());
        }

        //private static string Encrypt(string plainText)
        //{
        //    string key = "wjdsg432387#";
        //    byte[] EncryptKey = { };
        //    byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
        //    EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //    byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
        //    MemoryStream mStream = new MemoryStream();
        //    CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
        //    cStream.Write(inputByte, 0, inputByte.Length);
        //    cStream.FlushFinalBlock();
        //    return Convert.ToBase64String(mStream.ToArray());
        //}
        private const string ENCRYPTION_KEY = "key";
        private readonly static byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string Encrypt(string inputText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
        //public static MvcHtmlString EncodedActionLink(this HtmlHelper htmlHelper, string linkText, string Action, string ControllerName, string Area, object routeValues, object htmlAttributes)
        //{
        //    string queryString = string.Empty;
        //    string htmlAttributesString = string.Empty;
        //    //My Changes
        //    bool IsRoute = false;
        //    if (routeValues != null)
        //    {
        //        RouteValueDictionary d = new RouteValueDictionary(routeValues);
        //        for (int i = 0; i < d.Keys.Count; i++)
        //        {
        //            //My Changes
        //            if (!d.Keys.Contains("IsRoute"))
        //            {
        //                if (i > 0)
        //                {
        //                    queryString += "?";
        //                }
        //                queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
        //            }
        //            else
        //            {
        //                //My Changes
        //                if (!d.Keys.ElementAt(i).Contains("IsRoute"))
        //                {
        //                    queryString += d.Values.ElementAt(i);
        //                    IsRoute = true;
        //                }
        //            }
        //        }
        //    }

        //    if (htmlAttributes != null)
        //    {
        //        RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
        //        for (int i = 0; i < d.Keys.Count; i++)
        //        {
        //            htmlAttributesString += " " + d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
        //        }
        //    }


        //    StringBuilder ancor = new StringBuilder();
        //    ancor.Append("<a ");
        //    if (htmlAttributesString != string.Empty)
        //    {
        //        ancor.Append(htmlAttributesString);
        //    }
        //    ancor.Append(" href='");
        //    if (Area != string.Empty)
        //    {
        //        ancor.Append("/" + Area);
        //    }

        //    if (ControllerName != string.Empty)
        //    {
        //        ancor.Append("/" + ControllerName);
        //    }

        //    if (Action != "Index")
        //    {
        //        ancor.Append("/" + Action);
        //    }
        //    //My Changes
        //    if (queryString != string.Empty)
        //    {
        //        if (IsRoute == false)
        //            ancor.Append("?q=" + Encrypt(queryString));
        //        else
        //            ancor.Append("/" + Encrypt(queryString));
        //    }
        //    ancor.Append("'");
        //    ancor.Append(">");
        //    ancor.Append(linkText);
        //    ancor.Append("</a>");
        //    return new MvcHtmlString(ancor.ToString());
        //}
    }
}