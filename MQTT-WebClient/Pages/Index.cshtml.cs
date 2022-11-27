using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MQTT_WebClient.Services.Implementations;
using MQTT_WebClient.Services.Interfaces;


namespace MQTT_WebClient.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    public string message {get;set;} = string.Empty;

    private readonly ILogger<IndexModel> _logger;
    private readonly IPublisherProcessor _publisher;

    public IndexModel(ILogger<IndexModel> logger, IPublisherProcessor publisherProcessor)
    {
        _logger = logger;
        _publisher = publisherProcessor;
    }

    public void OnGet()
    {

    }

    public void OnPost(){
        _publisher.PublishMessageAsync(message,"myTopic");
    }


}
