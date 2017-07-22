namespace NeuOldDriver.Models {

    public class IPGWModel {
        public string username { get; set; }
        public string password { get; set; }
        public bool logged { get; set; }
        public ulong used { get; set; }
        public ulong used_time { get; set; }
        public string balance { get; set; }
        public string ip { get; set; }
    };
}
