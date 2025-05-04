﻿using Million.Domain.Models;

namespace Million.Application.External.WatchDog
{
    public interface IWatchDogService<T>
    {
        /// <summary>
        /// This method is used to logger by WatchDog lib.
        /// </summary>
        /// <param name="model"></param>
        void Execute(WatchDogModel model);
    }
}
