namespace MyResource.Core.Palettes.Models
{
    public class Palette
    {
        public int PaletteId { get; set; }
        public int? UserId { get; set; }  
        public string BaseClr { get; set; }
        public string SectionClr { get; set; }
        public string TextClr { get; set; }
        public string SecondaryTextClr { get; set; }
        public string AccentClr { get; set; }
        public string LineClr { get; set; }
        public string HoverClr { get; set; }
        public string ShadowClr { get; set; }
    }
}
