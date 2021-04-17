using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
  public class LocalMailService : IMailService
  {
    private IConfiguration _configuration;

    public LocalMailService(IConfiguration configuration)
    {
      _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public void Send(string subject, string message)
    {
      Debug.WriteLine($"Mail enviado de {_configuration["mailSettings:mailFromAddress"]} a {_configuration["mailSettings:mailToAddress"]} utilizando LocalMailService");
      Debug.WriteLine($"Asunto: {subject}");
      Debug.WriteLine($"Mensaje: {message}");
    }

  }
}