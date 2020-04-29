using Core.DomainServices.Interfaces;
using Core.Entities;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DomainServices.Implementation
{
    public class QuoteRepo : IQuoteRepo
    {
        private readonly DataContext _dataContext;
        public QuoteRepo(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public Quote AddQuote(Quote quote)
        {
            Quote _quote = _dataContext.Quotes.Add(quote).Entity;
            _dataContext.SaveChanges();

            return _quote;
        }

        public void DeleteQuote(int id)
        {
            _dataContext.Quotes.Attach(GetQuoteById(id)).State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public List<Quote> GetAllQuotes()
        {
            return _dataContext.Quotes.ToList();
        }

        public Quote GetQuoteById(int id)
        {
            var quote = _dataContext.Quotes.FirstOrDefault(q => q.Id == id);

            if (quote == null) throw new Exception($"No quote exist with ID {id}.");

            return quote;
        }

        public Quote UpdateQuote(Quote quote)
        {
            _dataContext.Quotes.Attach(quote).State = EntityState.Modified;
            _dataContext.SaveChanges();

            return GetQuoteById(quote.Id);
        }


        private bool CheckQuoteExist(int id)
        {
            // If no quote exist with given id, return false, else return true
            return _dataContext.Quotes.FirstOrDefault(q => q.Id == id) == null ? false : true;
        }
    }
}
