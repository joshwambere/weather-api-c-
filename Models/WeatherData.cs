namespace WeatherAppApi;

public partial class WeatherData
{
    public Coord Coord { get; set; }
    public Weather[] Weather { get; set; }
    public string Base { get; set; }
    public MainClass MainMain { get; set; }
    public long Visibility { get; set; }
    public Wind Wind { get; set; }
    public Clouds Clouds { get; set; }
    public long Dt { get; set; }
    public Sys Sys { get; set; }
    public long Timezone { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public long Cod { get; set; }
}

public partial class Clouds
{
    public long All { get; set; }
}

public partial class Coord
{
    public double Lon { get; set; }
    public double Lat { get; set; }
}

public partial class MainClass
{
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public long Pressure { get; set; }
    public long Humidity { get; set; }
}

public partial class Sys
{
    public long Type { get; set; }
    public long Id { get; set; }
    public string Country { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}

public partial class Weather
{
    public long Id { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}

public partial class Wind
{
    public double Speed { get; set; }
    public long Deg { get; set; }
}