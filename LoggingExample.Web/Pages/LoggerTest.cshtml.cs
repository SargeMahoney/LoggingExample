using LoggingExample.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoggingExample.Web.Pages
{
    public class LoggerTestModel : PageModel
    {
        private readonly ILoggerEngine _loggerEngine;

        public LoggerTestModel(ILoggerEngine loggerEngine)
        {
            this._loggerEngine = loggerEngine;
        }
        public async Task OnGet()
        {

            await _loggerEngine.Write("test", LogField.UI);
        }
    }
}
