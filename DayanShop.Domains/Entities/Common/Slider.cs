namespace DayanShop.Domains.Entities.Common;

public class Slider
{
    public int Id { get; set; }
    public string Link { get; set; }
    public string ImagePath { get; set; }
    public string? AltAttr { get; set; }
    public string? TitleAttr { get; set; }
    public int? Height { get; set; }
    public int? width { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public SliderPossition Possition { get; set; }
    public bool IsShow { get; set; }
}
public enum SliderPossition{
    TOP_RIGHT=0,
    TOP_LEFT=1,
    TOP_LEFT_CENTER=2,
    TOP_LEFT_BOTTOM = 3,
    BUTTOM_LEFT=4,
    BUTTOM_RIGHT=5,
}