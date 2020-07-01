using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NFSUOnline.Helpers
{
    public class Reader : BinaryReader
    {
        private byte[] buffer;

        public Reader(byte[] buffer) : base(new MemoryStream(buffer))
        {
            this.buffer = buffer;
        }

        public string readValue1(string value)
        {
            string bufferStr = Encoding.UTF8.GetString(buffer);

            int valueIdx = bufferStr.IndexOf(value, StringComparison.Ordinal);
            int endIdx = bufferStr.IndexOf('\x0A', valueIdx);

            int stringLen = endIdx - valueIdx;

            string valueStr = bufferStr.Substring(valueIdx, stringLen);

            string[] splitValueStr = valueStr.Split('=');

            return splitValueStr[1];
        }

        // Fuck you EA! You absolute fucking retards..
        public string readValue2(string value)
        {
            string bufferStr = Encoding.UTF8.GetString(buffer);

            int valueIdx = bufferStr.IndexOf(value, StringComparison.Ordinal);
            int endIdx = bufferStr.IndexOf('\x20', valueIdx);

            int stringLen = endIdx - valueIdx;

            string valueStr = bufferStr.Substring(valueIdx, stringLen);

            string[] splitValueStr = valueStr.Split('=');

            return splitValueStr[1];
        }

        public string readString(int length)
        {
            byte[] buffer = ReadBytes(length);

            return Encoding.UTF8.GetString(buffer);
        }

        private byte[] readBytes(int _Count, bool _Endian = false)
        {
            byte[] _Buffer = new byte[_Count];
            this.BaseStream.Read(_Buffer, 0, _Count);

            if (BitConverter.IsLittleEndian && _Endian)
            {
                Array.Reverse(_Buffer);
            }

            return _Buffer;
        }
    }
}
