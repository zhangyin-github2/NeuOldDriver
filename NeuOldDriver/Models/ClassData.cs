namespace NeuOldDriver.Models {

    public class ClassData {
        public string Text { get; set; }
        public string Major { get; set; }
        public string Category { get; set; }
        public string Term { get; set; }
        public double Rating { get; set; }

        public object this[string index] {
            get {
                switch(index) {
                    case "Text": return Text;
                    case "Major": return Major;
                    case "Term": return Term;
                    case "Category": return Category;
                    case "Rating": return Rating;
                    default: return null;
                }
            }
        }
    }
}
