﻿using System.Security.Cryptography;
using System.Text;

namespace PokeLite.MVVM.ViewModel
{
    public static class HashPassword
    {
        public static string CreateHash(string data)
        {
            byte[] dataBytes = Encoding.ASCII.GetBytes(data);
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(dataBytes);
                string hash = Convert.ToBase64String(hashBytes);
                return hash;
            }
        }
    }
}
