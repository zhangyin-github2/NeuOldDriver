using System;

namespace NeuOldDriver.Utils {

    public static class Sanitizer {

        /// <summary>
        /// Convert size in bytes to human readable string
        /// </summary>
        /// <param name="size">size in bytes</param>
        /// <returns>converted string</returns>
        public static string SanitizeSize(ulong size) {
            var units = new[] { "", "K", "M", "G", "T", "P", "E", "Z" };
            ulong remainder = 0;
            var unit = units.GetEnumerator();
            while (unit.MoveNext()) {
                if (size < 1024)
                    break;
                remainder = size & 1023;
                size >>= 10;
            }
            return String.Format("{0:N1} {1}B", size + remainder / 1024d, unit.Current);
        }

        /// <summary>
        /// Convert seconds to hour:minute:second format
        /// </summary>
        /// <param name="time">time in seconds</param>
        /// <returns>converted string</returns>
        public static string SanitizeTime(ulong time) {
            var seconds = time % 60;
            time /= 60;
            var minutes = time % 60;
            time /= 60;
            return String.Format("{0}:{1}:{2}", time, minutes, seconds);
        }

    }
}
