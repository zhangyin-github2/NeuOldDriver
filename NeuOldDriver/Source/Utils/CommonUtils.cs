using System;

namespace NeuOldDriver.Utils {

    public static class CommonUtils {

        /// <summary>
        /// Convert size in bytes to human readable string
        /// </summary>
        /// <param name="size">size in bytes</param>
        /// <returns>converted string</returns>
        public static string SanitizeSize(ulong size) {
            const string units = " KMGTPEZ";
            int unit = 0, len = units.Length;
            ulong remainder = 0;
            while (unit < len) {
                if (size < 1024)
                    break;
                remainder = size & 1023;
                size >>= 10;
            }
            return String.Format("{0:N1} {1}B", size + remainder / 1024d, units[unit]);
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string SanitizeTime(ulong time) {
            return "";
        }

    }
}
