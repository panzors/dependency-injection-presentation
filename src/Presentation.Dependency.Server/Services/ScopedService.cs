﻿namespace Presentation.Dependency.Server.Services
{
    public class ScopedListingService : IListingService, IScopedService
    {
        private readonly List<string> _data;

        public ScopedListingService() 
        {
            _data = new List<string>();
        }

        public IEnumerable<string> Add(string data)
        {
            _data.Add(data);
            return _data;
        }
    }
}
