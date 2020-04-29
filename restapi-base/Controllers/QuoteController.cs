using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AppServices.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace restapi_base.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly ILogger<QuoteController> _logger;

        public QuoteController(ILogger<QuoteController> logger, IQuoteService quoteService)
        {
            _quoteService = quoteService;
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult<List<Quote>> GetAllQuotes()
        {
            _logger.LogDebug($"GetAllQuotes was triggered.");
            try
            {
                var quotes = _quoteService.GetAllQuotes();
                _logger.LogInformation($"Returned {quotes.Count} quotes.");

                return quotes;
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all quotes: {e}");
                return BadRequest(e);
            }

        }
        
        [HttpGet()]
        [Route("{id}")]
        public ActionResult<Quote> GetQuoteById(int id)
        {
            _logger.LogDebug($"GetQuoteById was triggered. \nId: {id}");
            try
            {
                if ( id <= 0 ) return BadRequest();

                var quote = _quoteService.GetQuoteById(id);
                _logger.LogInformation($"Fetched quote with ID: {id}.");
                return quote;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Failed to fetch quote with ID: {id}: {e}");
                return BadRequest(e);
            }
        }

        [HttpPost()]
        public ActionResult<Quote> AddQuote(Quote quote)
        {
            _logger.LogDebug($"AddQuote was triggered. \nQuote: {quote}");
            try
            {
                if (quote == null) return BadRequest();

                var savedQuote = _quoteService.AddQuote(quote);
                _logger.LogInformation($"Added new quote to Database. ID: {savedQuote.Id}");

                return savedQuote;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Failed to save new quote: {e}");
                return BadRequest(e);
            }
        }

        [HttpDelete()]
        public ActionResult<Quote> DeleteQuote(int id)
        {
            _logger.LogDebug($"DeleteQuote was triggered. \nId: {id}");
            try
            {
                if (id <= 0) return BadRequest();

                _quoteService.DeleteQuote(id);

                _logger.LogInformation($"Deleted quite with ID: {id}");

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Failed to delete quote: {e}");
                return BadRequest(e);
            }
        }

        [HttpPut()]
        public ActionResult<Quote>UpdateQuote(Quote quote)
        {
            _logger.LogDebug($"UpdateQuote was triggered. \nQuote: {quote}");
            try
            {
                if (quote == null ) return BadRequest();
                if (quote.Id <= 0) return BadRequest("No Id provided for quote to update!");

                var updatedQuote = _quoteService.UpdateQuote(quote);

                _logger.LogInformation($"Updated quote: {updatedQuote}");

                return updatedQuote;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Failed to delete quote: {e}");
                return BadRequest(e);
            }
        }
    }
}