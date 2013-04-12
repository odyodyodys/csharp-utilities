using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Utilities.Security
{
    public static class StringEncryption
    {
        private static readonly byte[] entropy = Encoding.Unicode.GetBytes("a4e167fe393bceb85b67476feeade837181875822df6b2c475dfaa9c6aff0674");

        public static string EncryptString(this SecureString input)
        {
            if (input == null)
            {
                return null;
            }

            var encryptedData = ProtectedData.Protect(
                Encoding.Unicode.GetBytes(input.ToInsecureString()),
                entropy,
                DataProtectionScope.CurrentUser);

            return System.Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(this string encryptedData)
        {
            if (encryptedData == null)
            {
                return null;
            }

            try
            {
                var decryptedData = ProtectedData.Unprotect(
                    System.Convert.FromBase64String(encryptedData),
                    entropy,
                    DataProtectionScope.CurrentUser);

                return Encoding.Unicode.GetString(decryptedData).ToSecureString();
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(this IEnumerable<char> input)
        {
            if (input == null)
            {
                return null;
            }

            var secure = new SecureString();

            foreach (var c in input)
            {
                secure.AppendChar(c);
            }

            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(this SecureString input)
        {
            if (input == null)
            {
                return null;
            }

            var ptr = Marshal.SecureStringToBSTR(input);

            try
            {
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(ptr);
            }
        }

        public static string CypherText(string data)
        {
            return data.ToSecureString().EncryptString();
        }

        public static string DeCypherText(string data)
        {
            return data.DecryptString().ToInsecureString();
        }
    }

}
