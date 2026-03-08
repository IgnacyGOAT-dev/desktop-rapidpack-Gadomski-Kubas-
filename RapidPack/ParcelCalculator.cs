using System;

namespace RapidPack;

public class ParcelCalculator
{
    public string CalculatePrice(int parcelHeight, int parcelWidth, int parcelDepth, int parcelWeight, bool express, string deliveryChoice){
    
        if (parcelHeight <= 0) { return "Wysokość musi być większa od 0!"; }
        if (parcelWidth <= 0) { return "Szerokość musi być większa od 0!"; }
        if (parcelDepth <= 0) { return "Głębokość musi być większa od 0!"; }
        if (parcelWeight <= 0) { return "Waga musi być większa od 0!"; }
        if (parcelWeight > 30) { return "Waga przesyłki nie może przekraczać 30 kg!"; }
        if (deliveryChoice != "Standardowa" && deliveryChoice != "Ostrożnie" && deliveryChoice != "Paleta")
        {
            return "Nieznany typ przesyłki!";
        }
        double price;
        int dimensionsSum = parcelHeight + parcelWidth + parcelDepth;

        if (deliveryChoice == "Paleta") {
            price = 100;
        }
        else {
            price = 10 + (parcelWeight * 2); 

            if (deliveryChoice == "Ostrożnie")
            {
                price += 10;
            }

            if (dimensionsSum > 150)
            {
                price *= 1.5;
            }
        }

        if (express) {
            price += 15;
        }
        return "Podsumowanie wyceny:\n"
               + $"Wymiary: {parcelHeight} x {parcelWidth} x {parcelDepth} cm\n"
               + $"Waga: {parcelWeight} kg\n"
               + $"Typ przesyłki: {deliveryChoice}\n"
               + $"Ekspres: {(express ? "Tak" : "Nie")}\n"
               + $"Cena końcowa: {price:F2} zł";
    }
}