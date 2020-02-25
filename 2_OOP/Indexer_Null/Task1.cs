using System;


namespace Indexer_Null
{
    // Задание 1:
    
    // Определите класс футболиста, который содержит имя футболиста и его номер на поле.
    // И определите класс футбольной команды, который хранит 11 футболистов в виде массива и обеспечивает
    // доступ к этим футболистам через индексатор.

    class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Player(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    class Team
    {
        Player[] players;

        public Team()
        {
            players = new Player[11];
        }

        public Player this[int index]
        {
            get
            {
                if (index >= 0 && index < players.Length)
                    return players[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < players.Length)
                    players[index] = value;
            }
        }
    }
}
