using System;

namespace DllDatabase
{
    public class Audit

    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string Username { get; set; }
        public string Local { get; set; }
        public string IP { get; set; }
        public string GeoLocation { get; set; }
    }
}
