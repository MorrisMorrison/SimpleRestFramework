using System.Collections.Generic;

namespace SimpleRestFramework.Generator
{
    public interface IFileGenerator
    {
         void GenerateFile(string p_path, string p_fileName, string p_content);
    }
}