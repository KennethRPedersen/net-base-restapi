using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppServices.Interfaces
{
    public interface IQuoteService
    {
        /// <summary>
        /// Adds the given quote to the database
        /// </summary>
        /// <param name="quote">The quote to add</param>
        /// <returns><see cref="Quote"/></returns>
        Quote AddQuote(Quote quote);

        /// <summary>
        /// Gets all quotes in the database
        /// </summary>
        /// <returns>A list of <see cref="Quote"/></returns>
        List<Quote> GetAllQuotes();

        /// <summary>
        /// Fetches the quote matching the given ID.
        /// </summary>
        /// <param name="id">Id of the quote to return</param>
        /// <returns>A list of <see cref="Quote"/></returns>
        Quote GetQuoteById(int id);

        /// <summary>
        /// Updates the given quotes data
        /// </summary>
        /// <param name="quote">The updated quote</param>
        /// <returns><see cref="Quote"/></returns>
        Quote UpdateQuote(Quote quote);

        /// <summary>
        /// Deletes the quote matching the given ID.
        /// </summary>
        /// <param name="id">ID of the quote to delete</param>
        void DeleteQuote(int id);
    }
}
