namespace OOP_lab_5_7_2
{
    class Doctor
    {
        private string _surename;
        private string _profession;

        public string Surename
        {
            get => _surename;
            set => _surename = value;
        }

        public string Profession
        {
            get => _profession;
            set => _profession = value;
        }

        public virtual string UkrainianI(string str) 
        {
            char[] ch = str.ToCharArray();

            for (int i = 0; i < ch.Length; ++i)
            {
                if (ch[i] == '?')
                {
                    ch[i] = 'i';
                }
            }

            return new string(ch);
        }

        public Doctor()
        {
            _surename = "Не вказано.";
            _profession = "Не вказано.";
        }

        public Doctor(string surename, string profession)
        {
            Surename = UkrainianI(surename);
            Profession = UkrainianI(profession);
        }
    }
}
