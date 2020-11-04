﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;

namespace Travel_list_API.Data.Repositories
{
    public class TravelListRepository : ITravelListRepository
    {
        private readonly TravelListContext _dbContext;
        private readonly DbSet<TravelList> _travelLists; 
        public TravelListRepository(TravelListContext dBContext) { 
            _dbContext = dBContext; 
            _travelLists = dBContext.TravelLists; 
        }

        public void Add(TravelList travelList)
        {
            _travelLists.AddAsync(travelList);
        }

        public void Delete(TravelList travelList)
        {
            _travelLists.Remove(travelList);
        }

        public TravelList GetTravelListById(int id)
        {
            return _travelLists.Include(t => t.Items).SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<TravelList> GetTravelLists()
        {
            return _travelLists.Include(t => t.Items).ToList();
        }

        public void Update(TravelList travelList)
        {
            _travelLists.Update(travelList);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        } 
    }
}