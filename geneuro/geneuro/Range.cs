namespace geneuro {
    public class Range {
        public int First { get; set; }
        public int Second { get; set; }

        public Range() {
            First = 0;
            Second = 0;
        }

        public Range(int first, int second) {
            First = first;
            Second = second;
        }
    }
}
