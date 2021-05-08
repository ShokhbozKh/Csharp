using System;

namespace Assignment_03.Multi_Inheritance
{
    class IPhone : Computer, IMobile
    {
        public string Simcard { get; set; }

        public IPhone(int ram, double processor, string simcard)
            : base(ram, processor)
        {
            Simcard = simcard;
        }

        public override double CalculateSpeed() => RAM * 5.2 + Processor;

        public override void ConnectToInternet()
        {
            try
            {
                Console.WriteLine("Connecting...");
            }
            finally
            {
                Console.WriteLine("result");
            }
        }

        public string GetSimcardNumber()
        {
            if (!string.IsNullOrEmpty(Simcard))
            {
                return Simcard;
            }

            throw new Exception("This IPhone does not have simcard");
        }

        public void MakeCall(string phoneNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    Dial(phoneNumber);
                }
            }
            finally
            {
            }
        }

        private void Dial(string number)
        {
            // Make call
        }
    }
}
