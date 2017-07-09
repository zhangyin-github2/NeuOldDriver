namespace NeuOldDriver.Models {

    public class LoginData {
        public readonly string username;
        public readonly string password;
        public readonly bool   remember;

        public LoginData(string un, string pw, bool r) {
            username = un;
            password = pw;
            remember = r;
        }
    }

}
