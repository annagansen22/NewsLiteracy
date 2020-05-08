using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GamesData : MonoBehaviour
{
    public List<RealFakeData> realFakeData;
    public List<RealFakeData> sourceGameData;

    private void Start()
    {
        realFakeData = getHardcodedRealFakeData();
        sourceGameData = getHardcodedSourceGameData();
    }

    public List<RealFakeData> getRealFakeData()
    {
        return realFakeData;
    }

    public void setRealFakeData(List<RealFakeData> data)
    {
        realFakeData = data;
    }


    public List<RealFakeData> getSourceGameData()
    {
        return sourceGameData;
    }

    public void setSourceGameData(List<RealFakeData> data)
    {
        sourceGameData = data;
    }

    private List<RealFakeData> getHardcodedRealFakeData()
    {
        List<RealFakeData> data = new List<RealFakeData>() {
            new RealFakeData("showbusiness",
            "Komt er nu al een einde aan Shownieuws-avontuur Olcay Gulsen?", true),
            new RealFakeData("showbusiness",
            "Laatste twee afleveringen van serie Empire worden wellicht nooit gemaakt", true),
            new RealFakeData("showbusiness",
            "SBS past Lachen om Home Video’s aan naar Kijken naar Home Video’s", false),
            new RealFakeData("showbusiness",
            "Morgen DWDD zonder studio, presentator, camera", false),

            new RealFakeData("politics",
            "Kuzu (DENK) beschuldigt 'strijdmakker' Özturk van 'politieke broedermoord'", true),
            new RealFakeData("politics",
            "Kabinet schroeft productie kolencentrales terug voor klimaatdoel Urgenda", true),
            new RealFakeData("politics",
            "Docenten nemen telefoons ministers in en geven ze pas weer terug na oplossing", false),
            new RealFakeData("politics",
            "Woedende RIVM stort bak vol cijfers uit over Malieveld", false),

            new RealFakeData("actueel_nieuws",
            "Trumps naam komt op 'coronacheques' die Amerikanen ontvangen", true),
            new RealFakeData("actueel_nieuws",
            "Veel meer twintigers en dertigers omgekomen bij verkeersongelukken", true),
            new RealFakeData("actueel_nieuws",
            "Neef met slechte internetverbinding door familie verstoten", false),
            new RealFakeData("actueel_nieuws",
            "Zo krijg je superveel matches in de nieuwe corona-app", false),

            new RealFakeData("misdaad",
            "530 xtc-pillen tussen de puzzelstukjes", true),
            new RealFakeData("misdaad",
            "Veroordeelde moordenaar van man in Bredase flat meldt zich bij politie", true),
            new RealFakeData("misdaad",
            "Klik hier voor een EXCLUSIEVE gratis masterclass ‘mensen online oplichten’", false),
            new RealFakeData("misdaad",
            "Alweer kind (2) met wapen opgepakt", false),


            new RealFakeData("sport",
            "Lokomotiv Moskou-speler Samochvalov (22) overleden tijdens training", true),
            new RealFakeData("sport",
            "Japanse professor virologie pessimistisch over doorgaan Spelen in 2021", true),
            new RealFakeData("sport",
            "Nederlanders verliezen massaal interesse in darts na aftocht Barney", false),
            new RealFakeData("sport",
            "Gezondheidsvoordelen van hardlopen blijkt een hoax", false),

            new RealFakeData("klimaat",
            "Toppen Himalaya door lockdown voor eerst in decennia weer te zien", true),
            new RealFakeData("klimaat",
            "Alle landen hebben economisch voordeel van aanscherpen klimaatbeleid'", true),
            new RealFakeData("klimaat",
            "Komt door klimaatverandering het tussenjaar in gevaar?", false),
            new RealFakeData("klimaat",
            "Mannelijke wetenschappers: vrouwen voor 80% verantwoordelijk voor klimaatverandering", false)
        };
        return data;
    }

    private List<RealFakeData> getHardcodedSourceGameData()
    {
        List<RealFakeData> data = new List<RealFakeData>() {
            new RealFakeData("showbusiness",
            "Klopt het dat je na een deelname aan temptation island niet meer mee mag doen aan programma's zoals ex on the beach? ", false),
            new RealFakeData("showbusiness",
            "Mag het Eurovisie songfestival komende jaren nog wel in Nederland gehouden worden vanwege het corona virus?", true),

            new RealFakeData("politics",
            "Bestaat de harde kern van de PvdA uit laagopgeleide arbeiders?", false),
            new RealFakeData("politics",
            "Heeft de PVV linkse standpunten gehad in de afgelopen jaren?", true),

            new RealFakeData("actueel_nieuws",
            "Wordt het corona virus in stand gehouden door het nieuwe 5G netwerk?", false),
            new RealFakeData("actueel_nieuws",
            "Zal de eikenprocessierups dit jaar nog meer overlast veroorzaken dan vorig jaar dankzij het heersende corona virus? ", true),

            new RealFakeData("misdaad",
            "Misdaad Placeholder", true),
            new RealFakeData("misdaad",
            "Misdaad Placeholder", true),

            new RealFakeData("sport",
            "Sport Placeholder", true),
            new RealFakeData("sport",
            "Sport Placeholder", true),

            new RealFakeData("klimaat",
            "Toppen Himalaya door lockdown voor eerst in decennia weer te zien", true),
            new RealFakeData("klimaat",
            "Klimaat Placeholder", true),
        };
        return data;
    }
}
