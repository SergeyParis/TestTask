using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace TestTask.SDK.Helpers
{
    internal static class FileManager
    {
        private static int _bufferToReadWriteFile = 2048;
        private static int BufferToReadWriteFile => _bufferToReadWriteFile;

        public static void SaveFile(Stream writingStream, string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            try
            {
                using (FileStream writer = File.OpenWrite(filePath))
                {
                    WriteReadFiles(writingStream, writer);
                }
            }
            catch (Exception e) { throw e; }
        }
        public static XmlReader LoadXMLFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            try
            {
                using (FileStream reader = File.OpenRead(filePath))
                    return XmlReader.Create(reader);
            }
            catch (Exception e) { throw e; }
        }

        public static long GetLiveTimeFile(string absolutePath)
        {
            return File.Exists(absolutePath)
                ? DateTime.Now.Millisecond - File.GetCreationTime(absolutePath).Millisecond
                : -1;
        }

        private static void WriteReadFiles(Stream reader, Stream writer)
        {
            byte[] buffer = new byte[BufferToReadWriteFile];

            long length = reader.Length - BufferToReadWriteFile;
            while (reader.Position < length)
            {
                reader.Read(buffer, 0, buffer.Length);
                writer.Write(buffer, 0, buffer.Length);
            }

            length = reader.Length - reader.Position;
            reader.Read(buffer, 0, (int)length);
            writer.Write(buffer, 0, (int)length);
        }
    }
}
