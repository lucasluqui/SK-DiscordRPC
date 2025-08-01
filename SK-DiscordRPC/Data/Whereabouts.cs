using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Data
{
    public class Whereabouts
    {
        string ident = null;
        string locDetail = null;
        string locLargeImageKey = null;
        string locLargeImageDesc = null;

        public void setIdent (string ident)
        {
            this.ident = ident;
        }

        public void setLocDetail (string locDetail)
        {
            this.locDetail = locDetail;
        }

        public void setLargeImageKey (string key)
        {
            this.locLargeImageKey = key;
        }

        public void setLargeImageDesc (string desc)
        {
            this.locLargeImageDesc = desc;
        }

        public string getIdent ()
        {
            return this.ident;
        }

        public string getLocDetail ()
        {
            return this.locDetail;
        }

        public string getLargeImageKey ()
        {
            return this.locLargeImageKey;
        }

        public string getLargeImageDesc ()
        {
            return this.locLargeImageDesc;
        }
    }
}
