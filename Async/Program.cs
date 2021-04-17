using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      Coffee cup = PourCoffee();
      Console.WriteLine("Cafe está listo");

      Task<Egg> eggsTask = FryEggsAsync(2);
      Task<Bacon> baconTask = FryBaconAsync(3);
      Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);


      var list = new List<Task> { eggsTask, baconTask, toastTask };

      while (list.Count > 0)
      {
        Task finishedTask = await Task.WhenAny(list);

        if (finishedTask == eggsTask)
          Console.WriteLine("huevos estan listos");

        if (finishedTask == baconTask)
          Console.WriteLine("Tocino está listo");

        if (finishedTask == toastTask)
          Console.WriteLine("Tostadas listas");

        list.Remove(finishedTask);

      }


      Juice oj = PourOJ();
      Console.WriteLine("Jugo está listo");
      Console.WriteLine("Desayuno completado!");
    }

    private static Juice PourOJ()
    {
      Console.WriteLine("Servir jugo de naranja");
      return new Juice();
    }

    static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    {
      Toast toast = await ToastBreadAsync(number);
      ApplyButter(toast);
      ApplyJam(toast);
      return toast;
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("Agregar mermelada a las tostadas");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("Agregar mantequilla a las tostadas");

    private static async Task<Toast> ToastBreadAsync(int slices)
    {
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("Colocar una lamina de pan en la tostadora");
      }
      Console.WriteLine("Comenzar a tostar pan...");
      await Task.Delay(3000);
      Console.WriteLine("Terminar de tostar pan");

      return new Toast();
    }

    private static async Task<Bacon> FryBaconAsync(int slices)
    {
      Console.WriteLine($"Colocar {slices} laminas de tocino en el sarten");
      Console.WriteLine("Cocinar tocino por arriba...");
      await Task.Delay(3000);
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("Dar vuelta el tocino");
      }
      Console.WriteLine("Cocinar el segundo lado de tocino...");
      await Task.Delay(3000);
      Console.WriteLine("Colocar tocino en el plato");

      return new Bacon();
    }

    private static async Task<Egg> FryEggsAsync(int howMany)
    {
      Console.WriteLine("Quebrar huevos en el sarten...");
      await Task.Delay(3000);
      Console.WriteLine($"Cocinar {howMany} huevos");
      await Task.Delay(3000);
      Console.WriteLine("Colocar huevos en el plato");

      return new Egg();
    }

    private static Coffee PourCoffee()
    {
      Console.WriteLine("Servir cafe");
      return new Coffee();
    }
  }

  internal class Coffee
  {
  }

  internal class Bacon
  {
  }

  internal class Juice
  {
  }

  internal class Toast
  {
  }

  internal class Egg
  {
  }

}

