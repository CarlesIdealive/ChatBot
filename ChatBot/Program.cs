
using ChatBot;
using OpenAI.Chat;

var model = "gpt-5-nano";
Utilidades.CargarVariableDeEntorno();
var apiKey = Environment.GetEnvironmentVariable("OPENAI_KEY") 
                ?? throw new InvalidOperationException("OPENAI_KEY environment variable is not set.");
var cliente = new ChatClient(model, apiKey);

Console.WriteLine("IA: Hola, ¿cómo puedo ayudarte hoy?");
Console.WriteLine();
var mensajes = new List<ChatMessage>();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Tú: ");
    var input = Console.ReadLine();
    Console.ResetColor();

    if (string.IsNullOrWhiteSpace(input)) break;

    mensajes.Add(new UserChatMessage(input));

    Console.WriteLine();
    var respuesta = await cliente.CompleteChatAsync(mensajes);
    var respuestaIA = respuesta.Value.Content[0].Text;
    mensajes.Add(new AssistantChatMessage(respuestaIA));

    Console.WriteLine($"IA: {respuestaIA}");
    Console.WriteLine();
}