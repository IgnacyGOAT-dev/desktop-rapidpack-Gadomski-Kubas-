using System;

namespace RapidPack;

public class ParcelCalculator
{
    public string CalculatePrice(int parcelHeight, int parcelWidth, int parcelDepth, int parcelWeight, bool express, string deliveryChoice){
    
        if (parcelHeight <= 0)
        {
            return "Wysokość musi być większa od 0!";
        }
        if (parcelWidth <= 0)
        {
            return "Szerokość musi być większa od 0!";
        }
        if (parcelDepth <= 0)
        {
            return "Głębokość musi być większa od 0!";
        }

        if (parcelWeight <= 0)
        {
            return "Waga musi być większa od 0!";
        }

        if (parcelWeight > 30)
        {
            return "Waga przesyłki nie może przekraczać 30 kg!";
        }

        if (deliveryChoice != "Standardowa" && deliveryChoice != "Ostrożnie" && deliveryChoice != "Paleta")
        {
            return "Nieznany typ przesyłki!";
        }
        
    }
}