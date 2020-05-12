using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GamesData : MonoBehaviour
{
    public List<RealFakeData> realFakeData;
    public List<RealFakeData> sourceGameData;
    public List<HeadlineData> headlineData;
    public List<string> reflectionData;
    public List<InformationData> informationData;

    private void Start()
    {
        realFakeData = getHardcodedRealFakeData();
        sourceGameData = getHardcodedSourceGameData();
        headlineData = getHardcodedHeadlineData();
        reflectionData = getHardcodedReflectionData();
        informationData = getHardcodedInformationData();
    }

    public List<string> getReflectionData()
    {
        return reflectionData;
    }

    public void setReflectionData(List<string> data)
    {
        reflectionData = data;
    }
    public List<InformationData> getInformationData()
    {
        return informationData;
    }

    public void setInformationData(List<InformationData> data)
    {
        informationData = data;
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

    public List<HeadlineData> getHeadlineData()
    {
        return headlineData;
    }

    public void setHeadlineData(List<HeadlineData> data)
    {
        headlineData = data;
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

    private List<string> getHardcodedReflectionData()
    {
        List<string> data = new List<string>() { 
            "Hoe vonden jullie deze minigame gaan?", 
            "Welke strategie hebben jullie gebruikt bij het beantwoorden van de vragen?",
            "Heeft iedereen meegewerkt in het beantwoorden van de vragen?"};
        return data;
    }

    private List<InformationData> getHardcodedInformationData()
    {
        List<InformationData> data = new List<InformationData>() {
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),
            //BUFFER DATA:
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),

            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            //BUFFER DATA:
            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),

            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            //BUFFER DATA:
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),

            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een tijdschrift is meestal om te vermaken"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen"),
            //BUFFER DATA:
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een tijdschrift is meestal om te vermaken"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een tijdschrift is meestal om te vermaken"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een tijdschrift is meestal om te vermaken"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een tijdschrift is meestal om te vermaken"),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen")
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
            "Kunnen mensen tussen de 16 en 23 jaar zowel als kind als volwassene beoordeeld worden bij een strafrechtelijk proces ", true),
            new RealFakeData("misdaad",
            "Gökmen Tanis heeft levenslang gekregen voor het schietincident in een tram in Utrecht. Klopt het dat levenslang in Nederland eigenlijk betekent dat je 20 jaar de gevangenis in moet? ", true),

            new RealFakeData("sport",
            "Heeft het uitstellen van de olympische spelen in 2020 effect hebben op de olympische spelen in parijs?", false),
            new RealFakeData("sport",
            "Kan je topsport niveau bereiken zonder dat je vlees eet of supplementen gebruikt?", true),

            new RealFakeData("klimaat",
            "Toppen Himalaya door lockdown voor eerst in decennia weer te zien", true),
            new RealFakeData("klimaat",
            "Klimaat Placeholder", true),
        };
        return data;
    }

    private List<HeadlineData> getHardcodedHeadlineData()
    {
        List<HeadlineData> data = new List<HeadlineData>() {
            new HeadlineData("showbusiness", "Olcay Gulsen", "Komt er nu al een einde aan Shownieuws-avontuur Olcay Gulsen?"),

            new HeadlineData("politics", "Kuzu", "Kuzu (DENK) beschuldigt 'strijdmakker' Özturk van 'politieke broedermoord'"),

            new HeadlineData("actueel_nieuws", "Trumps naam", "Trumps naam komt op 'coronacheques' die Amerikanen ontvangen"),

            new HeadlineData("misdaad", "puzzelstukjes", "530 xtc-pillen tussen de puzzelstukjes"),

            new HeadlineData("sport", "Lokomotiv", "Lokomotiv Moskou-speler Samochvalov (22) overleden tijdens training"),

            new HeadlineData("klimaat", "Himalaya", "Toppen Himalaya door lockdown voor eerst in decennia weer te zien")
        };
        return data;
    }
}
