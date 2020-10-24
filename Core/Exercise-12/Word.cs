using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_12
{
    class Word
    {
        readonly string str;
        Word next;

        public Word(string str) => this.str = str;

        public void SetNextWord(Word word)
        {
            if (next is not null)
                next.SetNextWord(word);
            else
                next = word;
        }

        public void Show()
        {
            Console.Write(str);

            if (next is not null) next.Show();
        }
    }
}
