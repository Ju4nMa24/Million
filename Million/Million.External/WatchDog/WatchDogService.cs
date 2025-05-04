using Microsoft.Extensions.Logging;
using Million.Application.External.WatchDog;
using Million.Domain.Models;
using WatchDog;

namespace Million.External.WatchDog
{
    public class WatchDogService<T>(ILoggerFactory logger) : IWatchDogService<T>
    {
        private readonly ILogger<T> _logger = logger.CreateLogger<T>();
        /// <summary>
        /// This method is used to logger by WatchDog lib.
        /// </summary>
        /// <param name="model"></param>
        public void Execute(WatchDogModel model)
        {
            switch (model.Type)
            {
                case Domain.Enums.WatchDogTypes.Information:
                    _logger.LogInformation(model.Message);
                    WatchLogger.Log(model.Message);
                    break;
                case Domain.Enums.WatchDogTypes.Warning:
                    _logger.LogWarning(model.Message);
                    WatchLogger.LogWarning(model.Message);
                    break;
                case Domain.Enums.WatchDogTypes.Error:
                    _logger.LogError(model.Exception, model.Message);
                    WatchLogger.LogError(model.Message);
                    break;
            }
        }
    }
}
