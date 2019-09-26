using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Data
{
    public class Whereabout
    {
        string ident = null;
        string loc_id = null;
        string scene_id = null;

        public void setIdent(string ident)
        {
            this.ident = ident;
        }

        public void setLocId(string id)
        {
            this.loc_id = id;
        }

        public void setSceneId(string id)
        {
            this.scene_id = id;
        }

        public string getIdent()
        {
            return this.ident;
        }

        public string getLocId()
        {
            return this.loc_id;
        }

        public string getSceneId()
        {
            return this.scene_id;
        }
    }
}
