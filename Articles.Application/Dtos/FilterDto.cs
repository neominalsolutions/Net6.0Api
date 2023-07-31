namespace Articles.Application
{
    public class FilterDto
    {
        public int Size { get; set; } // veri adeti 12 
        public int Page { get; set; } // kaçıncı sayfa 5 
        public string? OrderBy { get; set; } // Title asc
        public string? ThenBy { get; set; } // createdAt desc
        public string? SearchText { get; set; }

    }
}
