using Login.Infrastructure.Logger.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using TFHKA.Storage.TableLogs;
using LogLevel = TFHKA.Storage.TableLogs.LogLevel;

namespace Login.Infrastructure.Logger
{
    public class LogAzure : ILogAzure
    {

        private string AccountName;
        private string AccountKey;
        private string AppId;
        private string Level;
        private string zoneTime;
        private LoggerTable<ObjEntry> Log;
        public ObjEntry EntryLog;
        private List<StepProcess> pasos;
        private static IConfiguration _configuration;

        public LogAzure(IConfiguration configuration)
        {
            _configuration = configuration;
            pasos = new List<StepProcess>();
            EntryLog = new ObjEntry();
            LoadConfig();
            Log = new LoggerTable<ObjEntry>(AppId, AccountName, AccountKey, EntryLog.PartitionKey, level: Level);
        }

        public void SetUp(string partitionKey, LogRequest logRequest)
        {
            pasos = new List<StepProcess>();
            LoadConfig();
            EntryLog = new ObjEntry(zoneTime);
            EntryLog.RowKeyTime = ColombiaTimezone();
            EntryLog.PartitionKey = partitionKey;
            EntryLog.NameMethod = logRequest.Method;
            EntryLog.Session = Guid.NewGuid().ToString();
            EntryLog.Application = logRequest.Application.ToString();
            EntryLog.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            EntryLog.Api = logRequest.Api;
            Log = new LoggerTable<ObjEntry>(AppId, AccountName, AccountKey, EntryLog.PartitionKey, level: Level);
        }

        private void LoadConfig()
        {
            AccountName = _configuration["StorageAzure:AccountName"];
            AccountKey = _configuration["StorageAzure:AccountKey"];
            AppId = _configuration["StorageAzure:Tablename"] + DateTime.Now.ToString("yyyyMM");
            zoneTime = _configuration["TimeZone"];

            string readLevel = _configuration["StorageAzure:LogLevel"];
            switch (readLevel)
            {
                case "Error":
                    Level = LogLevel.Error;
                    break;
                case "Notice":
                    Level = LogLevel.Notice;
                    break;
                case "Off":
                    Level = LogLevel.Off;
                    break;
                case "Warning":
                    Level = LogLevel.Error;
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="pcomment"></param>
        /// <param name="pLevel"></param>
        /// <param name="timeElapse"></param>
        public void WriteComment(string pname, string pcomment, LevelMsn pLevel = LevelMsn.Info, double timeElapse = 0)
        {
            try
            {
                pasos.Add(new StepProcess { HoraProcess = LogAzure.ColombiaTimezone(), NameProcess = pname, Comment = pcomment, LevelInfo = pLevel.ToString(), TimeElapse = timeElapse });
            }
            catch (Exception)
            {

            }
        }

        public void SaveLog(int codigo, string comment, ref Stopwatch time, LevelMsn level = LevelMsn.Info, byte[] document = null)
        {
            try
            {
                time.Stop();

                lock (EntryLog)
                {
                    EntryLog.Process = ConvertToJson(pasos);
                    EntryLog.Codigo = codigo;
                    EntryLog.Comment = comment;
                    EntryLog.Level = level.ToString();
                    EntryLog.ElapsedTime = time.ElapsedMilliseconds;

                    Log.Add(EntryLog, EntryLog.Level);
                    pasos.Clear();
                    EntryLog.ClearEntry();
                }
            }
            catch (Exception en)
            {
                pasos.Clear();
                EntryLog.ClearEntry();
            }
        }

        public string GetSession()
        {
            return EntryLog.Session;
        }
        public static string ConvertToJson(object objtoConvert)
        {
            try
            {
                return JsonConvert.SerializeObject(objtoConvert);
            }
            catch (Exception en)
            {
                return "Error en ConvertToJson";
            }
        }

        public static DateTime ColombiaTimezone()
        {
            string time = _configuration["TimeZone"];
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(time);

            DateTime dateColombia = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, timeZone);
            return dateColombia;
        }
    }
    public class ObjEntry : LogEntry
    {
        public ObjEntry() : base()
        {

        }

        public ObjEntry(string zoneTime) : base(zoneTime)
        {

        }

        public string NameMethod { get; set; }
        public double ElapsedTime { get; set; }
        public string Session { get; set; }
        public int Codigo { get; set; }
        public string Comment { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public string Application { get; set; }
        public string Api { get; set; }

        public void ClearEntry()
        {
            this.NameMethod = "";
            this.ElapsedTime = 0;
            this.Session = "";
            this.Codigo = 0;
            this.Comment = "";
            this.Version = "";
            this.Process = "";
            this.IpAddress = "";
            this.Application = "";
        }
    }

    public enum LevelMsn
    {
        Info = 1,
        Warning,
        Error
    }
}
