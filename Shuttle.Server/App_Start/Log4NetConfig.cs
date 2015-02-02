namespace Shuttle.Server.App_Start
{
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;

    public static class Log4NetConfig
    {
        public static void Init(bool verbose)
        {
            var appender = new ColoredConsoleAppender
            {
                Threshold = verbose ? Level.All : Level.Error,
                Layout =
                    new PatternLayout(
                    "%level [%thread] %d{HH:mm:ss} - %message%newline"),
            };
            appender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Debug,
                ForeColor = ColoredConsoleAppender.Colors.Cyan
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            appender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Info,
                ForeColor = ColoredConsoleAppender.Colors.Green
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            appender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Warn,
                ForeColor = ColoredConsoleAppender.Colors.Purple
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            appender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Error,
                ForeColor = ColoredConsoleAppender.Colors.Red
                    | ColoredConsoleAppender.Colors.HighIntensity
            });
            appender.AddMapping(new ColoredConsoleAppender.LevelColors
            {
                Level = Level.Fatal,
                ForeColor = ColoredConsoleAppender.Colors.White
                    | ColoredConsoleAppender.Colors.HighIntensity,
                BackColor = ColoredConsoleAppender.Colors.Red
            });

            appender.ActivateOptions();
            BasicConfigurator.Configure(appender);
        }
    }
}