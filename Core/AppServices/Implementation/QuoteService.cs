using Core.AppServices.Interfaces;
using Core.DomainServices.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppServices.Implementation
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepo _quoteRepo;

        public QuoteService(IQuoteRepo quoteRepo)
        {
            this._quoteRepo = quoteRepo;
        }

        public Quote AddQuote(Quote quote)
        {
            return _quoteRepo.AddQuote(quote);
        }

        public void DeleteQuote(int id)
        {
            _quoteRepo.DeleteQuote(id);
        }

        public List<Quote> GetAllQuotes()
        {
            return _quoteRepo.GetAllQuotes();
        }

        public Quote GetQuoteById(int id)
        {
            return _quoteRepo.GetQuoteById(id);
        }

        public Quote UpdateQuote(Quote quote)
        {
            return _quoteRepo.UpdateQuote(quote);
        }
    }
}
