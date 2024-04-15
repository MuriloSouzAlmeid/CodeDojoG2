using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;

namespace codeDojoApi.Controllers
{
    [ApiController]
    [Route("api/speech")]
    public class AzureSpeechController : Controller
    {
        [HttpPost("texttovoice")]
        public async Task<IActionResult> TextToVoice([FromBody] string text)
        {
            var speechConfig = SpeechConfig.FromSubscription("236738172a944deeb8d64c079178a6ae", "brazilsouth");
            speechConfig.SpeechSynthesisVoiceName = "pt-BR-NicolauNeural";

            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(text);

                if (speechSynthesisResult.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    return Ok(new { Message = "Texto convertido para voz com sucesso" });
                }
                else
                {
                    return BadRequest(new { Message = "A conversão de texto para voz falhou" });
                }
            }
        }
    }
}
