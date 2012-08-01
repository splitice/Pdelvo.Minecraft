﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Pdelvo.Minecraft.Network
{
    public static class ProtocolSecurity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        public static RSAParameters GenerateRSAKeyPair(out RSACryptoServiceProvider provider)
        {
            provider = new RSACryptoServiceProvider(1024);
            return provider.ExportParameters(true);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        internal static RSAParameters GenerateRSAPublicKey(byte[] key)
        {
            AsnKeyParser parser = new AsnKeyParser(key);
            return parser.ParseRSAPublicKey();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        private static RSAParameters GenerateRSAKey(byte[] key, bool isPrivate)
        {
            AsnKeyParser parser = new AsnKeyParser(key);
            return isPrivate ? parser.ParseRSAPrivateKey() : parser.ParseRSAPublicKey();
        }
        public static byte[] GenerateAes128Key()
        {

            return new SecureRandom().GenerateSeed(16);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        public static byte[] RSADecrypt(byte[] data, byte[] key, bool isPrivate)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (key == null)
                throw new ArgumentNullException("key");

            var provider = RSACryptoServiceProvider.Create();
            provider.ImportParameters(GenerateRSAKey(key, isPrivate));
            return provider.DecryptValue(data);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        public static byte[] RSADecrypt(byte[] data, RSACryptoServiceProvider provider, bool isPrivate)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            return provider.Decrypt(data,false);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "RSA is the name of the encryption standard")]
        public static byte[] RSAEncrypt(byte[] data, byte[] key, bool isPrivate)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (key == null)
                throw new ArgumentNullException("key");

            var provider = (RSACryptoServiceProvider)RSACryptoServiceProvider.Create();
            provider.ImportParameters(GenerateRSAKey(key, isPrivate));
            return provider.Encrypt(data, false);
        }

        public static string ComputeHash(params byte[][] bytes)
        {
            List<byte> b = new List<byte>();
            foreach (var item in bytes)
            {
                if (item == null)
                    if (bytes == null) throw new ArgumentNullException("bytes", "Inner array is null");
                b.AddRange(item);
            }
            return Cryptography.JavaHexDigest(b.ToArray());
        }
    }
}
