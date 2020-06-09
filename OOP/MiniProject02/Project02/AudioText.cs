namespace MiniProject01
{
    public class AudioText : ObjectPlus
    {
        public int Second { get; set; }
        public string Text { get; set; }
        public string Explaination { get; set; }

        private Audio _audio;

        public Audio Audio
        {
            get => _audio;
            set
            {
                if (_audio == null && value != null)
                {
                    _audio = value;
                    _audio.AddText(this);
                }
                else if (_audio != null && value == null)
                {
                    _audio.RemoveText(this);
                    _audio = null;
                }
                else if (_audio != null && value != null)
                {
                    _audio.RemoveText(this);
                    _audio = value;
                    _audio.AddText(this);
                }
            }
        }
    }
}