using System;
using System.Collections.Generic;
using System.Text;

namespace NFSUOnline.Helpers
{
    public static class Writer
    {
        public static void writeString(this List<byte> data, string value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value);

            data.AddRange(buffer);
        }

        public static void writeValue(this List<byte> data, string value1, string value2)
        {
            byte[] completeValue = Encoding.UTF8.GetBytes(value1 + "=" + value2 + '\x0A');

            data.AddRange(completeValue);
        }
    }
}
