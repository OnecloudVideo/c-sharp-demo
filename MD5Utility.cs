﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Onecloud.Video.RestfulApi.Demo
{
    class MD5Utility
    {
        public static string Compute(string str)
        {
            return bytesToHex(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(str)));
        }

        private static string bytesToHex(byte[] bytes)
        {
            var hex = "";
            for (var i = 0; i < bytes.Length; i++)
            {
                var aByte = (int)bytes[i];
                if(aByte < 0){
                    aByte += 256;
                }
                if (aByte < 16)
                {
                    hex += "0";
                }
                hex += aByte.ToString("X");
            }
            return hex;
        }
    }
}
