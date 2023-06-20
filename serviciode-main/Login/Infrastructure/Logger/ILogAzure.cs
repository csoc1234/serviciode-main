using Login.Infrastructure.Logger.Models;
using System.Diagnostics;

namespace Login.Infrastructure.Logger
{
    public interface ILogAzure
    {
        void SetUp(string partitionKey, LogRequest logRequest);

        void WriteComment(string pname, string pcomment, LevelMsn pLevel = LevelMsn.Info, double timeElapse = 0);

        void SaveLog(int codigo, string comment, ref Stopwatch time, LevelMsn level = LevelMsn.Info, byte[] document = null);

        string GetSession();
    }
}
