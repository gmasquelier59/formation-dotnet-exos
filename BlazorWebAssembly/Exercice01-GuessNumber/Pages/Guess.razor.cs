namespace Exercice01_GuessNumber.Pages
{
    public partial class Guess
    {
        int _nombreADeviner;
        int _nombreSaisi;
        int _nbEssais = 5;
        bool _nombreTrouve = false;
        string _messageAide = "";

        const int borneMini = 1;
        const int borneMaxi = 20;
        const int nbEssais = 5;


        public Guess()
        {
            Init();
        }

        public void VerifierSaisie()
        {
            if (_nombreSaisi < borneMini || _nombreSaisi > borneMaxi)
            {
                _messageAide = $"Le nombre doit être compris entre {borneMini} et {borneMaxi}";
                return;
            }

            if (_nombreSaisi != _nombreADeviner)
            {
                _messageAide = _nombreSaisi < _nombreADeviner ? "Le nombre est plus grand" : "Le nombre est plus petit";
                _nbEssais--;
            }
            else
                _nombreTrouve = true;
        }

        void Init()
        {
            _nbEssais = nbEssais;
            Random random = new Random();
            _nombreADeviner = random.Next(borneMini, borneMaxi + 1);
            _nombreTrouve = false;
            _messageAide = "";
        }
    }
}
