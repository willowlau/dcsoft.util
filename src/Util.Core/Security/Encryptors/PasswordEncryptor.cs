﻿namespace Util.Security.Encryptors
{
    /// <summary>
    /// 密码加密器
    /// </summary>
    public class PasswordEncryptor : IEncryptor
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">原始数据</param>
        public string Encrypt(string data)
        {
            return Util.Utils.Encrypt.AesEncrypt(data);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">已加密数据</param>
        public string Decrypt(string data)
        {
            return Util.Utils.Encrypt.AesDecrypt(data);
        }
    }
}