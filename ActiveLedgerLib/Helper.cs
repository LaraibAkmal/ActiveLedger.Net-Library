
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Text;

namespace ActiveLedgerLib
{
    public static class Helper
    {
        #region writing keys in file
        //writing Private key in the file in PEM format
        public static void WritekeyPairInFile(string filePath, AsymmetricCipherKeyPair keypair)
        {
            //creating file
            TextWriter textWriterPrivate = File.CreateText(filePath);
            //passing the file to PEM writer
            PemWriter pemWriterPrivate = new PemWriter(textWriterPrivate);
            //writing private/public key
            pemWriterPrivate.WriteObject(keypair.Private);
            pemWriterPrivate.WriteObject(keypair.Public);
            pemWriterPrivate.Writer.Flush();
            //closing text writer
            textWriterPrivate.Dispose();
        }
        //writing Public key in the file in PEM format
        public static void WritePublicKeyInFile(string filePath, AsymmetricCipherKeyPair keypair)
        {
            TextWriter textWriterPrivate = File.CreateText(filePath);
            PemWriter pemWriterPrivate = new PemWriter(textWriterPrivate);
            //wrting public key
            pemWriterPrivate.WriteObject(keypair.Public);
            pemWriterPrivate.Writer.Flush();
            //closing text writer
            textWriterPrivate.Dispose();
        }


        #endregion writing keys in file
        //read Keys from pem
       public static AsymmetricCipherKeyPair ReadAsymmetricKeyParameter(string keypairPathPEMFile)
        {
            var fileStream = System.IO.File.OpenText(keypairPathPEMFile);
            var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
            var KeyParameter = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            return KeyParameter;
        }

        //json to string Converter
        public static string ConvertJsonToString(JObject json)
        {
            string jsonStr = JsonConvert.SerializeObject(json);
            return jsonStr;

        }
        //Covert String to byte Array
        public static byte[] ConvertStringToByteArray(string str)
        {
            // Create a UnicodeEncoder to convert between byte array and string.
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] byteArray = ByteConverter.GetBytes(str);
            return byteArray;

        }
        //convert  byte Array to base 64 string
        public static string ConvertByteArrayToBase64String(byte[] byteArray)
        {
            string str = Convert.ToBase64String(byteArray);
            return str;

        }



    }
}
