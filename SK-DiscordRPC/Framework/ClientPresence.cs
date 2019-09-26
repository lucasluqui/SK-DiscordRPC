using DiscordRPC;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Framework
{
    public static class ClientPresence
    {

        private static void set(string detail, string state, string largeImageKey, string largeImageDesc)
        {
            AppWindow.client.SetPresence(new RichPresence()
            {
                Details = detail,
                State = state,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageDesc
                }
            });
        }

        public static void update()
        {
            string detail = null;
            string state = null;
            string largeImageKey = null;
            string largeImageDesc = null;
            Whereabout where = Parser.parseWhereabout();
            if(where.getIdent() != AppWindow.curWhere.getIdent())
            {
                AppWindow.curWhere = where;
                switch (where.getIdent())
                {
                    case IdentCodes.IDENT_READY_ROOM:
                        detail = "In Ready Room";
                        largeImageKey = ImageCodes.IMAGE_READY_ROOM;
                        largeImageDesc = "Ready Room";
                        break;
                    case IdentCodes.IDENT_TOWN_SQUARE:
                    case IdentCodes.IDENT_TOWN_SQUARE_EX:
                        detail = "In Town Square";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Town Square";
                        break;
                    case IdentCodes.IDENT_BAZAAR:
                        detail = "In Bazaar";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Bazaar";
                        break;
                    case IdentCodes.IDENT_ARCADE:
                        detail = "In Arcade";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Arcade";
                        break;
                    case IdentCodes.IDENT_GARRISON:
                        detail = "In Garrison";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Garrison";
                        break;
                    case IdentCodes.IDENT_MISSION_LOBBY:
                        detail = "In a Mission";
                        largeImageKey = ImageCodes.IMAGE_MISSION;
                        largeImageDesc = "Mission";
                        break;
                    case IdentCodes.IDENT_DANGER_MISSION_LOBBY:
                        detail = "In a Danger Mission";
                        largeImageKey = ImageCodes.IMAGE_MISSION;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS:
                        detail = "In GWW";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS;
                        largeImageDesc = "Gloaming Wildwoods";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE:
                        detail = "In RJP";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE;
                        largeImageDesc = "Royal Jelly Palace";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY:
                        detail = "In IMF";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY;
                        largeImageDesc = "Iron Munitions Factory";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL:
                        detail = "In FSC";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel";
                        break;
                    case IdentCodes.IDENT_OCH:
                        detail = "In OCH";
                        largeImageKey = ImageCodes.IMAGE_OCH;
                        largeImageDesc = "Operation Crimson Hammer";
                        break;
                    case IdentCodes.IDENT_TORTODRONES_LOBBY:
                        detail = "In March of the Tortodrones";
                        largeImageKey = ImageCodes.IMAGE_TORTODRONES;
                        largeImageDesc = "March of the Tortodrones";
                        break;
                    default:
                        break;
                }
                if (!AppContext.HIDE_KNIGHT)
                {
                    state = "Knight: " + Parser.parseKnightName();
                }
                else
                {
                    state = "Knight: [hidden]";
                }
                set(detail, state, largeImageKey, largeImageDesc);
            }
        }

    }
}
