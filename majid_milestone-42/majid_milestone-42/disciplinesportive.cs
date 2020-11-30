using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace majid_milestone_42
{
    class disciplinesportive
    {
        private string _nomeD;

        public string nomeD
        {
            get
            {
                return _nomeD;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio!");

                _nomeD = value;
            }
        }

        private int _livelloDil;
        public int livelloDil
        {
            get
            {
                return _livelloDil;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Inserire un valore valido");

                if (value > this._livelloJun || value > this._livelloSen)
                    throw new Exception("Valore sbagliato per il livello dilettanti");

                _livelloDil = value;
            }
        }

        private int _livelloJun;
        public int livelloJun
        {
            get
            {
                return _livelloJun;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Inserire un valore valido");

                if (value < this._livelloDil || value > this._livelloSen)
                    throw new Exception("Valore sbagliato per il livello junior");

                _livelloJun = value;
            }
        }

        private int _livelloSen;
        public int livelloSen
        {
            get
            {
                return _livelloSen;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Inserire un valore valido");

                if (value < this._livelloJun || value < this._livelloDil)
                    throw new Exception("Valore sbagliato per il livello senior");

                _livelloSen = value;
            }
        }

        public disciplinesportive(string nome, int lvlD, int lvlJ, int lvlS)
        {
            if (lvlD > lvlJ || lvlD > lvlS)
                throw new Exception("Valore sbagliato per il livello dilettanti");

            if (lvlJ < lvlD || lvlJ > lvlS)
                throw new Exception("Valore sbagliato per il livello junior");

            if (lvlS < lvlJ || lvlS <lvlD)
                throw new Exception("Valore sbagliato per il livello senior");

            this.nomeD = nome;
            this._livelloDil = lvlD;
            this._livelloJun = lvlJ;
            this._livelloSen = lvlS;
        }

    }
}
