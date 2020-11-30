using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace majid_milestone_42
{
    class gruppisportivi
    {

        public string ragioneS { get; set; }
        public string indirizzoS { get; set; }
        public string nomeP { get; set; }

        private string _telefono;
        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                //if(value.Length != 1)
                //    throw new Exception("Formato numero di telefono non valido");

                _telefono = value;
            }
        }

        private string _mail;
        public string mail
        {
            get
            {
                return _mail;
            }
            set
            {
                if(value.Contains("@") == false)
                    throw new Exception("Formato mail non valido");

                _mail = value;
            }
        }
        
        public gruppisportivi(string ragioneS, string indirizzoS, string nomeP, string telefono, string mail)
        {
            this.ragioneS = ragioneS;
            this.indirizzoS = indirizzoS;
            this.nomeP = nomeP;
            this.telefono = telefono;
            this.mail = mail;

        }
    }
}
