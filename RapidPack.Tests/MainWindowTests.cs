using Avalonia.Headless.XUnit;
using Xunit;
using System;
using Xunit.Abstractions;

namespace RapidPack.Tests
{
   public class ParcelCalculatorTests
   {
      private readonly ParcelCalculator calculator = new ParcelCalculator();

      [Fact]
      public void WeightAbove30_ShouldShowError()
      {
         (string, double) result = calculator.CalculatePrice(1, 1, 1, 67, false, "Standardowa");

         Assert.Equal("Waga przesyłki nie może przekraczać 30 kg!", result.Item1);
      }

      [Fact]
      public void PackageOver150cm_ShouldAdd50Percent()
      {
         // Paczka o sumie wymiarów >150 cm = +50%
         (string, double) result = calculator.CalculatePrice(57, 50, 63, 10, false, "Standardowa");
         
         // 10 + 102 = 30 | 30 + 50% = 45
         Assert.Equal(45, result.Item2);
      }

      [Fact]
      public void PaletaShouldAlwaysCost100()
      {
         // Paleta cena = zawsze 100 zł
         (string, double) result = calculator.CalculatePrice(64, 223, 156, 25, false, "Paleta");

         Assert.Equal(100, result.Item2);
      }

      [Fact] public void ExpressAndFragile_ShouldAddExtraFees()
      {
         // Paczka Ostroznie + Express = + 10 + 15 do ceny = +25
         (string, double) result = calculator.CalculatePrice(13, 6, 21, 5, true, "Ostrożnie");

         // 10 + 52 = 20 | 20 +10 (Ostrożnie) +15 (Express) = 45
         
         Assert.Equal(45, result.Item2);
      }

      [Fact] public void Standard_ShouldStayTheSame()
      {
         // Paczka Standard = +0 do ceny
         (string, double) result = calculator.CalculatePrice(13, 7, 21, 5, false, "Standardowa");

         // 10 + 5*2 = 20 | 20 + 0 = 20
         Assert.Equal(20, result.Item2);
      }
   }
}
