using System.ComponentModel;
using BetTracker.Components;

namespace BetTracker.Services;

public class BetService
{
    public BetService()
    {

    }

    private static BetService? _instance = null;
    public static BetService Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new BetService();
            }

            return _instance;
        }
    }

    public IEnumerable<Bet> GetBetData()
    => new[]
    {
        new Bet(
            date: DateTime.Now,
            betType: BetType.Straight,
            wager: new MoneyAmount{ Dollars = 1.25f, Units = 1f },
            terms: "person to get many goals",
            potential: new MoneyAmount{ Dollars = 1.75f, Units = 1.1f },
            actual: new MoneyAmount{ Dollars = 2.25f, Units = 1.2f }),
        new Bet(
            date: DateTime.Now,
            betType: BetType.Straight,
            wager: new MoneyAmount{ Dollars = 0.65f, Units = .15f },
            terms: "other person to get more goals",
            potential: new MoneyAmount{ Dollars = 3.75f, Units = 1.4f },
            actual: new MoneyAmount{ Dollars = 2.25f, Units = 1.2f }),
        new Bet(
            date: DateTime.Now,
            betType: BetType.RoundRobin,
            wager: new MoneyAmount { Dollars = 0.85f, Units = .11f },
            terms: "third person to get most goals",
            potential: new MoneyAmount { Dollars = 1.25f, Units = 0.33f },
            actual: new MoneyAmount { Dollars = 2.47f, Units = 0.82f })
    };
}

public enum BetType
{
    [Description("Straight Bet")]
    Straight,
    [Description("Parlay Bet")]
    Parlay,
    [Description("Round Robin Bet")]
    RoundRobin
}

public class Bet
{
    public DateTime Date;
    public BetType BetType;
    public string BetTypeString
    {
        get => BetType switch
        {
            BetType.Straight => "Straight Bet",
            BetType.Parlay => "Parlay Bet",
            BetType.RoundRobin => "Round Robin Bet",
            _ => "Unknown bet type"
        };
    }
    public MoneyAmount Wager;
    public string? Terms;
    public MoneyAmount PotentialPayout;
    public MoneyAmount ActualPayout;

    public Bet(
        DateTime date,
        BetType betType,
        MoneyAmount wager,
        string terms,
        MoneyAmount potential,
        MoneyAmount actual)
        {
            Date = date;
            BetType = betType;
            Wager = wager;
            Terms = terms;
            PotentialPayout = potential;
            ActualPayout = actual;
        }
}

public struct MoneyAmount
{
    public float Dollars;
    public float Units;
}