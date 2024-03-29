﻿using NativeAppsII_Windows_Groep18.Model;
using NativeAppsII_Windows_Groep18.Services.IServices;
using System;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.ViewModel
{
    public class AddTripViewModel
    {
        #region Fields
        private readonly ITripService _tripService;
        #endregion

        #region Constructors
        public AddTripViewModel(ITripService tripService)
        {
            _tripService = tripService;
        }
        #endregion

        #region Methods
        public async Task<Trip> AddTrip(string name, string location, DateTime startDate, DateTime endDate)
        {
            var trip = new Trip() { Name = name, Location = location, StartDate = startDate, EndDate = endDate };
            return await _tripService.UpsertTrip(trip);
        } 
        #endregion
    }
}