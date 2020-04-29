using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices.Interfaces
{
    public interface IQuoteRepo
    {
        Quote AddQuote(Quote quote);
        List<Quote> GetAllQuotes();
        Quote GetQuoteById(int id);
        Quote UpdateQuote(Quote quote);
        void DeleteQuote(int id);
    }
}
