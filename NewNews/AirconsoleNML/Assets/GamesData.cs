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
            new RealFakeData("showbusiness",
            "Amy Schumer komt terug op babynaam die klinkt als ‘genital’", true),
            new RealFakeData("showbusiness",
            "Jelte blikt terug op bewogen logeerpartij bij boerin Annemiek: ‘Ze stak anders in elkaar’", true),
            new RealFakeData("showbusiness",
            "Demi Lovato en Selena Gomez niet langer vriendinnen", true),
            new RealFakeData("showbusiness",
            "Faillissement op de loer voor familie Meiland", true),
            new RealFakeData("showbusiness",
            "'Gewoon Opnieuw' door Alex Klaasen wint Annie M.G. Schmidtprijs", true),
            new RealFakeData("showbusiness",
            "Bibi Breijman openhartig over burn-out, haar relatie met Waylon en ruzie met Monica Geuze", true),
            new RealFakeData("showbusiness",
            "Valsspelers, gevaarlijke spelletjes en een nieuw koppel doet z’n intrede: dit was aflevering acht van ‘Temptation Island’", true),
            new RealFakeData("showbusiness",
            "Bobbi Eden durft de deur niet meer uit", true),
            new RealFakeData("showbusiness",
            "Marco Borsato eist excuses Henny Huisman", true),

            new RealFakeData("politics",
            "Kuzu (DENK) beschuldigt 'strijdmakker' Özturk van 'politieke broedermoord'", true),
            new RealFakeData("politics",
            "Kabinet schroeft productie kolencentrales terug voor klimaatdoel Urgenda", true),
            new RealFakeData("politics",
            "Docenten nemen telefoons ministers in en geven ze pas weer terug na oplossing", false),
            new RealFakeData("politics",
            "Woedende RIVM stort bak vol cijfers uit over Malieveld", false),
            new RealFakeData("politics",
            "Als je haar maar goed zit – maar hoe krijgt premier Rutte dat voor elkaar?", true),
            new RealFakeData("politics",
            "Ruim 5000 leerlingen 'kwijt', minister Slob roept op om te blijven zoeken", true),
            new RealFakeData("politics",
            "Slob: we moeten het woord 'coronadiploma' niet meer gebruiken", true),
            new RealFakeData("politics",
            "Coronavirus maakt nieuwe bn'ers", true),
            new RealFakeData("politics",
            "Testament opstellen moet nu ook via Skype kunnen", true),
            new RealFakeData("politics",
            "Karaktermoord op Thierry Baudet", true),
            new RealFakeData("politics",
            "Kamerlid: 'Hufterigheid komt tot ontploffing in oudjaarsnacht'", true),
            new RealFakeData("politics",
            "Playboy-affaire VVD’ers duikt op in archief: ‘Vunzig. Verwaand. Dom’", true),
            new RealFakeData("politics",
            "Turkse asielzoeker moet vanaf 1 mei verplicht inburgeren", true),
            new RealFakeData("politics",
            "Rutte: Let op, er wordt dit weekend bekeurd", true),

            new RealFakeData("actueel_nieuws",
            "Trumps naam komt op 'coronacheques' die Amerikanen ontvangen", true),
            new RealFakeData("actueel_nieuws",
            "Veel meer twintigers en dertigers omgekomen bij verkeersongelukken", true),
            new RealFakeData("actueel_nieuws",
            "Neef met slechte internetverbinding door familie verstoten", false),
            new RealFakeData("actueel_nieuws",
            "Zo krijg je superveel matches in de nieuwe corona-app", false),
            new RealFakeData("actueel_nieuws",
            "Start Tour de France verschoven naar 29 augustus", true),
            new RealFakeData("actueel_nieuws",
            "Op deze school in Brabant wordt alweer les gegeven", true),
            new RealFakeData("actueel_nieuws",
            "‘Rouwband’ om eik als wapen tegen processierups: hier willen ze de jeuk voor zijn", true),
            new RealFakeData("actueel_nieuws",
            "Aardbeving tijdens quarantaine: ‘Je denkt dat je doodgaat’", true),
            new RealFakeData("actueel_nieuws",
            "’Vermoorde man Haarlem is Arubaan’", true),
            new RealFakeData("actueel_nieuws",
            "Amsterdam wint strijd tegen meer toeristenwinkels", true),
            new RealFakeData("actueel_nieuws",
            "VS stopt financiering gezondheidsorganisatie WHO om 'desinformatie'", true),
            new RealFakeData("actueel_nieuws",
            "Jezus blijft in grot: 'onverantwoord om nu uit de dood op te staan'", false),
            new RealFakeData("actueel_nieuws",
            "Kernenergie kan helpen bij aanpak klimaat, maar dat gaat wel wat kosten", true),

            new RealFakeData("misdaad",
            "530 xtc-pillen tussen de puzzelstukjes", true),
            new RealFakeData("misdaad",
            "Klik hier voor een EXCLUSIEVE gratis masterclass ‘mensen online oplichten’", false),
            new RealFakeData("misdaad",
            "Alweer kind (2) met wapen opgepakt", false),
            new RealFakeData("misdaad",
            "Agenten schieten man in been na melding huiselijk geweld", true),
            new RealFakeData("misdaad",
            "Steekpartij bij Penitentiaire Inrichting Alphen aan den Rijn", true),
            new RealFakeData("misdaad",
            "Jongen (15) meldt zich bij politie na pesten homostel ", true),
            new RealFakeData("misdaad",
            "Vrouw trouwt met man die haar redde tijdens schietpartij in Las Vegas", true),
            new RealFakeData("misdaad",
            "Jeugdzorg en Kinderbescherming zien geen toename in meldingen kindermishandeling", true),
            new RealFakeData("misdaad",
            "Wijkagent ruikt tijdens gesprek wietgeur en ontdekt hennepkwekerij", true),
            new RealFakeData("misdaad",
            "Verdachte van gewelddadige dood fotomodel Carolien (39) blijft vastzitten", true),
            new RealFakeData("misdaad",
            "Valse bekentenis in zaak - Arnhemse villamoord", true),
            new RealFakeData("misdaad",
            "Vrouw beroofd bij geldautomaat, politie zoekt getuigen", true),

            new RealFakeData("sport",
            "Lokomotiv Moskou-speler Samochvalov (22) overleden tijdens training", true),
            new RealFakeData("sport",
            "Japanse professor virologie pessimistisch over doorgaan Spelen in 2021", true),
            new RealFakeData("sport",
            "Nederlanders verliezen massaal interesse in darts na aftocht Barney", false),
            new RealFakeData("sport",
            "'GÉÉN VOETBAL & FESTIVALS TOT EINDE 2021'", false),
            new RealFakeData("sport",
            "Oud-Formule 1-coureur Stirling Moss op negentigjarige leeftijd overleden", true),

            new RealFakeData("klimaat",
            "Toppen Himalaya door lockdown voor eerst in decennia weer te zien", true),
            new RealFakeData("klimaat",
            "Alle landen hebben economisch voordeel van aanscherpen klimaatbeleid'", true),
            new RealFakeData("klimaat",
            "Komt door klimaatverandering het tussenjaar in gevaar?", false),
            new RealFakeData("klimaat",
            "Klimaatwetenschappers: ‘Niets doen is een uitstekende optie’", false),
            new RealFakeData("klimaat",
            "Mannelijke wetenschappers: vrouwen voor 80% verantwoordelijk voor klimaatverandering", false),
            new RealFakeData("klimaat",
            "Klimaatopwarming: winter in Game of Thrones zal maar twee afleveringen duren", false),
            new RealFakeData("klimaat",
            "Kabinet laat klimaatdoelen 2030 varen: ‘We gaan wel voor de herkansing’", false),
            new RealFakeData("klimaat",
            "'Gezondheid kinderen onder druk door commercie en klimaatverandering'", true),
            new RealFakeData("klimaat",
            "'Klimaatcrisis leidt tot meer geweld tegen vrouwen en meisjes'", true),
            new RealFakeData("klimaat",
            "’Klimaatplannen even in de ijskast’", true),
            new RealFakeData("klimaat",
            "Beter reisklimaat op Antarctica", true),
            new RealFakeData("klimaat",
            "Klimaatvraag: Zijn vliegtuigstrepen 'goed' voor het klimaat?", true),
            new RealFakeData("klimaat",
            "Eerste Nederlandse vulkaan ‘komt er’", false),
            new RealFakeData("klimaat",
            "Warmste 31 januari in De Bilt ooit gemeten", true)
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
            new HeadlineData("showbusiness", "Disney", "Disney stelt première van animatiefilm Soul uit tot 20 november"),
            new HeadlineData("showbusiness", "James Bond", "Collectie James Bond pistolen ter waarde van ruim 100.000 euro gestolen"),

            new HeadlineData("politics", "50Plus", "Er is wéér gedonder bij 50Plus"),
            new HeadlineData("politics", "wapen", "Tieners grijpen steeds vaker naar wapen in Amsterdam"),

            new HeadlineData("actueel_nieuws", "lockdown", "Mag het noorden als eerste uit de lockdown?"),
            new HeadlineData("actueel_nieuws", "complottheorieën", "Hoe complottheorieën over 5G en het coronavirus zich verspreiden"),

            new HeadlineData("misdaad", "moordenaar", "Veroordeelde moordenaar van man in Bredase flat meldt zich bij politie"),
            new HeadlineData("misdaad", "straatroof", "Tieners slaan en schoppen slachtoffer gewelddadige straatroof"),

            new HeadlineData("sport", "Titelverdediger", "Titelverdediger Bernal: ‘Vierenhalve maand om in vorm te komen’"),
            new HeadlineData("sport", "Tyson Fury", "Komt het gevecht van de eeuw er aan? Anthony Joshua daagt Tyson Fury uit"),

            new HeadlineData("klimaat", "klimaat", "Ruime meerderheid van Nederlanders denkt dat het klimaat verandert"),
            new HeadlineData("klimaat", "CO2-uitstoot", "Sterkste afname CO2-uitstoot ooit door corona-pandemie")
        };
        return data;
    }
}