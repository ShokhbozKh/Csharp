using System;
using System.Linq;

namespace Exercise_15
{
    class StringTokenizer
    {
        private string[] _stringInput;
        private int _indexCounter;

        // Check if there is string left
        public bool HasMoreTokens 
        {
            get => _indexCounter < _stringInput?.Length;
        }

        public StringTokenizer(string stringInput)
        {
            _stringInput = stringInput.Split(' ');
            _indexCounter = 0; 
        }

        // In case if the first input string was null, use the second
        public StringTokenizer(string stringInput, string stringInput1)
        {
            if (String.IsNullOrEmpty(stringInput))
                _stringInput = stringInput1?.Split(' ');
            else
                _stringInput = stringInput.Split(' ');

        }

        // Get the number of words in string
        public int? GetWords(string stringInput) => stringInput?.Split(' ').Count();

        // Get the next token and increment index
        public string NextToken()
        {
            if(_indexCounter < _stringInput.Length)
                return _stringInput[_indexCounter++];

            return "";
        }

        // Set the current source to the new one
        public void NewSource(string newInput)
        {
            _stringInput = newInput?.Split(' ');
            _indexCounter = 0;
        }
    }
}
