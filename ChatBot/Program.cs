
using ChatBot;
using OpenAI.Chat;

var model = "gpt-5-nano";
Utilidades.CargarVariableDeEntorno();
var apiKey = Environment.GetEnvironmentVariable("OPENAI_KEY") 
                ?? throw new InvalidOperationException("OPENAI_KEY environment variable is not set.");
var cliente = new ChatClient(model, apiKey);