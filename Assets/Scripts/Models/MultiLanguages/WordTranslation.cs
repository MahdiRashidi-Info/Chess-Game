using System;
using System.Collections.Generic;

namespace ChessGame.Models.MultiLanguages
{
    public class WordTranslation
    {
        public string word_key;
        public List<Value> values;
    }

    public class Value
    {
        public string lang_key;
        public string lang_value;
    }
}