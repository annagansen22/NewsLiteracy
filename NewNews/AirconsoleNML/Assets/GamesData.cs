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
    public List<MatchingData> matchingData;

    private void Start()
    {
        realFakeData = getHardcodedRealFakeData();
        sourceGameData = getHardcodedSourceGameData();
        headlineData = getHardcodedHeadlineData();
        reflectionData = getHardcodedReflectionData();
        informationData = getHardcodedInformationData();
        matchingData = getHardcodedMatchingData();
    }

    public List<MatchingData> getMatchingData()
    {
        return matchingData;
    }

    public void setMatchingData(List<MatchingData> data)
    {
        matchingData = data;
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
            "Komt er nu al een einde aan Shownieuws-avontuur Olcay Gulsen?\n\nBron: Veronica SuperGuide\nDatum: 25-3-2020 \nAuteur: Judith Regeling", true),
            new RealFakeData("showbusiness",
            "Laatste twee afleveringen van serie Empire worden wellicht nooit gemaakt\n\nBron: nu.nl\nDatum: 15-4-2020\nAuteur: onbekend", true),
            new RealFakeData("showbusiness",
            "SBS past Lachen om Home Video’s aan naar Kijken naar Home Video’s\n\nBron: speld.nl\nDatum: 10-3-2020\nAuteur: Tom Baalbergen en Simoon Hermus ", false),
            new RealFakeData("showbusiness",
            "Morgen DWDD zonder studio, presentator, camera\nBron: speld.nl\n\nDatum: 27-3-2020\nAuteur: Matthijs van Rumpt en Tom Baalbergen ", false),
            new RealFakeData("showbusiness",
            "Amy Schumer komt terug op babynaam die klinkt als ‘genital’\n\nBron: AD\nDatum: 15-04-2020\nAuteur: Showredactie  ", true),
            new RealFakeData("showbusiness",
            "Jelte blikt terug op bewogen logeerpartij bij boerin Annemiek: ‘Ze stak anders in elkaar’\n\nBron: AD\nDatum:14-4-2020\nAuteur:Suzanne Borgdorff ", true),
            new RealFakeData("showbusiness",
            "Demi Lovato en Selena Gomez niet langer vriendinnen\nBron: rtl boulevard\n\nDatum: 15-4-2020\nAuteur: Donald Duck  ", false),
            new RealFakeData("showbusiness",
            "Faillissement op de loer voor familie Meiland\nBron: RTL Boulevard\n\nDatum: 15-04-2020\nAuteur: Barack Obama ", false),
            new RealFakeData("showbusiness",
            "Gewoon Opnieuw' door Alex Klaasen wint Annie M.G. Schmidtprijs\n\nBron: NOS\nDatum: 10-04-2020\nAuteur: Onbekend ", true),
            new RealFakeData("showbusiness",
            "Bibi Breijman openhartig over burn-out, haar relatie met Waylon en ruzie met Monica Geuze\n\nBron: gids.tv\nDatum: 28-03-2020\nAuteur: Nicole Aalbers", true),
            new RealFakeData("showbusiness",
            "Valsspelers, gevaarlijke spelletjes en een nieuw koppel doet z’n intrede: dit was aflevering acht van ‘Temptation Island’\n\nBron: hetlaatstenieuws.be\nDatum: 25-11-2033 ", false),
            new RealFakeData("showbusiness",
            "Bobbi Eden durft de deur niet meer uit\nBron: zalando.nl\n\nDatum: 15-04-2020 \nAuteur: Showredactie ", false),
            new RealFakeData("showbusiness",
            "Marco Borsato eist excuses Henny Huisman\nBron:panorama.nl\n\nDatum: 09-04-2020\nAuteur: Redactie Panorama ", true),

            new RealFakeData("politics",
            "Kuzu (DENK) beschuldigt 'strijdmakker' Özturk van 'politieke broedermoord' \n\nBron:nu.nl \nDatum: 06-04-2020\nAuteur: Onbekend", true),
            new RealFakeData("politics",
            "Kabinet schroeft productie kolencentrales terug voor klimaatdoel Urgenda\n\nBron:nu.nl \nDatum: 26-15-2020\nAuteur: Edo van der Goot", true),
            new RealFakeData("politics",
            "Docenten nemen telefoons ministers in en geven ze pas weer terug na oplossing \n\nBron: speld.nl  \nDatum: 07-11-2019  \nAuteur: Elisabeth Koolen", false),
            new RealFakeData("politics",
            "Woedende RIVM stort bak vol cijfers uit over Malieveld \n\nBron:speld.nl \nDatum: 31-09-2019 \nAuteur: Jos Maaldrink", false),
            new RealFakeData("politics",
            "Als je haar maar goed zit – maar hoe krijgt premier Rutte dat voor elkaar?\n\nBron: rtlnieuws.nl \nDatum: 03-04-2020\nAuteur: Koning Willem Alexander", false),
            new RealFakeData("politics",
            "Ruim 5000 leerlingen 'kwijt', minister Slob roept op om te blijven zoeken\n\nBron:rtlnieuws.nl \nDatum:09-04-2020 \nAuteur: Redactie rtlnieuws.nl", true),
            new RealFakeData("politics",
            "Slob: we moeten het woord 'coronadiploma' niet meer gebruiken\n\nBron: nos.nl \nDatum:10-04-210 \nAuteur: Juf Ank", false),
            new RealFakeData("politics",
            "Coronavirus maakt nieuwe bn'ers\n\nBron: telegraaf.nl \nDatum:28-03-1945 \nAuteur: Daniel van Damen", false),
            new RealFakeData("politics",
            "Testament opstellen moet nu ook via Skype kunnen\n\nBron: telegraaf.nl\nDatum: 21-04-2020 \nAuteur: Maria van Loosdrecht", true),
            new RealFakeData("politics",
            "Karaktermoord op Thierry Baudet\n\nBron: telegraaf.nl \nDatum: 11-04-2020 \nAuteur: Saskia Belleman", true),
            new RealFakeData("politics",
            "Kamerlid: 'Hufterigheid komt tot ontploffing in oudjaarsnacht' \n\nBron:telegraaf.nl \nDatum:01-01-2020 \nAuteur: Redactie telegraaf", true),
            new RealFakeData("politics",
            "Playboy-affaire VVD’ers duikt op in archief: ‘Vunzig. Verwaand. Dom’\n\nBron: sportnieuws.nl \nDatum: 02-01-2020 \nAuteur: Hanneke Keultjes", false),
            new RealFakeData("politics",
            "Turkse asielzoeker moet vanaf 1 mei verplicht inburgeren\n\nBron: AD.nl \nDatum: 10-04-2020 \nAuteur: Laurens Kok", true),
            new RealFakeData("politics",
            "Rutte: Let op, er wordt dit weekend bekeurd\n\nBron: AD.nl \nDatum: 09-04-2020 \nAuteur: Tobias den Hartog", true),

            new RealFakeData("actueel_nieuws",
            "Trumps naam komt op 'coronacheques' die Amerikanen ontvangen\n\nBron: nu.nl \nDatum: 26-05-2020 \nAuteur: Redactie nu.nl", true),
            new RealFakeData("actueel_nieuws",
            "Veel meer twintigers en dertigers omgekomen bij verkeersongelukken\n\nBron: nos.nl \nDatum: 15-04-2020 \nAuteur: redactie nos.nl", true),
            new RealFakeData("actueel_nieuws",
            "Neef met slechte internetverbinding door familie verstoten\n\nBron: speld.nl \nDatum: 13-04-2020 \nAuteur: Spanjaarden", false),
            new RealFakeData("actueel_nieuws",
            "Zo krijg je superveel matches in de nieuwe corona-app\n\nBron: speld.nl \nDatum: 12-04-2020 \nAuteur: Rudolf Julius", false),
            new RealFakeData("actueel_nieuws",
            "Start Tour de France verschoven naar 29 augustus\n\nBron: nos.nl \nDatum: 15-04-2020 \nAuteur: Jos Helden", true),
            new RealFakeData("actueel_nieuws",
            "Op deze school in Brabant wordt alweer les gegeven\n\nBron: ad.nl \nDatum: 26-05-2020 \nAuteur: Trump", false),
            new RealFakeData("actueel_nieuws",
            "‘Rouwband’ om eik als wapen tegen processierups: hier willen ze de jeuk voor zijn\n\nBron: ad.nl \nDatum: 14-04-2020 \nAuteur: Tom Tacken", true),
            new RealFakeData("actueel_nieuws",
            "Aardbeving tijdens quarantaine: ‘Je denkt dat je doodgaat’ \n\nBron:grappigefeitjes.com \nDatum:20-04-2007 \nAuteur: Jan Hallen", false),
            new RealFakeData("actueel_nieuws",
            "’Vermoorde man Haarlem is Arubaan’\n\nBron:telegraaf.nl \nDatum:15-04-2020 \nAuteur: Mick van Welly", true),
            new RealFakeData("actueel_nieuws",
            "Amsterdam wint strijd tegen meer toeristenwinkels \n\nBron: telegraaf.nl \nDatum: 15-04-2020 \n Auteur: Mascha de Jong", true),
            new RealFakeData("actueel_nieuws",
            "VS stopt financiering gezondheidsorganisatie WHO om 'desinformatie' \n\nBron: nu.nl \nDatum: 15-04-2020 \nAuteur: Redactie nu.nl", true),
            new RealFakeData("actueel_nieuws",
            "Jezus blijft in grot: 'onverantwoord om nu uit de dood op te staan' \n\nBron: Speld.nl \nDatum: 12-04-2020 \nAuteur: Rudolf Julius", false),
            new RealFakeData("actueel_nieuws",
            "Kernenergie kan helpen bij aanpak klimaat, maar dat gaat wel wat kosten \n\nBron:nos.nl \nDatum: 15-04-2020 \nAuteur: Heleen Ekker", true),

            new RealFakeData("misdaad",
            "530 xtc-pillen tussen de puzzelstukjes\n\nBron: nos.nl \nDatum:14-04-2020 \nAuteur: Redactie nos.nl ", true),
            new RealFakeData("misdaad",
            "Klik hier voor een EXCLUSIEVE gratis masterclass ‘mensen online oplichten’\n\nBron: despeld.nl \nDatum: 03-04-2020 \nAuteur: Jan van Tiemen", false),
            new RealFakeData("misdaad",
            "Alweer kind (2) met wapen opgepakt \n\nBron: despeld.nl \nDatum:14-02-2020 \nAuteur: Tom Baalbergen", false),
            new RealFakeData("misdaad",
            "Agenten schieten man in been na melding huiselijk geweld \n\nBron: nos.nl \nDatum: 12-04-20 \nAuteur: Bloemist Arnhem", false),
            new RealFakeData("misdaad",
            "Steekpartij bij Penitentiaire Inrichting Alphen aan den Rijn \n\nBron: nu.nl \nDatum: 28-13-2020 \nAuteur: Redactie nu.nl", true),
            new RealFakeData("misdaad",
            "Jongen (15) meldt zich bij politie na pesten homostel \n\nBron: nosstories \nDatum: 09-05-2020 \nAuteur: Redactie NOS", true),
            new RealFakeData("misdaad",
            "Vrouw trouwt met man die haar redde tijdens schietpartij in Las Vegas \n\nBron: Linda.nl \nDatum: 15-04-2020 \nAuteur: Sophie Jansen", true),
            new RealFakeData("misdaad",
            "Jeugdzorg en Kinderbescherming zien geen toename in meldingen kindermishandeling \n\nBron: Linda.nl \nDatum: 15-04-2020 \nAuteur: Eline Lamper", true),
            new RealFakeData("misdaad",
            "Wijkagent ruikt tijdens gesprek wietgeur en ontdekt hennepkwekerij \n\nBron: AD.nl \nDatum: 20-04-2020 \nAuteur: Reinier Vermeer", true),
            new RealFakeData("misdaad",
            "Verdachte van gewelddadige dood fotomodel Carolien (39) blijft vastzitten \n\nBron: De Gelderlander \nDatum: 16-04-2020 \nAuteur: Henk van Gelder", true),
            new RealFakeData("misdaad",
            "Valse bekentenis in zaak - Arnhemse villamoord \n\nBron:kro-nrcv.nl \nBron: kro-nrcv.nl \nDatum: 09-01-2020 \nAuteur: Redactie NPO", true),
            new RealFakeData("misdaad",
            "Vrouw beroofd bij geldautomaat, politie zoekt getuigen \n\nBron: fok.nl \nDatum: 20-04-2020 \nAuteur: Beroofde bank ", true),
            new RealFakeData("misdaad",
            "Last Night in Belgium... Rellende '''jongeren''' \n\nBron: geenstijl.nl \nDatum: 20-01-2020 \nAuteur: Onbekend", false),

            new RealFakeData("sport",
            "Lokomotiv Moskou-speler Samochvalov (22) overleden tijdens training \n\nBron: nu.nl \nDatum: 20-04-2020 \nAuteur: Redactie nu.nl", true),
            new RealFakeData("sport",
            "Japanse professor virologie pessimistisch over doorgaan Spelen in 2021 \n\nBron: nos.nl \nDatum: 20-04-2020 \nAuteur: Redactie NOS", true),
            new RealFakeData("sport",
            "Nederlanders verliezen massaal interesse in darts na aftocht Barney \n\nBron: despeld.nl \nDatum: 13-03-2020 \nAuteur: Tom Baalbergen", false),
            new RealFakeData("sport",
            "GÉÉN VOETBAL & FESTIVALS TOT EINDE 2021' \n\nBron: Geenstijl.nl \nDatum: 14-04-2020 \n Auteur: @mosterd", false),
            new RealFakeData("sport",
            "Oud-Formule 1-coureur Stirling Moss op negentigjarige leeftijd overleden. \n\nBron: nu.nl \nDatum: 12-04-2020 \nAuteur: Redactie nu.nl", true),
            new RealFakeData("sport",
            "Stirling Moss (90) gestopt met racen \n\nBron: geenstijl.nl  \nDatum: 12-04-2020  \nAuteur: @van Rossum ", true),

            new RealFakeData("klimaat",
            "Toppen Himalaya door lockdown voor eerst in decennia weer te zien\n\nBron: nu.nl\nDatum: 10-04-2020\nAuteur: Redactie nu.nl", true),
            new RealFakeData("klimaat",
            "Klimaatopwarming: winter in Game of Thrones zal maar twee afleveringen duren\n\nBron: AD\nDatum: 15-04-2019\nAuteur: Italianen ", false),
            new RealFakeData("klimaat",
            "Alle landen hebben economisch voordeel van aanscherpen klimaatbeleid'\n\nBron: nu.nl\nDatum: 20-04-2020\nAuteur: Redactie nu.nl", true),
            new RealFakeData("klimaat",
            "Komt door klimaatverandering het tussenjaar in gevaar?\n\nBron: speld.nl\n Datum: 07-01-2020\nAuteur: Redactie de Speld in samenwerking met Greenpeace ", false),
            new RealFakeData("klimaat",
            "Klimaatwetenschappers: ‘Niets doen is een uitstekende optie’\n\n Bron: de Gelderlander\nDatum: 03-12-2020\nAuteur: Suske en Wiske ", false),
            new RealFakeData("klimaat",
            "Mannelijke wetenschappers: vrouwen voor 80% verantwoordelijk voor klimaatverandering\n\n Bron: RTL Nieuws\nDatum: 14-01-2020\nAuteur: Donald Trump", false),
            new RealFakeData("klimaat",
            "Kabinet laat klimaatdoelen 2030 varen: ‘We gaan wel voor de herkansing’\n\nBron: speld.nl\nDatum: 06-03-2019\nAuteur: Jop Eikelboom en Matthijs van Rumpt", false),
            new RealFakeData("klimaat",
            "Gezondheid kinderen onder druk door commercie en klimaatverandering'\n\nBron: NOS\nDatum: 19-02-2020\nAuteur: Redactie NOS", true),
            new RealFakeData("klimaat",
            "Klimaatcrisis leidt tot meer geweld tegen vrouwen en meisjes'\n\nBron: nu.nl\nDatum: 12-02-2020\nAuteur: Redactie nu.nl", true),
            new RealFakeData("klimaat",
            "’Klimaatplannen even in de ijskast’\n\nBron: Telegraaf\nDatum: 07-06-1846\nAuteur: Redactie telegraaf ", false),
            new RealFakeData("klimaat",
            "Beter reisklimaat op Antarctica\n\nBron: Telegraaf\nDatum: 20-02-2020\nAuteur: Brent Geenen ", true),
            new RealFakeData("klimaat",
            "Klimaatvraag: Zijn vliegtuigstrepen 'goed' voor het klimaat?\n\n Bron: nu.nl\n Datum: 21-04-2020\nAuteur: Redactie nu.nl", true),
            new RealFakeData("klimaat",
            "Eerste Nederlandse vulkaan ‘komt er’ \n\nBron: speld.nl\nDatum: 16-01-2012\nAuteur: Meike van den Berg en Richard van der Toren ", false),
            new RealFakeData("klimaat",
            "Warmste 31 januari in De Bilt ooit gemeten\n\nBron: Telegraaf\n Datum: 31-01-2020 \n Auteur: Redactie Telegraaf ", true)
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
            new InformationData("RealFakeScene", "Controleer altijd of het artikel recent geschreven is!"),
            new InformationData("RealFakeScene", "Speld.nl is een website waar expres nepnieuws op geplaatst wordt!"),
            //BUFFER DATA:
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),
            new InformationData("RealFakeScene", "Controleer altijd of het artikel recent geschreven is!"),
            new InformationData("RealFakeScene", "Speld.nl is een website waar expres nepnieuws op geplaatst wordt!"),
            new InformationData("RealFakeScene", "Check de bron om erachter te komen of nieuws echt of nep is!"),
            new InformationData("RealFakeScene", "Ga na of de titel geloofwaardig is; zou dit echt gebeurd kunnen zijn?"),
            new InformationData("RealFakeScene", "Controleer altijd of het artikel recent geschreven is!"),
            new InformationData("RealFakeScene", "Speld.nl is een website waar expres nepnieuws op geplaatst wordt!"),

            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)!"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen!"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            new InformationData("HeadlinesScene", "Denk na over het doel van het artikel als je een titel bedenkt!"),
            //BUFFER DATA:
            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)!"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen!"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            new InformationData("HeadlinesScene", "Denk na over het doel van het artikel als je een titel bedenkt!"),
            new InformationData("HeadlinesScene", "Een goede titel is niet te lang (niet meer dan 10 woorden)!"),
            new InformationData("HeadlinesScene", "Een goede titel spreekt aan om het artikel te gaan lezen!"),
            new InformationData("HeadlinesScene", "Als jullie doel is om te informeren, dan geeft een goede titel de belangrijkste informatie uit het artikel weer."),
            new InformationData("HeadlinesScene", "Denk na over het doel van het artikel als je een titel bedenkt!"),

            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "Controleer de auteur en datum als je na wil gaan of een bron betrouwbaar is!"),
            //BUFFER DATA:
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "Controleer de auteur en datum als je na wil gaan of een bron betrouwbaar is!"),
            new InformationData("SourceScene", "https://www.factcheck.nl/ is een website die je kan gebruiken om betrouwbare bronnen te vinden!"),
            new InformationData("SourceScene", "Let op: bekijk meerdere bronnen voordat je een goed antwoord kan formuleren."),
            new InformationData("SourceScene", "Controleer de auteur en datum als je na wil gaan of een bron betrouwbaar is!"),

            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren."),
            new InformationData("MatchingScene", "Als het iemands doel is om te opiniëren wil hij zijn mening geven zonder dat hij anderen ervan probeert te overtuigen dat dat waar is."),
            new InformationData("MatchingScene", "Auteurs van nieuwsartikelen hebben bepaalde vooroordelen waardoor zij informatie in een artikel op een bepaalde manier zullen brengen."),
            new InformationData("MatchingScene", "Sommige nieuwsbronnen hebben een specifieke doelgroep waarop zij hun artikelen en de manier die zijn geschreven zullen aanpassen."),
            //BUFFER DATA:
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren."),
            new InformationData("MatchingScene", "Als het iemands doel is om te opiniëren wil hij zijn mening geven zonder dat hij anderen ervan probeert te overtuigen dat dat waar is."),
            new InformationData("MatchingScene", "Auteurs van nieuwsartikelen hebben bepaalde vooroordelen waardoor zij informatie in een artikel op een bepaalde manier zullen brengen."),
            new InformationData("MatchingScene", "Sommige nieuwsbronnen hebben een specifieke doelgroep waarop zij hun artikelen en de manier die zijn geschreven zullen aanpassen."),
            new InformationData("MatchingScene", "Het belangrijkste doel van een krant is meestal om te informeren."),
            new InformationData("MatchingScene", "Als het iemands doel is om te opiniëren wil hij zijn mening geven zonder dat hij anderen ervan probeert te overtuigen dat dat waar is."),
            new InformationData("MatchingScene", "Auteurs van nieuwsartikelen hebben bepaalde vooroordelen waardoor zij informatie in een artikel op een bepaalde manier zullen brengen."),
            new InformationData("MatchingScene", "Sommige nieuwsbronnen hebben een specifieke doelgroep waarop zij hun artikelen en de manier die zijn geschreven zullen aanpassen."),
            new InformationData("MatchingScene", "Het belangrijkste doel van een opinieblog is meestal om te overtuigen")
        };
        return data;
    }

    private List<RealFakeData> getHardcodedSourceGameData()
    {
        List<RealFakeData> data = new List<RealFakeData>() {
            new RealFakeData("showbusiness",
            "Klopt het dat je na een deelname aan temptation island niet meer mee mag doen aan programma's zoals ex on the beach?", false),
            new RealFakeData("showbusiness",
            "Mag het Eurovisie songfestival komende jaren nog wel in Nederland gehouden worden vanwege het corona virus?", true),

            new RealFakeData("politics",
            "Bestaat de harde kern van de PvdA uit laagopgeleide arbeiders?", false),
            new RealFakeData("politics",
            "Heeft de PVV linkse standpunten gehad in de afgelopen jaren?", true),

            new RealFakeData("actueel_nieuws",
            "Wordt het corona virus in stand gehouden door het nieuwe 5G netwerk?", false),
            new RealFakeData("actueel_nieuws",
            "Zal de eikenprocessierups dit jaar nog meer overlast veroorzaken dan vorig jaar dankzij het heersende corona virus?", true),

            new RealFakeData("misdaad",
            "Kunnen mensen tussen de 16 en 23 jaar zowel als kind als volwassene beoordeeld worden bij een strafrechtelijk proces", true),
            new RealFakeData("misdaad",
            "Gökmen Tanis heeft levenslang gekregen voor het schietincident in een tram in Utrecht. Klopt het dat levenslang in Nederland eigenlijk betekent dat je 20 jaar de gevangenis in moet?", true),

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

    private List<MatchingData> getHardcodedMatchingData()
    {
        List<MatchingData> data = new List<MatchingData>() {
            new MatchingData(new Dictionary<string, string>() {
            {"www.LINDA.nl", "Amuseren"},
            {"www.GeenStijl.nl", "Overtuigen"},
            {"www.degelderlander.nl", "Informeren"},
            {"www.devolkskrant.nl/recensies", "Opiniëren"},
        }, "Bronnen", "Doelen"),
            new MatchingData(new Dictionary<string, string>() {
            {"Voorzitter politieke partij", "Politieke voorkeur"},
            {"Moskee eigenaar", "Religieuze achtergrond"},
            {"Eigenaar van bedrijf", "Verkopen"},
            {"Vlogger", "Zoveel mogelijk kijkers trekken"},
        }, "Auteurs", "Vooroordelen"),
            new MatchingData(new Dictionary<string, string>() {
            {"nosstories", "Jongeren"},
            {"Reformatorisch Dagblad", "Christenen"},
            {"Het Financieele Dagblad", "Ondernemers"},
            {"Het Parool", "Amsterdammers"},
        }, "Bronnen", "Doelgroepen"),
            new MatchingData(new Dictionary<string, string>() {
            {"Netflix lanceert heftige serie over omstreden Jeffrey Epstein", "Vermaken"},
            {"Australië in brand – Klimaatverandering? Onzin.", "Overtuigen"},
            {"Vaker WhatsApp-fraude: 'Je denkt: dit overkomt mij niet'", "Informeren"},
            {"Dit is op dit moment de favoriete jurk van Meghan Markle", "Verkopen"},
        }, "Titels", "Doelen"),
            new MatchingData(new Dictionary<string, string>() {
            {"www.nrc.nl/index/opinie/", "Opiniëren"},
            {"www.story.nl", "Vermaken"},
            {"www.ad.nl", "Informeren"},
            {"www.vvd.nl/nieuws/", "Overtuigen"},
        }, "Bronnen", "Doelen")
        };
        return data;
    }
}