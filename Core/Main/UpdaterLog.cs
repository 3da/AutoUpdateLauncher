using System;
using System.IO;

namespace Core.Main
{
    public class UpdaterLog : IDisposable
    {
        private readonly string _fileName;
        private bool _write;

        private readonly StreamWriter stream;

        public UpdaterLog(string fileName, bool write)
        {
            _fileName = fileName;
            _write = write;

            if (_write)
                stream = new StreamWriter(File.OpenWrite(fileName));
        }

        public void WriteUpdate(string fileName, string bakFileName)
        {
            if (!_write)
                throw new Exception();
            stream.WriteLine($"update {fileName} {bakFileName}");
            stream.Flush();
        }

        public void WriteAdd(string fileName)
        {
            if (!_write)
                throw new Exception();
            stream.WriteLine($"add {fileName}");
            stream.Flush();
        }

        public void WriteDelete(string fileName, string bakFileName)
        {
            if (!_write)
                throw new Exception();
            stream.WriteLine($"delete {fileName} {bakFileName}");
            stream.Flush();
        }

        public void Revert()
        {
            foreach (var line in File.ReadLines(_fileName))
            {
                var parts = line.Split(' ');
                switch (parts[0])
                {
                    case "update":
                        File.Delete(parts[1]);
                        File.Move(parts[2], parts[1]);
                        break;
                    case "add":
                        File.Delete(parts[1]);
                        break;
                    case "delete":
                        File.Move(parts[2], parts[1]);
                        break;
                }
            }

            File.Delete(_fileName);
        }

        public void Dispose()
        {
            stream?.Dispose();
        }

        public void Complete()
        {
            stream?.Flush();
            stream?.Close();
            _write = false;

            foreach (var line in File.ReadLines(_fileName))
            {
                var parts = line.Split(' ');
                switch (parts[0])
                {
                    case "update":
                        File.Delete(parts[2]);
                        break;
                    case "add":
                        break;
                    case "delete":
                        File.Delete(parts[2]);
                        break;
                }
            }

            File.Delete(_fileName);
        }
    }
}
