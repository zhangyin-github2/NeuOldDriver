namespace NeuOldDriver.Models {

    public class IPGWModel {
        public string username { get; set; }
        public string password { get; set; }
        public bool logged { get; set; }
        public ulong used { get; set; }
        public ulong used_time { get; set; }
        public string balance { get; set; }
        public string ip { get; set; }

        public void SetFrom(IPGWModel other) {
            if (other == null || ReferenceEquals(this, other))
                return;
            used = other.used;
            used_time = other.used_time;
            balance = other.balance;
            ip = other.ip;
        }
    };
}
