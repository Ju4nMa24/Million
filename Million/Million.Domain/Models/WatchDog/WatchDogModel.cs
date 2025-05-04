﻿using Million.Domain.Enums;

namespace Million.Domain.Models
{
    public class WatchDogModel
    {
        public required WatchDogTypes Type { get; set; }
        public required string Message { get; set; }
        public Exception? Exception { get; set; }
    }
}
