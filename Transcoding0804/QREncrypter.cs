using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace Transcoding0804
{
    public class QREncrypter
    {
        public string AESEncrypt(string plainText, string AESKey)
        {
            byte[] bytes = Encoding.Default.GetBytes(plainText);
            ICryptoTransform transform = new RijndaelManaged
            {
                KeySize = 0x80,
                Key = this.convertHexToByte(AESKey),
                BlockSize = 0x80,
                IV = Convert.FromBase64String("Dt8lyToo17X/XkXaQvihuA==")
            }.CreateEncryptor();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream.ToArray());
        }
        /// <summary>
        /// 轉換HEX值為 Binaries
        /// </summary>
        /// <param name="hexString">HEX字串</param>
        /// <returns>Binaries值</returns>
        private byte[] convertHexToByte(string hexString)
        {
            byte[] buffer = new byte[hexString.Length / 2];
            int index = 0;
            for (int i = 0; i < hexString.Length; i += 2)
            {
                int num3 = Convert.ToInt32(hexString.Substring(i, 2), 0x10);
                buffer[index] = BitConverter.GetBytes(num3)[0];
                index++;
            }
            return buffer;
        }
        private void inputValidate(string InvoiceNumber,
        //    string InvoiceDate,
        //    string InvoiceTime,
            string RandomNumber,
        //    decimal SalesAmount,
        //    decimal TaxAmount,
        //    decimal TotalAmount,
        //    string BuyerIdentifier,
        //    string RepresentIdentifier,
        //    string SellerIdentifier,
        //    string BusinessIdentifier,
        //    Array[] productArray,
            string AESKey)
        {
            try
            {
                if (string.IsNullOrEmpty(InvoiceNumber) || (InvoiceNumber.Length != 10))
                {
                    throw new Exception("Invaild InvoiceNumber: " + InvoiceNumber);
                }
                if (string.IsNullOrEmpty(RandomNumber) || (RandomNumber.Length != 4))
                {
                    throw new Exception("Invaild RandomNumber: " + RandomNumber);
                }
                if (string.IsNullOrEmpty(AESKey) || (AESKey.Length != 32))
                {
                    throw new Exception("Invaild AESKey: " + AESKey);
                }
                /*
                long num = long.Parse(InvoiceDate);
                int num2 = int.Parse(InvoiceDate.Substring(3, 2));
                int num3 = int.Parse(InvoiceDate.Substring(5));
                if ((num2 < 1) || (num2 > 12))
                {
                    throw new Exception();
                }
                if ((num3 < 1) || (num3 > 0x1f))
                {
                    throw new Exception();
                }
                */
            }
            catch (Exception)
            {
                /*
                if (string.IsNullOrEmpty(InvoiceDate))
                {
                    throw new Exception("Invaild InvoiceDate: " + InvoiceDate);
                }
                if (string.IsNullOrEmpty(InvoiceTime))
                {
                    throw new Exception("Invaild InvoiceTime: " + InvoiceTime);
                }
                if (SalesAmount < 0M)
                {
                    throw new Exception("Invaild SalesAmount: " + SalesAmount);
                }
                if (TotalAmount < 0M)
                {
                    throw new Exception("Invaild TotalAmount: " + TotalAmount);
                }
                if (string.IsNullOrEmpty(BuyerIdentifier) || (BuyerIdentifier.Length != 8))
                {
                    throw new Exception("Invaild BuyerIdentifier: " + BuyerIdentifier);
                }
                if (string.IsNullOrEmpty(RepresentIdentifier))
                {
                    throw new Exception("Invaild RepresentIdentifier: " + RepresentIdentifier);
                }
                if (string.IsNullOrEmpty(SellerIdentifier) || (SellerIdentifier.Length != 8))
                {
                    throw new Exception("Invaild SellerIdentifier: " + SellerIdentifier);
                }
                if (string.IsNullOrEmpty(BusinessIdentifier))
                {
                    throw new Exception("Invaild BusinessIdentifier: " + BusinessIdentifier);
                }
                if ((productArray == null) || (productArray.Length == 0))
                {
                    throw new Exception("Invaild ProductArray");
                }
                */
                throw new Exception();
            }
        }
        public string QRCodeINV(string InvoiceNumber,
            //    string InvoiceDate,
            //    string InvoiceTime,
            string RandomNumber,
            //    decimal SalesAmount,
            //    decimal TaxAmount,
            //    decimal TotalAmount,
            //    string BuyerIdentifier,
            //    string RepresentIdentifier,
            //    string SellerIdentifier,
            //    string BusinessIdentifier,
            //    string[][] productArray,
            string AESKey)
        {
            try
            {
                this.inputValidate(InvoiceNumber,
                    //        InvoiceDate,
                    //        InvoiceTime,
                    RandomNumber,
                    //        SalesAmount,
                    //        TaxAmount,
                    //        TotalAmount,
                    //        BuyerIdentifier,
                    //        RepresentIdentifier,
                    //        SellerIdentifier,
                    //        BusinessIdentifier,
                    //        productArray,
                    AESKey);
            }
            catch (Exception exception)
            {
                
                if (string.IsNullOrEmpty(InvoiceNumber) || (InvoiceNumber.Length != 10))
                {
                    throw new Exception("Invaild RandomNumber: " + InvoiceNumber);
                }
                if (string.IsNullOrEmpty(RandomNumber) || (RandomNumber.Length != 4))
                {
                    throw new Exception("Invaild RandomNumber: " + RandomNumber);
                }
                if (string.IsNullOrEmpty(AESKey) || (AESKey.Length != 32))
                {
                    throw new Exception("Invaild AESKey: " + AESKey);
                }

                throw exception;
            }
            return this.AESEncrypt(InvoiceNumber + RandomNumber, AESKey).PadRight(0x18);
        }
        public string InvoiceNumber { get; set; }
        public string RandomNumber { get; set; }
        public string AESKey { get; set; }

        public string CiphertGet() {
          //return this.QRCodeINV(InvoiceNumber, RandomNumber, AESKey); 
          return this.AESEncrypt(InvoiceNumber + RandomNumber, AESKey).PadRight(0x18);
        }
    }
}
