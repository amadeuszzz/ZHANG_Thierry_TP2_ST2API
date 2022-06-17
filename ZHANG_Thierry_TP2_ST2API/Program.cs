using System;

namespace ZHANG_Thierry_TP2_ST2API
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = new Api("8cbae7f191881e287c2b9e381ff5d923");

            OpenWeather morocco = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?lat=32&lon=-5&APPID=");
            Console.WriteLine("In Morocco the weather is : " + morocco.weather[0].main + " (" + morocco.weather[0].description + ")");

            OpenWeather oslo = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Oslo&APPID=");

            DateTimeOffset rise = DateTimeOffset.FromUnixTimeSeconds(oslo.sys.sunrise);
            DateTimeOffset set = DateTimeOffset.FromUnixTimeSeconds(oslo.sys.sunset);
            Console.WriteLine("Time for sun rise in Oslo : " + rise);
            Console.WriteLine("Time for sun set in Oslo : " + set);

            OpenWeather jakarta = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Jakarta&APPID=");
            Console.WriteLine("The temperatue in Jakarta is : " + (int)Math.Round((jakarta.main.temp - 273.15)) + "°C");

            OpenWeather newYork = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=New%20York&APPID=");
            OpenWeather tokyo = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Tokyo&APPID=");
            OpenWeather paris = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Paris&APPID=");
            OpenWeather max = newYork;
            if (tokyo.wind.speed > max.wind.speed)
                max = tokyo;
            if (paris.wind.speed > max.wind.speed)
                max = paris;
            Console.WriteLine("The windiest city from this list (New-York, Tokyo, Paris) is : " + max.name);

            OpenWeather kiev = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Kiev&APPID=");
            OpenWeather moscow = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Moscow&APPID=");
            OpenWeather berlin = api.getWeatherData("https://api.openweathermap.org/data/2.5/weather?q=Berlin&APPID=");

            Console.WriteLine("The humidity and pressure in Kiev is : " + kiev.main.humidity + "% , " + kiev.main.pressure + "hPa");
            Console.WriteLine("The humidity and pressure in Moscow is : " + moscow.main.humidity + "% , " + moscow.main.pressure + "hPa");
            Console.WriteLine("The humidity and pressure in berlin is : " + berlin.main.humidity + "% , " + berlin.main.pressure + "hPa");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
