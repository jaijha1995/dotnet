using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Configuration;

namespace Core.Common
{
    /// <summary>
    /// SymmCrypto is a wrapper of System.Security.Cryptography.SymmetricAlgorithm classes
    /// and simplifies the interface. It supports customized SymmetricAlgorithm as well.
    /// </summary>
    public class Encrypt
    {
        /// <remarks>
        /// Supported .Net intrinsic SymmetricAlgorithm classes.
        /// </remarks>

        public string Encrypting(string PlainText, string strKey24)
        {
            TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
            UnicodeEncoding uencode = new UnicodeEncoding();
            ASCIIEncoding aencode = new ASCIIEncoding();
            //Store plain text as  a byte array
            byte[] bytPlainText = uencode.GetBytes(PlainText);
            //Create a memory stream for holding encrypted text
            MemoryStream stmCipherText = new MemoryStream();
            //Private key
            byte[] slt = System.Text.ASCIIEncoding.ASCII.GetBytes("0");
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(strKey24, slt);
            byte[] bytDerivedKey = pdb.GetBytes(24);
            crp.Key = bytDerivedKey;
            //Initialization vector is the encryption seed
            crp.IV = pdb.GetBytes(8);
            //Create a crypto-writer to encrypt a bytearray inta a stream
            CryptoStream csEncrypted = new CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write);
            csEncrypted.Write(bytPlainText, 0, bytPlainText.Length);
            csEncrypted.FlushFinalBlock();
            //return result as a base64 encoded string
            return Convert.ToBase64String(stmCipherText.ToArray());

        }

        public string Decrypting(string strCiperText, string strKey24)
        {
            TripleDESCryptoServiceProvider crp = new TripleDESCryptoServiceProvider();
            UnicodeEncoding uencode = new UnicodeEncoding();
            ASCIIEncoding aencode = new ASCIIEncoding();
            //Store cipher text as  a byte array
            byte[] bytCipherText = Convert.FromBase64String(strCiperText);

            MemoryStream stmPlainText = new MemoryStream();
            MemoryStream stmCipherText = new MemoryStream(bytCipherText);
            //Private Key
            byte[] slt = System.Text.ASCIIEncoding.ASCII.GetBytes("0");
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(strKey24, slt);
            byte[] bytDerivedKey = pdb.GetBytes(24);
            crp.Key = bytDerivedKey;
            //Initialization vector 
            crp.IV = pdb.GetBytes(8);
            //Create a crypto stream decoder to decode a cipher text stream int aplain text stream
            CryptoStream csDecrypted = new CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read);
            StreamWriter sw = new StreamWriter(stmPlainText);
            StreamReader sr = new StreamReader(csDecrypted);
            sw.Write(sr.ReadToEnd());
            //Clean up afterwards
            sw.Flush();
            csDecrypted.Clear();
            crp.Clear();

            return uencode.GetString(stmPlainText.ToArray());

        }


        /////////////////  Add by Nitin

        public string Encrypt_QueryString(string str)
        {
            //str = str.Replace(" ", "+");
            string EncrptKey = ConfigurationManager.AppSettings["encryptKey"].ToString();
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt_QueryString(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = ConfigurationManager.AppSettings["encryptKey"].ToString();
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }





    }
}
