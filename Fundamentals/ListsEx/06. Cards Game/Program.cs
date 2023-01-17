using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static (List<int>, List<int>) CardShuffleWhenHandIsWon(List<int> winningDeck, List<int> losingDeck)
    {
        winningDeck.Add(winningDeck[0]);
        winningDeck.Add(losingDeck[0]);
        winningDeck.RemoveAt(0);
        losingDeck.RemoveAt(0);
        return (winningDeck, losingDeck);
    }

    static void Main()
    {
        List<int> player1Deck = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> player2Deck = Console.ReadLine().Split().Select(int.Parse).ToList();

        while (player1Deck.Count > 0 && player2Deck.Count > 0)
        {
            if (player1Deck[0] > player2Deck[0])
                (player1Deck, player2Deck) = CardShuffleWhenHandIsWon(player1Deck, player2Deck);
            else if (player1Deck[0] < player2Deck[0])
                (player2Deck, player1Deck) = CardShuffleWhenHandIsWon(player2Deck, player1Deck);
            else
            {
                player1Deck.RemoveAt(0);
                player2Deck.RemoveAt(0);
            }
        }

        if (player2Deck.Count == 0) Console.WriteLine($"First player wins! Sum: {player1Deck.Sum()}");
        else Console.WriteLine($"Second player wins! Sum: {player2Deck.Sum()}");
    }
}