using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Data
{
    public class Whereabout
    {
        string ident = null;
        string loc_detail = null;
        string loc_largeImageKey = null;
        string loc_largeImageDesc = null;

        public void setIdent(string ident)
        {
            this.ident = ident;
        }

        public void setLocDetail(string det)
        {
            this.loc_detail = det;
        }

        public void setLargeImageKey(string key)
        {
            this.loc_largeImageKey = key;
        }

        public void setLargeImageDesc(string desc)
        {
            this.loc_largeImageKey = desc;
        }

        public string getIdent()
        {
            return this.ident;
        }

        public string getLocDetail()
        {
            return this.loc_detail;
        }

        public string getLargeImageKey()
        {
            return this.loc_largeImageKey;
        }

        public string getLargeImageDesc()
        {
            return this.loc_largeImageDesc;
        }
    }
}
