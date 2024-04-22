using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;

namespace codeDojoApi.Controllers
{
    [ApiController]
    [Route("api/speech")]
    public class AzureSpeechController : Controller
    {
        [HttpPost("texttovoice")]
        public async Task TextToVoice([FromBody] string text)
        {
            var speechConfig = SpeechConfig.FromSubscription("236738172a944deeb8d64c079178a6ae", "brazilsouth");
            speechConfig.SpeechSynthesisVoiceName = "pt-BR-NicolauNeural";
            var speechSynthesizer = new SpeechSynthesizer(speechConfig);
            await speechSynthesizer.SpeakTextAsync(text);
        }
    }
}
