using System.Collections.Generic;

namespace NeuOldDriver.ViewModels {

    public enum WeekDays : int {
        MON = 0, TUE, WED, THU, FRI, SAT, SUN
    };

    public class ClassScheduleViewModel : ViewModelBase {

        public class Class {
            public string name { get; set; }
            public string teacher { get; set; }
            public string location { get; set; }
        };

        public IEnumerable<Class> this[WeekDays days] {
            get {
                int i = (int)days;
                return null;
            }
        }

    }
}
