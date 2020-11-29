using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace majid_milestone_42
{
    class atleta
    {
        private static List<string> _elecod = new List<string>();

        private string _codI;
        public string codI
        {
            get
            {
                return _codI;
            }
        }

        private string _med;

        public string med
        {
            get
            {
                return _med;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _med = value;
            }
        }

        private DateTime _dataS;

        public DateTime dataS
        {
            get
            {
                return _dataS;
            }
            set
            {
                if (value > DateTime.Now.Date)
                    throw new Exception("data non valida");

                _dataS = value;
            }
        }

        private string _nomeA;

        public string nomeA
        {
            get
            {
                return _nomeA;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");

                _nomeA = value;
            }
        }

        private string _cogn;

        public string cogn
        {
            get
            {
                return _cogn;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _cogn = value;
            }
        }

        private DateTime _dataN;

        public DateTime dataN
        {
            get
            {
                return _dataN;
            }
            set
            {
                if (value > DateTime.Now.Date)
                    throw new Exception("data non valida");

                _dataN = value;
            }
        }

        private string _citt;

        public string citt
        {
            get
            {
                return _citt;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _citt = value;
            }
        }

        private string _gruppoS;

        public string gruppoS
        {
            get
            {
                return _gruppoS;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _gruppoS = value;
            }
        }

        private string _disciplina;

        public string disciplina
        {
            get
            {
                return _disciplina;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _disciplina = value;
            }
        }

        private string _lvl;

        public string lvl
        {
            get
            {
                return _lvl;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Campo obbligatorio");
                _lvl = value;
            }
        }

        private int _ido;

        public int ido
        {
            get
            {
                return _ido;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Inserire un valore valido");

                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Campo obbligatorio");
                _ido = value;
            }
        }

        public atleta(string codI, string med, DateTime dataS, string nomeA, string cogn, DateTime dataN, string citt, string gruppoS, string disciplina, string lvl, int ido)
        {
            if (string.IsNullOrEmpty(codI) == true)
            {
                throw new Exception("Inserire un codice è obbligatorio");
            }

            if (_elecod.Contains(codI) == true)
            {
                throw new Exception("Codice fiscale già utilizzato");
            }

            _elecod.Add(codI);

            this._codI = codI;
            this.med = med;
            this.dataS = dataS;
            this.nomeA = nomeA;
            this.cogn = cogn;
            this.dataN = dataN;
            this.citt = citt;
            this.gruppoS = gruppoS;
            this.disciplina = disciplina;
            this.lvl = lvl;
            this.ido = ido;
        }
    }
}