using System;
namespace MassGenieAVTool.Utils
{
    public interface ISerializer
    {
        T Deserialize<T>(string input) where T : class;
        string Serialize<T>(T ObjectToSerialize);
    }
}
